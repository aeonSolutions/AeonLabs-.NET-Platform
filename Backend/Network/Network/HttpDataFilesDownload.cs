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

namespace AeonLabs.Network
{
    public class HttpDataFilesDownload : HttpDataCore
    {
        private string[] fileExtension;

        public event dataArrivedEventHandler dataArrived;

        public delegate void dataArrivedEventHandler(object sender, string requestData, Dictionary<string, string> misc);

        public event updateProgressStatisticsEventHandler updateProgressStatistics;

        public delegate void updateProgressStatisticsEventHandler(object sender, _data_statistics dataStatistics, Dictionary<string, string> misc);

        public HttpDataFilesDownload(environmentVarsCore _state = default, string _url = "") : base(_state, _url)
        {
        }

        public void initialize(int _threadCount = 0)
        {
            if (!_threadCount.Equals(0))
            {
                threadCount = _threadCount;
            }

            bwDataRequest = new BackgroundWorker[threadCount + 1];
            fileExtension = new string[threadCount + 1];
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

            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                e.Result = false;
                System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(state.currentLang);
                fileExtension[queueBWorker[Index]] = "{'error':true,'message':'" + My.Resources.strings.errorNoNetwork + "'}";
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
            string Data2Send = "";
            for (int i = 0, loopTo1 = PostData.Count - 1; i <= loopTo1; i++)
                Data2Send += HttpUtility.UrlEncode(PostData.Keys.ElementAtOrDefault(i)) + "=" + HttpUtility.UrlEncode(PostData[PostData.Keys.ElementAtOrDefault(i)]) + "&";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            var data = Encoding.UTF8.GetBytes(Data2Send);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            var requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            requestStream.Close();
            int readings = 0;
            var speedtimer = new Stopwatch();
            _data_statistics dataStatisticsItem;
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        using (var bytes = new MemoryStream())
                        {
                            var Buffer = new byte[257];
                            dataStatisticsItem.filesize = Math.Round(bytes.Length / (double)1024, 0);
                            dataStatisticsItem.bytesSentReceived = 0;
                            dataStatisticsItem.speed = 0;
                            dataStatistics[queueBWorker[Index]] = dataStatisticsItem;
                            while (bytes.Length < response.ContentLength)
                            {
                                int read = stream.Read(Buffer, 0, Buffer.Length);
                                if (read > 0)
                                {
                                    bytes.Write(Buffer, 0, read);
                                }
                                else
                                {
                                    break;
                                }

                                readings += 1;
                                if (readings >= 5)
                                {
                                    dataStatisticsItem.speed = 20480 / (speedtimer.ElapsedMilliseconds / (double)1000);
                                    dataStatistics[queueBWorker[Index]] = dataStatisticsItem;
                                    speedtimer.Reset();
                                    readings = 0;
                                    updateProgressStatistics?.Invoke(this, dataStatisticsItem, queue.misc);
                                }
                            }

                            var utf8Encoding = new UTF8Encoding(true);
                            if (response.StatusCode == HttpStatusCode.Accepted | (int)response.StatusCode == 200)
                            {
                                string responseFromServer = utf8Encoding.GetString(bytes.ToArray());
                                string decrypted = "";
                                if (IsBase64String(responseFromServer) & !responseFromServer.Equals(""))
                                {
                                    decrypted = encryption.decrypt(responseFromServer).Replace(@"\'", "'");
                                    fileExtension[queueBWorker[Index]] = decrypted;
                                    e.Result = false;
                                }
                                else if (response.GetResponseHeader("Content-Disposition") is object && !response.GetResponseHeader("Content-Disposition").Equals(""))
                                {
                                    fileExtension[queueBWorker[Index]] = response.GetResponseHeader("Content-Disposition").Substring(response.GetResponseHeader("Content-Disposition").IndexOf("filename=") + 9);
                                    e.Result = bytes.ToArray();
                                }
                                else
                                {
                                    System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(state.currentLang);
                                    fileExtension[queueBWorker[Index]] = "{'error':true,'message':'" + My.Resources.strings.contactingCommServer + " (" + ((int)response.StatusCode).ToString() + ")'}";
                                    e.Result = false;
                                }
                            }
                            else
                            {
                                System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(state.currentLang);
                                fileExtension[queueBWorker[Index]] = "{'error':true,'message':'" + My.Resources.strings.contactingCommServer + " (" + ((int)response.StatusCode).ToString() + ")', 'statuscode':'" + ((int)response.StatusCode).ToString() + "'}";
                                e.Result = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                e.Result = false;
                fileExtension[queueBWorker[Index]] = "{'error':true,'message':'" + ex.Message + "'}";
            }
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

            var data = new _queue_data_struct();
            if (ManagementNetwork.IsResponseOk(fileExtension[queueBWorker[Index]], "statuscode"))
            {
                data = queue[queueBWorker[Index]];
                data.status = 0; // re queue the file
                lock (queueLock)
                    queue[queueBWorker[Index]] = data;
                string errorMsg = "";
                _retry_attempts retry;
                retry.counter = retryAttempts.counter;
                retry.previousPattern = retryAttempts.previousPattern;
                retry.pattern = retryAttempts.pattern;
                retry.errorMessage = retryAttempts.errorMessage;
                errorMsg = ManagementNetwork.GetMessage(fileExtension[Index]);
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
            else if (ManagementNetwork.IsResponseOk(fileExtension[Index]))
            {
                errorMessage = ManagementNetwork.GetMessage(fileExtension[Index]);
            }

            if (!e.Result.Equals(false))
            {
                try
                {
                    fileExtension[queueBWorker[Index]] = queue[queueBWorker[Index]].filenameOrSavePath + fileExtension[queueBWorker[Index]];
                    File.WriteAllBytes(fileExtension[queueBWorker[Index]], (byte[])e.Result);
                }
                catch (Exception ex)
                {
                    _retry_attempts retry;
                    retry.counter = retryAttempts.counter;
                    retry.previousPattern = retryAttempts.previousPattern;
                    retry.pattern = retryAttempts.pattern;
                    retry.errorMessage = retryAttempts.errorMessage;
                    retry.counter = 100;
                    retry.previousPattern = retry.pattern;
                    retry.errorMessage = "error saving file";
                    retryAttempts = retry;
                }
                finally
                {
                }
            }

            data = new _queue_data_struct();
            data = queue[queueBWorker[Index]];
            data.status = -1; // completed sucessfully status
            lock (queueLock)
                queue[queueBWorker[Index]] = data;
            loadingCounter += 1;
            CompletionPercentage = (int)(loadingCounter / (double)queue.Count * 100);
            statusMessage = "Loading cloud files...";
            dataArrived?.Invoke(this, fileExtension[queueBWorker[Index]], queue[queueBWorker[Index]].misc);
        }
    }
}