using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace AeonLabs.PlugIns.SideBar.Settings
{
    [DesignerGenerated()]
    public partial class lateralSettingsForm : FormCustomized
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
            this.components = new System.ComponentModel.Container();
            this.ColorPickerDialog = new System.Windows.Forms.ColorDialog();
            this.ToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.selectBackGroundImage = new FontAwesome.Sharp.IconPictureBox();
            this.selectPanelBackColor = new FontAwesome.Sharp.IconPictureBox();
            this.panelForm = new PanelDoubleBuffer();
            this.trackBar = new TrackBarTransparent();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.selectBackGroundImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectPanelBackColor)).BeginInit();
            this.panelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // selectBackGroundImage
            // 
            this.selectBackGroundImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectBackGroundImage.BackColor = System.Drawing.Color.Transparent;
            this.selectBackGroundImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectBackGroundImage.IconChar = FontAwesome.Sharp.IconChar.FirefoxBrowser;
            this.selectBackGroundImage.IconColor = System.Drawing.Color.White;
            this.selectBackGroundImage.IconSize = 23;
            this.selectBackGroundImage.Location = new System.Drawing.Point(53, 85);
            this.selectBackGroundImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.selectBackGroundImage.Name = "selectBackGroundImage";
            this.selectBackGroundImage.Size = new System.Drawing.Size(23, 23);
            this.selectBackGroundImage.TabIndex = 3;
            this.selectBackGroundImage.TabStop = false;
            this.selectBackGroundImage.Click += new System.EventHandler(this.selectBackGroundImage_Click_1);
            // 
            // selectPanelBackColor
            // 
            this.selectPanelBackColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectPanelBackColor.BackColor = System.Drawing.Color.Transparent;
            this.selectPanelBackColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectPanelBackColor.IconChar = FontAwesome.Sharp.IconChar.Faucet;
            this.selectPanelBackColor.IconColor = System.Drawing.Color.White;
            this.selectPanelBackColor.IconSize = 23;
            this.selectPanelBackColor.Location = new System.Drawing.Point(13, 85);
            this.selectPanelBackColor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.selectPanelBackColor.Name = "selectPanelBackColor";
            this.selectPanelBackColor.Size = new System.Drawing.Size(23, 23);
            this.selectPanelBackColor.TabIndex = 2;
            this.selectPanelBackColor.TabStop = false;
            this.selectPanelBackColor.Click += new System.EventHandler(this.selectPanelBackColor_Click_1);
            // 
            // panelForm
            // 
            this.panelForm.Controls.Add(this.trackBar);
            this.panelForm.Controls.Add(this.selectBackGroundImage);
            this.panelForm.Controls.Add(this.selectPanelBackColor);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForm.Location = new System.Drawing.Point(0, 0);
            this.panelForm.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelForm.Name = "panelForm";
            this.panelForm.PANEL_CLOSED_STATE_DIM = 40;
            this.panelForm.PANEL_OPEN_STATE_DIM = 400;
            this.panelForm.SB_BOTH = 3;
            this.panelForm.SB_CTL = 2;
            this.panelForm.SB_HORZ = 0;
            this.panelForm.SB_VERT = 0;
            this.panelForm.ShowHorizontalScrolBar = false;
            this.panelForm.ShowVerticalScrolBar = false;
            this.panelForm.Size = new System.Drawing.Size(467, 120);
            this.panelForm.TabIndex = 356;
            // 
            // trackBar
            // 
            this.trackBar.BackColor = System.Drawing.Color.Transparent;
            this.trackBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.trackBar.Location = new System.Drawing.Point(0, 0);
            this.trackBar.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.trackBar.Maximum = 100;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(467, 45);
            this.trackBar.TabIndex = 4;
            this.trackBar.ValueChanged += new System.EventHandler(this.trackBar_ValueChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lateralSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(467, 120);
            this.ControlBox = false;
            this.Controls.Add(this.panelForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "lateralSettingsForm";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TargetOpacity = 1D;
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.Silver;
            ((System.ComponentModel.ISupportInitialize)(this.selectBackGroundImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectPanelBackColor)).EndInit();
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);

        }

        private FontAwesome.Sharp.IconPictureBox selectPanelBackColor;
        private ColorDialog ColorPickerDialog;
        private FontAwesome.Sharp.IconPictureBox selectBackGroundImage;
        private ToolTip ToolTips;
        private PanelDoubleBuffer panelForm;
        private TrackBarTransparent trackBar;
        private OpenFileDialog openFileDialog1;
    }
}