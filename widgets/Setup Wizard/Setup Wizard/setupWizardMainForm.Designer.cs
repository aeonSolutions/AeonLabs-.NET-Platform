using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace ConstructionSiteLogistics.Setup.Gui2
{
    [DesignerGenerated()]
    public partial class setupWizardMainForm : FormCustomized
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
            components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(setupWizardMainForm));
            _AlphaGradientPanel1 = new BlueActivity.AlphaGradientPanel();
            _AlphaGradientPanel1.Paint += AlphaGradientPanel1_Paint;
            _ColorWithAlpha1 = new BlueActivity.ColorWithAlpha();
            _Panel1 = new Panel();
            _Panel1.Paint += new PaintEventHandler(Panel1_Paint_1);
            _forwardPicBtn = new PictureBox();
            _forwardPicBtn.Click += new EventHandler(forwardPicBtn_Click_1);
            _Panel2 = new Panel();
            _backPicBtn = new PictureBox();
            _backPicBtn.Click += new EventHandler(backPicBtn_Click_1);
            _PanelMain = new Panel();
            _PanelMain.Paint += new PaintEventHandler(PanelMain_Paint);
            _PanelBottom = new Panel();
            _PanelBottom.Paint += new PaintEventHandler(PanelBottom_Paint);
            _PanelTop = new Panel();
            _title = new ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer();
            _title.Click += title_Click;
            _subtitle = new ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer();
            _ColorWithAlpha2 = new BlueActivity.ColorWithAlpha();
            _FadeInTimer = new Timer(components);
            _FadeInTimer.Tick += new EventHandler(FadeInTimer_Tick);
            _AlphaGradientPanel1.SuspendLayout();
            _Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_forwardPicBtn).BeginInit();
            _Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_backPicBtn).BeginInit();
            _PanelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // AlphaGradientPanel1
            // 
            _AlphaGradientPanel1.BackColor = System.Drawing.Color.Transparent;
            _AlphaGradientPanel1.Border = true;
            _AlphaGradientPanel1.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            _AlphaGradientPanel1.Colors.Add(_ColorWithAlpha1);
            _AlphaGradientPanel1.ContentPadding = new Padding(0);
            _AlphaGradientPanel1.Controls.Add(_Panel1);
            _AlphaGradientPanel1.Controls.Add(_Panel2);
            _AlphaGradientPanel1.Controls.Add(_PanelMain);
            _AlphaGradientPanel1.Controls.Add(_PanelBottom);
            _AlphaGradientPanel1.Controls.Add(_PanelTop);
            _AlphaGradientPanel1.CornerRadius = 25;
            _AlphaGradientPanel1.Corners = (BlueActivity.Corner)(BlueActivity.Corner.TopLeft | BlueActivity.Corner.TopRight | BlueActivity.Corner.BottomLeft | BlueActivity.Corner.BottomRight);

            _AlphaGradientPanel1.Dock = DockStyle.Fill;
            _AlphaGradientPanel1.Gradient = false;
            _AlphaGradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            _AlphaGradientPanel1.GradientOffset = 1.0F;
            _AlphaGradientPanel1.GradientSize = new System.Drawing.Size(0, 0);
            _AlphaGradientPanel1.GradientWrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            _AlphaGradientPanel1.Grayscale = false;
            _AlphaGradientPanel1.Image = null;
            _AlphaGradientPanel1.ImageAlpha = 75;
            _AlphaGradientPanel1.ImagePadding = new Padding(5);
            _AlphaGradientPanel1.ImagePosition = BlueActivity.ImagePosition.BottomRight;
            _AlphaGradientPanel1.ImageSize = new System.Drawing.Size(48, 48);
            _AlphaGradientPanel1.Location = new System.Drawing.Point(5, 5);
            _AlphaGradientPanel1.Margin = new Padding(1);
            _AlphaGradientPanel1.Name = "_AlphaGradientPanel1";
            _AlphaGradientPanel1.Rounded = true;
            _AlphaGradientPanel1.Size = new System.Drawing.Size(935, 500);
            _AlphaGradientPanel1.TabIndex = 3;
            // 
            // ColorWithAlpha1
            // 
            _ColorWithAlpha1.Alpha = 255;
            _ColorWithAlpha1.Color = System.Drawing.Color.WhiteSmoke;
            _ColorWithAlpha1.Parent = _AlphaGradientPanel1;
            // 
            // Panel1
            // 
            _Panel1.Controls.Add(_forwardPicBtn);
            _Panel1.Dock = DockStyle.Right;
            _Panel1.Location = new System.Drawing.Point(891, 71);
            _Panel1.Margin = new Padding(1);
            _Panel1.Name = "_Panel1";
            _Panel1.Size = new System.Drawing.Size(44, 408);
            _Panel1.TabIndex = 12;
            // 
            // forwardPicBtn
            // 
            _forwardPicBtn.Cursor = Cursors.Hand;
            _forwardPicBtn.Image = (System.Drawing.Image)resources.GetObject("forwardPicBtn.Image");
            _forwardPicBtn.Location = new System.Drawing.Point(17, 210);
            _forwardPicBtn.Margin = new Padding(2);
            _forwardPicBtn.Name = "_forwardPicBtn";
            _forwardPicBtn.Size = new System.Drawing.Size(14, 29);
            _forwardPicBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            _forwardPicBtn.TabIndex = 1;
            _forwardPicBtn.TabStop = false;
            // 
            // Panel2
            // 
            _Panel2.Controls.Add(_backPicBtn);
            _Panel2.Dock = DockStyle.Left;
            _Panel2.Location = new System.Drawing.Point(0, 71);
            _Panel2.Margin = new Padding(2);
            _Panel2.Name = "_Panel2";
            _Panel2.Size = new System.Drawing.Size(39, 408);
            _Panel2.TabIndex = 13;
            // 
            // backPicBtn
            // 
            _backPicBtn.Cursor = Cursors.Hand;
            _backPicBtn.Image = (System.Drawing.Image)resources.GetObject("backPicBtn.Image");
            _backPicBtn.Location = new System.Drawing.Point(8, 210);
            _backPicBtn.Margin = new Padding(2);
            _backPicBtn.Name = "_backPicBtn";
            _backPicBtn.Size = new System.Drawing.Size(14, 29);
            _backPicBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            _backPicBtn.TabIndex = 0;
            _backPicBtn.TabStop = false;
            // 
            // PanelMain
            // 
            _PanelMain.Location = new System.Drawing.Point(341, 165);
            _PanelMain.Margin = new Padding(1);
            _PanelMain.Name = "_PanelMain";
            _PanelMain.Size = new System.Drawing.Size(200, 155);
            _PanelMain.TabIndex = 11;
            // 
            // PanelBottom
            // 
            _PanelBottom.Dock = DockStyle.Bottom;
            _PanelBottom.Location = new System.Drawing.Point(0, 479);
            _PanelBottom.Margin = new Padding(1);
            _PanelBottom.Name = "_PanelBottom";
            _PanelBottom.Size = new System.Drawing.Size(935, 21);
            _PanelBottom.TabIndex = 10;
            // 
            // PanelTop
            // 
            _PanelTop.Controls.Add(_title);
            _PanelTop.Controls.Add(_subtitle);
            _PanelTop.Dock = DockStyle.Top;
            _PanelTop.Location = new System.Drawing.Point(0, 0);
            _PanelTop.Margin = new Padding(2);
            _PanelTop.Name = "_PanelTop";
            _PanelTop.Size = new System.Drawing.Size(935, 71);
            _PanelTop.TabIndex = 9;
            // 
            // title
            // 
            _title.BackColor = System.Drawing.Color.Transparent;
            _title.Dock = DockStyle.Top;
            _title.Font = new System.Drawing.Font("Trajan Pro", 22.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Conversions.ToByte(0));
            _title.ForeColor = System.Drawing.Color.Black;
            _title.Location = new System.Drawing.Point(0, 0);
            _title.Name = "_title";
            _title.Size = new System.Drawing.Size(935, 47);
            _title.TabIndex = 0;
            _title.Text = "Setup is Complete";
            _title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // subtitle
            // 
            _subtitle.Dock = DockStyle.Bottom;
            _subtitle.Font = new System.Drawing.Font("Trajan Pro", 12.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Conversions.ToByte(0));
            _subtitle.ForeColor = System.Drawing.Color.Black;
            _subtitle.Location = new System.Drawing.Point(0, 37);
            _subtitle.Name = "_subtitle";
            _subtitle.Size = new System.Drawing.Size(935, 34);
            _subtitle.TabIndex = 1;
            _subtitle.Text = "To start the Desktop app click the button bellow";
            _subtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ColorWithAlpha2
            // 
            _ColorWithAlpha2.Alpha = 255;
            _ColorWithAlpha2.Color = System.Drawing.Color.Black;
            _ColorWithAlpha2.Parent = null;
            // 
            // FadeInTimer
            // 
            _FadeInTimer.Interval = 50;
            // 
            // setupWizardMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(978, 544);
            this.Controls.Add(_AlphaGradientPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "setupWizardMainForm";
            this.Opacity = 0.999D;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.TargetOpacity = 1.0D;
            this.TransparencyKey = System.Drawing.Color.Maroon;
            _AlphaGradientPanel1.ResumeLayout(false);
            _Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_forwardPicBtn).EndInit();
            _Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_backPicBtn).EndInit();
            _PanelTop.ResumeLayout(false);
            this.VisibleChanged += setupWizard_1_VisibleChanged;
            this.Load += setupWizard_0_frm_Load;
            this.ResumeLayout(false);
        }

        private BlueActivity.AlphaGradientPanel _AlphaGradientPanel1;

        internal BlueActivity.AlphaGradientPanel AlphaGradientPanel1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _AlphaGradientPanel1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_AlphaGradientPanel1 != null)
                {
                    _AlphaGradientPanel1.Paint -= AlphaGradientPanel1_Paint;
                }

                _AlphaGradientPanel1 = value;
                if (_AlphaGradientPanel1 != null)
                {
                    _AlphaGradientPanel1.Paint += AlphaGradientPanel1_Paint;
                }
            }
        }

        private BlueActivity.ColorWithAlpha _ColorWithAlpha1;

        internal BlueActivity.ColorWithAlpha ColorWithAlpha1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ColorWithAlpha1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ColorWithAlpha1 != null)
                {
                }

                _ColorWithAlpha1 = value;
                if (_ColorWithAlpha1 != null)
                {
                }
            }
        }

        private Panel _PanelBottom;

        internal Panel PanelBottom
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PanelBottom;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PanelBottom != null)
                {
                    _PanelBottom.Paint -= PanelBottom_Paint;
                }

                _PanelBottom = value;
                if (_PanelBottom != null)
                {
                    _PanelBottom.Paint += PanelBottom_Paint;
                }
            }
        }

        private Panel _PanelTop;

        internal Panel PanelTop
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PanelTop;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PanelTop != null)
                {
                }

                _PanelTop = value;
                if (_PanelTop != null)
                {
                }
            }
        }

        private Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer _title;

        public Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer title
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _title;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_title != null)
                {
                    _title.Click -= title_Click;
                }

                _title = value;
                if (_title != null)
                {
                    _title.Click += title_Click;
                }
            }
        }

        private Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer _subtitle;

        public Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer subtitle
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _subtitle;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_subtitle != null)
                {
                }

                _subtitle = value;
                if (_subtitle != null)
                {
                }
            }
        }

        private Timer _FadeInTimer;

        internal Timer FadeInTimer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _FadeInTimer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_FadeInTimer != null)
                {
                    _FadeInTimer.Tick -= FadeInTimer_Tick;
                }

                _FadeInTimer = value;
                if (_FadeInTimer != null)
                {
                    _FadeInTimer.Tick += FadeInTimer_Tick;
                }
            }
        }

        private Panel _Panel2;

        internal Panel Panel2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Panel2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Panel2 != null)
                {
                }

                _Panel2 = value;
                if (_Panel2 != null)
                {
                }
            }
        }

        private BlueActivity.ColorWithAlpha _ColorWithAlpha2;

        internal BlueActivity.ColorWithAlpha ColorWithAlpha2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ColorWithAlpha2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ColorWithAlpha2 != null)
                {
                }

                _ColorWithAlpha2 = value;
                if (_ColorWithAlpha2 != null)
                {
                }
            }
        }

        private PictureBox _backPicBtn;

        internal PictureBox backPicBtn
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _backPicBtn;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_backPicBtn != null)
                {
                    _backPicBtn.Click -= backPicBtn_Click_1;
                }

                _backPicBtn = value;
                if (_backPicBtn != null)
                {
                    _backPicBtn.Click += backPicBtn_Click_1;
                }
            }
        }

        private Panel _Panel1;

        internal Panel Panel1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Panel1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Panel1 != null)
                {
                    _Panel1.Paint -= Panel1_Paint_1;
                }

                _Panel1 = value;
                if (_Panel1 != null)
                {
                    _Panel1.Paint += Panel1_Paint_1;
                }
            }
        }

        private PictureBox _forwardPicBtn;

        internal PictureBox forwardPicBtn
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _forwardPicBtn;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_forwardPicBtn != null)
                {
                    _forwardPicBtn.Click -= forwardPicBtn_Click_1;
                }

                _forwardPicBtn = value;
                if (_forwardPicBtn != null)
                {
                    _forwardPicBtn.Click += forwardPicBtn_Click_1;
                }
            }
        }

        private Panel _PanelMain;

        internal Panel PanelMain
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PanelMain;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PanelMain != null)
                {
                    _PanelMain.Paint -= PanelMain_Paint;
                }

                _PanelMain = value;
                if (_PanelMain != null)
                {
                    _PanelMain.Paint += PanelMain_Paint;
                }
            }
        }
    }
}