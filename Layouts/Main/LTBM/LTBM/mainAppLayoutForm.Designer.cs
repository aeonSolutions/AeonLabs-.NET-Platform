using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace AeonLabs.Layouts.Main
{
    public partial class mainAppLayoutForm : FormCustomized
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is object)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainAppLayoutForm));
            this.panelBottom = new PanelDoubleBuffer();
            this.statusText = new LabelDoubleBuffer();
            this.iconMenuSettings = new FontAwesome.Sharp.IconPictureBox();
            this.panelLeftSide = new PanelDoubleBuffer();
            this.panelMenuOptionsContainer = new PanelDoubleBuffer();
            this.panelMenuOptions = new PanelDoubleBuffer();
            this.menuToggleIcon = new FontAwesome.Sharp.IconPictureBox();
            this.panelMain = new PanelDoubleBuffer();
            this.panelTop = new PanelDoubleBuffer();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconMenuSettings)).BeginInit();
            this.panelLeftSide.SuspendLayout();
            this.panelMenuOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuToggleIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.Transparent;
            this.panelBottom.Controls.Add(this.statusText);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(350, 617);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.PANEL_CLOSED_STATE_DIM = 40;
            this.panelBottom.PANEL_OPEN_STATE_DIM = 400;
            this.panelBottom.SB_BOTH = 3;
            this.panelBottom.SB_CTL = 2;
            this.panelBottom.SB_HORZ = 0;
            this.panelBottom.SB_VERT = 0;
            this.panelBottom.ShowHorizontalScrolBar = false;
            this.panelBottom.ShowVerticalScrolBar = false;
            this.panelBottom.Size = new System.Drawing.Size(832, 30);
            this.panelBottom.TabIndex = 1;
            // 
            // statusText
            // 
            this.statusText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusText.Font = new System.Drawing.Font("Trajan Pro", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.statusText.ForeColor = System.Drawing.Color.White;
            this.statusText.Location = new System.Drawing.Point(0, 0);
            this.statusText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusText.Name = "statusText";
            this.statusText.Size = new System.Drawing.Size(832, 30);
            this.statusText.TabIndex = 0;
            this.statusText.Text = "status message";
            this.statusText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // iconMenuSettings
            // 
            this.iconMenuSettings.BackColor = System.Drawing.Color.Transparent;
            this.iconMenuSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconMenuSettings.IconChar = FontAwesome.Sharp.IconChar.Ideal;
            this.iconMenuSettings.IconColor = System.Drawing.Color.White;
            this.iconMenuSettings.IconSize = 35;
            this.iconMenuSettings.Location = new System.Drawing.Point(14, 3);
            this.iconMenuSettings.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.iconMenuSettings.Name = "iconMenuSettings";
            this.iconMenuSettings.Size = new System.Drawing.Size(35, 35);
            this.iconMenuSettings.TabIndex = 1;
            this.iconMenuSettings.TabStop = false;
            this.iconMenuSettings.Click += new System.EventHandler(this.iconMenuSettings_Click);
            // 
            // panelLeftSide
            // 
            this.panelLeftSide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelLeftSide.BackColor = System.Drawing.Color.Transparent;
            this.panelLeftSide.Controls.Add(this.panelMenuOptionsContainer);
            this.panelLeftSide.Controls.Add(this.panelMenuOptions);
            this.panelLeftSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeftSide.Location = new System.Drawing.Point(0, 0);
            this.panelLeftSide.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelLeftSide.Name = "panelLeftSide";
            this.panelLeftSide.PANEL_CLOSED_STATE_DIM = 40;
            this.panelLeftSide.PANEL_OPEN_STATE_DIM = 400;
            this.panelLeftSide.SB_BOTH = 3;
            this.panelLeftSide.SB_CTL = 2;
            this.panelLeftSide.SB_HORZ = 0;
            this.panelLeftSide.SB_VERT = 0;
            this.panelLeftSide.ShowHorizontalScrolBar = false;
            this.panelLeftSide.ShowVerticalScrolBar = false;
            this.panelLeftSide.Size = new System.Drawing.Size(350, 647);
            this.panelLeftSide.TabIndex = 3;
            this.panelLeftSide.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLeftSide_Paint);
            // 
            // panelMenuOptionsContainer
            // 
            this.panelMenuOptionsContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenuOptionsContainer.Location = new System.Drawing.Point(0, 38);
            this.panelMenuOptionsContainer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelMenuOptionsContainer.Name = "panelMenuOptionsContainer";
            this.panelMenuOptionsContainer.PANEL_CLOSED_STATE_DIM = 40;
            this.panelMenuOptionsContainer.PANEL_OPEN_STATE_DIM = 400;
            this.panelMenuOptionsContainer.SB_BOTH = 3;
            this.panelMenuOptionsContainer.SB_CTL = 2;
            this.panelMenuOptionsContainer.SB_HORZ = 0;
            this.panelMenuOptionsContainer.SB_VERT = 0;
            this.panelMenuOptionsContainer.ShowHorizontalScrolBar = false;
            this.panelMenuOptionsContainer.ShowVerticalScrolBar = false;
            this.panelMenuOptionsContainer.Size = new System.Drawing.Size(350, 62);
            this.panelMenuOptionsContainer.TabIndex = 3;
            // 
            // panelMenuOptions
            // 
            this.panelMenuOptions.BackColor = System.Drawing.Color.Transparent;
            this.panelMenuOptions.Controls.Add(this.menuToggleIcon);
            this.panelMenuOptions.Controls.Add(this.iconMenuSettings);
            this.panelMenuOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenuOptions.Location = new System.Drawing.Point(0, 0);
            this.panelMenuOptions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelMenuOptions.Name = "panelMenuOptions";
            this.panelMenuOptions.PANEL_CLOSED_STATE_DIM = 40;
            this.panelMenuOptions.PANEL_OPEN_STATE_DIM = 400;
            this.panelMenuOptions.SB_BOTH = 3;
            this.panelMenuOptions.SB_CTL = 2;
            this.panelMenuOptions.SB_HORZ = 0;
            this.panelMenuOptions.SB_VERT = 0;
            this.panelMenuOptions.ShowHorizontalScrolBar = false;
            this.panelMenuOptions.ShowVerticalScrolBar = false;
            this.panelMenuOptions.Size = new System.Drawing.Size(350, 38);
            this.panelMenuOptions.TabIndex = 3;
            // 
            // menuToggleIcon
            // 
            this.menuToggleIcon.BackColor = System.Drawing.Color.Transparent;
            this.menuToggleIcon.IconChar = FontAwesome.Sharp.IconChar.Faucet;
            this.menuToggleIcon.IconColor = System.Drawing.Color.White;
            this.menuToggleIcon.Location = new System.Drawing.Point(311, 6);
            this.menuToggleIcon.Name = "menuToggleIcon";
            this.menuToggleIcon.Size = new System.Drawing.Size(32, 32);
            this.menuToggleIcon.TabIndex = 0;
            this.menuToggleIcon.TabStop = false;
            // 
            // panelMain
            // 
            this.panelMain.AutoScroll = true;
            this.panelMain.BackColor = System.Drawing.Color.Transparent;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(350, 38);
            this.panelMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelMain.Name = "panelMain";
            this.panelMain.PANEL_CLOSED_STATE_DIM = 40;
            this.panelMain.PANEL_OPEN_STATE_DIM = 400;
            this.panelMain.SB_BOTH = 3;
            this.panelMain.SB_CTL = 2;
            this.panelMain.SB_HORZ = 0;
            this.panelMain.SB_VERT = 0;
            this.panelMain.ShowHorizontalScrolBar = false;
            this.panelMain.ShowVerticalScrolBar = false;
            this.panelMain.Size = new System.Drawing.Size(832, 579);
            this.panelMain.TabIndex = 4;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Transparent;
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(350, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.PANEL_CLOSED_STATE_DIM = 40;
            this.panelTop.PANEL_OPEN_STATE_DIM = 400;
            this.panelTop.SB_BOTH = 3;
            this.panelTop.SB_CTL = 2;
            this.panelTop.SB_HORZ = 0;
            this.panelTop.SB_VERT = 0;
            this.panelTop.ShowHorizontalScrolBar = false;
            this.panelTop.ShowVerticalScrolBar = false;
            this.panelTop.Size = new System.Drawing.Size(832, 38);
            this.panelTop.TabIndex = 5;
            // 
            // mainAppLayoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1182, 647);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelLeftSide);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(1106, 686);
            this.Name = "mainAppLayoutForm";
            this.Opacity = 0.15000000000000002D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TargetOpacity = 1D;
            this.Text = "MainApp";
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconMenuSettings)).EndInit();
            this.panelLeftSide.ResumeLayout(false);
            this.panelMenuOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.menuToggleIcon)).EndInit();
            this.ResumeLayout(false);

        }

        private PanelDoubleBuffer panelBottom;
        private LabelDoubleBuffer statusText;
        private PanelDoubleBuffer panelLeftSide;
        private PanelDoubleBuffer panelMain;
        private PanelDoubleBuffer panelTop;
        private FontAwesome.Sharp.IconPictureBox iconMenuSettings;
        private PanelDoubleBuffer panelMenuOptions;
        private PanelDoubleBuffer panelMenuOptionsContainer;
        private FontAwesome.Sharp.IconPictureBox menuToggleIcon;
    }
}
