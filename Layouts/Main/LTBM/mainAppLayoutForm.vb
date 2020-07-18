﻿Imports System.ComponentModel
Imports AeonLabs.Environment
Imports AeonLabs.Layout.Menu.Vertical
Imports AeonLabs.BasicLibraries

Public Class mainAppLayoutForm
    Inherits FormCustomized

#Region "SETUP LAYOUT"
#Region "REGISTER CONFIGURABLE LAYOUT CONTROLS"
    Private Sub registerConfigurableLayoutControls()
        'REGISTER CONFIGURABLE LAYOUT PANELS 
        registeredPanels.Add(panelLeftSide.Name)
        registeredPanels.Add(panelBottom.Name)
        registeredPanels.Add(panelTop.Name)
    End Sub
#End Region

#Region "assign control to assembly"
    Private Sub assignControlToAssembly()
        Dim err As Boolean = False
        Dim errMsg As String = ""

        If enVars.assemblies.ContainsKey("settings.layout.widget.dll") Then
            If enVars.assemblies("settings.layout.widget.dll").ContainsKey("lateralSettingsForm") Then
                enVars.assemblies("settings.layout.widget.dll").Item("lateralSettingsForm").control = panelMenuOptionsContainer
            Else
                errMsg &= "lateralSettingsForm"
                err = True
            End If
        Else
            errMsg &= "settings.layout.widget.dll"
            err = True
        End If

        If err Then
            Microsoft.VisualBasic.MsgBox("Error: assembly cound not be assigned a panel, " & errMsg)
            Me.Close()
            Exit Sub
        End If
    End Sub
#End Region

#Region "Layout settings"
    Private Const LATERAL_MENU_OPEN_WIDTH As Integer = 400

    'AssembliesToLoadAtStart = {({"Filename.Dll", "FormName", "NameSpace","UUID"}), ({"Filename.Dll", "FormName", "NameSpace","UUID"}), ({"Filename.Dll", "FormName", "NameSpace","UUID"}), ({"Filename.Dll", "FormName", "NameSpace","UUID"})}
    Public ReadOnly AssembliesToLoadAtStartOLD = {({"", "", "", ""}), ({"", "", "", ""}), ({"", "", "", ""}), ({"", "", "", ""})}



#End Region

#End Region

#Region "variables fields"
#Region "PUBLIC FIELDS"
    Public updateMainApp As environmentVarsCore.updateMainLayoutDelegate
    Public Property enVars As New environmentVarsCore
    Public Property statusMessage As String = ""
#End Region

#Region "PRIVATE FIELDS"
    'panel registered for layout color and background changes
    Private registeredPanels As New List(Of String)
    Private msgbox As messageBoxForm

    'STATUS MESSAGE 
    Private statusMessageLast As String = ""
    Private statusMessageTimeout As Integer = 10
    Private statusMessagePile As New List(Of String)
    Private WithEvents StatusMessagesDisplayTime As Timer
    Private WithEvents UpdateStatusMessageTimer As Timer

    'TOOLTIPS
    Private settingsToolTip As New ToolTip()
    Private menuToggleToolTip As New ToolTip()

    'CHANGE BACKGROUND IMAGE
    Private WithEvents ChangeBackgroundTimer As Timer
    Private WithEvents bwChangeBackground As New BackgroundWorker

#End Region


    Public CurrentWrapperForm As Form
    Public LoadedFrm As Form
    Public loaded As Boolean = False

    Private BusyMenuOption As Boolean = False

    Public Property usernamePhoto As PictureBox = Nothing


    Private eDelta As Integer
    Private Sensitivity As Integer = 20
#End Region

