using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;

namespace ConstructionSiteLogistics.AddOn.Translations.Web
{
    public class TranslationLibrary
    {
        public event getTranslationTextEventHandler getTranslationText;

        public delegate void getTranslationTextEventHandler(object sender, string responseData);

        private string translated = "";
        private environmentVars stateCore = new environmentVars();
        private languageTranslations translations;
        private HttpDataGetData _HttpDataRequestGoogleFree;

        private HttpDataGetData HttpDataRequestGoogleFree
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HttpDataRequestGoogleFree;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_HttpDataRequestGoogleFree != null)
                {
                    _HttpDataRequestGoogleFree.dataArrived -= HttpDataRequestGoogleFree_dataArrived;
                }

                _HttpDataRequestGoogleFree = value;
                if (_HttpDataRequestGoogleFree != null)
                {
                    _HttpDataRequestGoogleFree.dataArrived += HttpDataRequestGoogleFree_dataArrived;
                }
            }
        }

        private bool includeOriginalString;
        private string originalTextToTranslate;
        private string originLang;
        private string langToTranslate;

        public TranslationLibrary(string _text, string _langToTranslate, string _originLang, bool _includeOriginalString = true)
        {
            includeOriginalString = _includeOriginalString;
            originalTextToTranslate = _text;
            originLang = _originLang;
            langToTranslate = _langToTranslate;
            if (!stateCore.addonsLoaded || !stateCore.addons.ContainsKey("translation"))
            {
                translations.load("errorMessages");
                translated = "{'error':true,'message':'" + translations.getText("errorWeatherAddonNotFound") + ". " + translations.getText("contactEnterpriseSupport") + "'}";
                getTranslationText?.Invoke(this, translated);
                return;
            }
            else if (stateCore.addons("translation")("name").Equals("googleFreeTranslation"))
            {
                googleFreeTranslation();
            }
        }

        public void googleFreeTranslation()
        {
            // https://translate.googleapis.com/translate_a/single?client=gtx&sl=auto&tl={langtotranslate}&hl={originlang}&dt=t&dt=bd&dj=1&source=icon&q={text}

            translations = new languageTranslations(stateCore);
            if (langToTranslate.Equals(""))
            {
                langToTranslate = stateCore.defaultTranslatedLang;
            }

            if (originLang.Equals(""))
            {
                originLang = stateCore.currentLang;
            }

            translated = "";
            string str = originalTextToTranslate;
            int idx = str.IndexOf(Environment.NewLine + " _________________________" + Environment.NewLine);
            if (idx > 0)
            {
                str = str.Substring(0, idx);
            }
            // these chars are allowed   !"#$%&'()*+,-./:;<=>?@[\]^_`{|}~
            str = str.Replace(Environment.NewLine, "#$%@# ").Replace(".", "#$%@# ");
            string url = stateCore.addons("translation")("url").Replace("{langtotranslate}", langToTranslate).Replace("{originlang}", originLang).Replace("{text}", Uri.EscapeDataString(str)).Replace("{key}", stateCore.addons("translation")("key"));
            HttpDataRequestGoogleFree = new HttpDataGetData(stateCore, url);
            HttpDataRequestGoogleFree.initialize();
            HttpDataRequestGoogleFree.loadQueue(default, default, default);
            HttpDataRequestGoogleFree.startRequest();
        }

        private void HttpDataRequestGoogleFree_dataArrived(object sender, string responseData, Dictionary<string, string> misc)
        {
            try
            {
                var step3 = JObject.Parse(responseData);
                string responseStr = step3.SelectToken("sentences[0]").SelectToken("trans").ToString();
                responseStr = responseStr.Replace("#$%@#", Environment.NewLine).Replace("#$%@#", ".");
                string str = "";
                int idx;
                if (includeOriginalString)
                {
                    str = originalTextToTranslate;
                    idx = str.IndexOf(Environment.NewLine + " _________________________" + Environment.NewLine);
                    if (idx > 0)
                    {
                        str = str.Substring(0, idx);
                    }

                    str = str + Environment.NewLine + " _________________________" + Environment.NewLine;
                }
                else
                {
                    str = "";
                }

                translated = str + responseStr.ToString(System.Globalization.CultureInfo.InvariantCulture);
                getTranslationText?.Invoke(this, translated);
            }
            catch (Exception ex)
            {
                saveCrash(ex);
                getTranslationText?.Invoke(this, ex.ToString());
            }
        }
    }
}