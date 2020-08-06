using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;

namespace AeonLabs.Network
{
    public static class ManagementNetwork
    {
        public static bool IsFtpOnline(bool enableSSL, string url, string user, string pass)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(url));
            request.Credentials = new NetworkCredential(user, pass);
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            request.EnableSsl = enableSSL;
            try
            {
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                // Folder exists here
                return true;
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                // Does not exist
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    return false;
                }

                return false;
            }
        }

        public static bool IsOnline(string url)
        {
            try
            {
                var objUrl = new Uri(url);
                if (My.MyProject.Computer.Network.Ping(objUrl))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool IsResponseOk(string response, string jsonVar = "error")
        {
            if (response.Equals(""))
            {
                return false;
            }

            try
            {
                var jsonResult = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);
                return Conversions.ToBoolean(!jsonResult[jsonVar]);
            }
            catch (Exception ex)
            {
                return false;
            }

            // (jsonResult.Item("error").Item(0).Equals("true")) 

        }

        public static string GetMessage(string response)
        {
            try
            {
                var jsonResult = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);
                return Conversions.ToString(jsonResult["message"]);
            }
            catch (Exception ex)
            {
                return response;
            }
        }

        public static string GetMessageField(string response, string field)
        {
            try
            {
                var jsonResult = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);
                return Conversions.ToString(jsonResult[field]);
            }
            catch (Exception ex)
            {
                return "false";
            }
        }

        private static string encodeURL(string url)
        {
            int idx = 0;
            int idx2 = 0;
            int[] arr_s, arr_e;
            int pos = 0;
            return url;
            arr_s = new int[21];
            arr_e = new int[21];
            while (!url.IndexOf("=", idx).Equals(-1))
            {
                idx2 = url.IndexOf("=", idx) + 1;
                idx = url.IndexOf("&", idx2);
                if (idx.Equals(-1))
                {
                    idx = url.Length;
                }

                if (idx - idx2 > 0)
                {
                    arr_e[pos] = idx - idx2;
                    arr_s[pos] = idx2;
                    pos = pos + 1;
                }
            }

            for (int i = 0, loopTo = pos - 1; i <= loopTo; i++)
            {
                string substr = url.Substring(arr_s[i], arr_e[i]);
                string repstr = Uri.EscapeDataString(substr);
                url = url.Replace(substr, repstr);
            }

            return url;
        }
    }
}