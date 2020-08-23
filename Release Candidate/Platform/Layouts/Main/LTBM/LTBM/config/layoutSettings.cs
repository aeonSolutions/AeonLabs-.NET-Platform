using System.Collections.Generic;
using System.IO;
using System.Windows;
using AeonLabs.Environment;
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
            envars.addExternalFileToLoad("menuMinimizeArrow", "uparrow.png");
            envars.addExternalFileToLoad("menuExpandArrow", "downarrow.png");
            envars.addExternalFileToLoad("noNetwork", "noNetwork.png");
            if (envars.stateErrorFound) {
                MessageBox.Show(envars.stateErrorMessage);
            }
            string testFilesExist = "";
            foreach (KeyValuePair<string, string> item in envars.externalFilesToLoad)
            {
                FileInfo AssembFile = new FileInfo(envars.imagesPath + item.Value);
                AssembFile.Refresh();
                if (!AssembFile.Exists)
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