#Region "constructors"
    Public Sub InitializeForm(_envars As environmentVarsCore)
        If _envars IsNot Nothing Then
            enVars = _envars
        End If
        enVars.layoutDesign.menu.properties.ClosedStateSize = LATERAL_MENU_OPEN_WIDTH

        'ASSIGN ASSEMBLIES TO PANELS
        assignControlToAssembly()
    End Sub

    Public Sub New()
        Application.AddMessageFilter(Me)

        ' This call is required by the designer.
        Me.SuspendLayout()
        InitializeComponent()

        'Instantiating the delegate for update data from child forms
        updateMainApp = AddressOf updateMainAppLayout

        'Me.InactivityTimeOut = enVars.AutomaticLogoutTime

        Me.Visible = False
        Me.Opacity = 0
        Me.Refresh()

        registerConfigurableLayoutControls()
        addToolTips()

        Me.ResumeLayout()
        '' needs to be the last 
        If Not Me.IsDisposed Then
            Me.Show()
        End If
    End Sub
#End Region

#Region "TOOLTIPS"
    Private Sub addToolTips()
        'ADD TOOLTIPS 
        Dim menuToggleToolTip As New ToolTip()
        menuToggleToolTip.SetToolTip(menuIconPic, My.Resources.strings.MenuToggle)

        Dim settingsToolTip As New ToolTip()
        settingsToolTip.SetToolTip(iconMenuSettings, My.Resources.strings.settingsToggle)
    End Sub
#End Region

#Region "update environment and layout"
    Public Sub updateMainAppLayout(sender As Object, ByRef updateContents As updateMainAppClass)
        enVars = updateContents.envars

        If updateContents.updateTask.Equals(updateMainAppClass.UPDATE_LAYOUT) Then
            SuspendLayout()
            updateBkColorAndTransparency(Me, False, False)
            ResumeLayout()
            Refresh()
        ElseIf updateContents.updateTask.Equals(updateMainAppClass.UPDATE_LAYOUT_BACKGROUND) Then
            SuspendLayout()
            Me.BackgroundImage = Image.FromFile(updateContents.backGroundFileName)
            Me.BackgroundImageLayout = ImageLayout.Stretch

            updateBkImageOnChildForms(Me, False, Nothing)
            ResumeLayout()
            Refresh()
        ElseIf updateContents.updateTask.Equals(updateMainAppClass.UPDATE_ENVIRONMENT_VARS) Then
            'REDUNDANT ...
        End If
    End Sub

    Private Sub updateBkColorAndTransparency(ByVal ctrlContainer As Control, isOnChildren As Boolean, isOnForm As Boolean)
        For Each ctrl As Control In ctrlContainer.Controls
            Dim t = ctrl.Name
            Dim typ = ctrl.GetType

            If TypeOf ctrl Is PanelDoubleBuffer And Not isOnChildren Then
                If registeredPanels.Contains(ctrl.Name.ToString) Then
                    ctrl.BackColor = Color.FromArgb(enVars.layoutDesign.PanelTransparencyIndex, enVars.layoutDesign.PanelBackColor)
                    If ctrl.HasChildren Then
                        updateBkColorAndTransparency(ctrl, True, False)
                    End If
                End If
            ElseIf (TypeOf ctrl Is FormCustomized Or TypeOf ctrl Is Form) And isOnChildren Then
                updateBkColorAndTransparency(ctrl, True, True)
            ElseIf TypeOf ctrl Is PanelDoubleBuffer And isOnChildren And isOnForm Then
                ctrl.BackColor = Color.FromArgb(enVars.layoutDesign.PanelTransparencyIndex, enVars.layoutDesign.PanelBackColor)
            ElseIf TypeOf ctrl Is PanelDoubleBuffer And isOnChildren And ctrl.HasChildren Then
                updateBkColorAndTransparency(ctrl, True, False)
            End If
        Next
    End Sub

    Private Sub updateBkImageOnChildForms(ByVal ctrlContainer As Control, isOnChildren As Boolean, panelHost As PanelDoubleBuffer)
        For Each ctrl As Control In ctrlContainer.Controls
            Dim t = ctrl.Name
            Dim typ = ctrl.GetType

            If TypeOf ctrl Is PanelDoubleBuffer Then
                If ctrl.HasChildren Then
                    updateBkImageOnChildForms(ctrl, True, ctrl)
                End If
            ElseIf (TypeOf ctrl Is FormCustomized Or TypeOf ctrl Is Form) And isOnChildren Then
                ctrl.BackgroundImage = cropImage(Me.BackgroundImage, panelHost.Location, panelHost.Size, Me.Size)
                ctrl.BackgroundImageLayout = ImageLayout.Stretch
            End If
        Next
    End Sub
