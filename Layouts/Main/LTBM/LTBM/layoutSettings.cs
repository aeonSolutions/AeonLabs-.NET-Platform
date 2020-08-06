using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace AeonLabs.Layouts.Main
{
    public static class LayoutSettings
    {
        public const string LAYOUT_VERSION = "1.0.0";
        public const string LAYOUT_COMPATIBILITY_WITH_MAIN = "1.0.0";

        public static List<string> layoutCompatibilityApps()
        {
            var apps = new List<string>();
            apps.Add("remoteAttendance");
            return apps;
        }

        public static environmentVarsCore loadExternalFilesInUse(environmentVarsCore envars)
        {
            envars.externalFilesToLoad.Add("menuMinimizeArrow", "uparrow.png");
            envars.externalFilesToLoad.Add("menuExpandArrow", "downarrow.png");
            string testFilesExist = "";
            foreach (KeyValuePair<string, string> item in envars.externalFilesToLoad)
            {
                if (!My.MyProject.Computer.FileSystem.FileExists(envars.imagesPath + item.Value))
                {
                    testFilesExist += item.Value + "; ";
                }
            }

            if (!testFilesExist.Equals(""))
            {
                Interaction.MsgBox("Could not load the following files: " + testFilesExist);
                return default;
            }
            else
            {
                return envars;
            }
        }
    }
}