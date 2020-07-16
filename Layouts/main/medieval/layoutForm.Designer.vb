

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class mainAppLayoutForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mainAppLayoutForm))
        Me.panelBottom = New PanelDoubleBuffer()
        Me.statusText = New LabelDoubleBuffer()
        Me.panelLateralMenuContainer = New PanelDoubleBuffer()
        Me.iconMenuSettings = New FontAwesome.Sharp.IconPictureBox()
        Me.menuIconPic = New FontAwesome.Sharp.IconPictureBox()
        Me.PanelLateralWrapper = New PanelDoubleBuffer()
        Me.lateralPanelMenuOptionContainer = New PanelDoubleBuffer()
        Me.lateralPanelMenuWrapper = New PanelDoubleBuffer()
        Me.lateralPanelMenuOptions = New PanelDoubleBuffer()
        Me.panelMain = New PanelDoubleBuffer()
        Me.panelTop = New PanelDoubleBuffer()
        Me.ColorWithAlpha1 = New BlueActivity.ColorWithAlpha()
        Me.panelBottom.SuspendLayout()
        CType(Me.iconMenuSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.menuIconPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelLateralWrapper.SuspendLayout()
        Me.lateralPanelMenuWrapper.SuspendLayout()
        Me.lateralPanelMenuOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelBottom
        '
        Me.panelBottom.BackColor = System.Drawing.Color.Transparent
        Me.panelBottom.Controls.Add(Me.statusText)
        Me.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelBottom.Location = New System.Drawing.Point(300, 535)
        Me.panelBottom.Name = "panelBottom"
        Me.panelBottom.PANEL_CLOSED_STATE_DIM = 40
        Me.panelBottom.PANEL_OPEN_STATE_DIM = 400
        Me.panelBottom.Size = New System.Drawing.Size(713, 26)
        Me.panelBottom.TabIndex = 1
        '
        'statusText
        '
        Me.statusText.Dock = System.Windows.Forms.DockStyle.Fill
        Me.statusText.Font = New System.Drawing.Font("Trajan Pro", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.statusText.ForeColor = System.Drawing.Color.White
        Me.statusText.Location = New System.Drawing.Point(0, 0)
        Me.statusText.Name = "statusText"
        Me.statusText.Size = New System.Drawing.Size(713, 26)
        Me.statusText.TabIndex = 0
        Me.statusText.Text = "status message"
        Me.statusText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'panelLateralMenuContainer
        '
        Me.panelLateralMenuContainer.AutoSize = True
        Me.panelLateralMenuContainer.BackColor = System.Drawing.Color.Transparent
        Me.panelLateralMenuContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelLateralMenuContainer.Location = New System.Drawing.Point(0, 0)
        Me.panelLateralMenuContainer.Name = "panelLateralMenuContainer"
        Me.panelLateralMenuContainer.PANEL_CLOSED_STATE_DIM = 40
        Me.panelLateralMenuContainer.PANEL_OPEN_STATE_DIM = 400
        Me.panelLateralMenuContainer.Size = New System.Drawing.Size(300, 561)
        Me.panelLateralMenuContainer.TabIndex = 2
        '
        'iconMenuSettings
        '
        Me.iconMenuSettings.BackColor = System.Drawing.Color.Transparent
        Me.iconMenuSettings.Cursor = System.Windows.Forms.Cursors.Hand
        Me.iconMenuSettings.IconChar = FontAwesome.Sharp.IconChar.Cog
        Me.iconMenuSettings.IconColor = System.Drawing.Color.White
        Me.iconMenuSettings.IconSize = 30
        Me.iconMenuSettings.Location = New System.Drawing.Point(12, 3)
        Me.iconMenuSettings.Name = "iconMenuSettings"
        Me.iconMenuSettings.Size = New System.Drawing.Size(30, 30)
        Me.iconMenuSettings.TabIndex = 1
        Me.iconMenuSettings.TabStop = False
        '
        'menuIconPic
        '
        Me.menuIconPic.BackColor = System.Drawing.Color.Transparent
        Me.menuIconPic.Cursor = System.Windows.Forms.Cursors.Hand
        Me.menuIconPic.IconChar = FontAwesome.Sharp.IconChar.Bars
        Me.menuIconPic.IconColor = System.Drawing.Color.White
        Me.menuIconPic.IconSize = 30
        Me.menuIconPic.Location = New System.Drawing.Point(262, 3)
        Me.menuIconPic.Name = "menuIconPic"
        Me.menuIconPic.Size = New System.Drawing.Size(30, 30)
        Me.menuIconPic.TabIndex = 0
        Me.menuIconPic.TabStop = False
        '
        'PanelLateralWrapper
        '
        Me.PanelLateralWrapper.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PanelLateralWrapper.BackColor = System.Drawing.Color.Transparent
        Me.PanelLateralWrapper.Controls.Add(Me.lateralPanelMenuOptionContainer)
        Me.PanelLateralWrapper.Controls.Add(Me.lateralPanelMenuOptions)
        Me.PanelLateralWrapper.Controls.Add(Me.lateralPanelMenuWrapper)
        Me.PanelLateralWrapper.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelLateralWrapper.Location = New System.Drawing.Point(0, 0)
        Me.PanelLateralWrapper.Name = "PanelLateralWrapper"
        Me.PanelLateralWrapper.PANEL_CLOSED_STATE_DIM = 40
        Me.PanelLateralWrapper.PANEL_OPEN_STATE_DIM = 400
        Me.PanelLateralWrapper.Size = New System.Drawing.Size(300, 561)
        Me.PanelLateralWrapper.TabIndex = 3
        '
        'lateralPanelMenuOptionContainer
        '
        Me.lateralPanelMenuOptionContainer.Dock = System.Windows.Forms.DockStyle.Top
        Me.lateralPanelMenuOptionContainer.Location = New System.Drawing.Point(0, 33)
        Me.lateralPanelMenuOptionContainer.Name = "lateralPanelMenuOptionContainer"
        Me.lateralPanelMenuOptionContainer.PANEL_CLOSED_STATE_DIM = 40
        Me.lateralPanelMenuOptionContainer.PANEL_OPEN_STATE_DIM = 400
        Me.lateralPanelMenuOptionContainer.Size = New System.Drawing.Size(300, 54)
        Me.lateralPanelMenuOptionContainer.TabIndex = 3
        '
        'lateralPanelMenuWrapper
        '
        Me.lateralPanelMenuWrapper.Controls.Add(Me.panelLateralMenuContainer)
        Me.lateralPanelMenuWrapper.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lateralPanelMenuWrapper.Location = New System.Drawing.Point(0, 0)
        Me.lateralPanelMenuWrapper.Name = "lateralPanelMenuWrapper"
        Me.lateralPanelMenuWrapper.PANEL_CLOSED_STATE_DIM = 40
        Me.lateralPanelMenuWrapper.PANEL_OPEN_STATE_DIM = 400
        Me.lateralPanelMenuWrapper.Size = New System.Drawing.Size(300, 561)
        Me.lateralPanelMenuWrapper.TabIndex = 4
        '
        'lateralPanelMenuOptions
        '
        Me.lateralPanelMenuOptions.Controls.Add(Me.menuIconPic)
        Me.lateralPanelMenuOptions.Controls.Add(Me.iconMenuSettings)
        Me.lateralPanelMenuOptions.Dock = System.Windows.Forms.DockStyle.Top
        Me.lateralPanelMenuOptions.Location = New System.Drawing.Point(0, 0)
        Me.lateralPanelMenuOptions.Name = "lateralPanelMenuOptions"
        Me.lateralPanelMenuOptions.PANEL_CLOSED_STATE_DIM = 40
        Me.lateralPanelMenuOptions.PANEL_OPEN_STATE_DIM = 400
        Me.lateralPanelMenuOptions.Size = New System.Drawing.Size(300, 33)
        Me.lateralPanelMenuOptions.TabIndex = 3
        '
        'panelMain
        '
        Me.panelMain.AutoScroll = True
        Me.panelMain.BackColor = System.Drawing.Color.Transparent
        Me.panelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelMain.Location = New System.Drawing.Point(300, 0)
        Me.panelMain.Name = "panelMain"
        Me.panelMain.PANEL_CLOSED_STATE_DIM = 40
        Me.panelMain.PANEL_OPEN_STATE_DIM = 400
        Me.panelMain.Size = New System.Drawing.Size(713, 535)
        Me.panelMain.TabIndex = 4
        '
        'panelTop
        '
        Me.panelTop.BackColor = System.Drawing.Color.Transparent
        Me.panelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelTop.Location = New System.Drawing.Point(300, 0)
        Me.panelTop.Name = "panelTop"
        Me.panelTop.PANEL_CLOSED_STATE_DIM = 40
        Me.panelTop.PANEL_OPEN_STATE_DIM = 400
        Me.panelTop.Size = New System.Drawing.Size(713, 33)
        Me.panelTop.TabIndex = 5
        '
        'ColorWithAlpha1
        '
        Me.ColorWithAlpha1.Alpha = 80
        Me.ColorWithAlpha1.Color = System.Drawing.Color.White
        '
        'mainAppLayoutForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1013, 561)
        Me.Controls.Add(Me.panelTop)
        Me.Controls.Add(Me.panelMain)
        Me.Controls.Add(Me.panelBottom)
        Me.Controls.Add(Me.PanelLateralWrapper)
        Me.MinimumSize = New System.Drawing.Size(950, 600)
        Me.Name = "mainAppLayoutForm"
        Me.Opacity = 0.999R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TargetOpacity = 1.0R
        Me.Text = "MainApp"
        Me.TransparencyKey = System.Drawing.Color.Silver
        Me.panelBottom.ResumeLayout(False)
        CType(Me.iconMenuSettings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.menuIconPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelLateralWrapper.ResumeLayout(False)
        Me.lateralPanelMenuWrapper.ResumeLayout(False)
        Me.lateralPanelMenuWrapper.PerformLayout()
        Me.lateralPanelMenuOptions.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panelBottom As PanelDoubleBuffer
    Friend WithEvents panelLateralMenuContainer As PanelDoubleBuffer
    Friend WithEvents statusText As LabelDoubleBuffer
    Friend WithEvents PanelLateralWrapper As PanelDoubleBuffer
    Friend WithEvents panelMain As PanelDoubleBuffer
    Friend WithEvents panelTop As PanelDoubleBuffer
    Friend WithEvents menuIconPic As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents iconMenuSettings As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents lateralPanelMenuOptions As PanelDoubleBuffer
    Friend WithEvents lateralPanelMenuWrapper As PanelDoubleBuffer
    Friend WithEvents lateralPanelMenuOptionContainer As PanelDoubleBuffer
    Friend WithEvents ColorWithAlpha1 As BlueActivity.ColorWithAlpha
End Class
