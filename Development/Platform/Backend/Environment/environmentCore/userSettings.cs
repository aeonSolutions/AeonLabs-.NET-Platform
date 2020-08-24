
namespace AeonLabs.Environment.Core
{
    public class userSettingsClass
    {
        // UPDATES
        public bool checkForUpdatesIsEnabled { get; set; } = false;
        public bool packageUpdatesIsenabled { get; set; } = false;
        // LANGUAGE
        public string currentLang { get; set; } = "";
        public string country { get; set; } = "";
        public object defaultTranslatedLang { get; set; } = "fr";
    }
}