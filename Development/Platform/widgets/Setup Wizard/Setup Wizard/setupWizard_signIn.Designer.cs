using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace ConstructionSiteLogistics.Setup.Gui2
{
    [DesignerGenerated()]
    public partial class setupWizard_signIn : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(setupWizard_signIn));
            _server_msg = new ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer();
            _signInCode = new MaskedTextBox();
            _signInCode_lbl = new ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer();
            _send = new LinkLabel();
            _send.LinkClicked += new LinkLabelLinkClickedEventHandler(send_LinkClicked);
            _email_lbl = new ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer();
            _email = new TextBox();
            _show_password = new PictureBox();
            _show_password.Click += new EventHandler(show_password_Click);
            _sign_id = new MaskedTextBox();
            _forgot_id = new LinkLabel();
            _forgot_id.LinkClicked += new LinkLabelLinkClickedEventHandler(forgot_id_LinkClicked);
            _sign_in_lbl = new ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer();
            _PictureBox1 = new PictureBox();
            _ColorWithAlpha1 = new BlueActivity.ColorWithAlpha();
            ((System.ComponentModel.ISupportInitialize)_show_password).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // server_msg
            // 
            _server_msg.AutoSize = true;
            _server_msg.Font = new Font("Trajan Pro", 8.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _server_msg.ForeColor = Color.Black;
            _server_msg.Location = new Point(722, 456);
            _server_msg.Name = "_server_msg";
            _server_msg.Size = new Size(192, 20);
            _server_msg.TabIndex = 349;
            _server_msg.Text = "pass card on reader";
            // 
            // signInCode
            // 
            _signInCode.BorderStyle = BorderStyle.FixedSingle;
            _signInCode.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _signInCode.Location = new Point(719, 537);
            _signInCode.Margin = new Padding(4, 5, 4, 5);
            _signInCode.Name = "_signInCode";
            _signInCode.PasswordChar = '•';
            _signInCode.Size = new Size(353, 28);
            _signInCode.TabIndex = 348;
            _signInCode.ValidatingType = typeof(DateTime);
            // 
            // signInCode_lbl
            // 
            _signInCode_lbl.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _signInCode_lbl.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _signInCode_lbl.ForeColor = Color.Black;
            _signInCode_lbl.Location = new Point(250, 538);
            _signInCode_lbl.Margin = new Padding(4, 0, 4, 0);
            _signInCode_lbl.Name = "_signInCode_lbl";
            _signInCode_lbl.Size = new Size(460, 31);
            _signInCode_lbl.TabIndex = 347;
            _signInCode_lbl.Text = "Code";
            _signInCode_lbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // send
            // 
            _send.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _send.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _send.Location = new Point(707, 638);
            _send.Margin = new Padding(4, 0, 4, 0);
            _send.Name = "_send";
            _send.Size = new Size(366, 26);
            _send.TabIndex = 346;
            _send.TabStop = true;
            _send.Text = "Send";
            _send.TextAlign = ContentAlignment.MiddleRight;
            _send.Visible = false;
            // 
            // email_lbl
            // 
            _email_lbl.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _email_lbl.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _email_lbl.ForeColor = Color.Black;
            _email_lbl.Location = new Point(250, 606);
            _email_lbl.Margin = new Padding(4, 0, 4, 0);
            _email_lbl.Name = "_email_lbl";
            _email_lbl.Size = new Size(460, 28);
            _email_lbl.TabIndex = 345;
            _email_lbl.Text = "e-mail";
            _email_lbl.TextAlign = ContentAlignment.MiddleRight;
            _email_lbl.Visible = false;
            // 
            // email
            // 
            _email.Location = new Point(719, 603);
            _email.Margin = new Padding(4, 5, 4, 5);
            _email.Name = "_email";
            _email.Size = new Size(352, 26);
            _email.TabIndex = 344;
            _email.Visible = false;
            // 
            // show_password
            // 
            _show_password.Image = (Image)resources.GetObject("show_password.Image");
            _show_password.Location = new Point(1082, 537);
            _show_password.Margin = new Padding(4, 5, 4, 5);
            _show_password.Name = "_show_password";
            _show_password.Size = new Size(30, 31);
            _show_password.SizeMode = PictureBoxSizeMode.StretchImage;
            _show_password.TabIndex = 343;
            _show_password.TabStop = false;
            // 
            // sign_id
            // 
            _sign_id.BorderStyle = BorderStyle.FixedSingle;
            _sign_id.Culture = new System.Globalization.CultureInfo("");
            _sign_id.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _sign_id.Location = new Point(719, 486);
            _sign_id.Margin = new Padding(4, 5, 4, 5);
            _sign_id.Name = "_sign_id";
            _sign_id.Size = new Size(353, 28);
            _sign_id.TabIndex = 342;
            _sign_id.ValidatingType = typeof(DateTime);
            // 
            // forgot_id
            // 
            _forgot_id.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _forgot_id.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _forgot_id.Location = new Point(719, 575);
            _forgot_id.Margin = new Padding(4, 0, 4, 0);
            _forgot_id.Name = "_forgot_id";
            _forgot_id.Size = new Size(354, 25);
            _forgot_id.TabIndex = 12;
            _forgot_id.TabStop = true;
            _forgot_id.Text = "Forgot ID ?";
            _forgot_id.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sign_in_lbl
            // 
            _sign_in_lbl.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _sign_in_lbl.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _sign_in_lbl.ForeColor = Color.Black;
            _sign_in_lbl.Location = new Point(250, 488);
            _sign_in_lbl.Margin = new Padding(4, 0, 4, 0);
            _sign_in_lbl.Name = "_sign_in_lbl";
            _sign_in_lbl.Size = new Size(460, 31);
            _sign_in_lbl.TabIndex = 11;
            _sign_in_lbl.Text = "Sign in with your ID";
            _sign_in_lbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // PictureBox1
            // 
            _PictureBox1.Image = (Image)resources.GetObject("PictureBox1.Image");
            _PictureBox1.Location = new Point(548, 28);
            _PictureBox1.Margin = new Padding(4, 5, 4, 5);
            _PictureBox1.Name = "_PictureBox1";
            _PictureBox1.Size = new Size(525, 378);
            _PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            _PictureBox1.TabIndex = 2;
            _PictureBox1.TabStop = false;
            // 
            // ColorWithAlpha1
            // 
            _ColorWithAlpha1.Alpha = 150;
            _ColorWithAlpha1.Color = Color.Black;
            _ColorWithAlpha1.Parent = null;
            // 
            // setupWizard_signIn
            // 
            AutoScaleDimensions = new SizeF(9.0F, 20.0F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1600, 742);
            ControlBox = false;
            Controls.Add(_server_msg);
            Controls.Add(_signInCode);
            Controls.Add(_PictureBox1);
            Controls.Add(_signInCode_lbl);
            Controls.Add(_forgot_id);
            Controls.Add(_sign_in_lbl);
            Controls.Add(_send);
            Controls.Add(_sign_id);
            Controls.Add(_email_lbl);
            Controls.Add(_show_password);
            Controls.Add(_email);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "setupWizard_signIn";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            TransparencyKey = Color.Transparent;
            ((System.ComponentModel.ISupportInitialize)_show_password).EndInit();
            ((System.ComponentModel.ISupportInitialize)_PictureBox1).EndInit();
            Load += new EventHandler(setupWizard_1_Load);
            VisibleChanged += new EventHandler(setupWizard_VisibleChanged);
            ResumeLayout(false);
            PerformLayout();
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

        private Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer _sign_in_lbl;

        internal Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer sign_in_lbl
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _sign_in_lbl;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_sign_in_lbl != null)
                {
                }

                _sign_in_lbl = value;
                if (_sign_in_lbl != null)
                {
                }
            }
        }

        private LinkLabel _forgot_id;

        internal LinkLabel forgot_id
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _forgot_id;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_forgot_id != null)
                {
                    _forgot_id.LinkClicked -= forgot_id_LinkClicked;
                }

                _forgot_id = value;
                if (_forgot_id != null)
                {
                    _forgot_id.LinkClicked += forgot_id_LinkClicked;
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
                    _show_password.Click -= show_password_Click;
                }

                _show_password = value;
                if (_show_password != null)
                {
                    _show_password.Click += show_password_Click;
                }
            }
        }

        private MaskedTextBox _sign_id;

        internal MaskedTextBox sign_id
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _sign_id;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_sign_id != null)
                {
                }

                _sign_id = value;
                if (_sign_id != null)
                {
                }
            }
        }

        private Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer _email_lbl;

        internal Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer email_lbl
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _email_lbl;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_email_lbl != null)
                {
                }

                _email_lbl = value;
                if (_email_lbl != null)
                {
                }
            }
        }

        private TextBox _email;

        internal TextBox email
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _email;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_email != null)
                {
                }

                _email = value;
                if (_email != null)
                {
                }
            }
        }

        private LinkLabel _send;

        internal LinkLabel send
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _send;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_send != null)
                {
                    _send.LinkClicked -= send_LinkClicked;
                }

                _send = value;
                if (_send != null)
                {
                    _send.LinkClicked += send_LinkClicked;
                }
            }
        }

        private MaskedTextBox _signInCode;

        internal MaskedTextBox signInCode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _signInCode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_signInCode != null)
                {
                }

                _signInCode = value;
                if (_signInCode != null)
                {
                }
            }
        }

        private Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer _signInCode_lbl;

        internal Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer signInCode_lbl
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _signInCode_lbl;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_signInCode_lbl != null)
                {
                }

                _signInCode_lbl = value;
                if (_signInCode_lbl != null)
                {
                }
            }
        }

        private Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer _server_msg;

        internal Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer server_msg
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _server_msg;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_server_msg != null)
                {
                }

                _server_msg = value;
                if (_server_msg != null)
                {
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
    }
}