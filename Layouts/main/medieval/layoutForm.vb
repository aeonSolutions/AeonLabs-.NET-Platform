Imports System.ComponentModel
Imports AeonLabs.Environment
Imports AeonLabs.Environment.Assembly.assemblyEnvironmentVarsClass
Imports AeonLabs.Layout
Imports AeonLabs.Layout.Menu.Vertical
Imports AeonLabs.Layouts
Imports AeonLabs.PlugIns.SideBar.Settings


Public Class mainAppLayoutForm
    Inherits FormCustomized

#Region "variables fields"
    Public CurrentWrapperForm As Form
    Public LoadedFrm As Form
    Public childForm As String = ""
    Private checkPrint As Integer

    Private WithEvents StatusMessagesDisplayTime As Timer
    Private WithEvents UpdateStatusMessageTimer As Timer
    Private WithEvents ChangeBackgroundTimer As Timer

    Public loaded As Boolean = False
    Public Property enVars As New environmentVarsCore
    Public Property statusMessage As String = ""

    Private statusMessageLast As String = ""
    Private statusMessageTimeout As Integer = 10
    Private statusMessagePile As New List(Of String)

    Private msgbox As messageBoxForm

    Private BusyMenuOption As Boolean = False

    Public Property usernamePhoto As PictureBox = Nothing

    Private WithEvents bwChangeBackground As New BackgroundWorker
    Private WithEvents taskManager As tasksManager.tasksManagerClass

    Private eDelta As Integer
    Private Sensitivity As Integer = 20

#End Region

#Region "Layout settings"
    Private Const LATERAL_MENU_OPEN_WIDTH As Integer = 400
#End Region

#Region "constructors"
    Public Sub New(_enVars As environmentVarsCore)
        Application.AddMessageFilter(Me)

        ' This call is required by the designer.
        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()

        enVars = _enVars
        enVars.layoutDesign.menu.properties.ClosedStateSize = LATERAL_MENU_OPEN_WIDTH
        ' hook up the event handler
        AddHandler enVars.dataChanged, AddressOf mainLayout_DataChanged
        'Me.InactivityTimeOut = enVars.AutomaticLogoutTime

        'initialize async tasks manager
        taskManager = New tasksManager.tasksManagerClass

        ''DEFINE TASKs TO DO
        With taskManager
            .registerTask("loadAssemblies", tasksManager.tasksManagerClass.TO_START)
        End With
        taskManager.startListening()

        Me.Visible = False
        Me.Opacity = 0
        Me.Refresh()

        '' needs to be the last 
        Me.Show()
    End Sub
#End Region

#Region "update environment changes"
    Public Sub mainLayout_DataChanged(sender As Object, envars As environmentVarsCore)

    End Sub
#End Region

#Region "form events"
    Private Sub MyForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Application.RemoveMessageFilter(Me)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaded = False

        Refresh()
        Dim menuBuilder As MenuVerticalClass = New MenuVerticalClass(Me, enVars)
        panelLateralMenuContainer.Controls.Add(menuBuilder.buildMenu())
        enVars = menuBuilder.enVars

        SuspendLayout()

        PanelLateralWrapper.Parent = Me
        PanelLateralWrapper.Width = enVars.layoutDesign.menu.properties.ClosedStateSize
        PanelLateralWrapper.BackColor = Color.Transparent

        lateralPanelMenuOptionContainer.Parent = PanelLateralWrapper
        lateralPanelMenuOptionContainer.Height = 0

        lateralPanelMenuWrapper.Parent = PanelLateralWrapper
        lateralPanelMenuWrapper.BackColor = Color.Transparent

        panelLateralMenuContainer.Parent = lateralPanelMenuWrapper
        panelLateralMenuContainer.BackColor = Color.FromArgb(50, Color.Red)
        'hack to hide the scrool bars
        panelLateralMenuContainer.Dock = DockStyle.None
        panelLateralMenuContainer.Width = lateralPanelMenuWrapper.Width + 30
        panelLateralMenuContainer.Height = lateralPanelMenuWrapper.Height

        lateralPanelMenuOptions.Parent = PanelLateralWrapper
        lateralPanelMenuOptions.BackColor = Color.FromArgb(50, Color.Red)

        menuIconPic.Parent = lateralPanelMenuOptions
        menuIconPic.BackColor = Color.Transparent
        menuIconPic.Width = enVars.layoutDesign.MENU_CLOSED_STATE - 3
        menuIconPic.Height = enVars.layoutDesign.MENU_CLOSED_STATE - 3

        iconMenuSettings.Parent = lateralPanelMenuOptions
        iconMenuSettings.BackColor = Color.Transparent

        panelTop.Parent = Me
        panelTop.BackColor = Color.FromArgb(50, Color.Black)
        lateralPanelMenuOptions.BackColor = Color.FromArgb(50, Color.Red)

        panelBottom.Parent = Me
        panelBottom.BackColor = Color.FromArgb(50, Color.Black)

        statusText.Parent = panelBottom
        statusText.BackColor = Color.Transparent
        statusMessage = "status message test"

        MenuUpdate(False)

        ResumeLayout()
    End Sub

    Private currentForm As Form = Nothing
    Private Sub openChildForm(targetPanel As PanelDoubleBuffer, childForm As Form)

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
        childForm.BackgroundImage = cropImage(Me.BackgroundImage, targetPanel.Location.X, targetPanel.Location.Y, targetPanel.Width, targetPanel.Height)
        childForm.BackgroundImageLayout = ImageLayout.Stretch
        childForm.Show()
        'TODO
    End Sub

