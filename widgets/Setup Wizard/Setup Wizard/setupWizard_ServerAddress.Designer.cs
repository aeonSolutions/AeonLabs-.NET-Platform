using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace ConstructionSiteLogistics.Setup.Gui2
{
    [DesignerGenerated()]
    public partial class setupWizard_ServerAddress : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(setupWizard_ServerAddress));
            _domain_web_ex = new ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer();
            _server_web_addr_lbl = new ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer();
            _server_web_addr = new TextBox();
            _server_web_addr.TextChanged += new EventHandler(server_web_addr_TextChanged);
            _PictureBox1 = new PictureBox();
            _ColorWithAlpha1 = new BlueActivity.ColorWithAlpha();
            _selectionOkpic = new PictureBox();
            _TimerCheckIsOnline = new Timer(components);
            _TimerCheckIsOnline.Tick += new EventHandler(TimerCheckIsOnline_Tick);
            ((System.ComponentModel.ISupportInitialize)_PictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_selectionOkpic).BeginInit();
            SuspendLayout();
            // 
            // domain_web_ex
            // 
            _domain_web_ex.AutoSize = true;
            _domain_web_ex.Font = new Font("Trajan Pro", 7.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _domain_web_ex.ForeColor = Color.Black;
            _domain_web_ex.Location = new Point(454, 547);
            _domain_web_ex.Margin = new Padding(4, 0, 4, 0);
            _domain_web_ex.Name = "_domain_web_ex";
            _domain_web_ex.Size = new Size(278, 18);
            _domain_web_ex.TabIndex = 22;
            _domain_web_ex.Text = "ex.: http://www.yourdomain.com";
            // 
            // server_web_addr_lbl
            // 
            _server_web_addr_lbl.AutoSize = true;
            _server_web_addr_lbl.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _server_web_addr_lbl.ForeColor = Color.Black;
            _server_web_addr_lbl.Location = new Point(449, 482);
            _server_web_addr_lbl.Margin = new Padding(4, 0, 4, 0);
            _server_web_addr_lbl.Name = "_server_web_addr_lbl";
            _server_web_addr_lbl.Size = new Size(207, 23);
            _server_web_addr_lbl.TabIndex = 21;
            _server_web_addr_lbl.Text = "Server web address";
            _server_web_addr_lbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // server_web_addr
            // 
            _server_web_addr.Font = new Font("Arial", 9.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _server_web_addr.Location = new Point(453, 510);
            _server_web_addr.Margin = new Padding(4, 5, 4, 5);
            _server_web_addr.Name = "_server_web_addr";
            _server_web_addr.Size = new Size(634, 28);
            _server_web_addr.TabIndex = 3;
            // 
            // PictureBox1
            // 
            _PictureBox1.Image = (Image)resources.GetObject("PictureBox1.Image");
            _PictureBox1.Location = new Point(453, 29);
            _PictureBox1.Margin = new Padding(4, 5, 4, 5);
            _PictureBox1.Name = "_PictureBox1";
            _PictureBox1.Size = new Size(634, 378);
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
            // selectionOkpic
            // 
            _selectionOkpic.Image = (Image)resources.GetObject("selectionOkpic.Image");
            _selectionOkpic.Location = new Point(1094, 498);
            _selectionOkpic.Name = "_selectionOkpic";
            _selectionOkpic.Size = new Size(40, 40);
            _selectionOkpic.SizeMode = PictureBoxSizeMode.StretchImage;
            _selectionOkpic.TabIndex = 24;
            _selectionOkpic.TabStop = false;
            _selectionOkpic.Visible = false;
            // 
            // TimerCheckIsOnline
            // 
            _TimerCheckIsOnline.Interval = 1000;
            // 
            // setupWizard_ServerAddress
            // 
            AutoScaleDimensions = new SizeF(9.0F, 20.0F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1600, 742);
            ControlBox = false;
            Controls.Add(_selectionOkpic);
            Controls.Add(_domain_web_ex);
            Controls.Add(_server_web_addr_lbl);
            Controls.Add(_PictureBox1);
            Controls.Add(_server_web_addr);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "setupWizard_ServerAddress";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            TransparencyKey = Color.Transparent;
            ((System.ComponentModel.ISupportInitialize)_PictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)_selectionOkpic).EndInit();
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

        private PictureBox _selectionOkpic;

        internal PictureBox selectionOkpic
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _selectionOkpic;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_selectionOkpic != null)
                {
                }

                _selectionOkpic = value;
                if (_selectionOkpic != null)
                {
                }
            }
        }

        private Timer _TimerCheckIsOnline;

        internal Timer TimerCheckIsOnline
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TimerCheckIsOnline;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TimerCheckIsOnline != null)
                {
                    _TimerCheckIsOnline.Tick -= TimerCheckIsOnline_Tick;
                }

                _TimerCheckIsOnline = value;
                if (_TimerCheckIsOnline != null)
                {
                    _TimerCheckIsOnline.Tick += TimerCheckIsOnline_Tick;
                }
            }
        }
    }
}