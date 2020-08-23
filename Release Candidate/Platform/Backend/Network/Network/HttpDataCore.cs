using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Timers;
using System.Windows.Forms;
using AeonLabs.Environment;
using Microsoft.VisualBasic.CompilerServices;
using System.Text.Json;
using System.Reflection;
using System.Globalization;
using AeonLabs.Layouts.Dialogs;

namespace AeonLabs.Network
{
    public class HttpDataCore
    {
        public HttpDataCore()
        {
            RestartQueueTimer = new System.Timers.Timer();
        }

        public HttpDataCore(environmentVarsCore _state = default, string _overrideUrl = "")
        {
            RestartQueueTimer = new System.Timers.Timer();
            queue = new List<_queue_data_struct>();
            dataStatistics = new List<_data_statistics>();
            loadingCounter = 0;
            sendToQueue = false;
            if (_state is object && _overrideUrl.Equals(""))
            {
                url = _state.ServerBaseAddr + _state.ApiServerAddrPath;
            }
            else if (!_overrideUrl.Equals(""))
            {
                url = _overrideUrl;
            }
            else
            {
                throw new Exception("Initialization err: state and url cannot be both null at same time");
            }

            if (_state is object)
            {
                state = _state;
            }
        }

        public string url { get; set; }
        public environmentVarsCore state { get; set; } = new environmentVarsCore();
        public string errorMessage { get; set; } = "";
        public string statusMessage { get; set; }
        public int threadCount { get; set; } = 25;
        public object numberOfRetryAttempts { get; set; } = 5;
        public List<_queue_data_struct> queue { get; set; }
        public int[] queueBWorker { get; set; } // has the size of threadCount
        public object queueLock { get; set; } = new object();
        public _retry_attempts retryAttempts { get; set; } = new _retry_attempts();
        public List<_data_statistics> dataStatistics { get; set; }
        public int loadingCounter { get; set; }
        public int CompletionPercentage { get; set; } // value range 0-100
        public bool IsBusy { get; set; }


        public ResourceManager resources = new ResourceManager(Assembly.GetExecutingAssembly().EntryPoint.DeclaringType.Namespace + ".config.strings", Assembly.GetExecutingAssembly());

        public struct _queue_data_struct
        {
            public Dictionary<string, string> vars;
            public string filenameOrSavePath;                  // full address file name or full adress folder path
            public Dictionary<string, string> misc;
            public int status;                             // -1 - completed; 0- not sent yet; 1-already sent / processing 
        }

        public struct _retry_attempts
        {
            public int counter;
            public int pattern;
            public int previousPattern;
            public string errorMessage;
        }

        public struct _data_statistics
        {
            public double filesize;
            public double bytesSentReceived;
            public double speed;
        }

        private System.Timers.Timer _RestartQueueTimer;

