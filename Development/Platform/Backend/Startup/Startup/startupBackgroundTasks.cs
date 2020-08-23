using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using AeonLabs.Environment;
using AeonLabs.environmentLoading;
using AeonLabs.Network;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AeonLabs.StartUp
{
    public class startupBackgroundTasksClass
    {
        public environmentVarsCore state;
        private loadEnvironment _enVarsLoading;

        public loadEnvironment enVarsLoading
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _enVarsLoading;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_enVarsLoading != null)
                {
                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    _enVarsLoading.environmentDataLoadedCompleted -= enVarsLoading_environmentDataLoadedCompleted;
                }

                _enVarsLoading = value;
                if (_enVarsLoading != null)
                {
                    _enVarsLoading.environmentDataLoadedCompleted += enVarsLoading_environmentDataLoadedCompleted;
                }
            }
        }

        public event updatePrgressBarEventHandler updatePrgressBar;

        public delegate void updatePrgressBarEventHandler(object sender, int value);

        public event updateStatusMessageEventHandler updateStatusMessage;

        public delegate void updateStatusMessageEventHandler(object sender, string message);

        public event loginErrorEventHandler loginError;

        public delegate void loginErrorEventHandler(object sender, string message);

        public event startUpTasksCompletedEventHandler startUpTasksCompleted;

        public delegate void startUpTasksCompletedEventHandler(object sender, environmentVarsCore enVarsResult);

        private HttpDataPostData _loadLoginData;

        private HttpDataPostData loadLoginData
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _loadLoginData;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_loadLoginData != null)
                {
                    _loadLoginData.dataArrived -= loadLoginData_dataArrived;
                }

                _loadLoginData = value;
                if (_loadLoginData != null)
                {
                    _loadLoginData.dataArrived += loadLoginData_dataArrived;
                }
            }
        }

        private HttpDataPostData _loadCloudSettingsData;

        private HttpDataPostData loadCloudSettingsData
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _loadCloudSettingsData;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_loadCloudSettingsData != null)
                {
                    _loadCloudSettingsData.dataArrived -= loadCloudSettingsData_dataArrived;
                }

                _loadCloudSettingsData = value;
                if (_loadCloudSettingsData != null)
                {
                    _loadCloudSettingsData.dataArrived += loadCloudSettingsData_dataArrived;
                }
            }
        }

        private HttpDataGetData _sendCrashData;

        private HttpDataGetData sendCrashData
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _sendCrashData;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_sendCrashData != null)
                {
                    _sendCrashData.requestCompleted -= sendCrashData_requestCompleted;
                }

                _sendCrashData = value;
                if (_sendCrashData != null)
                {
                    _sendCrashData.requestCompleted += sendCrashData_requestCompleted;
                }
            }
        }

        private HttpDataGetData _loadUpdateStatusData;

        private HttpDataGetData loadUpdateStatusData
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _loadUpdateStatusData;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_loadUpdateStatusData != null)
                {
                }

                _loadUpdateStatusData = value;
                if (_loadUpdateStatusData != null)
                {
                }
            }
        }

        private HttpDataFilesDownload _getFiles;

        private HttpDataFilesDownload getFiles
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
                    _getFiles.dataArrived -= getFiles_dataArrived;
                    _getFiles.requestCompleted -= getfiles_requestCompleted;
                }

                _getFiles = value;
                if (_getFiles != null)
                {
                    _getFiles.dataArrived += getFiles_dataArrived;
                    _getFiles.requestCompleted += getfiles_requestCompleted;
                }
            }
        }

        private HttpDataFilesDownload _getUpdateFile;

        private HttpDataFilesDownload getUpdateFile
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _getUpdateFile;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_getUpdateFile != null)
                {
                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
                    _getUpdateFile.updateProgressStatistics -= getUpdateFile_updateProgressStatistics;
                    _getUpdateFile.dataArrived -= getUpdateFile_dataArrived;
                }

                _getUpdateFile = value;
                if (_getUpdateFile != null)
                {
                    _getUpdateFile.updateProgressStatistics += getUpdateFile_updateProgressStatistics;
                    _getUpdateFile.dataArrived += getUpdateFile_dataArrived;
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
                    _taskManager.tasksCompleted -= taskmanager_completed;
                }

                _taskManager = value;
                if (_taskManager != null)
                {
                    _taskManager.tasksCompleted += taskmanager_completed;
                }
            }
        }

        private List<string> dynamicAssembliesToLoad = new List<string>();
        private List<int> dynamicAssembliesToLoadIndex = new List<int>();
        private string cardId;
        private int LoadingCounter;
        private int LoadingCounterTotalTasks = 4;
        private Dictionary<string, string> programUpdateStatus;

        public startupBackgroundTasksClass(environmentVarsCore _enVars)
        {
            state = _enVars;
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void doLogin(string _cardId, string codeTxt)
        {
            cardId = _cardId;
            var vars = new Dictionary<string, string>();
            vars.Add("task", state.taskId["login"]);
            vars.Add("id", cardId);
            vars.Add("idkey", codeTxt);
            vars.Add("type", "unknown");
            loadLoginData = new HttpDataPostData(state);
            loadLoginData.initialize();
            loadLoginData.loadQueue(vars, null, null);
            loadLoginData.startRequest();
        }

        private void loadLoginData_dataArrived(object sender, string responseData, Dictionary<string, string> misc)
        {
            if (!ManagementNetwork.IsResponseOk(responseData))
            {
                loginError?.Invoke(this, ManagementNetwork.GetMessage(responseData));
                return;
            }

            dynamicAssembliesToLoad = new List<string>();
            try
            {
                var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseData);

                // USER CREDENTIALS
                state.userType = data["type"].ToString();
                state.userConnType = data["conntype"].ToString();
                state.username = data["username"].ToString();

                // USER PROFILE PHOTO
                if (data.ContainsKey("photo"))
                {
                    state.userPhoto = Conversions.ToString(data["photo"]);
                }

                // PROGRAM UPDATE STAUTS
                if (data.ContainsKey("status"))
                {
                    var jsonPuStatus = JsonConvert.DeserializeObject<Dictionary<string, object>>(data["status"].ToString());
                    programUpdateStatus.Add("version", jsonPuStatus["version"].ToString());
                    programUpdateStatus.Add("url", jsonPuStatus["url"].ToString());
                    programUpdateStatus.Add("changelog", jsonPuStatus["changelog"].ToString());
                    programUpdateStatus.Add("checksum", jsonPuStatus["checksum"].ToString());
                    programUpdateStatus.Add("mandatory", jsonPuStatus["mandatory"].ToString());
                }

                // LOAD DYNAMIC ASSEMBLIES
                if (data.ContainsKey("dlls") & state.customization.hasDynamicAssemblies)
                {
                    var DllsJson = JArray.Parse(data["dlls"].ToString());
                    for (int i = 0, loopTo = DllsJson.Count - 1; i <= loopTo; i++)
                        dynamicAssembliesToLoad.Add(DllsJson[i].ToString());
                }
            }
            catch (Exception ex)
            {
                state.successLogin = false;
                state.userId = "";
                // 'TODO message error
                loginError?.Invoke(this, "");
                return;
            }
            finally
            {
                state.userId = cardId;

                // TODO
                // add raise event here to load TOTP dialog for code verification
                // in case of needed to download dynamic assemblies outside the assemblies defined as static
                if (state.customization.hasDynamicAssemblies)
                {
                }
                else
                {
                    // only static assemblies
                    state.successLogin = true;
                }
            }

            // ÇONTINUE LOADING =========================================
            // 'DEFINE TASKS TO DO
            {
                var withBlock = taskManager;
                withBlock.registerTask("loadEnvironmentVarsFromCloud", Conversions.ToInteger(tasksManager.tasksManagerClass.TO_START));
                withBlock.registerTask("loadServerSettings", Conversions.ToInteger(tasksManager.tasksManagerClass.TO_START));
                withBlock.registerTask("sendCrashReports", Conversions.ToInteger(tasksManager.tasksManagerClass.TO_START));
                withBlock.registerTask("loadCloudFiles", Conversions.ToInteger(tasksManager.tasksManagerClass.TO_START));
                withBlock.registerTask("checkUpdates", Conversions.ToInteger(tasksManager.tasksManagerClass.TO_START));
            }

            taskManager.startListening();
            updatePrgressBar?.Invoke(this, 0);

            // Calculating number of tasks to do
            LoadingCounter = 0;
            var crashFile = new FileInfo(Path.Combine(state.basePath, "crash.log"));
            crashFile.Refresh();
            if (crashFile.Exists & state.SendDiagnosticData)
            {
                LoadingCounterTotalTasks = dynamicAssembliesToLoad.Count + state.authorizedFileTemplates.Count + 3;
            }
            else
            {
                LoadingCounterTotalTasks = dynamicAssembliesToLoad.Count + state.authorizedFileTemplates.Count + 2;
            }

            // ' in between load settings from cloud
            loadEnvironmentVarsFromCloud();
            loadServerSettings();
            sendCrashReports();
            loadCloudFiles();
            if (!My.MyProject.Application.Info.Version.ToString().Equals(programUpdateStatus["version"]) & programUpdateStatus["mandatory"].Equals("true"))
            {
                updateStatusMessage?.Invoke(this, "checking for updates ...");
                getUpdateFile = new HttpDataFilesDownload(state, state.customization.updateServerAddr);
                getUpdateFile.initialize();
                var vars = new Dictionary<string, string>();
                vars.Add("key", programUpdateStatus["checksum"]);
                getUpdateFile.loadQueue(vars, null, state.templatesPath);
                getUpdateFile.startRequest();
                taskManager.setStatus("checkUpdates", Conversions.ToInteger(tasksManager.tasksManagerClass.BUSY));
            }
        }

        private void getUpdateFile_updateProgressStatistics(object sender, HttpDataCore._data_statistics dataStatistics, Dictionary<string, string> misc)
        {
            updatePrgressBar?.Invoke(this, (int)(dataStatistics.bytesSentReceived / dataStatistics.filesize * 100));
        }

        private void getUpdateFile_dataArrived(object sender, string filenamePAth, Dictionary<string, string> misc)
        {
            try
            {
                var setupFile = new FileInfo(filenamePAth);
                setupFile.Refresh();
                if (setupFile.Exists)
                {
                    Process.Start(filenamePAth);
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                updateStatusMessage?.Invoke(this, "Error downloading update");
            }

            taskManager.setStatus("checkUpdates", Conversions.ToInteger(tasksManager.tasksManagerClass.FINISHED));
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void sendCrashReports()
        {
            taskManager.setStatus("checkUpdates", Conversions.ToInteger(tasksManager.tasksManagerClass.BUSY));

            // TODO: send encryped and auth crach reports plus add latency time on more
            var crashFile = new FileInfo(Path.Combine(state.basePath, "crash.log"));
            crashFile.Refresh();
            if (crashFile.Exists & state.SendDiagnosticData && BasicLibraries.FileManagementLib.FileInUse(Path.Combine(state.basePath, "crash.log")))
            {
                updateStatusMessage?.Invoke(this, "sending crash report data...");
                string report = My.MyProject.Computer.FileSystem.ReadAllText(Path.Combine(state.basePath, "crash.log"), System.Text.Encoding.UTF8);
                var logs = Strings.Split(report, "-------------end report---------------");
                sendCrashData = new HttpDataGetData(state, state.customization.crashReportServerAddr);
                sendCrashData.initialize();
                for (int i = 0, loopTo = logs.Length - 1; i <= loopTo; i++)
                {
                    if (logs[i].Replace(" ", "").Replace(System.Environment.NewLine, "").Equals(""))
                    {
                        continue;
                    }

                    var vars = new Dictionary<string, string>();
                    vars.Add("uuid", state.userId);
                    vars.Add("report", Uri.EscapeDataString(logs[i]));
                    sendCrashData.loadQueue(vars, null, state.libraryPath);
                }

                sendCrashData.startRequest();
            }
            else
            {
                taskManager.setStatus("checkUpdates", Conversions.ToInteger(tasksManager.tasksManagerClass.FINISHED));
            }
        }

        private void sendCrashData_requestCompleted(object sender, string responseData)
        {
            try
            {
                var crashFile = new FileInfo(Path.Combine(state.basePath, "crash.log"));
                crashFile.Refresh();
                crashFile.Delete();
            }
            catch (Exception ex)
            {
                updateStatusMessage?.Invoke(this, My.Resources.strings.errorDeletingData);
            }
            finally
            {
                updateStatusMessage?.Invoke(this, My.Resources.strings.crashDataSent);
            }

            LoadingCounter += 1;
            updatePrgressBar?.Invoke(this, (int)(LoadingCounter / (double)LoadingCounterTotalTasks * 100));
            taskManager.setStatus("checkUpdates", Conversions.ToInteger(tasksManager.tasksManagerClass.FINISHED));
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void loadCloudFiles()
        {
            taskManager.setStatus("loadCloudFiles", Conversions.ToInteger(tasksManager.tasksManagerClass.BUSY));
            LoadingCounter += 1;
            updatePrgressBar?.Invoke(this, (int)(LoadingCounter / (double)LoadingCounterTotalTasks * 100));
            updateStatusMessage?.Invoke(this, "Loading cloud settings...");

            // TODO review
            dynamicAssembliesToLoadIndex = new List<int>();
            bool found = false;
            for (int i = 0, loopTo = state.assemblies.Count - 1; i <= loopTo; i++)
            {
                found = false;
                for (int j = 0, loopTo1 = dynamicAssembliesToLoad.Count - 1; j <= loopTo1; j++)
                {
                    if (dynamicAssembliesToLoad.ElementAt(j).Equals(state.assemblies.ElementAt(i).Key))
                    {
                        dynamicAssembliesToLoadIndex.Add(i);
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    messageBoxForm msgbox;
                    msgbox = new messageBoxForm("Incorrect Dll files. You need to download and install the lastest version of the program at " + state.customization.websiteToLoadProgram, "exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    msgbox.ShowDialog();
                    taskManager.unload();
                    Application.Exit();
                    return;
                }
            }

            if (!Directory.Exists(state.tmpPath) | !Directory.Exists(state.libraryPath) | !Directory.Exists(state.templatesPath))
            {
                messageBoxForm msgbox;
                msgbox = new messageBoxForm("Folders not found. You need to download and install the lastest version of the program at " + state.customization.websiteToLoadProgram, "exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                msgbox.ShowDialog();
                Application.Exit();
                return;
            }

            var myDir = new DirectoryInfo(state.tmpPath);
            if (myDir.EnumerateFiles().Any())
            {
                try
                {
                    FileSystem.Kill(string.Format("{0}", state.tmpPath + "*.*"));
                }
                catch (Exception ex)
                {
                    messageBoxForm msgbox;
                    msgbox = new messageBoxForm("Unable do delete temporary files. Clear tmp folder and start the App again.", "exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    msgbox.ShowDialog();
                    Application.Exit();
                    return;
                }
            }

            myDir = new DirectoryInfo(state.templatesPath);
            if (myDir.EnumerateFiles().Any())
            {
                try
                {
                    FileSystem.Kill(string.Format("{0}", state.templatesPath + "*.*"));
                }
                catch (Exception ex)
                {
                    messageBoxForm msgbox;
                    msgbox = new messageBoxForm("Unable do delete templates files. Clear templates folder and start the App again.", "exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    msgbox.ShowDialog();
                    Application.Exit();
                    return;
                }
            }

            if (Directory.EnumerateFiles(state.libraryPath, "*.dll").Count() > 0)
            {
                try
                {
                    FileSystem.Kill(string.Format("{0}", state.libraryPath + "*.dll"));
                }
                catch (Exception ex)
                {
                    messageBoxForm msgbox;
                    msgbox = new messageBoxForm("Unable do delete dll files. Clear dll files in library folder and start the App again.", "exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    msgbox.ShowDialog();
                    taskManager.unload();
                    Application.Exit();
                    return;
                }
            }

            getFiles = new HttpDataFilesDownload(state);
            getFiles.initialize();
            // add DLLS to queue 
            for (int j = 0, loopTo2 = dynamicAssembliesToLoad.Count - 1; j <= loopTo2; j++)
            {
                var vars = new Dictionary<string, string>();
                vars.Add("task", "1100");
                vars.Add("file", dynamicAssembliesToLoad.ElementAt(j));
                getFiles.loadQueue(vars, null, state.libraryPath);
            }

            // add templates to queue
            if (state.authorizedFileTemplates is object)
            {
                var templates = state.authorizedFileTemplates;
                for (int j = 0, loopTo3 = templates.Count - 1; j <= loopTo3; j++)
                {
                    var vars = new Dictionary<string, string>();
                    vars.Add("task", "1050");
                    vars.Add("file", templates.ElementAt(j).Key);
                    getFiles.loadQueue(vars, null, state.templatesPath);
                }
            }

            getFiles.startRequest();
        }

        private void getFiles_dataArrived(object sender, string filenamePAth, Dictionary<string, string> misc)
        {
            updatePrgressBar?.Invoke(this, getFiles.CompletionPercentage);
            updateStatusMessage?.Invoke(this, getFiles.statusMessage);
        }

        private void getfiles_requestCompleted(object sender, string responseData)
        {
            try
            {
                // TODO review
                for (int i = 0, loopTo = state.assemblies.Count - 1; i <= loopTo; i++)
                {
                    var assembly = System.Reflection.Assembly.LoadFile(state.libraryPath + state.assemblies.ElementAt(i).Key);
                    state.assemblies[i.ToString()].Values.ElementAt(0).AssemblyObject = assembly.GetType(state.assemblies[i.ToString()].Values.ElementAt(0).spaceName);
                }
            }
            catch (Exception ex)
            {
                // TODO save crash report
                taskManager.unload();
                messageBoxForm msgbox;
                msgbox = new messageBoxForm("Error Loading libraries. You need to download and install the lastest version of the program at " + state.customization.websiteToLoadProgram, "exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                msgbox.ShowDialog();
                Application.Exit();
                return;
            }

            taskManager.setStatus("loadCloudFiles", Conversions.ToInteger(tasksManager.tasksManagerClass.FINISHED));
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void loadEnvironmentVarsFromCloud()
        {
            taskManager.setStatus("loadEnvironmentVarsFromCloud", Conversions.ToInteger(tasksManager.tasksManagerClass.BUSY));
            enVarsLoading = new loadEnvironment(state);
            enVarsLoading.loadAddons();
            // 'see result above
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void loadServerSettings()
        {
            taskManager.setStatus("loadServerSettings", Conversions.ToInteger(tasksManager.tasksManagerClass.BUSY));
            var vars = new Dictionary<string, string>();
            vars.Add("task", state.taskId["queries"]);
            vars.Add("request", "settings");
            loadCloudSettingsData = new HttpDataPostData(state);
            loadCloudSettingsData.initialize();
            loadCloudSettingsData.loadQueue(vars, null, null);
            loadCloudSettingsData.startRequest();
        }

        private void loadCloudSettingsData_dataArrived(object sender, string responseData, Dictionary<string, string> misc)
        {
            bool errorFlag = false;
            string errorMsg = "";
            if (!ManagementNetwork.IsResponseOk(responseData))
            {
                errorMsg = ManagementNetwork.GetMessage(responseData);
                errorFlag = true;
                goto Lastline;
            }

            Dictionary<string, List<string>> DBsettings;
            DBsettings = loadCloudSettingsData.ConvertDataToArray("settings", state.querySettingsFields, responseData);
            if (Information.IsNothing(DBsettings))
            {
                errorMsg = loadCloudSettingsData.errorMessage;
                errorFlag = true;
                goto Lastline;
            }

            state.maxWorkHoursDay = TimeSpan.Parse(DBsettings["work_hours"][0]);
            state.delayDaysValidationAttendance = Conversions.ToInteger(DBsettings["max_days_delay_validation"][0]);
            state.customization.businessname = DBsettings["company_name"][0];
        Lastline:
            ;
            if (errorFlag)
            {
                var MsgBox = new messageBoxForm(errorMsg + ". " + My.Resources.strings.tryAgain + " ?", My.Resources.strings.question, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (MsgBox.ShowDialog() == DialogResult.Yes)
                {
                    loadServerSettings();
                }
                else
                {
                    loginError?.Invoke(this, errorMsg);
                }

                return;
            }

            LoadingCounter += 1;
            updatePrgressBar?.Invoke(this, (int)(LoadingCounter / (double)LoadingCounterTotalTasks * 100));
            updateStatusMessage?.Invoke(this, "Loading cloud settings...done");
            taskManager.setStatus("loadServerSettings", Conversions.ToInteger(tasksManager.tasksManagerClass.FINISHED));
        }

        private void enVarsLoading_environmentDataLoadedCompleted(int task)
        {
            if (task.Equals(loadEnvironment.LOAD_ADDONS))
            {
                taskManager.setStatus("loadEnvironmentVarsFromCloud", Conversions.ToInteger(tasksManager.tasksManagerClass.FINISHED));
            }
        }

        private void taskmanager_completed(object sender)
        {
            startUpTasksCompleted?.Invoke(this, state);
        }
    }
}