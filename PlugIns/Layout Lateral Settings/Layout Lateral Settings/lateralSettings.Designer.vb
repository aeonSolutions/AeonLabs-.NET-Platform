

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class lateralSettingsForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ColorWithAlpha1 = New BlueActivity.ColorWithAlpha()
        Me.MacTrackBar1 = New XComponent.SliderBar.MACTrackBar()
        Me.selectPanelBackColor = New FontAwesome.Sharp.IconPictureBox()
        Me.panelForm = New PanelDoubleBuffer()
        Me.ColorPickerDialog = New System.Windows.Forms.ColorDialog()
        CType(Me.selectPanelBackColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelForm.SuspendLayout()
        Me.SuspendLayout()
        '
        'ColorWithAlpha1
        '
        Me.ColorWithAlpha1.Alpha = 40
        Me.ColorWithAlpha1.Color = System.Drawing.Color.Red
        Me.ColorWithAlpha1.Parent = Nothing
        '
        'MacTrackBar1
        '
        Me.MacTrackBar1.BackColor = System.Drawing.Color.Transparent
        Me.MacTrackBar1.BorderColor = System.Drawing.Color.Transparent
        Me.MacTrackBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.MacTrackBar1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MacTrackBar1.ForeColor = System.Drawing.Color.White
        Me.MacTrackBar1.IndentHeight = 6
        Me.MacTrackBar1.LargeChange = 10
        Me.MacTrackBar1.Location = New System.Drawing.Point(0, 0)
        Me.MacTrackBar1.Maximum = 100
        Me.MacTrackBar1.Minimum = 0
        Me.MacTrackBar1.Name = "MacTrackBar1"
        Me.MacTrackBar1.Size = New System.Drawing.Size(400, 38)
        Me.MacTrackBar1.TabIndex = 1
        Me.MacTrackBar1.TextTickStyle = System.Windows.Forms.TickStyle.None
        Me.MacTrackBar1.TickColor = System.Drawing.Color.White
        Me.MacTrackBar1.TickFrequency = 10
        Me.MacTrackBar1.TickHeight = 4
        Me.MacTrackBar1.TickStyle = System.Windows.Forms.TickStyle.Both
        Me.MacTrackBar1.TrackerColor = System.Drawing.Color.RoyalBlue
        Me.MacTrackBar1.TrackerSize = New System.Drawing.Size(16, 16)
        Me.MacTrackBar1.TrackLineColor = System.Drawing.Color.White
        Me.MacTrackBar1.TrackLineHeight = 3
        Me.MacTrackBar1.Value = 0
        '
        'selectPanelBackColor
        '
        Me.selectPanelBackColor.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.selectPanelBackColor.BackColor = System.Drawing.Color.Transparent
        Me.selectPanelBackColor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.selectPanelBackColor.IconChar = FontAwesome.Sharp.IconChar.Adjust
        Me.selectPanelBackColor.IconColor = System.Drawing.Color.White
        Me.selectPanelBackColor.IconSize = 20
        Me.selectPanelBackColor.Location = New System.Drawing.Point(12, 55)
        Me.selectPanelBackColor.Name = "selectPanelBackColor"
        Me.selectPanelBackColor.Size = New System.Drawing.Size(20, 20)
        Me.selectPanelBackColor.TabIndex = 2
        Me.selectPanelBackColor.TabStop = False
        '
        'panelForm
        '
        Me.panelForm.Controls.Add(Me.selectPanelBackColor)
        Me.panelForm.Controls.Add(Me.MacTrackBar1)
        Me.panelForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelForm.Location = New System.Drawing.Point(0, 0)
        Me.panelForm.Margin = New System.Windows.Forms.Padding(10)
        Me.panelForm.Name = "panelForm"
        Me.panelForm.PANEL_CLOSED_STATE_DIM = 40
        Me.panelForm.PANEL_OPEN_STATE_DIM = 400
        Me.panelForm.Size = New System.Drawing.Size(400, 87)
        Me.panelForm.TabIndex = 354
        '
        'lateralSettingsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(400, 87)
        Me.ControlBox = False
        Me.Controls.Add(Me.panelForm)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "lateralSettingsForm"
        Me.Opacity = 0R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.TransparencyKey = System.Drawing.Color.DimGray
        CType(Me.selectPanelBackColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelForm.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ColorWithAlpha1 As BlueActivity.ColorWithAlpha
    Private WithEvents MacTrackBar1 As XComponent.SliderBar.MACTrackBar
    Friend WithEvents selectPanelBackColor As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents panelForm As PanelDoubleBuffer
    Friend WithEvents ColorPickerDialog As ColorDialog
End Class
