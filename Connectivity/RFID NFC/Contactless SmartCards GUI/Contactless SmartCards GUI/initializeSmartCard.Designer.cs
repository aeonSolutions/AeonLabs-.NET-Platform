using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace ConstructionSiteLogistics.SmartCards.GUI
{
    [DesignerGenerated()]
    public partial class initializeSmartCard : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(initializeSmartCard));
            _closeBtn = new Button();
            _closeBtn.Click += new EventHandler(closeBtn_Click);
            _Panel1 = new Panel();
            _Panel1.Paint += new PaintEventHandler(Panel1_Paint);
            _authCode_lbl = new ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer();
            _readCodeOnly = new LinkLabel();
            _readCodeOnly.LinkClicked += new LinkLabelLinkClickedEventHandler(readCodeOnly_LinkClicked);
            _cardIdCode = new ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer();
            _progressBar = new ProgressBar();
            _StartBtn = new Button();
            _StartBtn.Click += new EventHandler(SaveAuthString_Click);
            _PictureBox1 = new PictureBox();
            _Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // closeBtn
            // 
            _closeBtn.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(131)), Conversions.ToInteger(Conversions.ToByte(193)), Conversions.ToInteger(Conversions.ToByte(79)));
            _closeBtn.FlatStyle = FlatStyle.Flat;
            _closeBtn.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _closeBtn.ForeColor = Color.White;
            _closeBtn.Location = new Point(363, 107);
            _closeBtn.Name = "_closeBtn";
            _closeBtn.Size = new Size(86, 26);
            _closeBtn.TabIndex = 337;
            _closeBtn.Text = "Fechar";
            _closeBtn.UseVisualStyleBackColor = false;
            // 
            // Panel1
            // 
            _Panel1.BorderStyle = BorderStyle.FixedSingle;
            _Panel1.Controls.Add(_authCode_lbl);
            _Panel1.Controls.Add(_readCodeOnly);
            _Panel1.Controls.Add(_cardIdCode);
            _Panel1.Controls.Add(_progressBar);
            _Panel1.Controls.Add(_StartBtn);
            _Panel1.Controls.Add(_PictureBox1);
            _Panel1.Controls.Add(_closeBtn);
            _Panel1.Dock = DockStyle.Fill;
            _Panel1.Location = new Point(0, 0);
            _Panel1.Name = "_Panel1";
            _Panel1.Size = new Size(454, 143);
            _Panel1.TabIndex = 338;
            // 
            // authCode_lbl
            // 
            _authCode_lbl.AutoSize = true;
            _authCode_lbl.Location = new Point(108, 90);
            _authCode_lbl.Name = "_authCode_lbl";
            _authCode_lbl.Size = new Size(29, 13);
            _authCode_lbl.TabIndex = 343;
            _authCode_lbl.Text = "Auth";
            // 
            // readCodeOnly
            // 
            _readCodeOnly.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _readCodeOnly.Location = new Point(288, 71);
            _readCodeOnly.Name = "_readCodeOnly";
            _readCodeOnly.Size = new Size(153, 18);
            _readCodeOnly.TabIndex = 342;
            _readCodeOnly.TabStop = true;
            _readCodeOnly.Text = "read code";
            _readCodeOnly.TextAlign = ContentAlignment.TopRight;
            // 
            // cardIdCode
            // 
            _cardIdCode.AutoSize = true;
            _cardIdCode.Location = new Point(107, 73);
            _cardIdCode.Name = "_cardIdCode";
            _cardIdCode.Size = new Size(34, 13);
            _cardIdCode.TabIndex = 341;
            _cardIdCode.Text = "UUID";
            // 
            // progressBar
            // 
            _progressBar.Location = new Point(107, 46);
            _progressBar.Name = "_progressBar";
            _progressBar.Size = new Size(334, 23);
            _progressBar.Style = ProgressBarStyle.Continuous;
            _progressBar.TabIndex = 340;
            // 
            // StartBtn
            // 
            _StartBtn.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(131)), Conversions.ToInteger(Conversions.ToByte(193)), Conversions.ToInteger(Conversions.ToByte(79)));
            _StartBtn.FlatStyle = FlatStyle.Flat;
            _StartBtn.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _StartBtn.ForeColor = Color.White;
            _StartBtn.Location = new Point(11, 107);
            _StartBtn.Name = "_StartBtn";
            _StartBtn.Size = new Size(86, 26);
            _StartBtn.TabIndex = 339;
            _StartBtn.Text = "new card";
            _StartBtn.UseVisualStyleBackColor = false;
            // 
            // PictureBox1
            // 
            _PictureBox1.Image = (Image)resources.GetObject("PictureBox1.Image");
            _PictureBox1.InitialImage = null;
            _PictureBox1.Location = new Point(11, 11);
            _PictureBox1.Name = "_PictureBox1";
            _PictureBox1.Size = new Size(90, 90);
            _PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            _PictureBox1.TabIndex = 338;
            _PictureBox1.TabStop = false;
            // 
            // initializeSmartCard
            // 
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(454, 143);
            ControlBox = false;
            Controls.Add(_Panel1);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "initializeSmartCard";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Initialize card";
            TopMost = true;
            _Panel1.ResumeLayout(false);
            _Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_PictureBox1).EndInit();
            Load += new EventHandler(meteo_frm_Load);
            Shown += new EventHandler(form_frm_show);
            ResumeLayout(false);
        }

        private Button _closeBtn;

        internal Button closeBtn
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _closeBtn;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_closeBtn != null)
                {
                    _closeBtn.Click -= closeBtn_Click;
                }

                _closeBtn = value;
                if (_closeBtn != null)
                {
                    _closeBtn.Click += closeBtn_Click;
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
                    _Panel1.Paint -= Panel1_Paint;
                }

                _Panel1 = value;
                if (_Panel1 != null)
                {
                    _Panel1.Paint += Panel1_Paint;
                }
            }
        }

        private ProgressBar _progressBar;

        internal ProgressBar progressBar
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _progressBar;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_progressBar != null)
                {
                }

                _progressBar = value;
                if (_progressBar != null)
                {
                }
            }
        }

        private Button _StartBtn;

        internal Button StartBtn
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _StartBtn;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_StartBtn != null)
                {
                    _StartBtn.Click -= SaveAuthString_Click;
                }

                _StartBtn = value;
                if (_StartBtn != null)
                {
                    _StartBtn.Click += SaveAuthString_Click;
                }
            }
        }

        private PictureBox _PictureBox1;

        internal PictureBox PictureBox1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PictureBox1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PictureBox1 != null)
                {
                }

                _PictureBox1 = value;
                if (_PictureBox1 != null)
                {
                }
            }
        }

        private Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer _cardIdCode;

        internal Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer cardIdCode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cardIdCode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cardIdCode != null)
                {
                }

                _cardIdCode = value;
                if (_cardIdCode != null)
                {
                }
            }
        }

        private LinkLabel _readCodeOnly;

        internal LinkLabel readCodeOnly
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _readCodeOnly;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_readCodeOnly != null)
                {
                    _readCodeOnly.LinkClicked -= readCodeOnly_LinkClicked;
                }

                _readCodeOnly = value;
                if (_readCodeOnly != null)
                {
                    _readCodeOnly.LinkClicked += readCodeOnly_LinkClicked;
                }
            }
        }

        private Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer _authCode_lbl;

        internal Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer authCode_lbl
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _authCode_lbl;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_authCode_lbl != null)
                {
                }

                _authCode_lbl = value;
                if (_authCode_lbl != null)
                {
                }
            }
        }
    }
}