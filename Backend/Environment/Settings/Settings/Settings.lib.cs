using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;

namespace AeonLabs.Settings
{
    public class Settings
    {
        private environmentVarsCore state;
        public string country;
        public string lang = null;
        public string adminName = null;
        public string adminId = null;
        public bool isNewServer = default;
        public bool isSharedServer = default;
        public string serverWebAddr = null;
        public string ApiServerAddrPath = null;
        public string ApiEncryptionKey = null;
        public string serverFtpAddr = null;
        public string serverFtpUser = null;
        public string serverFtpPwd = null;
        public bool serverFtpSsl = default;
        public string serverFtpPort = null;
        public string userId = null;
        public string dbLang = null;
        public string dbName = null;
        public string dbUser = null;
        public string dbPwd = null;
        public bool sendDiags = default;
        public bool sendCrash = default;
        public bool isTranslationEnabled = default;
        public string translationProvider = null;
        public string translationApiKey = null;
        public bool isWeatherEnabled = default;
        public string weatherProvider = null;
        public string weatherApiKey = null;
        public string programId = null;
        public bool disableOptions = default;
        public string errorMessage = "";
        public bool hasError = false;

        public Settings(environmentVarsCore _state)
        {
            state = _state;
        }

        public void updateState(environmentVarsCore _state)
        {
            state = _state;
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public bool save()
        {
            hasError = false;
            var vars = new Dictionary<string, string>();
            state.secretKey = state.SettingsSecretKey;
            var encryption = new AeonLabs.Security.AesCipher(state);
            vars.Add("country", country);
            vars.Add("language", lang);
            vars.Add("serverAddress", serverWebAddr);
            vars.Add("ApiServerAddrPath", ApiServerAddrPath);
            vars.Add("ApiEncryptionKey", ApiEncryptionKey);
            vars.Add("sendDiags", Conversions.ToString(sendDiags));
            vars.Add("sendCrash", Conversions.ToString(sendCrash));
            var serializer = new JavaScriptSerializer();
            string json = serializer.Serialize(vars);
            string encrypted = encryption.encrypt(json);
            var settingsFile = new FileInfo(Path.Combine(state.libraryPath, "ScrewDriver.eon"));
            settingsFile.Refresh();
            if (settingsFile.Exists)
            {
                try
                {
                    FileSystem.Kill(Path.Combine(state.libraryPath, "ScrewDriver.eon"));
                }
                catch (Exception ex)
                {
                    hasError = true;
                    System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(state.currentLang);
                    errorMessage = My.Resources.strings.errorDeletingData + ". " + My.Resources.strings.contactEnterpriseSupport;
                    return false;
                }
            }

            try
            {
                var bytes = Convert.FromBase64String(encrypted);
                File.WriteAllBytes(Path.Combine(state.libraryPath, "ScrewDriver.eon"), bytes);
            }
            catch (Exception ex)
            {
                hasError = true;
                System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(state.currentLang);
                errorMessage = My.Resources.strings.errorSavingData + ". " + My.Resources.strings.contactEnterpriseSupport;
                return false;
            }

            return true;
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public environmentVarsCore load()
        {
            state.secretKey = state.SettingsSecretKey;
            var encryption = new AeonLabs.Security.AesCipher(state);
            var settingsFile = new FileInfo(Path.Combine(state.libraryPath, "ScrewDriver.eon"));
            settingsFile.Refresh();
            if (settingsFile.Exists)
            {
                try
                {
                    var bytes = File.ReadAllBytes(Path.Combine(state.libraryPath, "ScrewDriver.eon"));
                    string encrypted = Convert.ToBase64String(bytes, 0, bytes.Length);
                    string decrypted = encryption.decrypt(encrypted);
                    var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(decrypted);
                    state.country = data["country"].ToString();
                    state.currentLang = data["language"].ToString();
                    state.ServerBaseAddr = data["serverAddress"].ToString();
                    state.ApiServerAddrPath = data["ApiServerAddrPath"].ToString();
                    state.secretKey = data["ApiEncryptionKey"].ToString();
                    state.SendDiagnosticData = data["sendDiags"];
                    state.SendCrashData = data["sendCrash"];
                    return state;
                }
                catch (Exception ex)
                {
                    hasError = true;
                    errorMessage = ex.ToString();
                    return default;
                }
            }
            else
            {
                hasError = true;
                System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(state.currentLang);
                errorMessage = My.Resources.strings.errorDataFileNotFound;
                return default;
            }
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}