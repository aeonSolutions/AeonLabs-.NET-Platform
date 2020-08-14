using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using AeonLabs.Environment;
using AeonLabs.Security;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Text.Json;
using Newtonsoft.Json;

namespace AeonLabs.Network
{
    public class HttpDataPostData : HttpDataCore
    {
        public event updateProgressEventHandler updateProgress;

        public delegate void updateProgressEventHandler(object sender, Dictionary<string, string> misc);

        public event dataArrivedEventHandler dataArrived;

        public delegate void dataArrivedEventHandler(object sender, string requestData, Dictionary<string, string> misc);

        public HttpDataPostData(environmentVarsCore _state = default, string _overrideUrl = "") : base(_state, _overrideUrl)
        {
        }

        public void initialize(int _threadCount = 0)
        {
            if (!_threadCount.Equals(0))
            {
                threadCount = _threadCount;
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
                e.Result = "{'error':true,'message':'" + resources.GetString("errorNoNetwork", CultureInfo.CurrentCulture)  + "'}";
                return;
            }

            if (vars is null)
            {
                e.Result = "{'error':true,'message':'missconfiguration vars'}";
                return;
            }

            if (!vars.ContainsKey("id"))
            {
                vars.Add("id", state.userId);
            }

            if (!vars.ContainsKey("pid"))
            {
                var appId = new FingerPrint();
                vars.Add("pid", appId.Value());
            }

            if (!vars.ContainsKey("language"))
            {
                vars.Add("language", state.currentLang);
            }

            if (!vars.ContainsKey("origin"))
            {
                vars.Add("origin", state.customization.softwareAccessMode);
            }

            string json = JsonConvert.SerializeObject(vars, Formatting.Indented);
            var encryption = new AesCipher(state);
            string encrypted = HttpUtility.UrlEncode(encryption.encrypt(json));
            var PostData = "origin=" + state.customization.softwareAccessMode + "&data=" + encrypted;
            var request = WebRequest.Create(url);
            string responseFromServer = "";
            string decrypted = "";
            request.Method = "POST";
            var byteArray = Encoding.UTF8.GetBytes(PostData);
            request.ContentType = "application/x-www-form-urlencoded";
            request.Headers.Add("Authorization", state.ApiHttpHeaderToken + "-" + state.customization.softwareAccessMode);
            request.ContentLength = (long)byteArray.Length;
            try
            {
                var dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                dataStream = response.GetResponseStream();
                var reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();
                if (response.StatusCode == HttpStatusCode.Accepted | (int)response.StatusCode == 200)
                {
                    if (IsBase64String(responseFromServer) & !responseFromServer.Equals(""))
                    {
                        decrypted = encryption.decrypt(responseFromServer).Replace(@"\'", "'");
                    }
                    else
                    {
                        System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(state.currentLang);
                        decrypted = "{'error':true,'encrypted':false,'message':'" + resources.GetString("contactingCommServer", CultureInfo.CurrentCulture) + " |" + responseFromServer + "|'}";
                    }
                }
                else
                {
                    System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(state.currentLang);
                    decrypted = "{'error':true,'message':'" + resources.GetString("contactingCommServer", CultureInfo.CurrentCulture) + " (" + ((int)response.StatusCode).ToString() + ")', 'statuscode':'" + ((int)response.StatusCode).ToString() + "'}";
                }
            }
            catch (Exception ex)
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(state.currentLang);
                decrypted = "{'error':true,'message':'" + resources.GetString("contactingCommServer", CultureInfo.CurrentCulture) + " (" + ex.Message.ToString().Replace("'", @"\'") + ")'}";
            }

            e.Result = decrypted.Replace(@"\'", "'");
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

            if (ManagementNetwork.IsResponseOk(Conversions.ToString(e.Result), "statuscode"))
            {
                data = new _queue_data_struct();
                data = queue[queueBWorker[Index]];
                data.status = 0; // re queue the file
                lock (queueLock)
                    queue[queueBWorker[Index]] = data;
                string errorMsg = ManagementNetwork.GetMessage(Conversions.ToString(e.Result));
                _retry_attempts retry;
                retry.counter = retryAttempts.counter;
                retry.previousPattern = retryAttempts.previousPattern;
                retry.pattern = retryAttempts.pattern;
                retry.errorMessage = retryAttempts.errorMessage;
                retry.errorMessage = retryAttempts.errorMessage.IndexOf(errorMsg) > -1 ? retryAttempts.errorMessage : retryAttempts.errorMessage + System.Environment.NewLine + errorMsg;
                retry.pattern = QueuesMultiHash(queue);
                if (retry.previousPattern.Equals(retry.pattern))
                {
                    retry.counter += 1;
                }
                else
                {
                    retry.counter = 1;
                    retry.previousPattern = retryAttempts.pattern;
                }

                retryAttempts = retry;
                return;
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