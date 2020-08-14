using System.Collections.Generic;
using System.Windows.Forms;

namespace AeonLabs.Layouts.Main
{
    public class initializeAssembly
    {
        public static Dictionary<string, Dictionary<string, environmentLoadedAssembliesClass>> AssembliesToLoadAtStart()
        {
            var returnAssemblies = new Dictionary<string, Dictionary<string, environmentLoadedAssembliesClass>>();
            Dictionary<string, environmentLoadedAssembliesClass> assembliesTypes;
            environmentLoadedAssembliesClass assemblyDetails;
            string fileName;
            string formName;

            // Add assembly
            assembliesTypes = new Dictionary<string, environmentLoadedAssembliesClass>();
            assemblyDetails = new environmentLoadedAssembliesClass();
            fileName = "settings.layout.widget.dll";
            formName = "lateralSettingsForm";
            assemblyDetails.assemblyFormName = formName;
            assemblyDetails.spaceName = "AeonLabs.PlugIns.SideBar.Settings";
            assemblyDetails.UID = "NPmPqPuuqlwPL6swalnnMSqKGCp6MTr9";
            assemblyDetails.positionX = null; // Nothing for default posX
            assemblyDetails.positionY = null; // Nothing for default poxY
            assemblyDetails.anchor = AnchorStyles.Left | AnchorStyles.Top;
            assemblyDetails.control = null;
            assembliesTypes.Add(formName, assemblyDetails);
            returnAssemblies.Add(fileName, assembliesTypes);
            // end of add assembly

            // RETURN ASSEMBLIES DICT list
            return returnAssemblies;
        }
    }
}