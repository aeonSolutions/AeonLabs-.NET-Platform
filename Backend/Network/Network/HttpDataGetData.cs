using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using AeonLabs.Environment;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace AeonLabs.Network
{
    public class HttpDataGetData : HttpDataCore
    {
        public event updateProgressEventHandler updateProgress;

        public delegate void updateProgressEventHandler(object sender, Dictionary<string, string> misc);

        public event dataArrivedEventHandler dataArrived;

        public delegate void dataArrivedEventHandler(object sender, string requestData, Dictionary<string, string> misc);

        public HttpDataGetData(environmentVarsCore _state = default, string _url = "") : base(_state, _url)
        {
        }

        public void initialize(int _threadCount = 0)
        {
            if (!_threadCount.Equals(0))
            {
                threadCount = _threadCount;
            }

            if (!url.Equals(state.ServerBaseAddr + state.ApiServerAddrPath))
            {
                var queueItem = new _queue_data_struct();
                queueItem.vars = new Dictionary<string, string>();
                queueItem.misc = null;
                queueItem.vars.Add("url", url);
                queueItem.status = 0;
                queueItem.filenameOrSavePath = "";
                queue.Add(queueItem);
            }
            else
            {
            }

            bwDataRequest = new BackgroundWorker[threadCount + 1];
            queueBWorker = new int[threadCount + 1];
            for (int shtIndex = 0, loopTo = threadCount; shtIndex <= loopTo; shtIndex++)
            {
                dataStatistics.Add(new _data_statistics());
                bwDataRequest[shtIndex] = new BackgroundWorker();
                bwDataRequest[shtIndex].WorkerReportsProgress = true;
                bwDataRequest[shtIndex].WorkerSupportsCancellation = true;
                bwDataRequest[shtIndex].DoWork += bwDataRequest_DoWork;
                bwDataRequest[shtIndex].RunWorkerCompleted += bwDataRequest_RunWorkerCompleted;
            }

            _retry_attempts retry;
            retry.counter = 0;
            retry.previousPattern = -1;
            retry.pattern = 0;
            retry.errorMessage = "";
            retryAttempts = retry;
        }

        private void bwDataRequest_DoWork(object sender, DoWorkEventArgs e)
        {

            // Find out the Index of the bWorker that called this DoWork (could be cleaner, I know)
            int Y;
            int Index = default;
            var loopTo = Information.UBound(bwDataRequest);
            for (Y = 0; Y <= loopTo; Y++)
            {
                if (sender.Equals(bwDataRequest[Y]))
                {
                    Index = Y;
                    break;
                }
            }

            _queue_data_struct queue;
            queue = (_queue_data_struct)e.Argument;
            var vars = new Dictionary<string, string>();
            vars = queue.vars;

            // TODO translation need to be local
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(state.currentLang);
                e.Result = "{'error':true,'message':'" + rm.GetString("errorNoNetwork", CultureInfo.CurrentCulture)  + "'}";
                return;
            }

            if (vars is object)
            {
                if (vars.Count > 0)
                {
                    for (int i = 0, loopTo1 = vars.Count - 1; i <= loopTo1; i++)
                    {
                        if (vars.ElementAt(i).Key.Equals("url"))
                        {
                            continue;
                        }

                        if (Conversions.ToBoolean(url.IndexOf("?")))
                        {
                            url += "&" + vars.ElementAt(i).Key + "=" + vars.ElementAt(i).Value;
                        }
                        else
                        {
                            url += "?" + vars.ElementAt(i).Key + "=" + vars.ElementAt(i).Value;
                        }
                    }
                }
            }

            var webClient = new WebClient();

            // ' webClient.Headers.Add("Connection", "Keep-Alive")
            // 'webClient.Headers.Add("Keep-Alive", "timeout=20")
            // 'webClient.Headers.Add("ENCTYPE", "multipart/form-data")
            webClient.Headers.Add("User-Agent", "Aeon Labs");
            byte[] result;
            try
            {
                result = webClient.DownloadData(url);
            }
            catch (Exception ex)
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(state.currentLang);
                e.Result = "{'error':true,'message':'" + rm.GetString("contactingCommServer", CultureInfo.CurrentCulture)  + " (" + ex.Message.ToString() + System.Environment.NewLine + url + ")'}";
                return;
            }

            var utf8Encoding = new UTF8Encoding(true);
            e.Result = utf8Encoding.GetString(result);
        }

        private void bwDataRequest_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Find out the Index of the bWorker that called this DoWork (could be cleaner, I know)
            int Y;
            int Index = default;
            var data = new _queue_data_struct();
            var loopTo = Information.UBound(bwDataRequest);
            for (Y = 0; Y <= loopTo; Y++)
            {
                if (sender.Equals(bwDataRequest[Y]))
                {
                    Index = Y;
                    break;
                }
            }

            data = new _queue_data_struct();
            data = queue[queueBWorker[Index]];
            data.status = -1; // completed sucessfully status
            lock (queueLock)
                queue[queueBWorker[Index]] = data;
            loadingCounter += 1;
            CompletionPercentage = (int)(loadingCounter / (double)queue.Count * 100);
            statusMessage = "Loading data from the cloud ...";
            updateProgress?.Invoke(this, queue[queueBWorker[Index]].misc);
            dataArrived?.Invoke(this, Conversions.ToString(e.Result), queue[queueBWorker[Index]].misc);
        }
    }
}