#End Region

#Region "form events"
    Private Sub MyForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Application.RemoveMessageFilter(Me)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form1_shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        SuspendLayout()

        loaded = False

        panelLeftSide.Parent = Me
        panelLeftSide.Width = enVars.layoutDesign.menu.properties.ClosedStateSize
        panelLeftSide.BackColor = Color.Transparent

        panelMenuOptionsContainer.Parent = panelLeftSide
        panelMenuOptionsContainer.Height = 0

        panelSideMenuContainer.Parent = panelLeftSide
        'hack to hide the scrool bars
        panelSideMenuContainer.Dock = DockStyle.None
        panelSideMenuContainer.Width = panelLeftSide.Width + 30
        panelSideMenuContainer.Height = panelLeftSide.Height

        'TOP OPTIONS ON SIDE PANEL
        panelMenuOptions.Parent = panelLeftSide
        'lateralPanelMenuOptions.BackColor = Color.FromArgb(50, Color.Red)

        menuIconPic.Parent = panelMenuOptions
        menuIconPic.BackColor = Color.Transparent
        menuIconPic.Width = enVars.layoutDesign.MENU_CLOSED_STATE - 3
        menuIconPic.Height = enVars.layoutDesign.MENU_CLOSED_STATE - 3

        iconMenuSettings.Parent = panelMenuOptions
        iconMenuSettings.BackColor = Color.Transparent

        'TOP PANEL
        panelTop.Parent = Me

        'BOTTOM PANEL
        panelBottom.Parent = Me

        statusText.Parent = panelBottom
        statusText.BackColor = Color.Transparent
        statusMessage = "status message test"

        updateBkColorAndTransparency(Me, False, False)



        Dim menuBuilder As MenuVerticalClass = New MenuVerticalClass(Me, enVars)
        panelSideMenuContainer.Controls.Add(menuBuilder.buildMenu())
        enVars = menuBuilder.enVars

        MenuUpdate(False)

        ResumeLayout()
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.IsDisposed Then
            Exit Sub
        End If
        If IsNothing(enVars) Then
            Exit Sub
        End If
        If (WindowState.Equals(FormWindowState.Maximized) Or WindowState.Equals(FormWindowState.Normal)) And enVars.successLogin.Equals(False) And loaded Then
            doLogin()
        End If

        If (WindowState = FormWindowState.Minimized) And loaded Then
            SuspendLayout()
            Me.WindowState = FormWindowState.Minimized
            ResumeLayout()
        ElseIf loaded Then
            'FormRedraw.Enabled = True
        End If

        If Not WindowState = FormWindowState.Maximized OrElse Not WindowState = FormWindowState.Minimized Then
            mbDoPaintBackground = True
            SuspendLayout()
            updateBkImageOnChildForms(Me, False, Nothing)
            ResumeLayout()
            Refresh()
        End If
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        Threading.Thread.CurrentThread.CurrentUICulture = Globalization.CultureInfo.GetCultureInfo(enVars.currentLang)

        msgbox = New messageBoxForm(My.Resources.strings.exitApp & " ?", My.Resources.strings.question, MessageBoxButtons.YesNo, MessageBoxIcon.Question, Me.Location.X + (Me.Width / 2), Me.Location.Y + Me.Height / 2, enVars)
        If msgbox.ShowDialog = MsgBoxResult.No Then
            e.Cancel = True
        End If
    End Sub
#End Region

