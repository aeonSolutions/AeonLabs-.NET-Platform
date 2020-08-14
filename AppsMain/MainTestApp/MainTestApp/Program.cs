using AeonLabs.Environment;
using AeonLabs.environmentLoading;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using System.Runtime.Loader;

namespace AeonLabs
{
    static class Program
    {

        #region Variables
        public static environmentVarsCore enVars;
        public static environmentVarsCore.updateMainLayoutDelegate updateMainApp;
        private static Network.HttpDataPostData _getUpdates;

        private static Network.HttpDataPostData getUpdates
        {
            get
            {
                return _getUpdates;
            }

            set
            {
                _getUpdates = value;
            }
        }

        private static global::System.Boolean waitForTasksToComplete = true;
        private static global::System.Boolean tasksCompletedSuccessfully = false;
        private static updateEnvironmentClass updateEnv = new updateEnvironmentClass();
        #endregion

        #region Main
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            enVars = new environmentVarsCore();

            // Instantiating the delegate for update data from child forms
            updateMainApp = updateMain;

            // set customization option
            enVars.customization.hasCodedCustomizationSettings = true;

            // check for customization file
            if (!LoadCustomizationFile())
            {
                return;
            }

            // check if local settings files exists 
            FileInfo settingsFile;
            settingsFile = new FileInfo(Path.Combine(enVars.libraryPath, "settings.eon"));
            settingsFile.Refresh();
            if (enVars.customization.hasLocalSettings & settingsFile.Exists)
            {
                // LOAD LOCAL SETTING
                loadLocalSettings();
            }

            // LOAD CONFIG MENU TREE
            var loadMenu = new menuOptions();
            enVars = loadMenu.Load(enVars);

            // TODO: LOAD USER DEFINED MENU TREE

            // Load assemblies across multiple locations
            var loadAssemblies = new assembliesToLoadClass();
            enVars = loadAssemblies.Load(enVars);
            // TODO: LOAD USER BOUGHT ASSEMBLIES (PACKAGES, WIDGETS, LAYOUTS)
            // loadUserAssemblies()

            // TODO REVIEW
            // LOAD CONFIG API CALL IDS
            loadAPItasksIDs();

            // LOAD CONFIG STATIC TEMPLATE FILES AUTHORIZED
            loadAuthorizedFileTemplates();

            // TODO: CHECK CORE FILES UPDATES
            // check if there are any downloaded core files to be updated

            // LOAD STARTUP FORM
            loadStartupForm();

            // LOAD MAIN LAYOUT ASSEMBLY
            EnvironmentAssembliesLoadClass AssembliesLoader = new EnvironmentAssembliesLoadClass(enVars);

            Type loadedType;
            FormCustomized mainForm;

            loadedType =  AssembliesLoader.LoadObjectTypeFromAssembly(enVars.customization.designLayoutCustomAssemblyFileName, enVars.customization.designLayoutCustomAssemblyNameSpace, "mainLayoutForm");
           if (loadedType is null)
            {
                 loadedType = AssembliesLoader.LoadObjectTypeFromAssembly(enVars.customization.designLayoutAssemblyFileName, enVars.customization.designLayoutAssemblyNameSpace, "mainLayoutForm");
                if (loadedType is null)
                {
                    MessageBox.Show("Error initializing main layout:");
                    Application.Exit();
                    return;
                }
            }
            mainForm = Activator.CreateInstance(loadedType, enVars) as FormCustomized;
            // start the main layout
            Application.Run(mainForm);

        }
        #endregion


