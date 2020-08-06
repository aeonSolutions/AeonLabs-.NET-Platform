using System;
using System.Reflection;
using System.Windows.Forms;

namespace AeonLabs.BasicLibraries
{
    public static class DLLlibrary
    {
        public static Form GetFormByName(string FormName)
        {
            var T = Type.GetType(FormName, true, true);
            return (Form)Activator.CreateInstance(T);
        }

        public static object loadExternalAssembly(environmentVarsCore state, string dllFileName, string className)
        {
            try
            {
                string fullPath = state.libraryPath + dllFileName;
                var asm = Assembly.LoadFrom(fullPath);
                var myType = asm.GetType(asm.GetName().Name + "." + className);
                return Activator.CreateInstance(myType);
            }
            catch (Exception ex)
            {
                return null;
            }

            return null;
        }

        public static FormCustomized loadAssembly()
        {
            // TODO
            try
            {
                var assembly = Assembly.LoadFile("store.dll");
                var type = assembly.GetType("AeonLabs.storeMainForm");
                Form SetupForm = Activator.CreateInstance(type) as Form;
                var TypesOnAssemblies = SetupForm.GetType().GetProperty("TypesOnAssemblies");
                TypesOnAssemblies.SetValue(SetupForm, type);
                var enVarsSetup = SetupForm.GetType().GetProperty("ExternalLoadEnVars");
                enVarsSetup.SetValue(SetupForm, "");
                SetupForm.ShowDialog();
            }
            catch (Exception ex)
            {
            }

            return default;
        }

        public static FormCustomized loadFormFromAssembly(string fileName, string formName, environmentVarsCore enVars, environmentVarsCore.updateMainLayoutDelegate updateMainApp)
        {
            var formToLoad = enVars.assemblies(fileName).Item(formName).assemblyFormToLoad;
            PropertyInfo setEnVars = formToLoad.GetType().GetProperty("envars");
            setEnVars.SetValue(formToLoad, enVars);
            PropertyInfo setUpdateMainApp = formToLoad.GetType().GetProperty("updateMainApp");
            setUpdateMainApp.SetValue(formToLoad, updateMainApp);
            return formToLoad;
        }
    }
}