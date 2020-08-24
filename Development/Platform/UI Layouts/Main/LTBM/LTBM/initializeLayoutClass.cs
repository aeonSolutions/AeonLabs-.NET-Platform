using AeonLabs.Environment.Core;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AeonLabs.Layouts.Main
{
    public class initializeAssembly
    {
        public static Dictionary<string, environmentAssembliesClass> AssembliesToLoadAtStart()
        {
            var returnAssemblies = new Dictionary<string, environmentAssembliesClass>();

            // SIDEBAR SETTINGS
            var assItem = new environmentAssembliesClass();
            assItem.assemblyFileName = "sideBarSettings.dll";
            assItem.friendlyUID = "sideBarSettings";
            assItem.assemblyFormName = "lateralSettingsForm";
            assItem.assemblyFormToLoad = default;
            assItem.AssemblyObject = default;
            assItem.defaultClassName = "";
            assItem.spaceName = "AeonLabs.PlugIns.SideBar.Settings";
            assItem.UID = "NPmPqPuuqlwPL6swalnnMSqKGCp6MTr9";
            assItem.positionX = default; // Nothing for default posX
            assItem.positionY = default; // Nothing for default poxY
            assItem.anchor = AnchorStyles.Left | AnchorStyles.Top;
            assItem.control = null;
            returnAssemblies.Add(assItem.friendlyUID, assItem);

            // RETURN ASSEMBLIES DICT list
            return returnAssemblies;
        }
    }
}
