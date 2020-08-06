using System.IO;
using System.Runtime.CompilerServices;
using AeonLabs.Environment;
using AeonLabs.environmentLoading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public partial class loadingForm
{
    public loadingForm()
    {
        base.Load += loadingForm_Load;
        base.Shown += loadingForm_shown;
    }

    public loadingForm(environmentVarsCore _enVars)
    {
        base.Load += loadingForm_Load;
        base.Shown += loadingForm_shown;
        enVars = _enVars;

        // This call is required by the designer.
        InitializeComponent();
        // Add any initialization after the InitializeComponent() call.

    }

    public environmentVarsCore enVars { get; set; }

    private Network.HttpDataFilesDownload _getFiles;

    private Network.HttpDataFilesDownload getFiles
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _getFiles;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_getFiles != null)
            {
                _getFiles.requestCompleted -= getfiles_requestCompleted;
            }

            _getFiles = value;
            if (_getFiles != null)
            {
                _getFiles.requestCompleted += getfiles_requestCompleted;
            }
        }
    }

    private Network.HttpDataPostData _getUpdates;

    private Network.HttpDataPostData getUpdates
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _getUpdates;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_getUpdates != null)
            {
                /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                /* TODO ERROR: Skipped RegionDirectiveTrivia */
                _getUpdates.requestCompleted -= getUpdates_requestCompleted;
            }

            _getUpdates = value;
            if (_getUpdates != null)
            {
                _getUpdates.requestCompleted += getUpdates_requestCompleted;
            }
        }
    }

    private tasksManager.tasksManagerClass _taskManager;

    private tasksManager.tasksManagerClass taskManager
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _taskManager;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_taskManager != null)
            {
                /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                _taskManager.tasksCompleted -= taskmanager_completed;
            }

            _taskManager = value;
            if (_taskManager != null)
            {
                _taskManager.tasksCompleted += taskmanager_completed;
            }
        }
    }

    private void loadingForm_Load(global::System.Object sender, EventArgs e)
    {
        Label1.Text = My.Resources.strings.loading;
        ;
#error Cannot convert AssignmentStatementSyntax - see comment for details
        /* Cannot convert AssignmentStatementSyntax, System.InvalidCastException: Unable to cast object of type 'Microsoft.CodeAnalysis.CSharp.Syntax.EmptyStatementSyntax' to type 'Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax'.
           at ICSharpCode.CodeConverter.CSharp.MethodBodyExecutableStatementVisitor.<VisitAssignmentStatement>d__35.MoveNext()
        --- End of stack trace from previous location where exception was thrown ---
           at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
           at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
           at ICSharpCode.CodeConverter.CSharp.HoistedNodeStateVisitor.<AddLocalVariablesAsync>d__6.MoveNext()
        --- End of stack trace from previous location where exception was thrown ---
           at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
           at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
           at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<DefaultVisitInnerAsync>d__3.MoveNext()

        Input:
                Me.progressbar.Location = New Point(Me.Width / 2 - Me.progressbar.Width / 2, Me.Height / 2 - Me.progressbar.Height / 2)

         */
        ;
#error Cannot convert AssignmentStatementSyntax - see comment for details
        /* Cannot convert AssignmentStatementSyntax, System.InvalidCastException: Unable to cast object of type 'Microsoft.CodeAnalysis.CSharp.Syntax.EmptyStatementSyntax' to type 'Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax'.
           at ICSharpCode.CodeConverter.CSharp.MethodBodyExecutableStatementVisitor.<VisitAssignmentStatement>d__35.MoveNext()
        --- End of stack trace from previous location where exception was thrown ---
           at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
           at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
           at ICSharpCode.CodeConverter.CSharp.HoistedNodeStateVisitor.<AddLocalVariablesAsync>d__6.MoveNext()
        --- End of stack trace from previous location where exception was thrown ---
           at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
           at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
           at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<DefaultVisitInnerAsync>d__3.MoveNext()

        Input:
                Me.Label1.Location = New Point(Me.Width / 2 - Me.Label1.Width / 2, Me.progressbar.Location.Y + Me.progressbar.Height)

         */
        progressbar.Visible = false;
        taskManager = new tasksManager.tasksManagerClass();
    }

    private void loadingForm_shown(global::System.Object sender, EventArgs e)
    {
        FileInfo setupFile;
        setupFile = new FileInfo(Path.Combine(enVars.libraryPath, "custom.eon"));
        setupFile.Refresh();
        // LOAD SETUP FILE
        if (setupFile.Exists & enVars.customization.hasSetup)
        {
            // TODO
            // LOAD SETUP FILE
        }

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
                return;
            }
        }

        // check if local settings files exists 
        FileInfo settingsFile;
        settingsFile = new FileInfo(Path.Combine(enVars.libraryPath, "settings.eon"));
        settingsFile.Refresh();
        if (enVars.customization.hasLocalSettings & settingsFile.Exists)
        {
            // 'DEFINE TASKS TO DO
            {
                var withBlock = taskManager;
                withBlock.registerTask("loadLocalSettings", tasksManager.tasksManagerClass.TO_START);
                if (enVars.checkForUpdatesIsEnabled & enVars.userSettings.checkForUpdatesIsEnabled)
                {
                    withBlock.registerTask("checkUpdates", tasksManager.tasksManagerClass.TO_START);
                }

                withBlock.registerTask("checkPackages", tasksManager.tasksManagerClass.TO_START);
            }

            taskManager.startListening();

            // LOAD LOCAL SETTINGS
            loadLocalSettings();
            if (enVars.checkForUpdatesIsEnabled & enVars.userSettings.checkForUpdatesIsEnabled)
            {
                // CHECK CORE FILES UPDATES
                var dlVars = enVars;
                dlVars.ApiServerAddrPath = enVars.customization.updateServerAddr;
                getUpdates = new Network.HttpDataPostData(dlVars);
                getUpdates.initialize();
                // add DLLS to queue 
                global::System.Object vars = new Dictionary<string, string>();
                vars.Add("task", "update");
                getUpdates.loadQueue(vars, default, default);
                taskManager.setStatus("checkUpdates", tasksManager.tasksManagerClass.BUSY);
                getUpdates.startRequest();
            }

            // ÇHECK PACKAGES
            checkPackages();

            // ÇHECK PLUGINS
            checkPlugins();
        }
        else
        {
            // TODO review
            var temp = new environmentVarsCore();
            temp.layoutDesign.loadDefaults(enVars);
            this.Close();
        }
    }

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private void checkPlugins()
    {
    }
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private void checkPackages()
    {
        // check if there are packages installed 
        taskManager.setStatus("checkPackages", tasksManager.tasksManagerClass.BUSY);
        FileInfo setupFile;
        var di = new DirectoryInfo(Path.Combine(enVars.packagesPath));
        var packagesToDownloadAndSetup = new Dictionary<string, string>();
        var packagesToConfig = new Dictionary<string, string>();
        var packagesInstalled = new Dictionary<string, string>();
        foreach (var folder in di.GetDirectories)
        {
            DirectoryInfo addToPackToSDownloadAndSetup = default;
            DirectoryInfo addToPackToConfig = default;

            // check integrity of the package
            setupFile = new FileInfo(folder.FullName + @"config\settings.cfg");
            setupFile.Refresh();
            if (!setupFile.Exists)
            {
                addToPackToSDownloadAndSetup = folder;
            }
            else
            {
                // load package settings (cjeck if is valid setitngs file) and check integrity of package files
                // TODO
                // çheck for updates of the package
                // TODO
                if (enVars.packageUpdatesIsEnabled & enVars.userSettings.packageUpdatesIsenabled)
                {
                }
                // check configuration file
                setupFile = new FileInfo(folder.FullName + @"config\config.cfg");
                setupFile.Refresh();
                if (!setupFile.Exists)
                {
                    addToPackToConfig = folder;
                }
                else
                {
                    // load packages configurantion and check if is valid
                    // TODO
                }
            }

            if (addToPackToConfig is object)
            {
                packagesToConfig.Add(addToPackToConfig.Name, addToPackToConfig.FullName);
            }

            if (addToPackToSDownloadAndSetup is object)
            {
                packagesToDownloadAndSetup.Add(addToPackToSDownloadAndSetup.Name, addToPackToSDownloadAndSetup.FullName);
            }

            if (addToPackToConfig is null & addToPackToSDownloadAndSetup is null)
            {
                packagesInstalled.Add(folder.Name, folder.FullName);
            }
        }

        if (packagesToDownloadAndSetup.Count > 0)
        {
            messageBoxForm msgbox;
            msgbox = new messageBoxForm("There are corrupted packages. Do you want to reinstall again ? ", "qestion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msgbox.ShowDialog() == DialogResult.Yes)
            {
                // LOAD STORE
                try
                {
                    Reflection.Assembly assembly = Reflection.Assembly.LoadFile(enVars.libraryPath + "store.dll");
                    Type type = assembly.GetType("AeonLabs.storeMainForm");
                    Form SetupForm = Activator.CreateInstance(type) as Form;
                    Reflection.PropertyInfo TypesOnAssemblies = SetupForm.GetType().GetProperty("TypesOnAssemblies");
                    TypesOnAssemblies.SetValue(SetupForm, type);
                    Reflection.PropertyInfo enVarsSetup = SetupForm.GetType().GetProperty("ExternalLoadEnVars");
                    enVarsSetup.SetValue(SetupForm, enVars);
                    this.Hide();
                    SetupForm.ShowDialog();
                    taskManager.setStatus("downloadSetup", tasksManager.tasksManagerClass.FINISHED);
                    if (enVars.customization.hasLocalSettings)
                    {
                        loadLocalSettings();
                    }
                }
                catch (Exception ex)
                {
                    taskManager.unload();
                    msgbox = new messageBoxForm("Store error. You need to download and install the lastest version of the program at " + enVars.customization.websiteToLoadProgram, "exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    msgbox.ShowDialog();
                    Application.Exit();
                    return;
                }
            }
            else
            {
                // TODO delete corrupted packages

            }
        }

        taskManager.setStatus("checkPackages", tasksManager.tasksManagerClass.FINISHED);
    }

    private void getUpdates_requestCompleted(global::System.Object sender, global::System.String responseData)
    {
        try
        {
            global::System.Object jsonLatResult = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseData);
            if (jsonLatResult.ContainsKey("update"))
            {
                JArray Jupdates = JArray.Parse(jsonLatResult.Item("update").ToString);
                foreach (var Jupdate in Jupdates)
                {
                    var notif = new notificationsClass();
                    notif.title = Jupdate.Item("title");
                    notif.message = Jupdate.Item("message");
                    notif.autoTaskExecute = Jupdate.Item("autotask");
                    notif.status = NOTIFICATIONS_UNREADED;
                    enVars.notifications.Add(notif);
                }
            }
        }
        catch (Exception ex)
        {
        }

        taskManager.setStatus("checkUpdates", tasksManager.tasksManagerClass.FINISHED);
    }
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private void loadSetupfile()
    {
        progressbar.Bar1.Value = 0;
        progressbar.Visible = true;
        var dlVars = enVars;
        dlVars.ApiServerAddrPath = enVars.customization.updateServerAddr;
        getFiles = new Network.HttpDataFilesDownload(dlVars);
        getFiles.initialize();
        // add DLLS to queue 
        global::System.Object vars = new Dictionary<string, string>();
        vars.Add("task", "download");
        vars.Add("file", "setup.dll");
        getFiles.loadQueue(vars, default, enVars.libraryPath);
        taskManager.setStatus("downloadSetup", tasksManager.tasksManagerClass.BUSY);
        getFiles.startRequest();
    }

    private void updateProgressStatistics(global::System.Object sender, Network.HttpDataFilesDownload._data_statistics dataStatistics, Dictionary misc)
    {
        if (!this.IsHandleCreated)
        {
            return;
        }

        progressbar.Invoke(() =>
        {
            ;
#error Cannot convert AssignmentStatementSyntax - see comment for details
            /* Cannot convert AssignmentStatementSyntax, System.ArgumentNullException: Value cannot be null.
            Parameter name: destination
               at Microsoft.CodeAnalysis.VisualBasic.VisualBasicCompilation.ClassifyConversion(ITypeSymbol source, ITypeSymbol destination)
               at ICSharpCode.CodeConverter.CSharp.TypeConversionAnalyzer.TryAnalyzeCsConversion(ExpressionSyntax vbNode, ITypeSymbol csType, ITypeSymbol csConvertedType, Conversion vbConversion, ITypeSymbol vbConvertedType, ITypeSymbol vbType, VisualBasicCompilation vbCompilation, Boolean isConst, TypeConversionKind& typeConversionKind)
               at ICSharpCode.CodeConverter.CSharp.TypeConversionAnalyzer.AnalyzeConversion(ExpressionSyntax vbNode, Boolean alwaysExplicit, Boolean isConst, ITypeSymbol forceSourceType, ITypeSymbol forceTargetType)
               at ICSharpCode.CodeConverter.CSharp.TypeConversionAnalyzer.AddExplicitConversion(ExpressionSyntax vbNode, ExpressionSyntax csNode, Boolean addParenthesisIfNeeded, Boolean defaultToCast, Boolean isConst, ITypeSymbol forceSourceType, ITypeSymbol forceTargetType)
               at ICSharpCode.CodeConverter.CSharp.MethodBodyExecutableStatementVisitor.<VisitAssignmentStatement>d__35.MoveNext()
            --- End of stack trace from previous location where exception was thrown ---
               at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
               at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
               at ICSharpCode.CodeConverter.CSharp.HoistedNodeStateVisitor.<AddLocalVariablesAsync>d__6.MoveNext()
            --- End of stack trace from previous location where exception was thrown ---
               at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
               at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
               at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<DefaultVisitInnerAsync>d__3.MoveNext()

            Input:
                                           Me.progressbar.Bar1.Value = dataStatistics.bytesSentReceived / dataStatistics.filesize

             */
        });
    }

    private void getfiles_requestCompleted(global::System.Object sender, global::System.String responseData)
    {
        try
        {
            Reflection.Assembly assembly = Reflection.Assembly.LoadFile(enVars.libraryPath + "setup.dll");
            Type type = assembly.GetType("AeonLabs.setupWizardMainForm");
            Form SetupForm = Activator.CreateInstance(type) as Form;
            Reflection.PropertyInfo TypesOnAssemblies = SetupForm.GetType().GetProperty("TypesOnAssemblies");
            TypesOnAssemblies.SetValue(SetupForm, type);
            Reflection.PropertyInfo enVarsSetup = SetupForm.GetType().GetProperty("ExternalLoadEnVars");
            enVarsSetup.SetValue(SetupForm, enVars);
            this.Hide();
            SetupForm.ShowDialog();
            taskManager.setStatus("downloadSetup", tasksManager.tasksManagerClass.FINISHED);
            if (enVars.customization.hasLocalSettings)
            {
                loadLocalSettings();
            }
        }
        catch (Exception ex)
        {
            taskManager.unload();
            messageBoxForm msgbox;
            msgbox = new messageBoxForm("Setup error. You need to download and install the lastest version of the program at " + enVars.customization.websiteToLoadProgram, "exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            msgbox.ShowDialog();
            Application.Exit();
            return;
        }
    }
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private void loadLocalSettings()
    {
        taskManager.setStatus("loadLocalSettings", tasksManager.tasksManagerClass.BUSY);
        global::System.Object loadEnv = new loadEnvironment(enVars, loadEnvironment.LOAD_SETTINGS);
        enVars = loadEnv.GetEnviroment();
        if (!enVars.stateLoaded)
        {
            taskManager.unload();
            messageBoxForm msgbox;
            msgbox = new messageBoxForm("(2) You need to download and install the lastest version of the program at " + enVars.customization.websiteToLoadProgram, "exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            msgbox.ShowDialog();
            Application.Exit();
            return;
        }

        taskManager.setStatus("loadLocalSettings", tasksManager.tasksManagerClass.FINISHED);
    }

    private void taskmanager_completed(global::System.Object sender)
    {
        this.Close();
    }

    private void exitAppLink_LinkClicked(global::System.Object sender, LinkLabelLinkClickedEventArgs e)
    {
        Application.Exit();
    }
}