
Imports System.Globalization
Imports System.IO
Imports System.Reflection
Imports System.Runtime.Remoting
Imports AeonLabs
Imports AeonLabs.Environment
Imports AeonLabs.environmentLoading
Imports AeonLabs.Network
Imports AeonLabs.tasksManager
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Module main
#Region "variables, fields, ..."
    Public enVars As New environmentVarsCore
    Public updateMainApp As environmentVarsCore.updateMainLayoutDelegate

    Private WithEvents getUpdates As Network.HttpDataPostData
    Private WithEvents taskManager As tasksManager.tasksManagerClass

    Private waitForTasksToComplete As Boolean = True
    Private tasksCompletedSuccessfully As Boolean = False
#End Region


#Region "sub main"
    Public Sub main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        taskManager = New tasksManagerClass
        'Instantiating the delegate for update data from child forms
        updateMainApp = AddressOf updateMain

        'set customization option
        enVars.customization.hasCodedCustomizationSettings = True

        ''DEFINE TASKS TO DO
        With taskManager
            .registerTask("loadLocalSettings", tasksManager.tasksManagerClass.TO_START)
            If enVars.checkForUpdatesIsEnabled Then
                .registerTask("checkUpdates", tasksManager.tasksManagerClass.TO_START)
            End If
        End With
        taskManager.startListening()

        taskManager.setStatus("loadLocalSettings", tasksManager.tasksManagerClass.BUSY)

        'check for customization file
        If Not LoadCustomizationFile() Then
            Exit Sub
        End If

        ' check if local settings files exists 
        Dim settingsFile As FileInfo
        settingsFile = New FileInfo(Path.Combine(enVars.libraryPath, "settings.eon"))
        settingsFile.Refresh()

        If enVars.customization.hasLocalSettings And settingsFile.Exists Then
            'LOAD LOCAL SETTING
            loadLocalSettings()
        End If

        enVars.checkForUpdatesIsEnabled = False
        'CHECK CORE FILES UPDATES
        If enVars.checkForUpdatesIsEnabled And ManagementNetwork.IsOnline(enVars.customization.updateServerAddr) Then
            getUpdates = New Network.HttpDataPostData(enVars, enVars.customization.updateServerAddr)
            getUpdates.initialize()
            'add DLLS to queue 
            Dim vars = New Dictionary(Of String, String)
            vars.Add("task", "update")

            taskManager.setStatus("checkUpdates", tasksManager.tasksManagerClass.BUSY)

            getUpdates.loadQueue(vars, Nothing, Nothing)
            getUpdates.startRequest()
        Else
            taskManager.setStatus("checkUpdates", tasksManager.tasksManagerClass.FINISHED)
        End If

        'LOAD MAIN LAYOUT ASSEMBLY
        'TODO LOAD custom layut in alternative to default layout // if previous got error dont load cusom, load default
        ' check if local settings files exists 
        Dim layoutFile As FileInfo
        layoutFile = New FileInfo(enVars.basePath & enVars.customization.designLayoutAssemblyFileName)
        layoutFile.Refresh()
        If Not layoutFile.Exists Then
            Microsoft.VisualBasic.MsgBox("Layout file not found. You need to reinstall the program")
            Exit Sub
        End If
        Dim assembly As Reflection.Assembly = Nothing
        Try
            assembly = Reflection.Assembly.LoadFile(enVars.basePath & enVars.customization.designLayoutAssemblyFileName)
            Dim typeMainLayoutIni = assembly.[GetType](enVars.customization.designLayoutAssemblyNameSpace & ".initializeLayoutClass")
            Dim iniClass = Activator.CreateInstance(typeMainLayoutIni, True)
            Dim methodInfo = typeMainLayoutIni.GetMethod("AssembliesToLoadAtStart")
            enVars.assemblies = methodInfo.Invoke(iniClass, Nothing)
        Catch ex As Exception
            MsgBox("Error initializing main layout:" & ex.Message)
            Application.Exit()
            Exit Sub
        End Try

        'TODO REVIEW
        'LOAD CONFIG API CALL IDS
        loadAPItasksIDs()

        'LOAD CONFIG STATIC ASSEMBLIES 
        enVars.assemblies = enVars.assemblies.Union(AuthorizedAssemblies.loadStatic().Where(Function(k) Not enVars.assemblies.ContainsKey(k.Key))).ToDictionary(Function(k) k.Key, Function(v) v.Value)

        'TODO review LOAD CONFIG DYNAMIC ASSEMBLIES 
        'enVars.assemblies = AuthorizedAssemblies.loadDynamic()

        'LOAD CONFIG STATIC TEMPLATE FILES AUTHORIZED
        loadAuthorizedFileTemplates()

        'LOAD CONFIG MENU TREE
        Dim loadMenu As menuOptions = New menuOptions
        enVars = loadMenu.Load(enVars)

        taskManager.setStatus("loadLocalSettings", tasksManager.tasksManagerClass.FINISHED)

        'continues on getupdates hanndle / task manager completed
        While waitForTasksToComplete
        End While
        If Not tasksCompletedSuccessfully Then
            Exit Sub
        End If
        'load main layout form
        Dim typeMainLayout As Type = Nothing
        Dim mainForm As FormCustomized = Nothing
        Try
            assembly = Reflection.Assembly.LoadFile(enVars.basePath & enVars.customization.designLayoutAssemblyFileName)
            typeMainLayout = assembly.[GetType](enVars.customization.designLayoutAssemblyNameSpace & ".mainAppLayoutForm")
            mainForm = TryCast(Activator.CreateInstance(typeMainLayout, enVars), FormCustomized)
        Catch ex As Exception
            MsgBox("Error loading main layout:" & ex.Message)
            Application.Exit()
            Exit Sub
        End Try
        'start the main layout
        Application.Run(mainForm)
    End Sub