#Region "mouse motion"
    Private Sub menuPanelLateral_mouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        doLPanelLateralScrool(sender, e)
    End Sub


    Private Sub Form1_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel

        Exit Sub


        eDelta = e.Delta
        Dim ctrlIni As Control = Me.GetChildAtPoint(New Drawing.Point(e.X, e.Y))

        Dim menuPanel As Panel = Nothing
        If TypeOf ctrlIni Is Panel Then
            Dim ctrl As Panel = CType(ctrlIni, Panel)
            If ctrl.Name.Equals("panelLateral") Then
                menuPanel = ctrl
            ElseIf ctrl.Parent.Parent IsNot Nothing Then
                If ctrl.Parent.Parent.Name.Equals("panelLateral") Then
                    menuPanel = ctrl.Parent
                End If
            End If
        End If

        If TypeOf ctrlIni Is LabelDoubleBuffer Then
            Dim ctrl As LabelDoubleBuffer = CType(ctrlIni, LabelDoubleBuffer)
            If ctrl.Parent.Parent IsNot Nothing Then
                If ctrl.Parent.Parent.Name.Equals("panelLateral") Then
                    menuPanel = ctrl.Parent
                End If
            End If
        End If
        If TypeOf ctrlIni Is PictureBox Then
            Dim ctrl As PictureBox = CType(ctrlIni, PictureBox)
            If ctrl.Parent.Parent IsNot Nothing Then
                If ctrl.Parent.Parent.Name.Equals("panelLateral") Then
                    menuPanel = ctrl.Parent
                End If
            End If
        End If

        If menuPanel Is Nothing Then
            Exit Sub
        End If


        If menuPanel.Name.Equals("panelLateral") Then

            Dim vScrollPosition As Integer = VScroll 'panelLateral.VerticalScroll.Value
            vScrollPosition -= Math.Sign(eDelta) * Sensitivity
            vScrollPosition = Math.Max(0, vScrollPosition)
            vScrollPosition = Math.Min(vScrollPosition, panelSideMenuContainer.VerticalScroll.Maximum)
            If Not vScrollPosition.Equals(panelSideMenuContainer.VerticalScroll.Value) Then
                panelSideMenuContainer.SuspendLayout()
                panelSideMenuContainer.AutoScroll = True
                panelSideMenuContainer.VerticalScroll.Enabled = True
                panelSideMenuContainer.VerticalScroll.Value = vScrollPosition
                panelSideMenuContainer.AutoScrollPosition = New Point(panelSideMenuContainer.AutoScrollPosition.X,
                         vScrollPosition)
                panelSideMenuContainer.AutoScroll = False
                panelSideMenuContainer.ResumeLayout()
                VScroll = vScrollPosition
            End If
            statusMessage = "VSCROOL: " & vScrollPosition & "      Previous:" & panelSideMenuContainer.VerticalScroll.Value
        End If

    End Sub
    Private Sub doLPanelLateralScrool(sender As Object, e As System.Windows.Forms.MouseEventArgs)

        If panelSideMenuContainer.Bounds.Contains(e.Location) Then
            Dim vScrollPosition As Integer = VScroll 'panelLateral.VerticalScroll.Value
            vScrollPosition -= Math.Sign(e.Delta) * Sensitivity
            vScrollPosition = Math.Max(0, vScrollPosition)
            vScrollPosition = Math.Min(vScrollPosition, panelSideMenuContainer.VerticalScroll.Maximum)
            If Not vScrollPosition.Equals(panelSideMenuContainer.VerticalScroll.Value) Then
                panelSideMenuContainer.SuspendLayout()
                panelSideMenuContainer.AutoScroll = True

                panelSideMenuContainer.AutoScrollPosition = New Point(panelSideMenuContainer.AutoScrollPosition.X,
                                  vScrollPosition)
                panelSideMenuContainer.AutoScroll = False
                panelSideMenuContainer.ResumeLayout()
                VScroll = vScrollPosition
            End If
            statusMessage = "VSCROOL: " & vScrollPosition & "      Previous:" & panelSideMenuContainer.VerticalScroll.Value
        End If
    End Sub
#End Region

