using System.IO;

namespace AeonLabs.Environment
{
    public class customization
    {
        public string ApplicationBrandNAme { get; set; } = "Missing brand";
        public string businessname { get; set; } = "missing business name";

        // default layout
        public string designLayoutAssemblyFileName { get; set; } = "";
        public string designLayoutAssemblyNameSpace { get; set; } = "";

        // úser defined custom layout
        public string designLayoutCustomAssemblyFileName { get; set; } = "";
        public string designLayoutCustomAssemblyNameSpace { get; set; } = "";
        public string designStartupLayoutAssemblyFileName { get; set; } = "";
        public string designStartupLayoutAssemblyNameSpace { get; set; } = "";
        public bool hasCodedCustomizationSettings { get; set; } = false;
        public bool hasLogin { get; set; } = false;
        public bool hasSetup { get; set; } = false;
        public bool hasLocalSettings { get; set; } = false;
        public bool hasCloudSettings { get; set; } = false;
        public bool hasStaticAssemblies { get; set; } = true;
        public bool hasDynamicAssemblies { get; set; } = true;
        public bool hasStaticDocumentTemplates { get; set; } = true;
        public bool hasDynamicDocumentTemplates { get; set; } = true;
        public string websiteToLoadProgram { get; set; } = "";
        public string softwareAccessMode { get; set; } = "";
        public string expireDate { get; set; } = ""; // 'expire date dd/mm/yyyy
        public string updateServerAddr { get; set; } = "http://www.remoteattendance.logistics/update";
        public string crashReportServerAddr { get; set; } = "";

        public void loadCustomizationFile(environmentVarsCore envars)
        {
            // ToDo check if customization file is present
            var custom = new FileInfo(envars.libraryPath + "custom.eon");
            custom.Refresh();
            if (custom.Exists)
            {
            }
            // TODO LOAD FILE
            else
            {
                // TODO LOAD BLANK UNCONFIGURED APP - MAKE AN external APP for building this file
            }
        }
    }
}