#End Region

#Region "load startup/splash form"
    Private Sub loadStartupForm()
        'to delete
        Dim dataUpdate As New updateMainAppClass
        dataUpdate.envars = enVars
        dataUpdate.envars.successLogin = True
        dataUpdate.updateTask = updateMainAppClass.UPDATE_LAYOUT
        updateMainApp.Invoke(Nothing, dataUpdate)
        Exit Sub

        'LOAD STARTUP & LOGIN DLG
        Dim layoutFile As FileInfo
        layoutFile = New FileInfo(enVars.basePath & enVars.customization.designStartupLayoutAssemblyFileName)
        layoutFile.Refresh()
        If Not layoutFile.Exists Then
            Microsoft.VisualBasic.MsgBox("Startup Layout file not found. You need to reinstall the program")
            Exit Sub
        End If
        Dim typeStartupLayout As Type = Nothing
        Dim startupLayout As FormCustomized = Nothing
        Dim assembly As Reflection.Assembly = Nothing
        Try
            assembly = Reflection.Assembly.LoadFile(enVars.basePath & enVars.customization.designStartupLayoutAssemblyFileName)
            typeStartupLayout = assembly.[GetType](enVars.customization.designLayoutAssemblyNameSpace & ".LayoutStartUpForm")
            startupLayout = TryCast(Activator.CreateInstance(typeStartupLayout, enVars, updateMainApp), FormCustomized)
        Catch ex As Exception
            MsgBox("Error loading main layout:" & ex.Message)
            Application.Exit()
            Exit Sub
        End Try

        'start the startup layout and waits for update answer from form
        Application.Run(startupLayout)
    End Sub
#End Region

#Region "update main and load main layout"
    Public Sub updateMain(sender As Object, ByRef updateContents As updateMainAppClass)
        enVars = updateContents.envars
        If Not enVars.successLogin And enVars.customization.hasLogin Then
            tasksCompletedSuccessfully = False
        Else
            tasksCompletedSuccessfully = True
        End If
        waitForTasksToComplete = False
    End Sub
#End Region

#Region "loadMainLayoutAssemblies"
    Private Sub loadMainLayoutAssemblies(load As Array)
        For indexA = 0 To load.Length - 1
            If load(indexA)(0).Equals("") Then
                Continue For
            End If
            Dim assembliesTypes As New Dictionary(Of String, environmentLoadedAssembliesClass)
            Dim assemblyDetails As New environmentLoadedAssembliesClass
            With assemblyDetails
                .assemblyFormName = load(indexA)(1)
                .spaceName = load(indexA)(2)
                .UID = load(indexA)(3)
            End With
            assembliesTypes.Add(load(indexA)(1), assemblyDetails)
            enVars.assemblies.Add(load(indexA)(0), assembliesTypes)
        Next
    End Sub

