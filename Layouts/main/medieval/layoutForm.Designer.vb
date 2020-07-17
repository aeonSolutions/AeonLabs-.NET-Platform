﻿

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
        Me.iconMenuSettings = New FontAwesome.Sharp.IconPictureBox()
        Me.menuIconPic = New FontAwesome.Sharp.IconPictureBox()
        Me.panelLeftSide = New PanelDoubleBuffer()
        Me.panelMenuOptionsContainer = New PanelDoubleBuffer()
        Me.panelMenuOptions = New PanelDoubleBuffer()
        Me.panelMain = New PanelDoubleBuffer()
        Me.panelTop = New PanelDoubleBuffer()
        Me.ColorWithAlpha1 = New BlueActivity.ColorWithAlpha()
        Me.panelSideMenuContainer = New PanelDoubleBuffer()
        Me.panelBottom.SuspendLayout()
        CType(Me.iconMenuSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.menuIconPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelLeftSide.SuspendLayout()
        Me.panelMenuOptions.SuspendLayout()
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
        'panelLeftSide
        '
        Me.panelLeftSide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panelLeftSide.BackColor = System.Drawing.Color.Transparent
        Me.panelLeftSide.Controls.Add(Me.panelMenuOptionsContainer)
        Me.panelLeftSide.Controls.Add(Me.panelSideMenuContainer)
        Me.panelLeftSide.Controls.Add(Me.panelMenuOptions)
        Me.panelLeftSide.Dock = System.Windows.Forms.DockStyle.Left
        Me.panelLeftSide.Location = New System.Drawing.Point(0, 0)
        Me.panelLeftSide.Name = "panelLeftSide"
        Me.panelLeftSide.PANEL_CLOSED_STATE_DIM = 40
        Me.panelLeftSide.PANEL_OPEN_STATE_DIM = 400
        Me.panelLeftSide.Size = New System.Drawing.Size(300, 561)
        Me.panelLeftSide.TabIndex = 3
        '
        'panelMenuOptionsContainer
        '
        Me.panelMenuOptionsContainer.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelMenuOptionsContainer.Location = New System.Drawing.Point(0, 33)
        Me.panelMenuOptionsContainer.Name = "panelMenuOptionsContainer"
        Me.panelMenuOptionsContainer.PANEL_CLOSED_STATE_DIM = 40
        Me.panelMenuOptionsContainer.PANEL_OPEN_STATE_DIM = 400
        Me.panelMenuOptionsContainer.Size = New System.Drawing.Size(300, 54)
        Me.panelMenuOptionsContainer.TabIndex = 3
        '
        'panelMenuOptions
        '
        Me.panelMenuOptions.BackColor = System.Drawing.Color.Transparent
        Me.panelMenuOptions.Controls.Add(Me.menuIconPic)
        Me.panelMenuOptions.Controls.Add(Me.iconMenuSettings)
        Me.panelMenuOptions.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelMenuOptions.Location = New System.Drawing.Point(0, 0)
        Me.panelMenuOptions.Name = "panelMenuOptions"
        Me.panelMenuOptions.PANEL_CLOSED_STATE_DIM = 40
        Me.panelMenuOptions.PANEL_OPEN_STATE_DIM = 400
        Me.panelMenuOptions.Size = New System.Drawing.Size(300, 33)
        Me.panelMenuOptions.TabIndex = 3
        '
        'panelMain
        '
        Me.panelMain.AutoScroll = True
        Me.panelMain.BackColor = System.Drawing.Color.Transparent
        Me.panelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelMain.Location = New System.Drawing.Point(300, 33)
        Me.panelMain.Name = "panelMain"
        Me.panelMain.PANEL_CLOSED_STATE_DIM = 40
        Me.panelMain.PANEL_OPEN_STATE_DIM = 400
        Me.panelMain.Size = New System.Drawing.Size(713, 502)
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
        Me.ColorWithAlpha1.Parent = Nothing
        '
        'panelSideMenuContainer
        '
        Me.panelSideMenuContainer.AutoSize = True
        Me.panelSideMenuContainer.BackColor = System.Drawing.Color.Transparent
        Me.panelSideMenuContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelSideMenuContainer.Location = New System.Drawing.Point(0, 33)
        Me.panelSideMenuContainer.Name = "panelSideMenuContainer"
        Me.panelSideMenuContainer.PANEL_CLOSED_STATE_DIM = 40
        Me.panelSideMenuContainer.PANEL_OPEN_STATE_DIM = 400
        Me.panelSideMenuContainer.Size = New System.Drawing.Size(300, 528)
        Me.panelSideMenuContainer.TabIndex = 2
        '
        'mainAppLayoutForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1013, 561)
        Me.Controls.Add(Me.panelMain)
        Me.Controls.Add(Me.panelTop)
        Me.Controls.Add(Me.panelBottom)
        Me.Controls.Add(Me.panelLeftSide)
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
        Me.panelLeftSide.ResumeLayout(False)
        Me.panelLeftSide.PerformLayout()
        Me.panelMenuOptions.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panelBottom As PanelDoubleBuffer
    Friend WithEvents statusText As LabelDoubleBuffer
    Friend WithEvents panelLeftSide As PanelDoubleBuffer
    Friend WithEvents panelMain As PanelDoubleBuffer
    Friend WithEvents panelTop As PanelDoubleBuffer
    Friend WithEvents menuIconPic As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents iconMenuSettings As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents panelMenuOptions As PanelDoubleBuffer
    Friend WithEvents panelMenuOptionsContainer As PanelDoubleBuffer
    Friend WithEvents ColorWithAlpha1 As BlueActivity.ColorWithAlpha
    Friend WithEvents panelSideMenuContainer As PanelDoubleBuffer
End Class