#Region "App main menu"
    Private Sub menuPanel_Click(sender As Object, e As EventArgs)
        Dim menukey As String = ""
        Dim subMenuPos As Integer = 0

        Dim menuPanel As Panel = Nothing
        If TypeOf sender Is Panel Then
            Dim ctrl As Panel = CType(sender, Panel)
            If Not ctrl.Name.Equals("panelLateral") Then
                menuPanel = ctrl
            ElseIf ctrl.Parent IsNot Nothing Then
                If ctrl.Parent.Parent.Name.Equals("panelLateral") Then
                    menuPanel = ctrl.Parent
                End If
            End If
        End If

        If TypeOf sender Is LabelDoubleBuffer Then
            Dim ctrl As LabelDoubleBuffer = CType(sender, LabelDoubleBuffer)
            menuPanel = ctrl.Parent
        End If

        If TypeOf sender Is PictureBox Then 'menu icon
            Dim ctrl As PictureBox = CType(sender, PictureBox)
            menuPanel = ctrl.Parent

            menukey = menuPanel.Name.Substring(0, menuPanel.Name.IndexOf("-"))
            subMenuPos = CInt(menuPanel.Name.Substring(menuPanel.Name.IndexOf("-") + 1))

            If panelLeftSide.Width.Equals(enVars.layoutDesign.MENU_OPEN_STATE) Then '' its open the lateral bar
                If enVars.layoutDesign.menu.items.ElementAt(subMenuPos).isOpen.Equals(False) Then '' menu is closed
                    enVars.layoutDesign.menu.items.ElementAt(subMenuPos).isOpen = True
                    MenuUpdate(True)
                Else
                    doMenuAnimmation("main")
                End If
            Else
                MenuUpdate(True)
            End If
            Exit Sub
        End If

        ''is the submenu wrapper panel ?
        If menuPanel.Name.IndexOf("-") > -1 Then
            menukey = menuPanel.Name.Substring(0, menuPanel.Name.IndexOf("-"))
            subMenuPos = CInt(menuPanel.Name.Substring(menuPanel.Name.IndexOf("-") + 1))
        Else
            menukey = menuPanel.Name
            subMenuPos = 0
        End If

        ''no content to load and is also menu title
        If enVars.layoutDesign.menu.items.ElementAt(subMenuPos).formWithContentsToLoad Is Nothing And subMenuPos.Equals(0) Then
            enVars.layoutDesign.menu.items.ElementAt(subMenuPos).isOpen = Not enVars.layoutDesign.menu.items.ElementAt(subMenuPos).isOpen
            ''leave lateral pane open
            MenuUpdate(True)
        End If

        If enVars.layoutDesign.menu.items.ElementAt(subMenuPos).formWithContentsToLoad IsNot Nothing Then
            MenuUpdate(False)

            If enVars.layoutDesign.menu.items.ElementAt(subMenuPos).showAsDialog Then
                enVars.layoutDesign.menu.items.ElementAt(subMenuPos).formWithContentsToLoad.ShowDialog()
            Else
                CurrentWrapperForm = enVars.layoutDesign.menu.items.ElementAt(subMenuPos).formWithContentsToLoad
                With CurrentWrapperForm
                    .TopLevel = False
                    .AutoSize = False
                End With

                CurrentWrapperForm.Size = panelMain.Size
                CurrentWrapperForm.Dock = DockStyle.Fill
                panelMain.Controls.Add(CurrentWrapperForm)
                CurrentWrapperForm.Show()
            End If
        End If
    End Sub

    Private Sub menuPanelExpand_click(sender As Object, e As EventArgs)
        Dim menuPanel As Panel = Nothing
        If TypeOf sender Is Panel Then
            Dim ctrl As Panel = CType(sender, Panel)
            menuPanel = ctrl.Parent
        End If
        If TypeOf sender Is LabelDoubleBuffer Then
            Dim ctrl As LabelDoubleBuffer = CType(sender, LabelDoubleBuffer)
            menuPanel = ctrl.Parent
        End If
        If TypeOf sender Is PictureBox Then
            Dim ctrl As PictureBox = CType(sender, PictureBox)
            menuPanel = ctrl.Parent
        End If

        Dim menuKey As String = menuPanel.Name.Substring(0, menuPanel.Name.IndexOf("-"))
        Dim submenuPos As Integer = CInt(menuPanel.Name.Substring(menuPanel.Name.IndexOf("-") + 1))

        If submenuPos.Equals(0) Then
            enVars.layoutDesign.menu.items.ElementAt(submenuPos).isOpen = Not enVars.layoutDesign.menu.items.ElementAt(submenuPos).isOpen
            MenuUpdate(True)
            Exit Sub
        End If

        Dim menuState As Boolean = True
        If enVars.layoutDesign.menu.items.ElementAt(0).menuWrapperPanel.Width.Equals(enVars.layoutDesign.MENU_OPEN_STATE) Then
            menuState = False
        End If

    End Sub

    Private Sub menuPanelNotifications_click(sender As Object, e As EventArgs)

    End Sub

    Public Sub doMenuAnimmation(origin As String)
        If (panelLeftSide.Width.Equals(enVars.layoutDesign.MENU_OPEN_STATE)) Then '' is open 
            MenuItemStateReset(False)
            MenuUpdate(False)
        ElseIf origin.Equals("main") Then
            MenuUpdate(True)
        End If
    End Sub

    Private Sub MenuUpdate(menuState As Boolean)
        panelSideMenuContainer.SuspendLayout()
        Dim menuPosX As Integer = 0
        Dim menuPosY As Integer = 0

        If menuState.Equals(True) Then
            panelLeftSide.Width = enVars.layoutDesign.MENU_OPEN_STATE
            menuIconPic.Location = New Point(panelLeftSide.Width - menuIconPic.Width - 3 - 10, menuIconPic.Location.Y)
        Else
            panelLeftSide.Width = enVars.layoutDesign.MENU_CLOSED_STATE
            menuIconPic.Location = New Point(5, menuIconPic.Location.Y)
        End If


        For i = 0 To enVars.layoutDesign.menu.items.Count - 1
            ''do opeing / closing of menu
            If enVars.layoutDesign.menu.items.ElementAt(i).isOpen Then
                With enVars.layoutDesign.menu.items.ElementAt(i).iconPicHolder(1)
                    .Image = Image.FromFile(enVars.imagesPath & "uparrow.png")
                    .SizeMode = PictureBoxSizeMode.StretchImage
                End With
                enVars.layoutDesign.menu.items.ElementAt(i).menuWrapperPanel.Height = enVars.layoutDesign.menu.items.ElementAt(i).menuWrapperOpenHeight
            Else
                With enVars.layoutDesign.menu.items.ElementAt(i).iconPicHolder(1)
                    .Image = Image.FromFile(enVars.imagesPath & "downarrow.png")
                    .SizeMode = PictureBoxSizeMode.StretchImage
                End With
                enVars.layoutDesign.menu.items.ElementAt(i).menuWrapperPanel.Height = enVars.layoutDesign.menu.properties.height
            End If
            If menuState.Equals(True) Then
                enVars.layoutDesign.menu.items.ElementAt(i).menuWrapperPanel.Width = enVars.layoutDesign.MENU_OPEN_STATE
            Else
                enVars.layoutDesign.menu.items.ElementAt(i).menuWrapperPanel.Width = enVars.layoutDesign.MENU_CLOSED_STATE
            End If
            enVars.layoutDesign.menu.items.ElementAt(i).menuWrapperPanel.Location = New Point(enVars.layoutDesign.menu.items.ElementAt(i).menuWrapperPanel.Location.X, menuPosY)
            menuPosY = menuPosY + enVars.layoutDesign.menu.items.ElementAt(i).menuWrapperPanel.Height + 1
        Next i

        panelSideMenuContainer.ResumeLayout()
    End Sub

    Private Sub MenuItemStateReset(menuState As Boolean)
        For i = 0 To enVars.layoutDesign.menu.items.Count - 1
            enVars.layoutDesign.menu.items.ElementAt(i).isOpen = menuState
        Next i
    End Sub