#End Region

#Region "Load Authorized file templates"
    Public Sub loadAuthorizedFileTemplates()
        Dim office As New Dictionary(Of String, String)

        office.Add("contract", "contrato.rtf")
        office.Add("destacamento", "destacamento.rtf")
        office.Add("act", "act.rtf")
        office.Add("ficha", "ficha.rtf")

        enVars.authorizedFileTemplates = office
    End Sub
#End Region

#Region "load API task IDs"
    Private Sub loadAPItasksIDs()
        Dim apiTasksSet = My.Resources.apiTasks.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, True, True)
        With enVars
            For Each task In apiTasksSet
                If Not task.value.Equals("") Then
                    .taskId.Add(task.value, task.key)
                End If
            Next
        End With
    End Sub
#End Region

    'TODO review JSON 
#Region "Get updates"
    Private Sub getUpdates_requestCompleted(sender As Object, responseData As String) Handles getUpdates.requestCompleted
        Try
            Dim jsonLatResult = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(responseData)
            If jsonLatResult.ContainsKey("update") Then
                Dim Jupdates As JArray = JArray.Parse(jsonLatResult.Item("update").ToString)
                For Each Jupdate In Jupdates
                    Dim notif As New notificationsClass
                    With notif
                        .title = Jupdate.Item("title")
                        .message = Jupdate.Item("message")
                        .autoTaskExecute = Jupdate.Item("autotask")
                        .status = NOTIFICATIONS_UNREADED
                    End With
                    enVars.notifications.Add(notif)
                Next Jupdate
            End If
        Catch ex As Exception

        End Try

        taskManager.setStatus("checkUpdates", tasksManager.tasksManagerClass.FINISHED)
    End Sub
#End Region

#Region "Load Local Settings"
    Private Sub loadLocalSettings()

        Dim loadEnv = New loadEnvironment(enVars, loadEnvironment.LOAD_SETTINGS)
        enVars = loadEnv.GetEnviroment()

        If Not enVars.stateLoaded Then
            taskManager.unload()
            Dim msgbox As messageBoxForm
            msgbox = New messageBoxForm("(2) You need to download and install the lastest version of the program at " & enVars.customization.websiteToLoadProgram, "exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            Application.Exit()
            Exit Sub
        End If
    End Sub
#End Region

#Region "load customization file"
    Private Function LoadCustomizationFile() As Boolean
        Dim custom = New FileInfo(enVars.libraryPath & "custom.eon")
        custom.Refresh()
        If custom.Exists And Not enVars.customization.hasCodedCustomizationSettings Then
            enVars.customization.loadCustomizationFile(enVars)
        ElseIf enVars.customization.hasCodedCustomizationSettings Then
            'LOAD Çustomizations coded in for the App
            enVars = setupCustomizationVariables(enVars)
        End If

        'check if program has an expire date
        If Not enVars.customization.expireDate.Equals("") Then
            Dim today As New MonthCalendar
            Dim oneYear As New MonthCalendar
            oneYear.SetDate(Date.ParseExact(enVars.customization.expireDate, "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo))
            If today.TodayDate > oneYear.SelectionStart Then 'APP EXPIRE DATE OVERDUE
                Dim msgbox As messageBoxForm
                msgbox = New messageBoxForm("You need to download and install the lastest version of the program at " & enVars.customization.websiteToLoadProgram, "exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                msgbox.ShowDialog()
                Application.Exit()
                Return False
            End If
        End If
        Return True
    End Function
#End Region

#Region "taskManager completed - continue loading program"
    Private Sub taskmanager_completed(sender As Object) Handles taskManager.tasksCompleted
        'TODO
        Dim bogusHasUpdate = False
        If bogusHasUpdate Then
            'TODO LOAD THE BLANK INTRO LOADING PANE to download updates
            Exit Sub
        Else
            loadStartupForm()
        End If
    End Sub
#End Region
End Module
