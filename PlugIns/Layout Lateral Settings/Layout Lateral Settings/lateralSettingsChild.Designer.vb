Imports XComponent.SliderBar

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class lateralSettingsChild
    Inherits FormCustomized

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
        Me.MacTrackBar1 = New XComponent.SliderBar.MACTrackBar()
        Me.ColorDialog = New System.Windows.Forms.ColorDialog()
        Me.selectPanelBackColor = New FontAwesome.Sharp.IconPictureBox()
        Me.AlphaGradientPanel1 = New BlueActivity.AlphaGradientPanel()
        Me.ColorWithAlpha1 = New BlueActivity.ColorWithAlpha()
        CType(Me.selectPanelBackColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AlphaGradientPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MacTrackBar1
        '
        Me.MacTrackBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MacTrackBar1.BackColor = System.Drawing.Color.Transparent
        Me.MacTrackBar1.BorderColor = System.Drawing.Color.Transparent
        Me.MacTrackBar1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MacTrackBar1.ForeColor = System.Drawing.Color.White
        Me.MacTrackBar1.IndentHeight = 6
        Me.MacTrackBar1.LargeChange = 10
        Me.MacTrackBar1.Location = New System.Drawing.Point(0, 0)
        Me.MacTrackBar1.Maximum = 100
        Me.MacTrackBar1.Minimum = 0
        Me.MacTrackBar1.Name = "MacTrackBar1"
        Me.MacTrackBar1.Size = New System.Drawing.Size(314, 38)
        Me.MacTrackBar1.TabIndex = 1
        Me.MacTrackBar1.TextTickStyle = System.Windows.Forms.TickStyle.None
        Me.MacTrackBar1.TickColor = System.Drawing.Color.White
        Me.MacTrackBar1.TickFrequency = 10
        Me.MacTrackBar1.TickHeight = 4
        Me.MacTrackBar1.TickStyle = System.Windows.Forms.TickStyle.Both
        Me.MacTrackBar1.TrackerColor = System.Drawing.Color.DeepPink
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
        Me.selectPanelBackColor.Location = New System.Drawing.Point(10, 47)
        Me.selectPanelBackColor.Name = "selectPanelBackColor"
        Me.selectPanelBackColor.Size = New System.Drawing.Size(20, 20)
        Me.selectPanelBackColor.TabIndex = 2
        Me.selectPanelBackColor.TabStop = False
        '
        'AlphaGradientPanel1
        '
        Me.AlphaGradientPanel1.BackColor = System.Drawing.Color.Transparent
        Me.AlphaGradientPanel1.Border = False
        Me.AlphaGradientPanel1.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Me.AlphaGradientPanel1.Colors.Add(Me.ColorWithAlpha1)
        Me.AlphaGradientPanel1.ContentPadding = New System.Windows.Forms.Padding(0)
        Me.AlphaGradientPanel1.Controls.Add(Me.MacTrackBar1)
        Me.AlphaGradientPanel1.Controls.Add(Me.selectPanelBackColor)
        Me.AlphaGradientPanel1.CornerRadius = 20
        Me.AlphaGradientPanel1.Corners = BlueActivity.Corner.None
        Me.AlphaGradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AlphaGradientPanel1.Gradient = False
        Me.AlphaGradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.AlphaGradientPanel1.GradientOffset = 1.0!
        Me.AlphaGradientPanel1.GradientSize = New System.Drawing.Size(0, 0)
        Me.AlphaGradientPanel1.GradientWrapMode = System.Drawing.Drawing2D.WrapMode.Tile
        Me.AlphaGradientPanel1.Grayscale = False
        Me.AlphaGradientPanel1.Image = Nothing
        Me.AlphaGradientPanel1.ImageAlpha = 75
        Me.AlphaGradientPanel1.ImagePadding = New System.Windows.Forms.Padding(5)
        Me.AlphaGradientPanel1.ImagePosition = BlueActivity.ImagePosition.BottomRight
        Me.AlphaGradientPanel1.ImageSize = New System.Drawing.Size(48, 48)
        Me.AlphaGradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.AlphaGradientPanel1.Margin = New System.Windows.Forms.Padding(2)
        Me.AlphaGradientPanel1.Name = "AlphaGradientPanel1"
        Me.AlphaGradientPanel1.Rounded = True
        Me.AlphaGradientPanel1.Size = New System.Drawing.Size(314, 78)
        Me.AlphaGradientPanel1.TabIndex = 352
        '
        'ColorWithAlpha1
        '
        Me.ColorWithAlpha1.Alpha = 0
        Me.ColorWithAlpha1.Color = System.Drawing.Color.Silver
        Me.ColorWithAlpha1.Parent = Me.AlphaGradientPanel1
        '
        'lateralSettingsChild
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(314, 78)
        Me.Controls.Add(Me.AlphaGradientPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "lateralSettingsChild"
        Me.TargetOpacity = 1.0R
        Me.Text = "Form1"
        Me.TransparencyKey = System.Drawing.Color.Gainsboro
        CType(Me.selectPanelBackColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AlphaGradientPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents MacTrackBar1 As MACTrackBar
    Friend WithEvents ColorDialog As ColorDialog
    Friend WithEvents selectPanelBackColor As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents AlphaGradientPanel1 As BlueActivity.AlphaGradientPanel
    Friend WithEvents ColorWithAlpha1 As BlueActivity.ColorWithAlpha
End Class