#Region " Resize / crop Image "
    Public Function cropImage(ByVal sourceImage As Image, posX As Integer, posY As Integer, width As Integer, height As Integer) As Image
        Dim wRatio = sourceImage.Width / Me.ClientSize.Width
        Dim hRatio = sourceImage.Height / Me.ClientSize.Height

        Dim area = New Rectangle(posX * wRatio, posY * hRatio, width * wRatio, height * hRatio)

        Dim outPut As New Bitmap(width, height)
        Dim DescREctangle As Rectangle = New Rectangle(0, 0, outPut.Width, outPut.Height)
        Dim g As Graphics = Drawing.Graphics.FromImage(outPut)
        g.DrawImage(sourceImage, DescREctangle, area, GraphicsUnit.Pixel)
        g.Save()
        g.Dispose()
        Return outPut
    End Function

    Public Overloads Shared Function ResizeImage(SourceImage As Drawing.Image, TargetWidth As Int32, TargetHeight As Int32) As Drawing.Bitmap
        Dim bmSource = New Drawing.Bitmap(SourceImage)

        Return ResizeImage(bmSource, TargetWidth, TargetHeight)
    End Function

    Public Overloads Shared Function ResizeImage(bmSource As Drawing.Bitmap, TargetWidth As Int32, TargetHeight As Int32) As Drawing.Bitmap
        Dim bmDest As New Drawing.Bitmap(TargetWidth, TargetHeight, Drawing.Imaging.PixelFormat.Format32bppArgb)

        Dim nSourceAspectRatio = bmSource.Width / bmSource.Height
        Dim nDestAspectRatio = bmDest.Width / bmDest.Height

        Dim NewX = 0
        Dim NewY = 0
        Dim NewWidth = bmDest.Width
        Dim NewHeight = bmDest.Height

        If nDestAspectRatio = nSourceAspectRatio Then
            'same ratio
        ElseIf nDestAspectRatio > nSourceAspectRatio Then
            'Source is taller
            NewWidth = Convert.ToInt32(Math.Floor(nSourceAspectRatio * NewHeight))
            NewX = Convert.ToInt32(Math.Floor((bmDest.Width - NewWidth) / 2))
        Else
            'Source is wider
            NewHeight = Convert.ToInt32(Math.Floor((1 / nSourceAspectRatio) * NewWidth))
            NewY = Convert.ToInt32(Math.Floor((bmDest.Height - NewHeight) / 2))
        End If

        Using grDest = Drawing.Graphics.FromImage(bmDest)
            With grDest
                .CompositingQuality = Drawing.Drawing2D.CompositingQuality.HighQuality
                .InterpolationMode = Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
                .PixelOffsetMode = Drawing.Drawing2D.PixelOffsetMode.HighQuality
                .SmoothingMode = Drawing.Drawing2D.SmoothingMode.AntiAlias
                .CompositingMode = Drawing.Drawing2D.CompositingMode.SourceOver

                .DrawImage(bmSource, NewX, NewY, NewWidth, NewHeight)
            End With
        End Using

        Return bmDest
    End Function