#End Region

#Region "Status Message"
    Private Sub UpdateStatusMessageTimer_Tick(sender As Object, e As EventArgs) Handles UpdateStatusMessageTimer.Tick
        If Not statusMessage.Equals(statusText.Text) Then
            If StatusMessagesDisplayTime.Enabled.Equals(False) Then
                StatusMessagesDisplayTime.Enabled = True
            End If
            If statusMessageTimeout >= 5 Then
                statusText.Text = statusMessage
                statusMessageTimeout = 0
            Else
                statusMessagePile.Add(statusMessage)
            End If
        End If
    End Sub

    Private Sub StatusMessagesDisplayTime_Tick(sender As Object, e As EventArgs) Handles StatusMessagesDisplayTime.Tick
        statusMessageTimeout += 1
        If statusMessageTimeout.Equals(5) Then
            If statusMessagePile.Count > 0 Then
                statusMessage = statusMessagePile.ElementAt(0)
                statusMessagePile.RemoveAt(0)
            End If
        End If
    End Sub
#End Region

#Region "selction clicks"
    Private Sub panelLateral_Click(sender As Object, e As EventArgs) Handles panelSideMenuContainer.Click, panelSideMenuContainer.Click
        If (panelLeftSide.Width.Equals(enVars.layoutDesign.MENU_OPEN_STATE)) Then '' is open 
            MenuUpdate(False)
        Else
            MenuUpdate(True)
        End If
    End Sub

    Private Sub menuIconPic_Click_1(sender As Object, e As EventArgs) Handles menuIconPic.Click
        If menuIconPic.Location.X.Equals(5) Then
            MenuUpdate(True)
        Else
            MenuUpdate(False)
        End If
    End Sub



