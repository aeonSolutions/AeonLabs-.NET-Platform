using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace AeonLabs.Network
{
    public class HttpDataFilesUpload : HttpDataCore
    {
        public event updateProgressStatisticsEventHandler updateProgressStatistics;

        public delegate void updateProgressStatisticsEventHandler(object sender, Dictionary<string, string> misc);

        public event dataArrivedEventHandler dataArrived;

        public delegate void dataArrivedEventHandler(object sender, string responseData, Dictionary<string, string> misc);

        public HttpDataFilesUpload(environmentVarsCore _state = default, string _url = "") : base(_state, _url)
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
            byte[] responseBytes;

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

            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(state.currentLang);
                responseBytes = Encoding.UTF8.GetBytes("{'error':true,'message':'" + My.Resources.strings.errorNoNetwork + "'}");
                return;
            }

            _queue_data_struct queue;
            queue = (_queue_data_struct)e.Argument;
            var vars = new Dictionary<string, string>();
            vars = queue.vars;
            if (!vars.ContainsKey("id"))
            {
                vars.Add("id", state.userId);
            }

            if (!vars.ContainsKey("pid"))
            {
                var appId = new FingerPrint();
                vars.Add("pid", appId.Value);
            }

            if (!vars.ContainsKey("language"))
            {
                vars.Add("language", state.currentLang);
            }

            var serializer = new JavaScriptSerializer();
            string json = serializer.Serialize(vars);
            var encryption = new AesCipher(state);
            string encrypted = HttpUtility.UrlEncode(encryption.encrypt(json));
            var PostData = new Dictionary<string, string>();
            PostData.Add("origin", state.customization.softwareAccessMode);
            PostData.Add("data", encrypted);
            double currentspeed = -1;
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            var boundarybytes = Encoding.ASCII.GetBytes(Constants.vbCrLf + "--" + boundary + Constants.vbCrLf);
            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";
            wr.KeepAlive = true;
            wr.Credentials = CredentialCache.DefaultCredentials;
            var rs = wr.GetRequestStream();
            string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"" + Constants.vbCrLf + Constants.vbCrLf + "{1}";
            for (int i = 0, loopTo1 = PostData.Count - 1; i <= loopTo1; i++)
            {
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                string formitem = string.Format(formdataTemplate, PostData.Keys.ElementAtOrDefault(i), PostData[PostData.Keys.ElementAtOrDefault(i)]);
                var formitembytes = Encoding.UTF8.GetBytes(formitem);
                rs.Write(formitembytes, 0, formitembytes.Length);
            }

            rs.Write(boundarybytes, 0, boundarybytes.Length);
            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"" + Constants.vbCrLf + "Content-Type: {2}" + Constants.vbCrLf + Constants.vbCrLf;
            string header = string.Format(headerTemplate, "file", Path.GetFileName(queue.filenameOrSavePath), "application/octet-stream");
            var headerbytes = Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);
            var fileStream = new FileStream(queue.filenameOrSavePath, FileMode.Open, FileAccess.Read);
            var buffer = new byte[4096];
            int bytesRead = 0;
            double totalBytesRead = 0;
            int readings = 0;
            var speedtimer = new Stopwatch();
            _data_statistics dataStatisticsItem;
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(state.currentLang);
            dataStatisticsItem.filesize = Conversions.ToDouble(My.Resources.strings.size + ": " + Math.Round(fileStream.Length / (double)1024, 0) + " " + My.Resources.strings.bytes);
            dataStatisticsItem.bytesSentReceived = 0;
            dataStatisticsItem.speed = 0;
            dataStatistics[queueBWorker[Index]] = dataStatisticsItem;
            bytesRead = fileStream.Read(buffer, 0, buffer.Length);
            while (bytesRead != 0)
            {
                rs.Write(buffer, 0, bytesRead);
                dataStatisticsItem.bytesSentReceived += bytesRead;
                dataStatistics[queueBWorker[Index]] = dataStatisticsItem;
                readings += 1;
                if (readings >= 5)
                {
                    dataStatisticsItem.speed = 20480 / (speedtimer.ElapsedMilliseconds / (double)1000);
                    dataStatistics[queueBWorker[Index]] = dataStatisticsItem;
                    speedtimer.Reset();
                    readings = 0;
                    updateProgressStatistics?.Invoke(this, queue.misc);
                }

                bytesRead = fileStream.Read(buffer, 0, buffer.Length);
            }

            fileStream.Close();
            var trailer = Encoding.ASCII.GetBytes(Constants.vbCrLf + "--" + boundary + "--" + Constants.vbCrLf);
            rs.Write(trailer, 0, trailer.Length);
            rs.Close();
            WebResponse wresp = null;
            try
            {
                wresp = wr.GetResponse();
                var stream2 = wresp.GetResponseStream();
                var reader2 = new StreamReader(stream2);
                responseBytes = Encoding.UTF8.GetBytes(reader2.ReadToEnd());
            }
            catch (Exception ex)
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(state.currentLang);
                responseBytes = Encoding.UTF8.GetBytes("{'error':true,'message':'" + My.Resources.strings.contactingCommServer + ":" + ex.Message + "'}");
                if (wresp is object)
                {
                    wresp.Close();
                    wresp = null;
                }
            }

            wr = null;
            e.Result = responseBytes;
        }

        private void bwDataRequest_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            string responseFromServer = Encoding.UTF8.GetString((byte[])e.Result);
            string decrypted = "";
            var encryption = new AesCipher(state);
            _queue_data_struct data;
            try
            {
                if (IsBase64String(responseFromServer) & !responseFromServer.Equals(""))
                {
                    decrypted = encryption.decrypt(responseFromServer);
                }
                else
                {
                    System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(state.currentLang);
                    decrypted = "{'error':true,'message':'" + My.Resources.strings.contactingCommServer + " |" + responseFromServer + "|'}";
                }
            }
            catch (Exception ex)
            {
                decrypted = "{'error':true,'message':'" + ex.Message.ToString().Replace("'", @"\'") + "'}";
            }

            if (!ManagementNetwork.IsResponseOk(decrypted))
            {
                data = new _queue_data_struct();
                data = queue[queueBWorker[Index]];
                data.status = 0; // re queue the file
                lock (queueLock)
                    queue[queueBWorker[Index]] = data;
                string errorMsg = ManagementNetwork.GetMessage(decrypted);
                _retry_attempts retry;
                retry.counter = retryAttempts.counter;
                retry.previousPattern = retryAttempts.previousPattern;
                retry.pattern = retryAttempts.pattern;
                retry.errorMessage = retryAttempts.errorMessage;
                retry.errorMessage = retryAttempts.errorMessage.IndexOf(errorMsg) > -1 ? retryAttempts.errorMessage : retryAttempts.errorMessage + Environment.NewLine + errorMsg;
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
            statusMessage = "Uploading data to the cloud ...";
            dataArrived?.Invoke(this, decrypted, queue[queueBWorker[Index]].misc);
        }
    }
}