
Imports System.Globalization
Imports System.IO
Imports AeonLabs
Imports AeonLabs.Environment
Imports AeonLabs.Environment.Assembly
Imports AeonLabs.Environment.Assembly.assemblyEnvironmentVarsClass
Imports AeonLabs.Layouts
Imports AeonLabs.Layouts.StartUp

Module main
    Public enVars As New environmentVarsCore

    Public Sub main()
        'set customization option
        enVars.customization.hasCodedCustomizationSettings = True

        'check for customization file
        Dim custom = New FileInfo(enVars.libraryPath & "custom.eon")
        custom.Refresh()
        If custom.Exists And Not enVars.customization.hasCodedCustomizationSettings Then
            enVars.customization.loadCustomizationFile(enVars)
        ElseIf enVars.customization.hasCodedCustomizationSettings Then
            'LOAD Çustomizations coded in for the App
            enVars = setupCustomizationVariables(enVars)
        End If

        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)

        'LOAD THE REQUIERED ASSEMBLY BY THE MAIN LAYOUT
        enVars.assemblies = mainAppLayoutForm.AssembliesToLoadAtStart()

        'LOAD THE BLANK INTRO PANE 
        Dim loading As New Loading.loadingForm(enVars)
        Application.Run(loading)
        If enVars.settingsLoaded Then
            enVars = loading.enVars

            'TODO REVIEW
            'LOAD CONFIG API CALL IDS
            loadAPItasksIDs()

            'LOAD CONFIG STATIC ASSEMBLIES 
            enVars.assemblies = AuthorizedAssemblies.loadStatic()

            'TODO review LOAD CONFIG DYNAMIC ASSEMBLIES 
            'enVars.assemblies = AuthorizedAssemblies.loadDynamic()

            'LOAD CONFIG STATIC TEMPLATE FILES AUTHORIZED
            loadAuthorizedFileTemplates()

            'LOAD CONFIG MENU TREE
            Dim loadMenu As menuOptions = New menuOptions
            enVars = loadMenu.Load(enVars)

            'LOAD STARTUP & LOGIN DLG
            Dim startupLayout As New LayoutStartUpForm(enVars)
            Application.Run(startupLayout)
            If Not enVars.successLogin Then
                Application.Exit()
                Exit Sub
            End If
            enVars = startupLayout.enVars
        Else
            enVars.layoutDesign.loadDefaults(enVars)
        End If

        'LOAD DEFAULT LAYOUT
        ''TODO LOAD custom layut in alternative to default layout // if previous got error dont load cusom, load default
        Dim mainLayout = New mainAppLayoutForm(enVars)
        Application.Run(mainLayout)
    End Sub

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

End Module