        public System.Timers.Timer RestartQueueTimer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RestartQueueTimer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _RestartQueueTimer = value;
            }
        }

        public BackgroundWorker[] bwDataRequest;

        public event requestCompletedEventHandler requestCompleted;

        public delegate void requestCompletedEventHandler(object sender, string requestData); // TODO add misc vars

        private bool sendToQueue;

        public void loadQueue(Dictionary<string, string> vars, Dictionary<string, string> misc = null, string filenameOrSavePath = null)
        {
            var queueItem = new _queue_data_struct();
            queueItem.vars = new Dictionary<string, string>();
            queueItem.misc = new Dictionary<string, string>();
            queueItem.vars = vars;
            queueItem.status = 0;
            queueItem.misc = misc;
            queueItem.filenameOrSavePath = filenameOrSavePath;
            queue.Add(queueItem);
        }

        public void clearQueue()
        {
            loadingCounter = 0;
            queue = new List<_queue_data_struct>();
        }

        public void startRequest()
        {
            if (bwDataRequest[0] is null)
            {
                throw new Exception("You need to call initialze first");
                return;
            }

            // startSendQueue()
            IsBusy = true;
            RestartQueueTimer.Elapsed += new ElapsedEventHandler(QueueTimerTick);
            {
                var withBlock = RestartQueueTimer;
                withBlock.Enabled = true;
                withBlock.Interval = 500;
                withBlock.Start();
            }
        }

        private void QueueTimerTick(object sender, ElapsedEventArgs e)
        {
            if (QueuesToComplete(queue).Equals(0) & QueuesToSend(queue).Equals(0))
            {
                RestartQueueTimer.Stop();
                queue = new List<_queue_data_struct>();
                requestCompleted?.Invoke(this, null);
                IsBusy = false;
                return;
            }


            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreaterEqual(retryAttempts.counter, numberOfRetryAttempts, false))) // ToDo a retry number of attempts before quits
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(state.currentLang);
                messageBoxForm MsgBox;
                MsgBox = new messageBoxForm(retryAttempts.errorMessage + ". " + resources.GetString("tryAgain") + " ?", resources.GetString("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (MsgBox.ShowDialog() == DialogResult.Yes)
                {
                    _retry_attempts retry;
                    retry.counter = 0;
                    retry.previousPattern = -1;
                    retry.pattern = 0;
                    retry.errorMessage = "";
                    retryAttempts = retry;
                    startSendQueue();
                }
                else
                {
                    RestartQueueTimer.Stop();
                    queue = new List<_queue_data_struct>();
                    requestCompleted?.Invoke(this, null);
                    IsBusy = false;
                    return;
                }

                return;
            }
            else if (!sendToQueue & QueuesToSend(queue) > 0)
            {
                startSendQueue();
            }
        }

        private void startSendQueue()
        {
            sendToQueue = true;
            while (QueuesToSend(queue) > 0)
            {
                for (int shtIndex = 0, loopTo = threadCount; shtIndex <= loopTo; shtIndex++)
                {
                    for (int i = 0, loopTo1 = queue.Count - 1; i <= loopTo1; i++)
                    {
                        if (!bwDataRequest[shtIndex].IsBusy)
                        {
                            lock (queueLock)
                            {
                                if (queue.ElementAt(i).status.Equals(0))
                                {
                                    var data = new _queue_data_struct();
                                    data.vars = queue.ElementAt(i).vars;
                                    data.status = 1;
                                    data.misc = queue.ElementAt(i).misc;
                                    data.filenameOrSavePath = queue.ElementAt(i).filenameOrSavePath;
                                    queue[i] = data;
                                    queueBWorker[shtIndex] = i;
                                    dataStatistics[shtIndex] = new _data_statistics();
                                    bwDataRequest[shtIndex].RunWorkerAsync(queue[i]);
                                    System.Threading.Thread.Sleep(50);
                                }
                            }
                        }
                    }
                }
            }

            sendToQueue = false;
        }

        public int QueuesToSend(List<_queue_data_struct> queue)
        {
            int counter = 0;
            for (int i = 0, loopTo = queue.Count - 1; i <= loopTo; i++)
            {
                if (queue[i].status.Equals(0))
                {
                    counter += 1;
                }
            }

            return counter;
        }

        public int QueuesToComplete(List<_queue_data_struct> queue)
        {
            int counter = 0;
            for (int i = 0, loopTo = queue.Count - 1; i <= loopTo; i++)
            {
                if (queue[i].status.Equals(1))
                {
                    counter += 1;
                }
            }

            return counter;
        }

        public int QueuesMultiHash(List<_queue_data_struct> queue)
        {
            int counter = 0;
            for (int i = 0, loopTo = queue.Count - 1; i <= loopTo; i++)
            {
                if (queue[i].status.Equals(1))
                {
                    counter += i;
                }
            }

            return counter;
        }

        public bool IsBase64String(string s)
        {
            s = s.Trim();
            return s.Length % 4 == 0 && Regex.IsMatch(s, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
        }

        // +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public Dictionary<string, List<string>> ConvertDataToArray(string key, string[] fields, string response)
        {
            if (ManagementNetwork.GetMessage(response).Equals("1001"))
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(state.currentLang);
                errorMessage = "{'error':true,'message':'" + resources.GetString("errorNoRecordsFound", CultureInfo.CurrentCulture) + "'}";
                return null;
            }

            try
            {
                var jsonResult = JsonSerializer.Deserialize<Dictionary<string, List<List<Object>>>>(response);
                if (jsonResult.ContainsKey(key))
                {

                    if (!jsonResult[key].ElementAt(0).Count.Equals(fields.Length))
                    {
                        System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(state.currentLang);
                        errorMessage = "{'error':true,'message':'" + resources.GetString("JsonFieldsMismatch", CultureInfo.CurrentCulture) + ". table(" + key + "'}";
                        return null;
                    }
                    else
                    {
                        var results = new Dictionary<string, List<string>>();
                        for (int k = 0, loopTo = fields.Length - 1; k <= loopTo; k++)
                        {
                            var fieldValues = new List<string>();
                            var loopTo1 = Conversions.ToInteger(Operators.SubtractObject(jsonResult[key].Count, 1));
                            for (int i = 0; i <= Conversions.ToInteger(loopTo1); i++)
                                fieldValues.Add(jsonResult[key].ElementAt(i).ElementAt(k).ToString());
                            results.Add(fields[k], fieldValues);
                        }

                        return results;
                    }
                }
                else
                {
                    System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(state.currentLang);
                    errorMessage = "{'error':true,'message':'" + resources.GetString("JsonkeyNotFound", CultureInfo.CurrentCulture) + " (" + key + "'}";
                    return null;
                }
            }
            catch (Exception ex)
            {
                errorMessage = "{'error':true,'message':'" + ex.ToString() + "'}";
                errorMessage = ex.ToString();
                return null;
            }
        }
    }
}