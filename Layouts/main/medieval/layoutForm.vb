Imports System.ComponentModel
Imports System.Drawing.Printing
Imports System.IO
Imports System.Net
Imports AeonLabs
Imports AeonLabs.Environment
Imports AeonLabs.Layout

Public Class layoutForm
    Inherits FormCustomized

    Public CurrentWrapperForm As Form
    Public LoadedFrm As Form
    Public childForm As String = ""
    Private checkPrint As Integer

    Public loaded As Boolean = False
    Public Property enVars As New environmentVarsCore
    Public Property statusMessage As String = ""

    Private statusMessageLast As String = ""
    Private statusMessageTimeout As Integer = 10
    Private statusMessagePile As New List(Of String)

    Private msgbox As messageBoxForm

    Private BusyMenuOption As Boolean = False

    Public Property usernamePhoto As PictureBox = Nothing

    Private mbDoPaintBackground As Boolean
    Private Const WM_SYSCOMMAND = &H112

    'inactivity timer code auto logout
    Private inActivity As New Stopwatch

    Private WithEvents bwChangeBackground As New BackgroundWorker
    Private WithEvents taskManager As tasksManager.tasksManagerClass

    Private Vscroll As Integer
    Private eDelta As Integer



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

        ElseIf loaded Then
            FormRedraw.Enabled = True
        End If

        If WindowState = FormWindowState.Maximized OrElse WindowState = FormWindowState.Minimized Then
            mbDoPaintBackground = True
            Invalidate()
        End If
    End Sub
    Private Sub FormRedraw_Tick(sender As Object, e As EventArgs) Handles FormRedraw.Tick
        FormRedraw.Enabled = False
    End Sub

    Public Sub New(enVars As environmentVarsCore)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        Application.AddMessageFilter(Me)

        ' This call is required by the designer.
        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()

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

    Private Sub MyForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Application.RemoveMessageFilter(Me)
    End Sub

    Private Const WM_MAXBUTTONSomethingSomething As Integer = &HF030  '61488
    Private Const WM_MINBUTTONSomethingSomething As Integer = &HF120   '61728
    ' sub to address flickering on maximize form
    Protected Overrides Sub WndProc(ByRef m As Message)
        'Traps specifically for "Maximize" button
        Try
            If m.Msg = WM_SYSCOMMAND Then
                ' Handle running on 64-bit platforms
                Dim param As Long
                If (IntPtr.Size = 4) Then
                    param = CLng(m.WParam.ToInt32)
                Else
                    param = CLng(m.WParam.ToInt64)
                End If

                If CInt(param) = WM_MAXBUTTONSomethingSomething Then
                    mbDoPaintBackground = False
                ElseIf CInt(param) = WM_MINBUTTONSomethingSomething Then
                    mbDoPaintBackground = False
                End If
            Else
                ' Not a WM_SYSCOMMAND message
            End If
        Catch ex As Exception

        End Try
        'Listen for operating system messages to the application. If the form to expire is moved, mousemove detected, keydown detected it will stay open
        'When no message is sent from the OS within 30 seconds the form will expire.
        resetActivity()
        MyBase.WndProc(m)
    End Sub

    Public Sub resetActivity()
        inActivity.Reset()
        inActivity.Start()
    End Sub

    Private Sub formTimeOut_tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles formTimeOut.Tick
        If inActivity.Elapsed > enVars.AutomaticLogoutTime Then
            usernamePhoto.Image = Image.FromFile(enVars.imagesPath & Convert.ToString("worker.icon.png"))
            usernamePhoto.SizeMode = PictureBoxSizeMode.StretchImage
            UnloadForms()
            doLogin()
        End If
    End Sub

    Private Sub MainMdiForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaded = False

        Refresh()

        buildMenu()
        hideInfoPanels(False)
        SuspendLayout()


        panelTop.Parent = Me
        panelTop.BackColor = Color.FromArgb(150, Color.Black)

        panelBottom.Parent = Me
        panelBottom.BackColor = Color.FromArgb(150, Color.Black)

        statusText.Parent = panelBottom
        statusText.BackColor = Color.Transparent
        statusMessage = "teste"

        PanelLateralWrapper.Parent = Me
        PanelLateralWrapper.Width = enVars.bundleSpecificVars.menuProperties.widthClosed

        PanelLateral.Width = PanelLateralWrapper.Width + 30
        PanelLateral.Height = PanelLateralWrapper.Height

        PanelLateral.Parent = PanelLateralWrapper
        PanelLateral.AutoScroll = True
        PanelLateral.VerticalScroll.Enabled = True
        PanelLateral.VerticalScroll.Visible = False

        PanelLateral.HorizontalScroll.Enabled = False
        PanelLateral.HorizontalScroll.Visible = False

        PanelLateral.AutoScrollPosition = New Point(0, 0)
        PanelLateral.Dock = DockStyle.None

        PanelLateral.BackColor = enVars.bundleSpecificVars.MenuPanelBackColor
        PanelLateral.Width = enVars.bundleSpecificVars.menuProperties.widthClosed
        ''AddHandler PanelLateral.MouseMove, AddressOf menuPanelLateral_mouseMove

        menuIIconPic.Parent = PanelLateral
        menuIIconPic.BackColor = Color.Transparent
        menuIIconPic.Location = New Point(5, 5)

        PanelMain.Parent = Me
        PanelMain.BackColor = Color.FromArgb(80, Color.Black)

        TransparentRichTextBox1.Parent = PanelTransparentTextBox1
        TransparentRichTextBox1.ForeColor = Color.FromArgb(20, Color.White)

        PictureBoxSearch.Parent = panelTop
        PictureBoxSearch.BackColor = Color.Transparent
        label_date.Text = ""
        label_time.Text = ""

        label_date.Parent = PanelLateral
        label_time.Parent = PanelLateral
        schedule_notice.Parent = PanelLateral
        Panelweather.Parent = PanelLateral
        PanelSchedule.Parent = PanelLateral

        resizeMenuElementsByOrder(Nothing, label_date)
        resizeMenuElementsByOrder(label_date, label_time)
        resizeMenuElementsByOrder(label_time, schedule_notice)
        resizeMenuElementsByOrder(schedule_notice, Panelweather)
        resizeMenuElementsByOrder(Panelweather, PanelSchedule)

        panelBottom.Visible = True
        panelTop.Visible = True
        PanelLateral.Visible = True
        PanelMain.Visible = True
        ResumeLayout()
    End Sub

    Private Sub MainMdiForm_show(sender As Object, e As EventArgs) Handles MyBase.Shown
        ''Me.Hide()
        ''splashScreenLogin = New SplashScreen(Me)
        ''If Not splashScreenLogin.ShowDialog() = DialogResult.OK Then
        ''Close()
        ''Application.Exit()
        ''Exit Sub
        ''End If

        ''auto logout
        resetActivity()
        formTimeOut.Interval = 60 * 1000 'check every 1 second for new messages from the OS
        formTimeOut.Start()
        inActivity.Reset()
        inActivity.Start()
        ''change background
        ChangeBackgroundTimer.Interval = 60 * 1000 'check every 1 minute 
        ChangeBackgroundTimer.Start()
        'clock
        clock.Start()

        SuspendLayout()
        Me.Opacity = 100
        Me.WindowState = FormWindowState.Maximized
        Me.Visible = True
        ResumeLayout()
        loaded = True

    End Sub

    ''Private Sub wrapper_Paint_1(sender As Object, e As TableLayoutCellPaintEventArgs) Handles wrapper.CellPaint, wrapper.Paint
    '' If e.Row = 0 Or e.Row = 2 Then
    ''Using brush As SolidBrush = New SolidBrush(Color.FromArgb(150, Color.Black))
    ''e.Graphics.FillRectangle(brush, e.CellBounds)
    ''End Using
    ''End If
    ''End Sub

    Private Sub buildMenu()
        Dim menuPosY As Integer = PanelSchedule.Location.Y + PanelSchedule.Height
        Dim menuPosX As Integer = 0
        Dim titlePosY As Integer = 0
        Dim subMenuActiveBarColor = Color.FromArgb(80, Color.Orange)
        Dim totalHeight As Integer = 0

        Dim subMenuExpandIcon As New PictureBox
        Dim subMenuIcon As New PictureBox

        Dim fontToMeasure As New Font(enVars.fontTitle.Families(0), enVars.subMenuTitleFontSize, Drawing.FontStyle.Regular)
        Dim sizeOfString As New SizeF
        Dim g As Graphics = Me.CreateGraphics
        sizeOfString = g.MeasureString("PQWER", fontToMeasure)
        Dim subMenuPanelHeight As Integer

        Dim menuitem As New List(Of AeonLabs.Environment.bundleSpecificVarsClass._menuStruct)
        For i = 0 To enVars.bundleSpecificVars.menu.Count - 1
            Dim menuItemKey As String = enVars.bundleSpecificVars.menu.ElementAt(i).Key
            Dim subMenuItems As List(Of AeonLabs.Environment.bundleSpecificVarsClass._menuStruct)
            subMenuItems = enVars.bundleSpecificVars.menu.ElementAt(i).Value
            Dim menuPanel As Panel = New PanelDoubleBuffer With {
                .Width = enVars.bundleSpecificVars.menuProperties.widthClosed,
                .Location = New Point(0, menuPosY + i * (enVars.bundleSpecificVars.menuProperties.height + 1)),
                .Height = enVars.bundleSpecificVars.menuProperties.height,
                .Name = menuItemKey,
                .Parent = Me,
                .BackColor = Color.Transparent
            }

            subMenuPanelHeight = 0
            For j = 0 To subMenuItems.Count - 1
                Dim subMenuItem As New AeonLabs.Environment.bundleSpecificVarsClass._menuStruct
                subMenuItem.iconPicHolder = New List(Of PictureBox)

                subMenuItem = subMenuItems.ElementAt(j)
                Dim subMenuPanel As New PanelDoubleBuffer With {
                .Width = enVars.bundleSpecificVars.menuProperties.width,
                .Height = enVars.bundleSpecificVars.menuProperties.height,
                .BackColor = enVars.bundleSpecificVars.menuProperties.bkColor,
                .Parent = menuPanel,
                .Name = menuItemKey & "-" & j,
                .Location = New Point(0, subMenuPanelHeight)
                }

                AddHandler subMenuPanel.Click, AddressOf menuPanel_Click
                ''AddHandler subMenuPanel.MouseMove, AddressOf menuPanelLateral_mouseMove

                If subMenuItem.submenu.Equals(False) Then ' MENU ITEM HEADER ================================================================================
                    menuPosX = enVars.bundleSpecificVars.menuProperties.widthClosed

                    subMenuIcon = New PictureBox With {
                    .Width = enVars.bundleSpecificVars.menuProperties.widthClosed - 10,
                    .Height = enVars.bundleSpecificVars.menuProperties.widthClosed - 10,
                    .Location = New Point(10 / 2, (enVars.bundleSpecificVars.menuProperties.height - enVars.bundleSpecificVars.menuProperties.widthClosed) / 2),
                    .Parent = subMenuPanel,
                    .Cursor = Cursors.Hand
                    }

                    If subMenuItem.TagTitle.Equals("username") Then
                        If (enVars.userPhoto.Equals("")) Then
                            subMenuIcon.Image = Image.FromFile(enVars.imagesPath & "worker.icon.png")
                        Else
                            subMenuIcon.InitialImage = Image.FromFile(enVars.imagesPath & Convert.ToString("loading.png"))
                            subMenuIcon.SizeMode = PictureBoxSizeMode.StretchImage

                            Dim tClient As WebClient = New WebClient
                            Try
                                Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(enVars.ServerBaseAddr & "/csaml/photos/" & enVars.userPhoto)))
                                subMenuIcon.Image = tImage
                            Catch ex As Exception
                                Threading.Thread.CurrentThread.CurrentUICulture = Globalization.CultureInfo.GetCultureInfo(enVars.currentLang)

                                subMenuIcon.Image = Image.FromFile(enVars.imagesPath & Convert.ToString("worker.icon.png"))
                                statusMessage = My.Resources.strings.errorDownloadingPhoto
                            End Try
                        End If
                        usernamePhoto = subMenuIcon
                    ElseIf Not subMenuItem.icon.Equals("") Then
                        Dim checkFile = New FileInfo(enVars.imagesPath & subMenuItem.icon)
                        checkFile.Refresh()
                        If checkFile.Exists Then
                            With subMenuIcon
                                .Image = Image.FromFile(enVars.imagesPath & subMenuItem.icon)
                            End With
                        End If
                    End If
                    With subMenuIcon
                        .SizeMode = PictureBoxSizeMode.StretchImage
                    End With
                    AddHandler subMenuIcon.Click, AddressOf menuPanel_Click
                    ''AddHandler subMenuIcon.MouseMove, AddressOf menuPanelLateral_mouseMove

                    subMenuPanel.Controls.Add(subMenuIcon)

                    subMenuExpandIcon = New PictureBox With {
                        .Width = enVars.bundleSpecificVars.menuProperties.widthClosed - 15,
                        .Height = enVars.bundleSpecificVars.menuProperties.widthClosed - 15,
                        .Image = Image.FromFile(enVars.imagesPath & "downarrow.png"),
                        .SizeMode = PictureBoxSizeMode.StretchImage,
                        .Location = New Point(enVars.bundleSpecificVars.menuProperties.width - (enVars.bundleSpecificVars.menuProperties.widthClosed - 15), enVars.bundleSpecificVars.menuProperties.height / 2 - (enVars.bundleSpecificVars.menuProperties.widthClosed - 15) / 2),
                        .Parent = subMenuPanel,
                        .Name = menuItemKey & "-expandIcon",
                        .Cursor = Cursors.Hand
                    }
                    'TODO add tooltips
                    AddHandler subMenuExpandIcon.Click, AddressOf menuPanelExpand_click
                    '' AddHandler subMenuExpandIcon.MouseMove, AddressOf menuPanelLateral_mouseMove

                    subMenuPanel.Controls.Add(subMenuExpandIcon)
                Else ' SUBMENU ITEM =======================================================================================================================
                    menuPosX = 5 + 5
                    With subMenuPanel
                        .Height = sizeOfString.Height + 10
                        .Location = New Point(15, subMenuPanel.Location.Y)
                        .Width = subMenuPanel.Width - 15
                    End With

                    Dim activeBar As New PanelDoubleBuffer With {
                       .Width = 5,
                       .Height = subMenuPanel.Height,
                       .BackColor = subMenuActiveBarColor,
                       .Location = New Point(0, 0),
                       .Parent = subMenuPanel
                    }
                    subMenuPanel.Controls.Add(activeBar)

                    Dim notif As New LabelDoubleBuffer With {
                        .Location = New Point(subMenuPanel.Width - enVars.bundleSpecificVars.menuProperties.widthClosed, 5),
                        .Font = New Font(enVars.fontTitle.Families(0), enVars.subMenuTitleFontSize, Drawing.FontStyle.Regular),
                        .Text = "",
                        .Parent = subMenuPanel,
                        .ForeColor = Color.Orange,
                        .BackColor = Color.Transparent,
                        .Cursor = Cursors.Hand
                    }
                    If subMenuItem.notifications > 0 Then
                        If subMenuItem.notifications < 10 Then
                            notif.Text = "0" & subMenuItem.notifications.ToString
                        Else
                            notif.Text = subMenuItem.notifications.ToString
                        End If
                    End If
                    AddHandler notif.Click, AddressOf menuPanelNotifications_click
                    '' AddHandler notif.MouseMove, AddressOf menuPanelLateral_mouseMove

                    subMenuPanel.Controls.Add(notif)
                End If

                'MENU ITEM TITLE TEXT =====================================================================================================================
                If subMenuItem.TagTitle.Equals("username") Then
                    Dim subtitle As New LabelDoubleBuffer With {
                        .Font = New Font(enVars.fontTitle.Families(0), enVars.subMenuTitleFontSize, Drawing.FontStyle.Regular),
                        .Location = New Point(menuPosX, 26),
                        .Text = enVars.customization.businessname,
                        .Parent = subMenuPanel,
                        .ForeColor = Color.White,
                        .BackColor = Color.Transparent,
                        .Width = enVars.bundleSpecificVars.menuProperties.width,
                        .Cursor = Cursors.Hand
                    }

                    AddHandler subtitle.Click, AddressOf menuPanel_Click
                    ''  AddHandler subtitle.MouseMove, AddressOf menuPanelLateral_mouseMove

                    subMenuPanel.Controls.Add(subtitle)
                    titlePosY = 5
                ElseIf j = 0 Then
                    titlePosY = (subMenuPanel.Height - sizeOfString.Height) / 2 - 5
                Else
                    titlePosY = 5
                End If

                Dim title As New LabelDoubleBuffer With {
                    .Font = New Font(enVars.fontTitle.Families(0), enVars.menuTitleFontSize, Drawing.FontStyle.Regular),
                    .Location = New Point(menuPosX, titlePosY),
                    .Text = If(subMenuItem.TagTitle.Equals("username"), If(enVars.username.Equals(""), "menuProfileTitle", enVars.username), "subTitle"),
                    .Parent = subMenuPanel,
                    .ForeColor = Color.White,
                    .BackColor = Color.Transparent,
                    .Width = enVars.bundleSpecificVars.menuProperties.width,
                    .Cursor = Cursors.Hand
                }

                AddHandler title.Click, AddressOf menuPanel_Click
                ''AddHandler title.MouseMove, AddressOf menuPanelLateral_mouseMove

                subMenuPanel.Controls.Add(title)

                ''AddHandler menuPanel.MouseMove, AddressOf menuPanelLateral_mouseMove

                menuPanel.Controls.Add(subMenuPanel)
                subMenuPanelHeight += subMenuPanel.Height + 1

                enVars.bundleSpecificVars.menu(menuItemKey)(j).subMenuPanel = subMenuPanel
                enVars.bundleSpecificVars.menu(menuItemKey)(j).iconPicHolder = New List(Of PictureBox)
                enVars.bundleSpecificVars.menu(menuItemKey)(j).iconPicHolder.Add(subMenuIcon)
                enVars.bundleSpecificVars.menu(menuItemKey)(j).iconPicHolder.Add(subMenuExpandIcon)
            Next j

            PanelLateral.Controls.Add(menuPanel)
            enVars.bundleSpecificVars.menu(menuItemKey)(0).menuWrapperPanel = menuPanel
            enVars.bundleSpecificVars.menu(menuItemKey)(0).menuWrapperOpenHeight = subMenuPanelHeight
            enVars.bundleSpecificVars.menu(menuItemKey)(0).enVars = False

            totalHeight += (subMenuItems.Count) * enVars.bundleSpecificVars.menuProperties.height + 1
        Next i

        '' Set position on top of your panel

        ''Set maximum position of your panel beyond the point your panel items reach.
        ''You'll have to change this size depending on the total size of items for your case.
        '' PanelLateral.VerticalScroll.Maximum = totalHeight + PanelSchedule.Location.Y + PanelSchedule.Height
    End Sub

    Private Sub panelLateralWrapper_Resize(sender As Object, e As System.EventArgs) Handles PanelLateralWrapper.Resize
        PanelLateral.Width = PanelLateralWrapper.Width + 30
        PanelLateral.Height = PanelLateralWrapper.Height
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
            If ctrl.Name.Equals("PanelLateral") Then
                menuPanel = ctrl
            ElseIf ctrl.Parent.Parent IsNot Nothing Then
                If ctrl.Parent.Parent.Name.Equals("PanelLateral") Then
                    menuPanel = ctrl.Parent
                End If
            End If
        End If

        If TypeOf ctrlIni Is LabelDoubleBuffer Then
            Dim ctrl As LabelDoubleBuffer = CType(ctrlIni, LabelDoubleBuffer)
            If ctrl.Parent.Parent IsNot Nothing Then
                If ctrl.Parent.Parent.Name.Equals("PanelLateral") Then
                    menuPanel = ctrl.Parent
                End If
            End If
        End If
        If TypeOf ctrlIni Is PictureBox Then
            Dim ctrl As PictureBox = CType(ctrlIni, PictureBox)
            If ctrl.Parent.Parent IsNot Nothing Then
                If ctrl.Parent.Parent.Name.Equals("PanelLateral") Then
                    menuPanel = ctrl.Parent
                End If
            End If
        End If

        If menuPanel Is Nothing Then
            Exit Sub
        End If


        If menuPanel.Name.Equals("PanelLateral") Then

            Dim vScrollPosition As Integer = Vscroll 'PanelLateral.VerticalScroll.Value
            vScrollPosition -= Math.Sign(eDelta) * Sensitivity
            vScrollPosition = Math.Max(0, vScrollPosition)
            vScrollPosition = Math.Min(vScrollPosition, PanelLateral.VerticalScroll.Maximum)
            If Not vScrollPosition.Equals(PanelLateral.VerticalScroll.Value) Then
                PanelLateral.SuspendLayout()
                PanelLateral.AutoScroll = True
                PanelLateral.VerticalScroll.Enabled = True
                PanelLateral.VerticalScroll.Value = vScrollPosition
                PanelLateral.AutoScrollPosition = New Point(PanelLateral.AutoScrollPosition.X,
                         vScrollPosition)
                PanelLateral.AutoScroll = False
                PanelLateral.ResumeLayout()
                Vscroll = vScrollPosition
            End If
            statusMessage = "VSCROOL: " & vScrollPosition & "      Previous:" & PanelLateral.VerticalScroll.Value
        End If

    End Sub
    Private Sub doLPanelLateralScrool(sender As Object, e As System.Windows.Forms.MouseEventArgs)

        If PanelLateral.Bounds.Contains(e.Location) Then
            Dim vScrollPosition As Integer = Vscroll 'PanelLateral.VerticalScroll.Value
            vScrollPosition -= Math.Sign(e.Delta) * Sensitivity
            vScrollPosition = Math.Max(0, vScrollPosition)
            vScrollPosition = Math.Min(vScrollPosition, PanelLateral.VerticalScroll.Maximum)
            If Not vScrollPosition.Equals(PanelLateral.VerticalScroll.Value) Then
                PanelLateral.SuspendLayout()
                PanelLateral.AutoScroll = True

                PanelLateral.AutoScrollPosition = New Point(PanelLateral.AutoScrollPosition.X,
                                  vScrollPosition)
                PanelLateral.AutoScroll = False
                PanelLateral.ResumeLayout()
                Vscroll = vScrollPosition
            End If
            statusMessage = "VSCROOL: " & vScrollPosition & "      Previous:" & PanelLateral.VerticalScroll.Value
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

            If PanelLateralWrapper.Width.Equals(enVars.bundleSpecificVars.menuProperties.width + 5) Then '' its open the lateral bar
                If enVars.bundleSpecificVars.menu.Item(menukey).ElementAt(subMenuPos).enVars.Equals(False) Then '' menu is closed
                    enVars.bundleSpecificVars.menu.Item(menukey).ElementAt(subMenuPos).enVars = True
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


        If enVars.bundleSpecificVars.menu.Item(menukey).ElementAt(subMenuPos).TagTitle.Equals("menuExitTitle") Then
            terminateApplicationAndExit()
            Exit Sub
        End If

        If enVars.bundleSpecificVars.menu.Item(menukey).ElementAt(subMenuPos).TagTitle.Equals("menuExitTitle") Then
            UnloadForms()
            doLogin()
            Exit Sub
        End If

        If enVars.bundleSpecificVars.menu.Item(menukey).ElementAt(subMenuPos).TagTitle.Equals("menuItemExport") Then
            ''            exportData()
            Exit Sub
        End If

        If enVars.bundleSpecificVars.menu.Item(menukey).ElementAt(subMenuPos).TagTitle.Equals("menuItemPrint") Then
            ''  DataPrint()
            Exit Sub
        End If

        ''no content to load and is also menu title
        If enVars.bundleSpecificVars.menu.Item(menukey).ElementAt(subMenuPos).contentToLoadForm Is Nothing And subMenuPos.Equals(0) Then
            enVars.bundleSpecificVars.menu.Item(menukey).ElementAt(subMenuPos).enVars = Not enVars.bundleSpecificVars.menu.Item(menukey).ElementAt(subMenuPos).enVars
            ''leave lateral pane open
            MenuUpdate(True)
        End If


        If enVars.bundleSpecificVars.menu.Item(menukey).ElementAt(subMenuPos).contentToLoadForm IsNot Nothing Then
            MenuUpdate(False)

            If enVars.bundleSpecificVars.menu.Item(menukey).ElementAt(subMenuPos).showDialog Then
                enVars.bundleSpecificVars.menu.Item(menukey).ElementAt(subMenuPos).contentToLoadForm.ShowDialog()
            Else
                CurrentWrapperForm = enVars.bundleSpecificVars.menu.Item(menukey).ElementAt(subMenuPos).contentToLoadForm
                With CurrentWrapperForm
                    .TopLevel = False
                    .AutoSize = False
                End With

                CurrentWrapperForm.Size = PanelMain.Size
                CurrentWrapperForm.Dock = DockStyle.Fill
                PanelMain.Controls.Add(CurrentWrapperForm)
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
            enVars.bundleSpecificVars.menu.Item(menuKey).ElementAt(submenuPos).enVars = Not enVars.bundleSpecificVars.menu.Item(menuKey).ElementAt(submenuPos).enVars
            MenuUpdate(True)
            Exit Sub
        End If

        Dim menuState As Boolean = True
        If enVars.bundleSpecificVars.menu.Item(menuKey).ElementAt(0).menuWrapperPanel.Width.Equals(enVars.bundleSpecificVars.menuProperties.width) Then
            menuState = False
        End If

    End Sub

    Private Sub menuPanelNotifications_click(sender As Object, e As EventArgs)

    End Sub

    Private Sub menuIIconPic_Click(sender As Object, e As EventArgs) Handles menuIIconPic.Click
        If menuIIconPic.Location.X.Equals(5) Then
            MenuUpdate(True)
        Else
            MenuUpdate(False)
        End If
    End Sub

    Public Sub doMenuAnimmation(origin As String)
        If (PanelLateralWrapper.Width.Equals(enVars.bundleSpecificVars.menuProperties.width + 5)) Then '' is open 
            MenuItemStateReset(False)
            MenuUpdate(False)
        ElseIf origin.Equals("main") Then
            MenuUpdate(True)
        End If
    End Sub

    Private Sub hideInfoPanels(status As Boolean)
        label_date.Visible = status
        label_time.Visible = status
        PanelSchedule.Visible = status
        Panelweather.Visible = status
        schedule_notice.Visible = status
    End Sub
    Private Sub MenuUpdate(menuState As Boolean)
        PanelLateral.SuspendLayout()
        Dim menuPosY As Integer = PanelSchedule.Location.Y + PanelSchedule.Height
        Dim menuPosX As Integer = 0

        If menuState.Equals(True) Then
            PanelLateralWrapper.Width = enVars.bundleSpecificVars.menuProperties.width + 5
            hideInfoPanels(menuState)
            menuIIconPic.Location = New Point(PanelLateralWrapper.Width - menuIIconPic.Width - 5, menuIIconPic.Location.Y)
        Else
            PanelLateralWrapper.Width = enVars.bundleSpecificVars.menuProperties.widthClosed
            hideInfoPanels(menuState)
            menuIIconPic.Location = New Point(5, menuIIconPic.Location.Y)
        End If

        resizeMenuElementsByOrder(Nothing, label_date)
        resizeMenuElementsByOrder(label_date, label_time)
        resizeMenuElementsByOrder(label_time, schedule_notice)
        resizeMenuElementsByOrder(schedule_notice, Panelweather)
        resizeMenuElementsByOrder(Panelweather, PanelSchedule)

        For i = 0 To enVars.bundleSpecificVars.menu.Count - 1
            ''do opeing / closing of menu
            If enVars.bundleSpecificVars.menu.ElementAt(i).Value.ElementAt(0).enVars Then
                With enVars.bundleSpecificVars.menu.ElementAt(i).Value.ElementAt(1).iconPicHolder(1)
                    .Image = Image.FromFile(enVars.imagesPath & "uparrow.png")
                    .SizeMode = PictureBoxSizeMode.StretchImage
                End With
                enVars.bundleSpecificVars.menu.ElementAt(i).Value.ElementAt(0).menuWrapperPanel.Height = enVars.bundleSpecificVars.menu.ElementAt(i).Value.ElementAt(0).menuWrapperOpenHeight
            Else
                With enVars.bundleSpecificVars.menu.ElementAt(i).Value.ElementAt(1).iconPicHolder(1)
                    .Image = Image.FromFile(enVars.imagesPath & "downarrow.png")
                    .SizeMode = PictureBoxSizeMode.StretchImage
                End With
                enVars.bundleSpecificVars.menu.ElementAt(i).Value.ElementAt(0).menuWrapperPanel.Height = enVars.bundleSpecificVars.menuProperties.height
            End If
            If menuState.Equals(True) Then
                enVars.bundleSpecificVars.menu.ElementAt(i).Value.ElementAt(0).menuWrapperPanel.Width = enVars.bundleSpecificVars.menuProperties.width
            Else
                enVars.bundleSpecificVars.menu.ElementAt(i).Value.ElementAt(0).menuWrapperPanel.Width = enVars.bundleSpecificVars.menuProperties.widthClosed
            End If
            enVars.bundleSpecificVars.menu.ElementAt(i).Value.ElementAt(0).menuWrapperPanel.Location = New Point(enVars.bundleSpecificVars.menu.ElementAt(i).Value.ElementAt(0).menuWrapperPanel.Location.X, menuPosY)
            menuPosY = menuPosY + enVars.bundleSpecificVars.menu.ElementAt(i).Value.ElementAt(0).menuWrapperPanel.Height + 1
        Next i

        PanelLateral.ResumeLayout()
    End Sub

    Private Sub MenuItemStateReset(menuState As Boolean)
        For i = 0 To enVars.bundleSpecificVars.menu.Count - 1
            enVars.bundleSpecificVars.menu.ElementAt(i).Value.ElementAt(0).enVars = menuState
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
        mask.Parent = PanelMain
        PanelMain.Controls.Clear()
        PanelMain.Controls.Add(mask)
        mask.BringToFront()
        PanelMain.Refresh()
    End Sub

    Public Sub UnloadForms()
        childForm = ""
        If Not IsNothing(CurrentWrapperForm) Then
            CurrentWrapperForm.Close()
            CurrentWrapperForm.Dispose()
        End If

        PanelMain.Refresh()
        Exit Sub

        If Me.PanelMain.Controls.Count > 0 Then
            Dim ctrl As Control = Nothing
            For i As Integer = Me.PanelMain.Controls.Count - 1 To 0 Step -1
                ctrl = Me.PanelMain.Controls(i)
                Try
                    'MISSING - BUGS HERE EVEN INSIDE THE TRY BLOCK
                    Me.PanelMain.Controls.Remove(ctrl)
                Catch ex As Exception
                    statusMessage = "Error unloading form"
                End Try
            Next
            ctrl.Dispose()
        End If
    End Sub

    Private Sub clock_Tick(sender As Object, e As EventArgs) Handles clock.Tick
        If (PanelLateral.Width.Equals(enVars.bundleSpecificVars.menuProperties.widthClosed)) Then
            label_date.Text = ""
            label_time.Text = ""
        Else
            label_time.Text = TimeOfDay.ToString("HH : mm")
            label_date.Text = DateTime.Now.ToString("dddd " & System.Environment.NewLine & "     MMMM, dd")
        End If
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

    Private Sub main_minimize_Click_1(sender As Object, e As EventArgs) Handles main_minimize.Click
        SuspendLayout()
        Me.WindowState = FormWindowState.Minimized
        ResumeLayout()
    End Sub

    Private Sub main_exit_Click(sender As Object, e As EventArgs) Handles main_exit.Click
        terminateApplicationAndExit()
    End Sub

    Private Sub terminateApplicationAndExit()
        Threading.Thread.CurrentThread.CurrentUICulture = Globalization.CultureInfo.GetCultureInfo(enVars.currentLang)

        msgbox = New messageBoxForm(My.Resources.strings.exitApp & " ?", My.Resources.strings.question, MessageBoxButtons.YesNo, MessageBoxIcon.Question, Me.Location.X + (Me.Width / 2), Me.Location.Y + Me.Height / 2, enVars)
        If msgbox.ShowDialog = MsgBoxResult.Yes Then
            ' UnloadForms()
            Close()
            System.Windows.Forms.Application.Exit()
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
        PanelLateral.Width = 36
    End Sub

    Private Sub wrapper_Resize(sender As Object, e As System.EventArgs)
        If CurrentWrapperForm IsNot Nothing Then
            CurrentWrapperForm.Size = PanelMain.Size
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

    Private Sensitivity As Integer = 20



    Private Sub PanelMain_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub PanelLateral_Paint(sender As Object, e As PaintEventArgs) Handles PanelLateral.Paint

    End Sub

    Private Sub PanelMain_Paint_1(sender As Object, e As PaintEventArgs) Handles PanelMain.Paint

    End Sub


End Class