#Region "Icon quick settings side panel"
    Private optionsIsOnpen As Boolean = False
    Private Sub iconMenuSettings_Click_1(sender As Object, e As EventArgs) Handles iconMenuSettings.Click
        If optionsIsOnpen Then
            optionsIsOnpen = False
            If Not IsNothing(currentForm) Then
                currentForm.Close()
            End If
            panelMenuOptionsContainer.Height = 0
        Else
            optionsIsOnpen = True

            Dim formToLoad As FormCustomized = loadFormFromAssembly("settings.layout.widget.dll", "lateralSettingsForm", enVars, updateMainApp)

            panelMenuOptionsContainer.Height = formToLoad.Height
            openChildForm(panelMenuOptionsContainer, formToLoad)
        End If
    End Sub
#End Region



    Private Sub panelLateralMenuContainer_Paint(sender As Object, e As PaintEventArgs) Handles panelSideMenuContainer.Paint

    End Sub

#End Region







    Private Sub panelLateralWrapper_Resize(sender As Object, e As System.EventArgs) Handles panelLeftSide.Resize
        panelSideMenuContainer.Width = panelLeftSide.Width + 30
        panelSideMenuContainer.Height = panelLeftSide.Height
    End Sub

    Private Sub resizeMenuElementsByOrder(previous As Control, current As Control)
        If previous Is Nothing Then
            current.Location = New Point(0, 0)
        Else
            current.Location = New Point(0, previous.Location.Y + previous.Height)
        End If
        current.Width = panelLeftSide.Width
        current.Dock = DockStyle.None
    End Sub


    Private currentForm As Form = Nothing
    Private Sub openChildForm(targetPanel As PanelDoubleBuffer, childForm As Form)
        SuspendLayout()
        If currentForm IsNot Nothing Then currentForm.Close()
        currentForm = childForm
        childForm.TopLevel = False
        childForm.FormBorderStyle = FormBorderStyle.None
        childForm.Dock = DockStyle.Fill
        childForm.Parent = targetPanel
        childForm.Width = targetPanel.Width
        targetPanel.Height = childForm.Height
        targetPanel.Controls.Add(childForm)
        targetPanel.Tag = childForm
        childForm.BringToFront()
        childForm.BackgroundImage = cropImage(Me.BackgroundImage, targetPanel.Location, targetPanel.Size, Me.Size)
        childForm.BackgroundImageLayout = ImageLayout.Stretch
        childForm.Show()
        ResumeLayout()
    End Sub


    Private Sub doLogin()
        If Not loaded Then
            Exit Sub
        End If
        'TODO clear session vars
        enVars.successLogin = False
        If (WindowState.Equals(FormWindowState.Minimized)) Then
            Exit Sub
        End If

        ''If Application.OpenForms().OfType(Of SplashScreen).Any Then
        ''Exit Sub
        ''End If

        ''Me.Hide()
        '' If splashScreenLogin.ShowDialog() = DialogResult.OK Then
        ''Me.Show()
        ''Else
        ''Application.Exit()
        ''Close()
        ''End If
    End Sub

    Public Sub NoNetwork()
        If Not IsNothing(CurrentWrapperForm) Then
            CurrentWrapperForm.Close()
            CurrentWrapperForm.Dispose()
        End If

        Dim mask As PictureBox = New PictureBox
        mask.Dock = DockStyle.Fill
        mask.Top = TopMost
        mask.Image = Image.FromFile(enVars.imagesPath & Convert.ToString("noNetwork.png"))
        mask.SizeMode = PictureBoxSizeMode.CenterImage
        mask.Parent = panelMain
        panelMain.Controls.Clear()
        panelMain.Controls.Add(mask)
        mask.BringToFront()
        panelMain.Refresh()
    End Sub

    Public Sub UnloadForms()
        If Not IsNothing(CurrentWrapperForm) Then
            CurrentWrapperForm.Close()
            CurrentWrapperForm.Dispose()
        End If

        panelMain.Refresh()
        Exit Sub

        If Me.panelMain.Controls.Count > 0 Then
            Dim ctrl As Control = Nothing
            For i As Integer = Me.panelMain.Controls.Count - 1 To 0 Step -1
                ctrl = Me.panelMain.Controls(i)
                Try
                    'MISSING - BUGS HERE EVEN INSIDE THE TRY BLOCK
                    Me.panelMain.Controls.Remove(ctrl)
                Catch ex As Exception
                    statusMessage = "Error unloading form"
                End Try
            Next
            ctrl.Dispose()
        End If
    End Sub




    ''Private Sub sidebarWrapper_Paint(sender As Object, e As TableLayoutCellPaintEventArgs) 'Handles sidebarWrapperContents.Paint
    ''Dim TheControl As Control = CType(sender, Control)
    ''Dim oRAngle As Rectangle = New Rectangle(0, 0, TheControl.Width, TheControl.Height)
    ''Dim oGradientBrush As Brush = New System.Drawing.Drawing2D.LinearGradientBrush(
    ''                                oRAngle, enVars.colorMainMenu,
    ''                              enVars.colorMainMenu,
    ''                            System.Drawing.Drawing2D _
    ''.LinearGradientMode.ForwardDiagonal)
    ''  e.Graphics.FillRectangle(oGradientBrush, oRAngle)
    ''End Sub

    Private Sub wrapper_got_focus(sender As Object, e As EventArgs)
        panelSideMenuContainer.Width = 36
    End Sub

    Private Sub wrapper_Resize(sender As Object, e As System.EventArgs)
        If CurrentWrapperForm IsNot Nothing Then
            CurrentWrapperForm.Size = panelMain.Size
            CurrentWrapperForm.Refresh()
        End If
    End Sub

    Private Sub ChangeBackgroundTimer_Tick(sender As Object, e As EventArgs) Handles ChangeBackgroundTimer.Tick
        bwChangeBackground.RunWorkerAsync()
    End Sub


    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object,
                                         ByVal e As System.ComponentModel.DoWorkEventArgs) _
                                         Handles bwChangeBackground.DoWork

        'load background files from path or web ?


    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object,
                                                     ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) _
                                                     Handles bwChangeBackground.RunWorkerCompleted

        ''Me.BackgroundImage= 

    End Sub



End Class