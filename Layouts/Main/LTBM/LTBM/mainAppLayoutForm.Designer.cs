using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace AeonLabs.Layouts.Main
{
    [DesignerGenerated()]
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(mainAppLayoutForm));
            _panelBottom = new PanelDoubleBuffer();
            _statusText = new LabelDoubleBuffer();
            _statusText.Click += statusText_Click;
            _iconMenuSettings = new FontAwesome.Sharp.IconPictureBox();
            _iconMenuSettings.Click += new EventHandler(iconMenuSettings_Click_1);
            _menuToggleIcon = new FontAwesome.Sharp.IconPictureBox();
            _menuToggleIcon.Click += new EventHandler(menuIconPic_Click_1);
            _panelLeftSide = new PanelDoubleBuffer();
            _panelLeftSide.Resize += panelLateralWrapper_Resize;
            _panelMenuOptionsContainer = new PanelDoubleBuffer();
            _panelMenuOptions = new PanelDoubleBuffer();
            _panelMain = new PanelDoubleBuffer();
            _panelTop = new PanelDoubleBuffer();
            _panelTop.Paint += panelTop_Paint;
            _panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_iconMenuSettings).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_menuToggleIcon).BeginInit();
            _panelLeftSide.SuspendLayout();
            _panelMenuOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            _panelBottom.BackColor = Color.Transparent;
            _panelBottom.Controls.Add(_statusText);
            _panelBottom.Dock = DockStyle.Bottom;
            _panelBottom.Location = new Point(300, 535);
            _panelBottom.Name = "_panelBottom";
            _panelBottom.PANEL_CLOSED_STATE_DIM = 40;
            _panelBottom.PANEL_OPEN_STATE_DIM = 400;
            _panelBottom.SB_BOTH = 3;
            _panelBottom.SB_CTL = 2;
            _panelBottom.SB_HORZ = 0;
            _panelBottom.SB_VERT = 0;
            _panelBottom.ShowHorizontalScrolBar = false;
            _panelBottom.ShowVerticalScrolBar = false;
            _panelBottom.Size = new Size(713, 26);
            _panelBottom.TabIndex = 1;
            // 
            // statusText
            // 
            _statusText.Dock = DockStyle.Fill;
            _statusText.Font = new Font("Trajan Pro", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _statusText.ForeColor = Color.White;
            _statusText.Location = new Point(0, 0);
            _statusText.Name = "_statusText";
            _statusText.Size = new Size(713, 26);
            _statusText.TabIndex = 0;
            _statusText.Text = "status message";
            _statusText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // iconMenuSettings
            // 
            _iconMenuSettings.BackColor = Color.Transparent;
            _iconMenuSettings.Cursor = Cursors.Hand;
            _iconMenuSettings.IconChar = FontAwesome.Sharp.IconChar.Cog;
            _iconMenuSettings.IconColor = Color.White;
            _iconMenuSettings.IconSize = 30;
            _iconMenuSettings.Location = new Point(12, 3);
            _iconMenuSettings.Name = "_iconMenuSettings";
            _iconMenuSettings.Size = new Size(30, 30);
            _iconMenuSettings.TabIndex = 1;
            _iconMenuSettings.TabStop = false;
            // 
            // menuToggleIcon
            // 
            _menuToggleIcon.BackColor = Color.Transparent;
            _menuToggleIcon.Cursor = Cursors.Hand;
            _menuToggleIcon.IconChar = FontAwesome.Sharp.IconChar.Bars;
            _menuToggleIcon.IconColor = Color.White;
            _menuToggleIcon.IconSize = 25;
            _menuToggleIcon.Location = new Point(262, 3);
            _menuToggleIcon.Name = "_menuToggleIcon";
            _menuToggleIcon.Size = new Size(25, 25);
            _menuToggleIcon.TabIndex = 0;
            _menuToggleIcon.TabStop = false;
            // 
            // panelLeftSide
            // 
            _panelLeftSide.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _panelLeftSide.BackColor = Color.Transparent;
            _panelLeftSide.Controls.Add(_panelMenuOptionsContainer);
            _panelLeftSide.Controls.Add(_panelMenuOptions);
            _panelLeftSide.Dock = DockStyle.Left;
            _panelLeftSide.Location = new Point(0, 0);
            _panelLeftSide.Name = "_panelLeftSide";
            _panelLeftSide.PANEL_CLOSED_STATE_DIM = 40;
            _panelLeftSide.PANEL_OPEN_STATE_DIM = 400;
            _panelLeftSide.SB_BOTH = 3;
            _panelLeftSide.SB_CTL = 2;
            _panelLeftSide.SB_HORZ = 0;
            _panelLeftSide.SB_VERT = 0;
            _panelLeftSide.ShowHorizontalScrolBar = false;
            _panelLeftSide.ShowVerticalScrolBar = false;
            _panelLeftSide.Size = new Size(300, 561);
            _panelLeftSide.TabIndex = 3;
            // 
            // panelMenuOptionsContainer
            // 
            _panelMenuOptionsContainer.Dock = DockStyle.Top;
            _panelMenuOptionsContainer.Location = new Point(0, 33);
            _panelMenuOptionsContainer.Name = "_panelMenuOptionsContainer";
            _panelMenuOptionsContainer.PANEL_CLOSED_STATE_DIM = 40;
            _panelMenuOptionsContainer.PANEL_OPEN_STATE_DIM = 400;
            _panelMenuOptionsContainer.SB_BOTH = 3;
            _panelMenuOptionsContainer.SB_CTL = 2;
            _panelMenuOptionsContainer.SB_HORZ = 0;
            _panelMenuOptionsContainer.SB_VERT = 0;
            _panelMenuOptionsContainer.ShowHorizontalScrolBar = false;
            _panelMenuOptionsContainer.ShowVerticalScrolBar = false;
            _panelMenuOptionsContainer.Size = new Size(300, 54);
            _panelMenuOptionsContainer.TabIndex = 3;
            // 
            // panelMenuOptions
            // 
            _panelMenuOptions.BackColor = Color.Transparent;
            _panelMenuOptions.Controls.Add(_menuToggleIcon);
            _panelMenuOptions.Controls.Add(_iconMenuSettings);
            _panelMenuOptions.Dock = DockStyle.Top;
            _panelMenuOptions.Location = new Point(0, 0);
            _panelMenuOptions.Name = "_panelMenuOptions";
            _panelMenuOptions.PANEL_CLOSED_STATE_DIM = 40;
            _panelMenuOptions.PANEL_OPEN_STATE_DIM = 400;
            _panelMenuOptions.SB_BOTH = 3;
            _panelMenuOptions.SB_CTL = 2;
            _panelMenuOptions.SB_HORZ = 0;
            _panelMenuOptions.SB_VERT = 0;
            _panelMenuOptions.ShowHorizontalScrolBar = false;
            _panelMenuOptions.ShowVerticalScrolBar = false;
            _panelMenuOptions.Size = new Size(300, 33);
            _panelMenuOptions.TabIndex = 3;
            // 
            // panelMain
            // 
            _panelMain.AutoScroll = true;
            _panelMain.BackColor = Color.Transparent;
            _panelMain.Dock = DockStyle.Fill;
            _panelMain.Location = new Point(300, 33);
            _panelMain.Name = "_panelMain";
            _panelMain.PANEL_CLOSED_STATE_DIM = 40;
            _panelMain.PANEL_OPEN_STATE_DIM = 400;
            _panelMain.SB_BOTH = 3;
            _panelMain.SB_CTL = 2;
            _panelMain.SB_HORZ = 0;
            _panelMain.SB_VERT = 0;
            _panelMain.ShowHorizontalScrolBar = false;
            _panelMain.ShowVerticalScrolBar = false;
            _panelMain.Size = new Size(713, 502);
            _panelMain.TabIndex = 4;
            // 
            // panelTop
            // 
            _panelTop.BackColor = Color.Transparent;
            _panelTop.Dock = DockStyle.Top;
            _panelTop.Location = new Point(300, 0);
            _panelTop.Name = "_panelTop";
            _panelTop.PANEL_CLOSED_STATE_DIM = 40;
            _panelTop.PANEL_OPEN_STATE_DIM = 400;
            _panelTop.SB_BOTH = 3;
            _panelTop.SB_CTL = 2;
            _panelTop.SB_HORZ = 0;
            _panelTop.SB_VERT = 0;
            _panelTop.ShowHorizontalScrolBar = false;
            _panelTop.ShowVerticalScrolBar = false;
            _panelTop.Size = new Size(713, 33);
            _panelTop.TabIndex = 5;
            // 
            // mainAppLayoutForm
            // 
            this.AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.DarkRed;
            this.BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.ClientSize = new Size(1013, 561);
            this.Controls.Add(_panelMain);
            this.Controls.Add(_panelTop);
            this.Controls.Add(_panelBottom);
            this.Controls.Add(_panelLeftSide);
            this.MinimumSize = new Size(950, 600);
            this.Name = "mainAppLayoutForm";
            this.Opacity = 0.15000000000000002D;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.TargetOpacity = 1.0D;
            this.Text = "MainApp";
            _panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_iconMenuSettings).EndInit();
            ((System.ComponentModel.ISupportInitialize)_menuToggleIcon).EndInit();
            _panelLeftSide.ResumeLayout(false);
            _panelMenuOptions.ResumeLayout(false);
            this.FormClosing += MyForm_FormClosing;
            this.Load += Form1_Load;
            this.Shown += Form1_shown;
            this.Resize += Form1_Resize;
            this.FormClosing += Form1_FormClosing;
            this.MouseWheel += Form1_MouseWheel;
            this.ResumeLayout(false);
        }

        private PanelDoubleBuffer _panelBottom;

        internal PanelDoubleBuffer panelBottom
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _panelBottom;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_panelBottom != null)
                {
                }

                _panelBottom = value;
                if (_panelBottom != null)
                {
                }
            }
        }

        private LabelDoubleBuffer _statusText;

        internal LabelDoubleBuffer statusText
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _statusText;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_statusText != null)
                {
                    _statusText.Click -= statusText_Click;
                }

                _statusText = value;
                if (_statusText != null)
                {
                    _statusText.Click += statusText_Click;
                }
            }
        }

        private PanelDoubleBuffer _panelLeftSide;

        internal PanelDoubleBuffer panelLeftSide
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _panelLeftSide;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_panelLeftSide != null)
                {
                    _panelLeftSide.Resize -= panelLateralWrapper_Resize;
                }

                _panelLeftSide = value;
                if (_panelLeftSide != null)
                {
                    _panelLeftSide.Resize += panelLateralWrapper_Resize;
                }
            }
        }

        private PanelDoubleBuffer _panelMain;

        internal PanelDoubleBuffer panelMain
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _panelMain;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_panelMain != null)
                {
                }

                _panelMain = value;
                if (_panelMain != null)
                {
                }
            }
        }

        private PanelDoubleBuffer _panelTop;

        internal PanelDoubleBuffer panelTop
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _panelTop;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_panelTop != null)
                {
                    _panelTop.Paint -= panelTop_Paint;
                }

                _panelTop = value;
                if (_panelTop != null)
                {
                    _panelTop.Paint += panelTop_Paint;
                }
            }
        }

        private FontAwesome.Sharp.IconPictureBox _menuToggleIcon;

        internal FontAwesome.Sharp.IconPictureBox menuToggleIcon
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _menuToggleIcon;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_menuToggleIcon != null)
                {
                    _menuToggleIcon.Click -= menuIconPic_Click_1;
                }

                _menuToggleIcon = value;
                if (_menuToggleIcon != null)
                {
                    _menuToggleIcon.Click += menuIconPic_Click_1;
                }
            }
        }

        private FontAwesome.Sharp.IconPictureBox _iconMenuSettings;

        internal FontAwesome.Sharp.IconPictureBox iconMenuSettings
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _iconMenuSettings;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_iconMenuSettings != null)
                {
                    _iconMenuSettings.Click -= iconMenuSettings_Click_1;
                }

                _iconMenuSettings = value;
                if (_iconMenuSettings != null)
                {
                    _iconMenuSettings.Click += iconMenuSettings_Click_1;
                }
            }
        }

        private PanelDoubleBuffer _panelMenuOptions;

        internal PanelDoubleBuffer panelMenuOptions
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _panelMenuOptions;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_panelMenuOptions != null)
                {
                }

                _panelMenuOptions = value;
                if (_panelMenuOptions != null)
                {
                }
            }
        }

        private PanelDoubleBuffer _panelMenuOptionsContainer;

        internal PanelDoubleBuffer panelMenuOptionsContainer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _panelMenuOptionsContainer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_panelMenuOptionsContainer != null)
                {
                }

                _panelMenuOptionsContainer = value;
                if (_panelMenuOptionsContainer != null)
                {
                }
            }
        }
    }
}