        #region "load startup"
        private static void loadStartupForm()
        {
            // to delete
            var dataUpdate = new updateMainAppClass();
            dataUpdate.envars = enVars;
            dataUpdate.envars.successLogin = true;
            dataUpdate.updateTask = updateMainAppClass.UPDATE_LAYOUT;
            updateMainApp.Invoke(default, ref dataUpdate);
            return;

            // LOAD STARTUP & LOGIN DLG
            FileInfo layoutFile;
            layoutFile = new FileInfo(enVars.basePath + enVars.customization.designStartupLayoutAssemblyFileName);
            layoutFile.Refresh();
            if (!layoutFile.Exists)
            {
                MessageBox.Show("Startup Layout file not found. You need to reinstall the program");
                Application.Exit();
                return;
            }

            Type typeStartupLayout = default;
            FormCustomized startupLayout = default;
            System.Reflection.Assembly assembly = default;
            try
            {
                assembly = System.Reflection.Assembly.LoadFile(enVars.basePath + enVars.customization.designStartupLayoutAssemblyFileName);
                typeStartupLayout = assembly.GetType(enVars.customization.designLayoutAssemblyNameSpace + ".LayoutStartUpForm");
                startupLayout = Activator.CreateInstance(typeStartupLayout, enVars, updateMainApp) as FormCustomized;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading main layout:" + ex.Message);
                Application.Exit();
                return;
            }

            // start the startup layout and waits for update answer from form
            Application.Run(startupLayout);
        }
        #endregion

        #region "update main"
        public static void updateMain(global::System.Object sender, ref updateMainAppClass updateContents)
        {
            enVars = updateContents.envars;
            if (!enVars.successLogin & enVars.customization.hasLogin)
            {
                tasksCompletedSuccessfully = false;
            }
            else
            {
                tasksCompletedSuccessfully = true;
            }

            waitForTasksToComplete = false;
        }
        #endregion

        #region "load auth file templates"
        public static void loadAuthorizedFileTemplates()
        {
            var office = new Dictionary<string, string>();
            office.Add("contract", "contrato.rtf");
            office.Add("destacamento", "destacamento.rtf");
            office.Add("act", "act.rtf");
            office.Add("ficha", "ficha.rtf");
            enVars.authorizedFileTemplates = office;
        }
        #endregion

        #region "load API tasks ID"
        private static void loadAPItasksIDs()
        {
            ResourceManager apiTasksSet = new ResourceManager(Assembly.GetExecutingAssembly().EntryPoint.DeclaringType.Namespace + ".config.apiTasks", Assembly.GetExecutingAssembly());

            var withBlock = enVars;

            IDictionaryEnumerator dictNumerator = apiTasksSet.GetResourceSet(CultureInfo.CurrentCulture,true, true).GetEnumerator();

            while (dictNumerator.MoveNext())
            {
                    if (!dictNumerator.Value.Equals(""))
                    {
                        withBlock.taskId.Add(dictNumerator.Value.ToString(), dictNumerator.Key.ToString());
                    }
                }
        }
        #endregion

        #region "Load Local Settings"
        private static void loadLocalSettings()
        {
            loadEnvironment loadEnv = new loadEnvironment(enVars, loadEnvironment.LOAD_SETTINGS);
            enVars = loadEnv.GetEnviroment();
            if (!enVars.stateLoaded)
            {
                messageBoxForm msgbox;
                msgbox = new messageBoxForm("(2) You need to download and install the lastest version of the program at " + enVars.customization.websiteToLoadProgram, "exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                msgbox.ShowDialog();
                Application.Exit();
                return;
            }
        }
        #endregion

        #region "Load customization File"
        private static global::System.Boolean LoadCustomizationFile()
        {
            FileInfo custom = new FileInfo(enVars.libraryPath + "custom.eon");
            custom.Refresh();
            if (custom.Exists & !enVars.customization.hasCodedCustomizationSettings)
            {
                enVars.customization.loadCustomizationFile(enVars);
            }
            else if (enVars.customization.hasCodedCustomizationSettings)
            {
                // LOAD Çustomizations coded in for the App
                enVars = AppCustomization.setupCustomizationVariables(enVars);
            }

            // check if program has an expire date
            if (!enVars.customization.expireDate.Equals(""))
            {
                var today = new MonthCalendar();
                var oneYear = new MonthCalendar();
                oneYear.SetDate(DateTime.ParseExact(enVars.customization.expireDate, "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo));
                if (today.TodayDate > oneYear.SelectionStart) // APP EXPIRE DATE OVERDUE
                {
                    messageBoxForm msgbox;
                    msgbox = new messageBoxForm("You need to download and install the lastest version of the program at " + enVars.customization.websiteToLoadProgram, "exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    msgbox.ShowDialog();
                    Application.Exit();
                    return false;
                }
            }

            return true;
        }
        #endregion

    }
}
