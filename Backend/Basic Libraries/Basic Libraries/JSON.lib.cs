using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;

namespace AeonLabs.BasicLibraries
{
    public static class JSonFunctionsLibrary
    {
        public static bool IsNullOrEmpty(JToken token)
        {
            return token.Equals(null) | token.Type.Equals(JTokenType.Array) & !token.HasValues | token.Type.Equals(JTokenType.Object) & !token.HasValues | token.Type.Equals(JTokenType.String) & token.ToString().Equals(string.Empty) | token.Type.Equals(JTokenType.Null);
        }

        public static Dictionary<string, string> getTaskTranslations(string jsonString)
        {
            if (jsonString.Equals(""))
            {
                return null;
            }

            var translations = new Dictionary<string, string>();
            try
            {
                var j = new JavaScriptSerializer().Deserialize<object>(jsonString);
                foreach (KeyValuePair<string, object> entry in (IEnumerable)j)
                    translations.Add(entry.Key, Conversions.ToString(entry.Value));
            }
            catch (Exception ex)
            {
                return null;
            }

            return translations;
        }
    }
}