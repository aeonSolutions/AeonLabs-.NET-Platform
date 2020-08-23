using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace ConstructionSiteLogistics.Setup.Gui2
{
    [DesignerGenerated()]
    public partial class setupWizard_NewFtpWebSettings : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(setupWizard_NewFtpWebSettings));
            _password_lbl = new ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer();
            _password = new TextBox();
            _password.TextChanged += new EventHandler(password_TextChanged);
            _username_lbl = new ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer();
            _username = new TextBox();
            _username.TextChanged += new EventHandler(username_TextChanged);
            _connectionType_lbl = new ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer();
            _connectionType = new ComboBox();
            _server_ftp_port_lbl = new ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer();
            _server_ftp_port = new TextBox();
            _domain_ftp_ex = new ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer();
            _server_ftp_addr_lbl = new ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer();
            _server_ftp_addr = new TextBox();
            _server_ftp_addr.TextChanged += new EventHandler(server_ftp_addr_TextChanged);
            _domain_web_ex = new ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer();
            _server_web_addr_lbl = new ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer();
            _server_web_addr = new TextBox();
            _server_web_addr.TextChanged += new EventHandler(server_web_addr_TextChanged);
            _PictureBox1 = new PictureBox();
            _ColorWithAlpha1 = new BlueActivity.ColorWithAlpha();
            ((System.ComponentModel.ISupportInitialize)_PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // password_lbl
            // 
            _password_lbl.AutoSize = true;
            _password_lbl.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _password_lbl.ForeColor = Color.Black;
            _password_lbl.Location = new Point(712, 508);
            _password_lbl.Margin = new Padding(4, 0, 4, 0);
            _password_lbl.Name = "_password_lbl";
            _password_lbl.Size = new Size(108, 23);
            _password_lbl.TabIndex = 33;
            _password_lbl.Text = "password";
            // 
            // password
            // 
            _password.Font = new Font("Arial", 9.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _password.Location = new Point(715, 532);
            _password.Margin = new Padding(4, 5, 4, 5);
            _password.Name = "_password";
            _password.Size = new Size(210, 28);
            _password.TabIndex = 32;
            // 
            // username_lbl
            // 
            _username_lbl.AutoSize = true;
            _username_lbl.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _username_lbl.ForeColor = Color.Black;
            _username_lbl.Location = new Point(710, 444);
            _username_lbl.Margin = new Padding(4, 0, 4, 0);
            _username_lbl.Name = "_username_lbl";
            _username_lbl.Size = new Size(107, 23);
            _username_lbl.TabIndex = 31;
            _username_lbl.Text = "username";
            // 
            // username
            // 
            _username.Font = new Font("Arial", 9.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _username.Location = new Point(713, 470);
            _username.Margin = new Padding(4, 5, 4, 5);
            _username.Name = "_username";
            _username.Size = new Size(432, 28);
            _username.TabIndex = 30;
            // 
            // connectionType_lbl
            // 
            _connectionType_lbl.AutoSize = true;
            _connectionType_lbl.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _connectionType_lbl.ForeColor = Color.Black;
            _connectionType_lbl.Location = new Point(712, 372);
            _connectionType_lbl.Margin = new Padding(4, 0, 4, 0);
            _connectionType_lbl.Name = "_connectionType_lbl";
            _connectionType_lbl.Size = new Size(187, 23);
            _connectionType_lbl.TabIndex = 29;
            _connectionType_lbl.Text = "connection type";
            // 
            // connectionType
            // 
            _connectionType.DropDownStyle = ComboBoxStyle.DropDownList;
            _connectionType.ForeColor = Color.Gray;
            _connectionType.FormattingEnabled = true;
            _connectionType.Location = new Point(715, 398);
            _connectionType.Margin = new Padding(3, 2, 3, 2);
            _connectionType.Name = "_connectionType";
            _connectionType.Size = new Size(430, 28);
            _connectionType.TabIndex = 28;
            // 
            // server_ftp_port_lbl
            // 
            _server_ftp_port_lbl.AutoSize = true;
            _server_ftp_port_lbl.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _server_ftp_port_lbl.ForeColor = Color.Black;
            _server_ftp_port_lbl.Location = new Point(1173, 254);
            _server_ftp_port_lbl.Margin = new Padding(4, 0, 4, 0);
            _server_ftp_port_lbl.Name = "_server_ftp_port_lbl";
            _server_ftp_port_lbl.Size = new Size(59, 23);
            _server_ftp_port_lbl.TabIndex = 27;
            _server_ftp_port_lbl.Text = "Port";
            // 
            // server_ftp_port
            // 
            _server_ftp_port.Font = new Font("Arial", 9.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _server_ftp_port.Location = new Point(1176, 280);
            _server_ftp_port.Margin = new Padding(4, 5, 4, 5);
            _server_ftp_port.Name = "_server_ftp_port";
            _server_ftp_port.Size = new Size(77, 28);
            _server_ftp_port.TabIndex = 26;
            // 
            // domain_ftp_ex
            // 
            _domain_ftp_ex.AutoSize = true;
            _domain_ftp_ex.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _domain_ftp_ex.ForeColor = Color.Black;
            _domain_ftp_ex.Location = new Point(710, 317);
            _domain_ftp_ex.Margin = new Padding(4, 0, 4, 0);
            _domain_ftp_ex.Name = "_domain_ftp_ex";
            _domain_ftp_ex.Size = new Size(319, 23);
            _domain_ftp_ex.TabIndex = 25;
            _domain_ftp_ex.Text = "ex.: ftp://ftp.yourdomain.com";
            // 
            // server_ftp_addr_lbl
            // 
            _server_ftp_addr_lbl.AutoSize = true;
            _server_ftp_addr_lbl.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _server_ftp_addr_lbl.ForeColor = Color.Black;
            _server_ftp_addr_lbl.Location = new Point(710, 254);
            _server_ftp_addr_lbl.Margin = new Padding(4, 0, 4, 0);
            _server_ftp_addr_lbl.Name = "_server_ftp_addr_lbl";
            _server_ftp_addr_lbl.Size = new Size(201, 23);
            _server_ftp_addr_lbl.TabIndex = 24;
            _server_ftp_addr_lbl.Text = "Server ftp address";
            // 
            // server_ftp_addr
            // 
            _server_ftp_addr.Font = new Font("Arial", 9.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _server_ftp_addr.Location = new Point(713, 280);
            _server_ftp_addr.Margin = new Padding(4, 5, 4, 5);
            _server_ftp_addr.Name = "_server_ftp_addr";
            _server_ftp_addr.Size = new Size(432, 28);
            _server_ftp_addr.TabIndex = 23;
            // 
            // domain_web_ex
            // 
            _domain_web_ex.AutoSize = true;
            _domain_web_ex.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _domain_web_ex.ForeColor = Color.Black;
            _domain_web_ex.Location = new Point(712, 189);
            _domain_web_ex.Margin = new Padding(4, 0, 4, 0);
            _domain_web_ex.Name = "_domain_web_ex";
            _domain_web_ex.Size = new Size(355, 23);
            _domain_web_ex.TabIndex = 22;
            _domain_web_ex.Text = "ex.: http://www.yourdomain.com";
            // 
            // server_web_addr_lbl
            // 
            _server_web_addr_lbl.AutoSize = true;
            _server_web_addr_lbl.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _server_web_addr_lbl.ForeColor = Color.Black;
            _server_web_addr_lbl.Location = new Point(712, 128);
            _server_web_addr_lbl.Margin = new Padding(4, 0, 4, 0);
            _server_web_addr_lbl.Name = "_server_web_addr_lbl";
            _server_web_addr_lbl.Size = new Size(207, 23);
            _server_web_addr_lbl.TabIndex = 21;
            _server_web_addr_lbl.Text = "Server web address";
            // 
            // server_web_addr
            // 
            _server_web_addr.Font = new Font("Arial", 9.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _server_web_addr.Location = new Point(715, 152);
            _server_web_addr.Margin = new Padding(4, 5, 4, 5);
            _server_web_addr.Name = "_server_web_addr";
            _server_web_addr.Size = new Size(432, 28);
            _server_web_addr.TabIndex = 3;
            // 
            // PictureBox1
            // 
            _PictureBox1.Image = (Image)resources.GetObject("PictureBox1.Image");
            _PictureBox1.Location = new Point(231, 128);
            _PictureBox1.Margin = new Padding(4, 5, 4, 5);
            _PictureBox1.Name = "_PictureBox1";
            _PictureBox1.Size = new Size(447, 301);
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
            // setupWizard_NewFtpWebSettings
            // 
            AutoScaleDimensions = new SizeF(9.0F, 20.0F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1600, 742);
            ControlBox = false;
            Controls.Add(_password_lbl);
            Controls.Add(_password);
            Controls.Add(_PictureBox1);
            Controls.Add(_username_lbl);
            Controls.Add(_server_ftp_addr);
            Controls.Add(_domain_web_ex);
            Controls.Add(_username);
            Controls.Add(_server_ftp_addr_lbl);
            Controls.Add(_connectionType_lbl);
            Controls.Add(_server_web_addr_lbl);
            Controls.Add(_connectionType);
            Controls.Add(_domain_ftp_ex);
            Controls.Add(_server_ftp_port_lbl);
            Controls.Add(_server_web_addr);
            Controls.Add(_server_ftp_port);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "setupWizard_NewFtpWebSettings";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            TransparencyKey = Color.Transparent;
            ((System.ComponentModel.ISupportInitialize)_PictureBox1).EndInit();
            VisibleChanged += new EventHandler(setupWizard_1_VisibleChanged);
            Load += new EventHandler(setupWizard_1_Load);
            Shown += new EventHandler(setupWizard_1_shown);
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

        private Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer _server_web_addr_lbl;

        internal Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer server_web_addr_lbl
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _server_web_addr_lbl;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_server_web_addr_lbl != null)
                {
                }

                _server_web_addr_lbl = value;
                if (_server_web_addr_lbl != null)
                {
                }
            }
        }

        private TextBox _server_web_addr;

        internal TextBox server_web_addr
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _server_web_addr;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_server_web_addr != null)
                {
                    _server_web_addr.TextChanged -= server_web_addr_TextChanged;
                }

                _server_web_addr = value;
                if (_server_web_addr != null)
                {
                    _server_web_addr.TextChanged += server_web_addr_TextChanged;
                }
            }
        }

        private Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer _domain_web_ex;

        internal Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer domain_web_ex
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _domain_web_ex;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_domain_web_ex != null)
                {
                }

                _domain_web_ex = value;
                if (_domain_web_ex != null)
                {
                }
            }
        }

        private Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer _server_ftp_port_lbl;

        internal Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer server_ftp_port_lbl
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _server_ftp_port_lbl;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_server_ftp_port_lbl != null)
                {
                }

                _server_ftp_port_lbl = value;
                if (_server_ftp_port_lbl != null)
                {
                }
            }
        }

        private TextBox _server_ftp_port;

        internal TextBox server_ftp_port
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _server_ftp_port;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_server_ftp_port != null)
                {
                }

                _server_ftp_port = value;
                if (_server_ftp_port != null)
                {
                }
            }
        }

        private Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer _domain_ftp_ex;

        internal Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer domain_ftp_ex
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _domain_ftp_ex;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_domain_ftp_ex != null)
                {
                }

                _domain_ftp_ex = value;
                if (_domain_ftp_ex != null)
                {
                }
            }
        }

        private Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer _server_ftp_addr_lbl;

        internal Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer server_ftp_addr_lbl
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _server_ftp_addr_lbl;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_server_ftp_addr_lbl != null)
                {
                }

                _server_ftp_addr_lbl = value;
                if (_server_ftp_addr_lbl != null)
                {
                }
            }
        }

        private TextBox _server_ftp_addr;

        internal TextBox server_ftp_addr
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _server_ftp_addr;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_server_ftp_addr != null)
                {
                    _server_ftp_addr.TextChanged -= server_ftp_addr_TextChanged;
                }

                _server_ftp_addr = value;
                if (_server_ftp_addr != null)
                {
                    _server_ftp_addr.TextChanged += server_ftp_addr_TextChanged;
                }
            }
        }

        private Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer _password_lbl;

        internal Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer password_lbl
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _password_lbl;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_password_lbl != null)
                {
                }

                _password_lbl = value;
                if (_password_lbl != null)
                {
                }
            }
        }

        private Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer _username_lbl;

        internal Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer username_lbl
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _username_lbl;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_username_lbl != null)
                {
                }

                _username_lbl = value;
                if (_username_lbl != null)
                {
                }
            }
        }

        private TextBox _username;

        internal TextBox username
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _username;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_username != null)
                {
                    _username.TextChanged -= username_TextChanged;
                }

                _username = value;
                if (_username != null)
                {
                    _username.TextChanged += username_TextChanged;
                }
            }
        }

        private Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer _connectionType_lbl;

        internal Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer connectionType_lbl
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _connectionType_lbl;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_connectionType_lbl != null)
                {
                }

                _connectionType_lbl = value;
                if (_connectionType_lbl != null)
                {
                }
            }
        }

        private ComboBox _connectionType;

        internal ComboBox connectionType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _connectionType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_connectionType != null)
                {
                }

                _connectionType = value;
                if (_connectionType != null)
                {
                }
            }
        }

        private TextBox _password;

        internal TextBox password
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _password;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_password != null)
                {
                    _password.TextChanged -= password_TextChanged;
                }

                _password = value;
                if (_password != null)
                {
                    _password.TextChanged += password_TextChanged;
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