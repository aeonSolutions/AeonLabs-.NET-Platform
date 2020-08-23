using System.Text.RegularExpressions;

namespace AeonLabs.BasicLibraries
{
    public static class ImputValidation
    {
        public static bool IsValidEmailFormat(string s)
        {
            try
            {
                var a = new System.Net.Mail.MailAddress(s);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static bool IsValidUrl(string protocol, string url)
        {
            if (!protocol.Equals("http") & !protocol.Equals("https") & !protocol.Equals("ftp") & !protocol.Equals("http|https") & !protocol.Equals("https|http"))
                return false;
            if (url is null)
                return false;
            if (url.Equals(""))
                return false;
            bool result = Regex.IsMatch(url, "(" + protocol + @")://(([www\.])?|([\da-z-\.]+))\.([a-z\.]{2,30})$");
            return result;
        }
    }
}