#End Region


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
            Invalidate()
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


    Private Sub topPanel_Paint(sender As Object, e As PaintEventArgs)

    End Sub


    Private Sub panelLateralWrapper_Resize(sender As Object, e As System.EventArgs) Handles PanelLateralWrapper.Resize
        panelLateralMenuContainer.Width = PanelLateralWrapper.Width + 30
        panelLateralMenuContainer.Height = PanelLateralWrapper.Height
    End Sub

    Private Sub resizeMenuElementsByOrder(previous As Control, current As Control)
        If previous Is Nothing Then
            current.Location = New Point(0, 0)
        Else
            current.Location = New Point(0, previous.Location.Y + previous.Height)
        End If
        current.Width = PanelLateralWrapper.Width
        current.Dock = DockStyle.None
    End Sub

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
            vScrollPosition = Math.Min(vScrollPosition, panelLateralMenuContainer.VerticalScroll.Maximum)
            If Not vScrollPosition.Equals(panelLateralMenuContainer.VerticalScroll.Value) Then
                panelLateralMenuContainer.SuspendLayout()
                panelLateralMenuContainer.AutoScroll = True
                panelLateralMenuContainer.VerticalScroll.Enabled = True
                panelLateralMenuContainer.VerticalScroll.Value = vScrollPosition
                panelLateralMenuContainer.AutoScrollPosition = New Point(panelLateralMenuContainer.AutoScrollPosition.X,
                         vScrollPosition)
                panelLateralMenuContainer.AutoScroll = False
                panelLateralMenuContainer.ResumeLayout()
                VScroll = vScrollPosition
            End If
            statusMessage = "VSCROOL: " & vScrollPosition & "      Previous:" & panelLateralMenuContainer.VerticalScroll.Value
        End If

    End Sub
    Private Sub doLPanelLateralScrool(sender As Object, e As System.Windows.Forms.MouseEventArgs)

        If panelLateralMenuContainer.Bounds.Contains(e.Location) Then
            Dim vScrollPosition As Integer = VScroll 'panelLateral.VerticalScroll.Value
            vScrollPosition -= Math.Sign(e.Delta) * Sensitivity
            vScrollPosition = Math.Max(0, vScrollPosition)
            vScrollPosition = Math.Min(vScrollPosition, panelLateralMenuContainer.VerticalScroll.Maximum)
            If Not vScrollPosition.Equals(panelLateralMenuContainer.VerticalScroll.Value) Then
                panelLateralMenuContainer.SuspendLayout()
                panelLateralMenuContainer.AutoScroll = True

                panelLateralMenuContainer.AutoScrollPosition = New Point(panelLateralMenuContainer.AutoScrollPosition.X,
                                  vScrollPosition)
                panelLateralMenuContainer.AutoScroll = False
                panelLateralMenuContainer.ResumeLayout()
                VScroll = vScrollPosition
            End If
            statusMessage = "VSCROOL: " & vScrollPosition & "      Previous:" & panelLateralMenuContainer.VerticalScroll.Value
        End If
    End Sub
#End Region
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

            If PanelLateralWrapper.Width.Equals(enVars.layoutDesign.MENU_OPEN_STATE) Then '' its open the lateral bar
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
        If (PanelLateralWrapper.Width.Equals(enVars.layoutDesign.MENU_OPEN_STATE)) Then '' is open 
            MenuItemStateReset(False)
            MenuUpdate(False)
        ElseIf origin.Equals("main") Then
            MenuUpdate(True)
        End If
    End Sub

    Private Sub MenuUpdate(menuState As Boolean)
        panelLateralMenuContainer.SuspendLayout()
        Dim menuPosX As Integer = 0
        Dim menuPosY As Integer = 0

        If menuState.Equals(True) Then
            PanelLateralWrapper.Width = enVars.layoutDesign.MENU_OPEN_STATE
            menuIconPic.Location = New Point(PanelLateralWrapper.Width - menuIconPic.Width - 3 - 10, menuIconPic.Location.Y)
        Else
            PanelLateralWrapper.Width = enVars.layoutDesign.MENU_CLOSED_STATE
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

        panelLateralMenuContainer.ResumeLayout()
    End Sub

    Private Sub MenuItemStateReset(menuState As Boolean)
        For i = 0 To enVars.layoutDesign.menu.items.Count - 1
            enVars.layoutDesign.menu.items.ElementAt(i).isOpen = menuState
        Next i
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
        childForm = ""
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
        childForm = ""
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
        panelLateralMenuContainer.Width = 36
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

#Region "selction clicks"
    Private Sub panelLateral_Click(sender As Object, e As EventArgs) Handles panelLateralMenuContainer.Click
        If (PanelLateralWrapper.Width.Equals(enVars.layoutDesign.MENU_OPEN_STATE)) Then '' is open 
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

    Private Sub iconMenuSettings_Click(sender As Object, e As EventArgs)

    End Sub

    Private optionsIsOnpen As Boolean = False
    Private Sub iconMenuSettings_Click_1(sender As Object, e As EventArgs) Handles iconMenuSettings.Click
        If optionsIsOnpen Then
            optionsIsOnpen = False
            If Not IsNothing(currentForm) Then
                currentForm.Close()
            End If
            lateralPanelMenuOptionContainer.Height = 0
        Else
            optionsIsOnpen = True
            Dim formToLoad = New lateralSettingsForm(enVars)
            openChildForm(lateralPanelMenuOptionContainer, formToLoad)
            lateralPanelMenuOptionContainer.Height = formToLoad.Height
        End If
    End Sub

    Private Sub panelMain_Paint(sender As Object, e As PaintEventArgs) Handles panelMain.Paint

    End Sub

    Private Sub panelLateralMenuContainer_Paint(sender As Object, e As PaintEventArgs) Handles panelLateralMenuContainer.Paint

    End Sub
#End Region

End Class