using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Windows.Forms;

namespace AeonLabs.Environment.Core
{
    public class environmentAssembliesClass
    {
        public const int LAYOUT_PACKAGE = 1;
        public const int STARTUP_PACKAGE = 10;
        public const int REGULAR_PACKAGE = 100;
        public const int WIDGET = 200;
        public int packageType;
        public bool deleteOnExit;

        public string spaceName { get; set; }
        public string defaultClassName { get; set; }
        public string assemblyFileName { get; set; }

        public string friendlyUID { get; set; }
        public string UID { get; set; }
        
        public Type AssemblyObject { get; set; }        
        public FormCustomized assemblyFormToLoad { get; set; }
        public string assemblyFormName { get; set; }
 
        public int minWidth { get; set; }
        public int minHeight { get; set; }
        public int positionX { get; set; }
        public int positionY { get; set; }
        public Control control { get; set; }
        public AnchorStyles anchor { get; set; }
    }

    public class EnvironmentAssignedToControlClass
    {
        public int positionX { get; set; }
        public int positionY { get; set; }
        public Control control { get; set; }
        public AnchorStyles anchor { get; set; }
        public environmentAssembliesClass assembly { get; set; }
    }

    public class EnvironmentAssembliesLoadClass {
        public class CollectibleAssemblyLoadContext : AssemblyLoadContext
        {
            public CollectibleAssemblyLoadContext() : base(isCollectible: true)
            { }

            protected override Assembly Load(AssemblyName assemblyName)
            {
                return null;
            }
        }


        public Dictionary<string, CollectibleAssemblyLoadContext> context = new Dictionary<string, CollectibleAssemblyLoadContext>();
        
        public Dictionary<string, Environment.Core.environmentAssembliesClass> getAssemblies { get; set; }

        private Dictionary<string, Environment.Core.environmentAssembliesClass> enVarsAssemblies;
        private environmentVarsCore enVars;

        public EnvironmentAssembliesLoadClass(environmentVarsCore _enVars) {
            enVarsAssemblies = _enVars.assemblies;
            enVars = _enVars;
        }

        public string errorMessage {get; set;}

        #region Assign Control to assembly
        public Boolean assignControlAssembly(string friendlyName, Control ctrl) {
            bool err = false;
             errorMessage = "";

            if (enVars.assemblies.ContainsKey(friendlyName))
            {
                enVars.assemblies[friendlyName].control = ctrl;
            }
            else
            {
                errorMessage += friendlyName;
                err = true;
            }

            if (err) return false;

            return true;
        }
        #endregion

        #region load object from assembly - friendly
        public Type friendlyLoadTypeObjectFromAssembly(string friendlyName, string layoutNameSpace="", string classNameToLoad="") {
            if (layoutNameSpace.Equals("")) {
                layoutNameSpace = enVars.assemblies[friendlyName].spaceName;
            }
            if (classNameToLoad.Equals(""))
            {
                classNameToLoad = enVars.assemblies[friendlyName].assemblyFormName;
            }

            return LoadObjectTypeFromAssembly(enVars.assemblies[friendlyName].assemblyFileName, layoutNameSpace, classNameToLoad, friendlyName);
        }
        #endregion

        #region load Object from assembly
        
        public Type LoadObjectTypeFromAssembly(string layoutFilename, string layoutNameSpace, string classNameToLoad, string friendlyName="")
        {
            Type typeToLoad = default;
            FileInfo layoutFile;
            try
            {
                layoutFile = new FileInfo(enVars.libraryPath + layoutFilename);
                layoutFile.Refresh();
                if (!layoutFile.Exists)
                {
                    errorMessage="Layout file not found. You need to reinstall the program";
                    return null;
                }
            }
            catch (Exception ex){
                errorMessage = "Error Layout file (" + ex.Message.ToString() + "). You need to reinstall the program";
                return null;
            }

            if (friendlyName.Equals("")) {
                friendlyName = classNameToLoad;
            }

            try
            {
                System.Reflection.Assembly assemblyRaw = System.Reflection.Assembly.LoadFrom(enVars.libraryPath + layoutFilename);
                context.Add(friendlyName, new CollectibleAssemblyLoadContext());
                System.Reflection.Assembly assembly = context[friendlyName].LoadFromAssemblyPath(enVars.libraryPath + layoutFilename);

                // check if assembly has assemblies to load
                Type typeMainLayoutIni = assembly.GetType(layoutNameSpace + ".initializeAssembly");
                if (typeMainLayoutIni != null)
                {
                    Object iniClass = Activator.CreateInstance(typeMainLayoutIni, true);
                    MethodInfo methodInfo = typeMainLayoutIni.GetMethod("AssembliesToLoadAtStart");
                    if (methodInfo != null)
                    {
                        Dictionary<string, Environment.Core.environmentAssembliesClass> assembliesOn = (Dictionary<string, Environment.Core.environmentAssembliesClass>)methodInfo.Invoke(iniClass, default);
                        getAssemblies = enVarsAssemblies.Union(assembliesOn.Where(k => !enVarsAssemblies.ContainsKey(k.Key))).ToDictionary(k => k.Key, v => v.Value);
                    }
                }

                string t = "";
                foreach (Type type in assembly.GetTypes())
                {
                    t+=type.FullName + " >> ";
                }
                typeToLoad = assembly.GetType(layoutNameSpace + "." + classNameToLoad);
                if (typeToLoad is null) {
                    errorMessage = "Class not found or invalid namespace";
                }
            }

            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return null;
            }
            return typeToLoad;
        }
        #endregion

        #region unload assembly
        public bool unload(string friendlyName) {
            context[friendlyName].Unload();
            RunGarbageCollection();
            context.Remove(friendlyName);
            return true;
        }
        #endregion

        #region run garbage collection
        public static void RunGarbageCollection()
        {
            try
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            catch (System.Exception)
            {
                //sometimes GC.Collet/WaitForPendingFinalizers crashes, just ignore for this blog post
            }
        }
        #endregion

    }

}