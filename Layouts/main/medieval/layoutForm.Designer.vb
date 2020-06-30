Imports System.Windows.Forms
Imports System.Drawing

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class layoutForm
    Inherits FormCustomized

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(layoutForm))
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.clock = New System.Windows.Forms.Timer(Me.components)
        Me.formTimeOut = New System.Windows.Forms.Timer(Me.components)
        Me.StatusMessagesDisplayTime = New System.Windows.Forms.Timer(Me.components)
        Me.FormRedraw = New System.Windows.Forms.Timer(Me.components)
        Me.ChangeBackgroundTimer = New System.Windows.Forms.Timer(Me.components)
        Me.PanelMain = New PanelDoubleBuffer()
        Me.panelTop = New PanelDoubleBuffer()
        Me.PanelTransparentTextBox1 = New PanelTransparentTextBox()
        Me.TransparentRichTextBox1 = New TransparentRichTextBox()
        Me.main_exit = New System.Windows.Forms.PictureBox()
        Me.PictureBoxSearch = New System.Windows.Forms.PictureBox()
        Me.main_minimize = New System.Windows.Forms.PictureBox()
        Me.panelBottom = New PanelDoubleBuffer()
        Me.statusText = New LabelDoubleBuffer()
        Me.PanelLateral = New PanelDoubleBuffer()
        Me.menuIIconPic = New PictureBoxDoubleBuffer()
        Me.PanelSchedule = New System.Windows.Forms.Panel()
        Me.Label8 = New LabelDoubleBuffer()
        Me.Label7 = New LabelDoubleBuffer()
        Me.Label6 = New LabelDoubleBuffer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New LabelDoubleBuffer()
        Me.Panelweather = New System.Windows.Forms.Panel()
        Me.PictureBoxDoubleBuffer1 = New PictureBoxDoubleBuffer()
        Me.Label4 = New LabelDoubleBuffer()
        Me.Label3 = New LabelDoubleBuffer()
        Me.Label2 = New LabelDoubleBuffer()
        Me.Label1 = New LabelDoubleBuffer()
        Me.LabelTemperature = New LabelDoubleBuffer()
        Me.schedule_notice = New LabelDoubleBuffer()
        Me.label_time = New LabelDoubleBuffer()
        Me.label_date = New LabelDoubleBuffer()
        Me.PanelLateralWrapper = New PanelDoubleBuffer()
        Me.panelTop.SuspendLayout()
        Me.PanelTransparentTextBox1.SuspendLayout()
        CType(Me.main_exit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.main_minimize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelBottom.SuspendLayout()
        Me.PanelLateral.SuspendLayout()
        CType(Me.menuIIconPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelSchedule.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panelweather.SuspendLayout()
        CType(Me.PictureBoxDoubleBuffer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelLateralWrapper.SuspendLayout()
        Me.SuspendLayout()
        '
        'PrintDocument1
        '
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'clock
        '
        Me.clock.Interval = 1000
        '
        'formTimeOut
        '
        Me.formTimeOut.Interval = 60000
        '
        'StatusMessagesDisplayTime
        '
        Me.StatusMessagesDisplayTime.Interval = 1000
        '
        'FormRedraw
        '
        Me.FormRedraw.Interval = 500
        '
        'ChangeBackgroundTimer
        '
        Me.ChangeBackgroundTimer.Interval = 60000
        '
        'PanelMain
        '
        Me.PanelMain.BackColor = System.Drawing.Color.Transparent
        Me.PanelMain.Enabled = False
        Me.PanelMain.Location = New System.Drawing.Point(708, 348)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Size = New System.Drawing.Size(1940, 1100)
        Me.PanelMain.TabIndex = 14
        Me.PanelMain.Visible = False
        '
        'panelTop
        '
        Me.panelTop.BackColor = System.Drawing.Color.Transparent
        Me.panelTop.Controls.Add(Me.PanelTransparentTextBox1)
        Me.panelTop.Controls.Add(Me.main_exit)
        Me.panelTop.Controls.Add(Me.PictureBoxSearch)
        Me.panelTop.Controls.Add(Me.main_minimize)
        Me.panelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelTop.Location = New System.Drawing.Point(421, 0)
        Me.panelTop.Name = "panelTop"
        Me.panelTop.Padding = New System.Windows.Forms.Padding(20, 0, 20, 0)
        Me.panelTop.Size = New System.Drawing.Size(1519, 75)
        Me.panelTop.TabIndex = 13
        Me.panelTop.Visible = False
        '
        'PanelTransparentTextBox1
        '
        Me.PanelTransparentTextBox1.BackColor = System.Drawing.Color.Transparent
        Me.PanelTransparentTextBox1.Controls.Add(Me.TransparentRichTextBox1)
        Me.PanelTransparentTextBox1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.PanelTransparentTextBox1.Location = New System.Drawing.Point(6, 22)
        Me.PanelTransparentTextBox1.Name = "PanelTransparentTextBox1"
        Me.PanelTransparentTextBox1.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.PanelTransparentTextBox1.Size = New System.Drawing.Size(533, 39)
        Me.PanelTransparentTextBox1.TabIndex = 16
        '
        'TransparentRichTextBox1
        '
        Me.TransparentRichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TransparentRichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TransparentRichTextBox1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TransparentRichTextBox1.ForeColor = System.Drawing.Color.White
        Me.TransparentRichTextBox1.Location = New System.Drawing.Point(20, 0)
        Me.TransparentRichTextBox1.Multiline = False
        Me.TransparentRichTextBox1.Name = "TransparentRichTextBox1"
        Me.TransparentRichTextBox1.Size = New System.Drawing.Size(513, 39)
        Me.TransparentRichTextBox1.TabIndex = 0
        Me.TransparentRichTextBox1.Text = "Type here to start a search"
        '
        'main_exit
        '
        Me.main_exit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.main_exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.main_exit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.main_exit.Image = CType(resources.GetObject("main_exit.Image"), System.Drawing.Image)
        Me.main_exit.Location = New System.Drawing.Point(1455, 21)
        Me.main_exit.Margin = New System.Windows.Forms.Padding(4, 5, 20, 5)
        Me.main_exit.Name = "main_exit"
        Me.main_exit.Size = New System.Drawing.Size(35, 35)
        Me.main_exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.main_exit.TabIndex = 13
        Me.main_exit.TabStop = False
        '
        'PictureBoxSearch
        '
        Me.PictureBoxSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBoxSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBoxSearch.Image = CType(resources.GetObject("PictureBoxSearch.Image"), System.Drawing.Image)
        Me.PictureBoxSearch.Location = New System.Drawing.Point(556, 21)
        Me.PictureBoxSearch.Name = "PictureBoxSearch"
        Me.PictureBoxSearch.Size = New System.Drawing.Size(40, 40)
        Me.PictureBoxSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxSearch.TabIndex = 15
        Me.PictureBoxSearch.TabStop = False
        '
        'main_minimize
        '
        Me.main_minimize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.main_minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.main_minimize.Cursor = System.Windows.Forms.Cursors.Hand
        Me.main_minimize.Image = CType(resources.GetObject("main_minimize.Image"), System.Drawing.Image)
        Me.main_minimize.Location = New System.Drawing.Point(1397, 21)
        Me.main_minimize.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.main_minimize.Name = "main_minimize"
        Me.main_minimize.Size = New System.Drawing.Size(35, 35)
        Me.main_minimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.main_minimize.TabIndex = 8
        Me.main_minimize.TabStop = False
        '
        'panelBottom
        '
        Me.panelBottom.BackColor = System.Drawing.Color.Transparent
        Me.panelBottom.Controls.Add(Me.statusText)
        Me.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelBottom.Location = New System.Drawing.Point(421, 1070)
        Me.panelBottom.Name = "panelBottom"
        Me.panelBottom.Size = New System.Drawing.Size(1519, 30)
        Me.panelBottom.TabIndex = 12
        Me.panelBottom.Visible = False
        '
        'statusText
        '
        Me.statusText.Dock = System.Windows.Forms.DockStyle.Fill
        Me.statusText.Font = New System.Drawing.Font("Trajan Pro", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.statusText.ForeColor = System.Drawing.Color.White
        Me.statusText.Location = New System.Drawing.Point(0, 0)
        Me.statusText.Name = "statusText"
        Me.statusText.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.statusText.Size = New System.Drawing.Size(1519, 30)
        Me.statusText.TabIndex = 0
        Me.statusText.Text = "Loading..."
        Me.statusText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PanelLateral
        '
        Me.PanelLateral.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PanelLateral.BackColor = System.Drawing.Color.Transparent
        Me.PanelLateral.Controls.Add(Me.menuIIconPic)
        Me.PanelLateral.Controls.Add(Me.PanelSchedule)
        Me.PanelLateral.Controls.Add(Me.Panelweather)
        Me.PanelLateral.Controls.Add(Me.schedule_notice)
        Me.PanelLateral.Controls.Add(Me.label_time)
        Me.PanelLateral.Controls.Add(Me.label_date)
        Me.PanelLateral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelLateral.Location = New System.Drawing.Point(0, 0)
        Me.PanelLateral.Name = "PanelLateral"
        Me.PanelLateral.Size = New System.Drawing.Size(421, 1100)
        Me.PanelLateral.TabIndex = 0
        Me.PanelLateral.Visible = False
        '
        'menuIIconPic
        '
        Me.menuIIconPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.menuIIconPic.Cursor = System.Windows.Forms.Cursors.Hand
        Me.menuIIconPic.Image = CType(resources.GetObject("menuIIconPic.Image"), System.Drawing.Image)
        Me.menuIIconPic.Location = New System.Drawing.Point(365, 16)
        Me.menuIIconPic.Name = "menuIIconPic"
        Me.menuIIconPic.Size = New System.Drawing.Size(40, 40)
        Me.menuIIconPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.menuIIconPic.TabIndex = 29
        Me.menuIIconPic.TabStop = False
        '
        'PanelSchedule
        '
        Me.PanelSchedule.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PanelSchedule.BackColor = System.Drawing.Color.Transparent
        Me.PanelSchedule.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PanelSchedule.Controls.Add(Me.Label8)
        Me.PanelSchedule.Controls.Add(Me.Label7)
        Me.PanelSchedule.Controls.Add(Me.Label6)
        Me.PanelSchedule.Controls.Add(Me.Panel1)
        Me.PanelSchedule.Controls.Add(Me.Label5)
        Me.PanelSchedule.Location = New System.Drawing.Point(0, 506)
        Me.PanelSchedule.Name = "PanelSchedule"
        Me.PanelSchedule.Padding = New System.Windows.Forms.Padding(5, 0, 30, 0)
        Me.PanelSchedule.Size = New System.Drawing.Size(421, 224)
        Me.PanelSchedule.TabIndex = 28
        '
        'Label8
        '
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label8.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(5, 158)
        Me.Label8.Name = "Label8"
        Me.Label8.Padding = New System.Windows.Forms.Padding(10, 10, 5, 10)
        Me.Label8.Size = New System.Drawing.Size(332, 44)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "10:40 - Lunch with Client   ------------------------------"
        '
        'Label7
        '
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(5, 120)
        Me.Label7.Name = "Label7"
        Me.Label7.Padding = New System.Windows.Forms.Padding(10, 10, 5, 10)
        Me.Label7.Size = New System.Drawing.Size(332, 38)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "10:40 - Project Call   ------------------------------"
        '
        'Label6
        '
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label6.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(5, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Padding = New System.Windows.Forms.Padding(10, 10, 5, 10)
        Me.Label6.Size = New System.Drawing.Size(332, 48)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "10:40 - Weekly meeting    -------------------------------"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(337, 72)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(54, 152)
        Me.Panel1.TabIndex = 6
        '
        'PictureBox3
        '
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(14, 100)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(25, 25)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 2
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(14, 56)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(25, 25)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(14, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(25, 25)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Font = New System.Drawing.Font("Trajan Pro", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(386, 72)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Your Schedule"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panelweather
        '
        Me.Panelweather.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panelweather.BackColor = System.Drawing.Color.Transparent
        Me.Panelweather.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panelweather.Controls.Add(Me.PictureBoxDoubleBuffer1)
        Me.Panelweather.Controls.Add(Me.Label4)
        Me.Panelweather.Controls.Add(Me.Label3)
        Me.Panelweather.Controls.Add(Me.Label2)
        Me.Panelweather.Controls.Add(Me.Label1)
        Me.Panelweather.Controls.Add(Me.LabelTemperature)
        Me.Panelweather.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panelweather.Location = New System.Drawing.Point(0, 328)
        Me.Panelweather.Name = "Panelweather"
        Me.Panelweather.Padding = New System.Windows.Forms.Padding(0, 0, 30, 0)
        Me.Panelweather.Size = New System.Drawing.Size(421, 178)
        Me.Panelweather.TabIndex = 27
        '
        'PictureBoxDoubleBuffer1
        '
        Me.PictureBoxDoubleBuffer1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBoxDoubleBuffer1.Image = CType(resources.GetObject("PictureBoxDoubleBuffer1.Image"), System.Drawing.Image)
        Me.PictureBoxDoubleBuffer1.Location = New System.Drawing.Point(40, 20)
        Me.PictureBoxDoubleBuffer1.Name = "PictureBoxDoubleBuffer1"
        Me.PictureBoxDoubleBuffer1.Size = New System.Drawing.Size(50, 50)
        Me.PictureBoxDoubleBuffer1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxDoubleBuffer1.TabIndex = 6
        Me.PictureBoxDoubleBuffer1.TabStop = False
        '
        'Label4
        '
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label4.Font = New System.Drawing.Font("Trajan Pro", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(274, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 66)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "chance" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "rain"
        '
        'Label3
        '
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label3.Font = New System.Drawing.Font("Trajan Pro", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(102, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 67)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "km/h" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "wind"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label2.Font = New System.Drawing.Font("Trajan Pro", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(201, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 30)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "100%"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label1.Font = New System.Drawing.Font("Trajan Pro", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(35, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 30)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "70.7"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelTemperature
        '
        Me.LabelTemperature.AutoSize = True
        Me.LabelTemperature.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelTemperature.Font = New System.Drawing.Font("Trajan Pro", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTemperature.ForeColor = System.Drawing.Color.White
        Me.LabelTemperature.Location = New System.Drawing.Point(99, 20)
        Me.LabelTemperature.Name = "LabelTemperature"
        Me.LabelTemperature.Size = New System.Drawing.Size(103, 45)
        Me.LabelTemperature.TabIndex = 1
        Me.LabelTemperature.Text = "23 C"
        '
        'schedule_notice
        '
        Me.schedule_notice.BackColor = System.Drawing.Color.Transparent
        Me.schedule_notice.Font = New System.Drawing.Font("Trajan Pro", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.schedule_notice.ForeColor = System.Drawing.Color.White
        Me.schedule_notice.Location = New System.Drawing.Point(0, 222)
        Me.schedule_notice.Name = "schedule_notice"
        Me.schedule_notice.Padding = New System.Windows.Forms.Padding(5, 0, 30, 0)
        Me.schedule_notice.Size = New System.Drawing.Size(421, 106)
        Me.schedule_notice.TabIndex = 26
        Me.schedule_notice.Text = "You have to leave the office in 25 minutes"
        Me.schedule_notice.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'label_time
        '
        Me.label_time.BackColor = System.Drawing.Color.Transparent
        Me.label_time.Dock = System.Windows.Forms.DockStyle.Top
        Me.label_time.Font = New System.Drawing.Font("Trajan Pro", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_time.ForeColor = System.Drawing.Color.White
        Me.label_time.Location = New System.Drawing.Point(0, 127)
        Me.label_time.Name = "label_time"
        Me.label_time.Padding = New System.Windows.Forms.Padding(0, 0, 30, 0)
        Me.label_time.Size = New System.Drawing.Size(421, 95)
        Me.label_time.TabIndex = 25
        Me.label_time.Text = "07:34"
        Me.label_time.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'label_date
        '
        Me.label_date.BackColor = System.Drawing.Color.Transparent
        Me.label_date.Dock = System.Windows.Forms.DockStyle.Top
        Me.label_date.Font = New System.Drawing.Font("Trajan Pro", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_date.ForeColor = System.Drawing.Color.White
        Me.label_date.Location = New System.Drawing.Point(0, 0)
        Me.label_date.Margin = New System.Windows.Forms.Padding(0)
        Me.label_date.Name = "label_date"
        Me.label_date.Padding = New System.Windows.Forms.Padding(15, 20, 30, 5)
        Me.label_date.Size = New System.Drawing.Size(421, 127)
        Me.label_date.TabIndex = 24
        Me.label_date.Text = "Monday" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "December, 7th"
        '
        'PanelLateralWrapper
        '
        Me.PanelLateralWrapper.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PanelLateralWrapper.BackColor = System.Drawing.Color.Transparent
        Me.PanelLateralWrapper.Controls.Add(Me.PanelLateral)
        Me.PanelLateralWrapper.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelLateralWrapper.Location = New System.Drawing.Point(0, 0)
        Me.PanelLateralWrapper.Name = "PanelLateralWrapper"
        Me.PanelLateralWrapper.Size = New System.Drawing.Size(421, 1100)
        Me.PanelLateralWrapper.TabIndex = 15
        '
        'MainMdiform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1940, 1100)
        Me.ControlBox = False
        Me.Controls.Add(Me.panelBottom)
        Me.Controls.Add(Me.panelTop)
        Me.Controls.Add(Me.PanelLateralWrapper)
        Me.Controls.Add(Me.PanelMain)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "layoutForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gestion de Chantiers"
        Me.TransparencyKey = System.Drawing.Color.Gainsboro
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.panelTop.ResumeLayout(False)
        Me.PanelTransparentTextBox1.ResumeLayout(False)
        CType(Me.main_exit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxSearch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.main_minimize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelBottom.ResumeLayout(False)
        Me.PanelLateral.ResumeLayout(False)
        CType(Me.menuIIconPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelSchedule.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panelweather.ResumeLayout(False)
        Me.Panelweather.PerformLayout()
        CType(Me.PictureBoxDoubleBuffer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelLateralWrapper.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents PrintDialog1 As PrintDialog
    Friend WithEvents PageSetupDialog1 As PageSetupDialog
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents clock As Timer
    Friend WithEvents formTimeOut As Timer
    Friend WithEvents StatusMessagesDisplayTime As Timer
    Friend WithEvents FormRedraw As Timer
    Private WithEvents main_minimize As PictureBox
    Friend WithEvents label_date As LabelDoubleBuffer
    Friend WithEvents schedule_notice As LabelDoubleBuffer
    Friend WithEvents label_time As LabelDoubleBuffer
    Friend WithEvents PanelSchedule As Panel
    Friend WithEvents Panelweather As Panel
    Friend WithEvents Label4 As LabelDoubleBuffer
    Friend WithEvents Label3 As LabelDoubleBuffer
    Friend WithEvents Label2 As LabelDoubleBuffer
    Friend WithEvents Label1 As LabelDoubleBuffer
    Friend WithEvents LabelTemperature As LabelDoubleBuffer
    Friend WithEvents Label5 As LabelDoubleBuffer
    Private WithEvents main_exit As PictureBox
    Friend WithEvents PictureBoxSearch As PictureBox
    Friend WithEvents PanelTransparentTextBox1 As PanelTransparentTextBox
    Friend WithEvents TransparentRichTextBox1 As TransparentRichTextBox
    Friend WithEvents ChangeBackgroundTimer As Timer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PanelLateral As PanelDoubleBuffer
    Friend WithEvents panelBottom As PanelDoubleBuffer
    Friend WithEvents panelTop As PanelDoubleBuffer
    Friend WithEvents PanelMain As PanelDoubleBuffer
    Friend WithEvents statusText As LabelDoubleBuffer
    Friend WithEvents PictureBoxDoubleBuffer1 As PictureBoxDoubleBuffer
    Friend WithEvents PanelLateralWrapper As PanelDoubleBuffer
    Friend WithEvents Label8 As LabelDoubleBuffer
    Friend WithEvents Label7 As LabelDoubleBuffer
    Friend WithEvents Label6 As LabelDoubleBuffer
    Friend WithEvents menuIIconPic As PictureBoxDoubleBuffer
End Class
