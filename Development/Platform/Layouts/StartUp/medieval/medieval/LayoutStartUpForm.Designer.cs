using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using BlueActivity.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace AeonLabs.Layouts.StartUp
{
    [DesignerGenerated()]
    public partial class LayoutStartUpForm : FormCustomized
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(LayoutStartUpForm));
            _VersionLabel = new LabelDoubleBuffer();
            _cancelCard_lbl = new LinkLabel();
            _cancelCard_lbl.LinkClicked += new LinkLabelLinkClickedEventHandler(cancelCard_lbl_LinkClicked);
            _statusMessage = new LabelDoubleBuffer();
            _titleLabel = new LabelDoubleBuffer();
            _locationLabel = new LabelDoubleBuffer();
            _quoteOfTheDaySentenceLabel = new LabelDoubleBuffer();
            _versionTitleLabel = new LabelDoubleBuffer();
            _TitleFlavourLabel = new LabelDoubleBuffer();
            _websiteLink = new LinkLabel();
            _websiteLink.LinkClicked += new LinkLabelLinkClickedEventHandler(websiteLink_LinkClicked);
            _progressbar = new CircularProgressBar.CircularProgress.CircularProgressBar();
            _panelLogin = new BlueActivity.Controls.AlphaGradientPanel();
            _ColorWithAlpha1 = new BlueActivity.Controls.ColorWithAlpha();
            _loginBtn = new PictureBox();
            _loginBtn.Click += new EventHandler(loginBtn_Click);
            _cardId_lbl = new LabelDoubleBuffer();
            _cardId = new TextBox();
            _access_code = new LabelDoubleBuffer();
            _codetxt = new MaskedTextBox();
            _codetxt.KeyPress += new KeyPressEventHandler(codetxt_KeyPress);
            _show_password = new PictureBox();
            _show_password.Click += new EventHandler(PictureBox1_Click);
            _PanelLocationText = new Panel();
            _locationTextTimer = new Timer(components);
            _locationTextTimer.Tick += new EventHandler(locationTextTimer_Tick);
            _animatedBackGround = new PictureBoxDoubleBuffer();
            _panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_loginBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_show_password).BeginInit();
            _PanelLocationText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_animatedBackGround).BeginInit();
            this.SuspendLayout();
            // 
            // VersionLabel
            // 
            _VersionLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _VersionLabel.BackColor = Color.Maroon;
            _VersionLabel.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _VersionLabel.ForeColor = Color.White;
            _VersionLabel.ImageAlign = ContentAlignment.BottomRight;
            _VersionLabel.Location = new Point(1076, 31);
            _VersionLabel.Margin = new Padding(0);
            _VersionLabel.Name = "_VersionLabel";
            _VersionLabel.Size = new Size(153, 21);
            _VersionLabel.TabIndex = 1;
            _VersionLabel.Text = "1.0.0";
            _VersionLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cancelCard_lbl
            // 
            _cancelCard_lbl.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cancelCard_lbl.AutoSize = true;
            _cancelCard_lbl.BackColor = Color.Maroon;
            _cancelCard_lbl.Cursor = Cursors.Hand;
            _cancelCard_lbl.Font = new Font("Trajan Pro", 10.0F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _cancelCard_lbl.LinkBehavior = LinkBehavior.NeverUnderline;
            _cancelCard_lbl.LinkColor = Color.White;
            _cancelCard_lbl.Location = new Point(1263, 658);
            _cancelCard_lbl.Margin = new Padding(2, 0, 2, 0);
            _cancelCard_lbl.Name = "_cancelCard_lbl";
            _cancelCard_lbl.Size = new Size(43, 18);
            _cancelCard_lbl.TabIndex = 342;
            _cancelCard_lbl.TabStop = true;
            _cancelCard_lbl.Text = "EXIT";
            // 
            // statusMessage
            // 
            _statusMessage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _statusMessage.BackColor = Color.Maroon;
            _statusMessage.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _statusMessage.ForeColor = Color.White;
            _statusMessage.Location = new Point(944, 248);
            _statusMessage.Margin = new Padding(2, 0, 2, 0);
            _statusMessage.Name = "_statusMessage";
            _statusMessage.Size = new Size(288, 44);
            _statusMessage.TabIndex = 3;
            _statusMessage.Text = "Loading files...";
            _statusMessage.TextAlign = ContentAlignment.TopRight;
            // 
            // titleLabel
            // 
            _titleLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _titleLabel.BackColor = Color.Maroon;
            _titleLabel.Font = new Font("Trajan Pro", 24.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _titleLabel.ForeColor = Color.White;
            _titleLabel.Location = new Point(938, 369);
            _titleLabel.Margin = new Padding(2, 0, 0, 0);
            _titleLabel.Name = "_titleLabel";
            _titleLabel.Size = new Size(296, 83);
            _titleLabel.TabIndex = 341;
            _titleLabel.Text = "Construction Site Logistics";
            _titleLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // locationLabel
            // 
            _locationLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _locationLabel.AutoSize = true;
            _locationLabel.BackColor = Color.Maroon;
            _locationLabel.Font = new Font("Trajan Pro", 10.0F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _locationLabel.ForeColor = Color.White;
            _locationLabel.Location = new Point(207, 0);
            _locationLabel.Margin = new Padding(2, 0, 2, 0);
            _locationLabel.Name = "_locationLabel";
            _locationLabel.Size = new Size(154, 18);
            _locationLabel.TabIndex = 342;
            _locationLabel.Text = "Brussels, Belgium";
            _locationLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // quoteOfTheDaySentenceLabel
            // 
            _quoteOfTheDaySentenceLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _quoteOfTheDaySentenceLabel.BackColor = Color.Maroon;
            _quoteOfTheDaySentenceLabel.Font = new Font("Trajan Pro", 10.0F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _quoteOfTheDaySentenceLabel.ForeColor = Color.White;
            _quoteOfTheDaySentenceLabel.Location = new Point(889, 522);
            _quoteOfTheDaySentenceLabel.Margin = new Padding(2, 0, 2, 0);
            _quoteOfTheDaySentenceLabel.Name = "_quoteOfTheDaySentenceLabel";
            _quoteOfTheDaySentenceLabel.Size = new Size(343, 81);
            _quoteOfTheDaySentenceLabel.TabIndex = 344;
            _quoteOfTheDaySentenceLabel.Text = "To be successful you've got to be willing to fail.";
            _quoteOfTheDaySentenceLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // versionTitleLabel
            // 
            _versionTitleLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _versionTitleLabel.BackColor = Color.Maroon;
            _versionTitleLabel.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _versionTitleLabel.ForeColor = Color.White;
            _versionTitleLabel.ImageAlign = ContentAlignment.BottomRight;
            _versionTitleLabel.Location = new Point(1076, 9);
            _versionTitleLabel.Margin = new Padding(0);
            _versionTitleLabel.Name = "_versionTitleLabel";
            _versionTitleLabel.Size = new Size(153, 22);
            _versionTitleLabel.TabIndex = 345;
            _versionTitleLabel.Text = "VERSION";
            _versionTitleLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // TitleFlavourLabel
            // 
            _TitleFlavourLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _TitleFlavourLabel.BackColor = Color.Maroon;
            _TitleFlavourLabel.Font = new Font("Trajan Pro", 14.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _TitleFlavourLabel.ForeColor = Color.White;
            _TitleFlavourLabel.Location = new Point(978, 454);
            _TitleFlavourLabel.Margin = new Padding(2, 0, 2, 0);
            _TitleFlavourLabel.Name = "_TitleFlavourLabel";
            _TitleFlavourLabel.Size = new Size(256, 23);
            _TitleFlavourLabel.TabIndex = 346;
            _TitleFlavourLabel.Text = "OFFICE";
            _TitleFlavourLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // websiteLink
            // 
            _websiteLink.AutoSize = true;
            _websiteLink.BackColor = Color.Maroon;
            _websiteLink.Cursor = Cursors.Hand;
            _websiteLink.Font = new Font("Trajan Pro", 8.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _websiteLink.LinkBehavior = LinkBehavior.NeverUnderline;
            _websiteLink.LinkColor = Color.White;
            _websiteLink.Location = new Point(1015, 477);
            _websiteLink.Margin = new Padding(2, 0, 2, 0);
            _websiteLink.Name = "_websiteLink";
            _websiteLink.Size = new Size(219, 14);
            _websiteLink.TabIndex = 350;
            _websiteLink.TabStop = true;
            _websiteLink.Text = "www.SiteLogistics.Construction";
            // 
            // progressbar
            // 
            _progressbar.BackColor = Color.Black;
            _progressbar.Bar1.ActiveColor = Color.White;
            _progressbar.Bar1.BorderColor = Color.DarkRed;
            _progressbar.Bar1.Enabled = true;
            _progressbar.Bar1.FinishColor = Color.Honeydew;
            _progressbar.Bar1.InactiveColor = Color.DarkGray;
            _progressbar.Bar2.ActiveColor = Color.LightSeaGreen;
            _progressbar.Bar2.BorderColor = Color.Black;
            _progressbar.Bar2.FinishColor = Color.LightGreen;
            _progressbar.Bar2.InactiveColor = Color.LightGray;
            _progressbar.Bar3.ActiveColor = Color.LightSeaGreen;
            _progressbar.Bar3.BorderColor = Color.Black;
            _progressbar.Bar3.FinishColor = Color.LightGreen;
            _progressbar.Bar3.InactiveColor = Color.LightGray;
            _progressbar.Bar4.ActiveColor = Color.LightSeaGreen;
            _progressbar.Bar4.BorderColor = Color.Black;
            _progressbar.Bar4.FinishColor = Color.LightGreen;
            _progressbar.Bar4.InactiveColor = Color.LightGray;
            _progressbar.Bar5.ActiveColor = Color.LightSeaGreen;
            _progressbar.Bar5.BorderColor = Color.Black;
            _progressbar.Bar5.FinishColor = Color.LightGreen;
            _progressbar.Bar5.InactiveColor = Color.LightGray;
            _progressbar.Font = new Font("Trajan Pro", 14.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _progressbar.ForeColor = Color.White;
            _progressbar.Image = null;
            _progressbar.Location = new Point(1123, 144);
            _progressbar.MinimumSize = new Size(20, 20);
            _progressbar.Name = "_progressbar";
            _progressbar.Size = new Size(100, 100);
            _progressbar.TabIndex = 351;
            _progressbar.TextShadowColor = Color.White;
            // 
            // panelLogin
            // 
            _panelLogin.BackColor = Color.Transparent;
            _panelLogin.Border = true;
            _panelLogin.BorderColor = Color.White;
            _panelLogin.Colors.Add(_ColorWithAlpha1);
            _panelLogin.ContentPadding = new Padding(0);
            _panelLogin.Controls.Add(_loginBtn);
            _panelLogin.Controls.Add(_cardId_lbl);
            _panelLogin.Controls.Add(_cardId);
            _panelLogin.Controls.Add(_access_code);
            _panelLogin.Controls.Add(_codetxt);
            _panelLogin.Controls.Add(_show_password);
            _panelLogin.CornerRadius = 45;
            _panelLogin.Corners = (BlueActivity.Controls.Corner)(BlueActivity.Controls.Corner.TopLeft | BlueActivity.Controls.Corner.BottomRight);
            _panelLogin.Gradient = false;
            _panelLogin.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            _panelLogin.GradientOffset = 1.0F;
            _panelLogin.GradientSize = new Size(0, 0);
            _panelLogin.GradientWrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            _panelLogin.Grayscale = false;
            _panelLogin.Image = null;
            _panelLogin.ImageAlpha = 100;
            _panelLogin.ImagePadding = new Padding(5);
            _panelLogin.ImagePosition = BlueActivity.Controls.ImagePosition.Center;
            _panelLogin.ImageSize = new Size(128, 128);
            _panelLogin.Location = new Point(485, 292);
            _panelLogin.Name = "_panelLogin";
            _panelLogin.RightToLeft = RightToLeft.Yes;
            _panelLogin.Rounded = true;
            _panelLogin.Size = new Size(231, 133);
            _panelLogin.TabIndex = 348;
            // 
            // ColorWithAlpha1
            // 
            _ColorWithAlpha1.Alpha = 150;
            _ColorWithAlpha1.Color = Color.Black;
            _ColorWithAlpha1.Parent = _panelLogin;
            // 
            // loginBtn
            // 
            _loginBtn.Cursor = Cursors.Hand;
            _loginBtn.Image = (Image)resources.GetObject("loginBtn.Image");
            _loginBtn.Location = new Point(191, 58);
            _loginBtn.Margin = new Padding(2, 2, 2, 2);
            _loginBtn.Name = "_loginBtn";
            _loginBtn.Size = new Size(27, 26);
            _loginBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            _loginBtn.TabIndex = 346;
            _loginBtn.TabStop = false;
            // 
            // cardId_lbl
            // 
            _cardId_lbl.AutoSize = true;
            _cardId_lbl.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _cardId_lbl.ForeColor = Color.White;
            _cardId_lbl.Location = new Point(37, 19);
            _cardId_lbl.Margin = new Padding(2, 0, 2, 0);
            _cardId_lbl.Name = "_cardId_lbl";
            _cardId_lbl.Size = new Size(23, 15);
            _cardId_lbl.TabIndex = 344;
            _cardId_lbl.Text = "ID";
            // 
            // cardId
            // 
            _cardId.BackColor = Color.Maroon;
            _cardId.BorderStyle = BorderStyle.FixedSingle;
            _cardId.Font = new Font("Calibri", 12.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _cardId.Location = new Point(39, 37);
            _cardId.Margin = new Padding(2, 2, 2, 2);
            _cardId.Name = "_cardId";
            _cardId.Size = new Size(122, 27);
            _cardId.TabIndex = 1;
            // 
            // access_code
            // 
            _access_code.AutoSize = true;
            _access_code.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _access_code.ForeColor = Color.White;
            _access_code.Location = new Point(37, 67);
            _access_code.Margin = new Padding(2, 0, 2, 0);
            _access_code.Name = "_access_code";
            _access_code.Size = new Size(44, 15);
            _access_code.TabIndex = 1;
            _access_code.Text = "Code";
            // 
            // codetxt
            // 
            _codetxt.BackColor = Color.Maroon;
            _codetxt.BorderStyle = BorderStyle.FixedSingle;
            _codetxt.Font = new Font("Calibri", 12.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _codetxt.Location = new Point(37, 85);
            _codetxt.Margin = new Padding(2, 2, 2, 2);
            _codetxt.Name = "_codetxt";
            _codetxt.PasswordChar = '•';
            _codetxt.Size = new Size(94, 27);
            _codetxt.TabIndex = 2;
            _codetxt.ValidatingType = typeof(DateTime);
            // 
            // show_password
            // 
            _show_password.Cursor = Cursors.Hand;
            _show_password.Image = (Image)resources.GetObject("show_password.Image");
            _show_password.Location = new Point(135, 89);
            _show_password.Margin = new Padding(2, 2, 2, 2);
            _show_password.Name = "_show_password";
            _show_password.Size = new Size(23, 16);
            _show_password.SizeMode = PictureBoxSizeMode.StretchImage;
            _show_password.TabIndex = 339;
            _show_password.TabStop = false;
            // 
            // PanelLocationText
            // 
            _PanelLocationText.BackColor = Color.Maroon;
            _PanelLocationText.Controls.Add(_locationLabel);
            _PanelLocationText.Location = new Point(871, 344);
            _PanelLocationText.Margin = new Padding(2, 2, 2, 2);
            _PanelLocationText.Name = "_PanelLocationText";
            _PanelLocationText.Size = new Size(363, 25);
            _PanelLocationText.TabIndex = 352;
            // 
            // locationTextTimer
            // 
            _locationTextTimer.Interval = 50;
            // 
            // animatedBackGround
            // 
            _animatedBackGround.Image = (Image)resources.GetObject("animatedBackGround.Image");
            _animatedBackGround.Location = new Point(0, 0);
            _animatedBackGround.Margin = new Padding(2, 2, 2, 2);
            _animatedBackGround.Name = "_animatedBackGround";
            _animatedBackGround.Size = new Size(1234, 701);
            _animatedBackGround.SizeMode = PictureBoxSizeMode.StretchImage;
            _animatedBackGround.TabIndex = 4;
            _animatedBackGround.TabStop = false;
            // 
            // LayoutStartUpForm
            // 
            this.AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.BackgroundImageLayout = ImageLayout.None;
            this.ClientSize = new Size(1238, 701);
            this.ControlBox = false;
            this.Controls.Add(_statusMessage);
            this.Controls.Add(_PanelLocationText);
            this.Controls.Add(_progressbar);
            this.Controls.Add(_websiteLink);
            this.Controls.Add(_panelLogin);
            this.Controls.Add(_cancelCard_lbl);
            this.Controls.Add(_TitleFlavourLabel);
            this.Controls.Add(_versionTitleLabel);
            this.Controls.Add(_VersionLabel);
            this.Controls.Add(_quoteOfTheDaySentenceLabel);
            this.Controls.Add(_titleLabel);
            this.Controls.Add(_animatedBackGround);
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LayoutStartUpForm";
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.TransparencyKey = Color.WhiteSmoke;
            _panelLogin.ResumeLayout(false);
            _panelLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_loginBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)_show_password).EndInit();
            _PanelLocationText.ResumeLayout(false);
            _PanelLocationText.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_animatedBackGround).EndInit();
            this.Load += SplashScreen1_Load;
            this.VisibleChanged += SplashScreen_visibility;
            this.Shown += SplashScreen1_Shown;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private LabelDoubleBuffer _VersionLabel;

        internal LabelDoubleBuffer VersionLabel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _VersionLabel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_VersionLabel != null)
                {
                }

                _VersionLabel = value;
                if (_VersionLabel != null)
                {
                }
            }
        }

        private TextBox _cardId;

        internal TextBox cardId
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cardId;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cardId != null)
                {
                }

                _cardId = value;
                if (_cardId != null)
                {
                }
            }
        }

        private LabelDoubleBuffer _cardId_lbl;

        internal LabelDoubleBuffer cardId_lbl
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cardId_lbl;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cardId_lbl != null)
                {
                }

                _cardId_lbl = value;
                if (_cardId_lbl != null)
                {
                }
            }
        }

        private LinkLabel _cancelCard_lbl;

        internal LinkLabel cancelCard_lbl
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cancelCard_lbl;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cancelCard_lbl != null)
                {
                    _cancelCard_lbl.LinkClicked -= cancelCard_lbl_LinkClicked;
                }

                _cancelCard_lbl = value;
                if (_cancelCard_lbl != null)
                {
                    _cancelCard_lbl.LinkClicked += cancelCard_lbl_LinkClicked;
                }
            }
        }

        private PictureBox _show_password;

        internal PictureBox show_password
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _show_password;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_show_password != null)
                {
                    _show_password.Click -= PictureBox1_Click;
                }

                _show_password = value;
                if (_show_password != null)
                {
                    _show_password.Click += PictureBox1_Click;
                }
            }
        }

        private MaskedTextBox _codetxt;

        internal MaskedTextBox codetxt
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _codetxt;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_codetxt != null)
                {
                    _codetxt.KeyPress -= codetxt_KeyPress;
                }

                _codetxt = value;
                if (_codetxt != null)
                {
                    _codetxt.KeyPress += codetxt_KeyPress;
                }
            }
        }

        private LabelDoubleBuffer _access_code;

        internal LabelDoubleBuffer access_code
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _access_code;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_access_code != null)
                {
                }

                _access_code = value;
                if (_access_code != null)
                {
                }
            }
        }

        private LabelDoubleBuffer _statusMessage;

        internal LabelDoubleBuffer statusMessage
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _statusMessage;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_statusMessage != null)
                {
                }

                _statusMessage = value;
                if (_statusMessage != null)
                {
                }
            }
        }

        private LabelDoubleBuffer _titleLabel;

        internal LabelDoubleBuffer titleLabel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _titleLabel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_titleLabel != null)
                {
                }

                _titleLabel = value;
                if (_titleLabel != null)
                {
                }
            }
        }

        private LabelDoubleBuffer _locationLabel;

        internal LabelDoubleBuffer locationLabel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _locationLabel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_locationLabel != null)
                {
                }

                _locationLabel = value;
                if (_locationLabel != null)
                {
                }
            }
        }

        private LabelDoubleBuffer _quoteOfTheDaySentenceLabel;

        internal LabelDoubleBuffer quoteOfTheDaySentenceLabel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _quoteOfTheDaySentenceLabel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_quoteOfTheDaySentenceLabel != null)
                {
                }

                _quoteOfTheDaySentenceLabel = value;
                if (_quoteOfTheDaySentenceLabel != null)
                {
                }
            }
        }

        private LabelDoubleBuffer _versionTitleLabel;

        internal LabelDoubleBuffer versionTitleLabel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _versionTitleLabel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_versionTitleLabel != null)
                {
                }

                _versionTitleLabel = value;
                if (_versionTitleLabel != null)
                {
                }
            }
        }

        private LabelDoubleBuffer _TitleFlavourLabel;

        internal LabelDoubleBuffer TitleFlavourLabel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TitleFlavourLabel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TitleFlavourLabel != null)
                {
                }

                _TitleFlavourLabel = value;
                if (_TitleFlavourLabel != null)
                {
                }
            }
        }

        private PictureBox _loginBtn;

        internal PictureBox loginBtn
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _loginBtn;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_loginBtn != null)
                {
                    _loginBtn.Click -= loginBtn_Click;
                }

                _loginBtn = value;
                if (_loginBtn != null)
                {
                    _loginBtn.Click += loginBtn_Click;
                }
            }
        }

        private AlphaGradientPanel _panelLogin;

        internal AlphaGradientPanel panelLogin
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _panelLogin;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_panelLogin != null)
                {
                }

                _panelLogin = value;
                if (_panelLogin != null)
                {
                }
            }
        }

        private ColorWithAlpha _ColorWithAlpha1;

        internal ColorWithAlpha ColorWithAlpha1
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

        private LinkLabel _websiteLink;

        internal LinkLabel websiteLink
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _websiteLink;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_websiteLink != null)
                {
                    _websiteLink.LinkClicked -= websiteLink_LinkClicked;
                }

                _websiteLink = value;
                if (_websiteLink != null)
                {
                    _websiteLink.LinkClicked += websiteLink_LinkClicked;
                }
            }
        }

        private CircularProgressBar.CircularProgress.CircularProgressBar _progressbar;

        internal CircularProgressBar.CircularProgress.CircularProgressBar progressbar
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _progressbar;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_progressbar != null)
                {
                }

                _progressbar = value;
                if (_progressbar != null)
                {
                }
            }
        }

        private Panel _PanelLocationText;

        internal Panel PanelLocationText
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PanelLocationText;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PanelLocationText != null)
                {
                }

                _PanelLocationText = value;
                if (_PanelLocationText != null)
                {
                }
            }
        }

        private Timer _locationTextTimer;

        internal Timer locationTextTimer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _locationTextTimer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_locationTextTimer != null)
                {
                    _locationTextTimer.Tick -= locationTextTimer_Tick;
                }

                _locationTextTimer = value;
                if (_locationTextTimer != null)
                {
                    _locationTextTimer.Tick += locationTextTimer_Tick;
                }
            }
        }

        private PictureBoxDoubleBuffer _animatedBackGround;

        internal PictureBoxDoubleBuffer animatedBackGround
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _animatedBackGround;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_animatedBackGround != null)
                {
                }

                _animatedBackGround = value;
                if (_animatedBackGround != null)
                {
                }
            }
        }
    }
}