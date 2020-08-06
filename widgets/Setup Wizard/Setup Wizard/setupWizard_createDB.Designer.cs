using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace ConstructionSiteLogistics.Setup.Gui2
{
    [DesignerGenerated()]
    public partial class setupWizard_createDB : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(setupWizard_createDB));
            _ColorWithAlpha1 = new BlueActivity.ColorWithAlpha();
            _db_name = new TextBox();
            _db_name.TextChanged += new EventHandler(db_name_TextChanged);
            _db_name_lbl = new ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer();
            _db_user = new TextBox();
            _db_user.TextChanged += new EventHandler(db_user_TextChanged);
            _PictureBox1 = new PictureBox();
            _db_user_lbl = new ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer();
            _db_pwd = new TextBox();
            _db_pwd.TextChanged += new EventHandler(db_pwd_TextChanged);
            _db_pwd_lbl = new ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer();
            ((System.ComponentModel.ISupportInitialize)_PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // ColorWithAlpha1
            // 
            _ColorWithAlpha1.Alpha = 150;
            _ColorWithAlpha1.Color = Color.Black;
            _ColorWithAlpha1.Parent = null;
            // 
            // db_name
            // 
            _db_name.Font = new Font("Arial", 9.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _db_name.Location = new Point(583, 526);
            _db_name.Margin = new Padding(4, 5, 4, 5);
            _db_name.Name = "_db_name";
            _db_name.Size = new Size(352, 28);
            _db_name.TabIndex = 10;
            // 
            // db_name_lbl
            // 
            _db_name_lbl.AutoSize = true;
            _db_name_lbl.BackColor = Color.Transparent;
            _db_name_lbl.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _db_name_lbl.ForeColor = Color.Black;
            _db_name_lbl.Location = new Point(578, 499);
            _db_name_lbl.Margin = new Padding(4, 0, 4, 0);
            _db_name_lbl.Name = "_db_name_lbl";
            _db_name_lbl.Size = new Size(159, 23);
            _db_name_lbl.TabIndex = 11;
            _db_name_lbl.Text = "DataBase name";
            // 
            // db_user
            // 
            _db_user.Font = new Font("Arial", 9.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _db_user.Location = new Point(583, 591);
            _db_user.Margin = new Padding(4, 5, 4, 5);
            _db_user.Name = "_db_user";
            _db_user.Size = new Size(352, 28);
            _db_user.TabIndex = 15;
            // 
            // PictureBox1
            // 
            _PictureBox1.Image = (Image)resources.GetObject("PictureBox1.Image");
            _PictureBox1.Location = new Point(487, 45);
            _PictureBox1.Margin = new Padding(4, 5, 4, 5);
            _PictureBox1.Name = "_PictureBox1";
            _PictureBox1.Size = new Size(542, 409);
            _PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            _PictureBox1.TabIndex = 2;
            _PictureBox1.TabStop = false;
            // 
            // db_user_lbl
            // 
            _db_user_lbl.AutoSize = true;
            _db_user_lbl.BackColor = Color.Transparent;
            _db_user_lbl.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _db_user_lbl.ForeColor = Color.Black;
            _db_user_lbl.Location = new Point(578, 563);
            _db_user_lbl.Margin = new Padding(4, 0, 4, 0);
            _db_user_lbl.Name = "_db_user_lbl";
            _db_user_lbl.Size = new Size(274, 23);
            _db_user_lbl.TabIndex = 16;
            _db_user_lbl.Text = "DataBase access username";
            // 
            // db_pwd
            // 
            _db_pwd.Font = new Font("Arial", 9.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _db_pwd.Location = new Point(583, 656);
            _db_pwd.Margin = new Padding(4, 5, 4, 5);
            _db_pwd.Name = "_db_pwd";
            _db_pwd.Size = new Size(352, 28);
            _db_pwd.TabIndex = 17;
            // 
            // db_pwd_lbl
            // 
            _db_pwd_lbl.AutoSize = true;
            _db_pwd_lbl.BackColor = Color.Transparent;
            _db_pwd_lbl.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _db_pwd_lbl.ForeColor = Color.Black;
            _db_pwd_lbl.Location = new Point(578, 628);
            _db_pwd_lbl.Margin = new Padding(4, 0, 4, 0);
            _db_pwd_lbl.Name = "_db_pwd_lbl";
            _db_pwd_lbl.Size = new Size(275, 23);
            _db_pwd_lbl.TabIndex = 18;
            _db_pwd_lbl.Text = "DataBase access password";
            // 
            // setupWizard_createDB
            // 
            AutoScaleDimensions = new SizeF(9.0F, 20.0F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1600, 742);
            ControlBox = false;
            Controls.Add(_db_pwd_lbl);
            Controls.Add(_db_pwd);
            Controls.Add(_PictureBox1);
            Controls.Add(_db_user_lbl);
            Controls.Add(_db_name);
            Controls.Add(_db_name_lbl);
            Controls.Add(_db_user);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "setupWizard_createDB";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            TransparencyKey = Color.Transparent;
            ((System.ComponentModel.ISupportInitialize)_PictureBox1).EndInit();
            VisibleChanged += new EventHandler(setupWizard_VisibleChanged);
            Load += new EventHandler(setupWizard_1_Load);
            ResumeLayout(false);
            PerformLayout();
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

        private TextBox _db_name;

        internal TextBox db_name
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _db_name;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_db_name != null)
                {
                    _db_name.TextChanged -= db_name_TextChanged;
                }

                _db_name = value;
                if (_db_name != null)
                {
                    _db_name.TextChanged += db_name_TextChanged;
                }
            }
        }

        private Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer _db_name_lbl;

        internal Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer db_name_lbl
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _db_name_lbl;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_db_name_lbl != null)
                {
                }

                _db_name_lbl = value;
                if (_db_name_lbl != null)
                {
                }
            }
        }

        private TextBox _db_user;

        internal TextBox db_user
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _db_user;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_db_user != null)
                {
                    _db_user.TextChanged -= db_user_TextChanged;
                }

                _db_user = value;
                if (_db_user != null)
                {
                    _db_user.TextChanged += db_user_TextChanged;
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

        private Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer _db_user_lbl;

        internal Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer db_user_lbl
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _db_user_lbl;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_db_user_lbl != null)
                {
                }

                _db_user_lbl = value;
                if (_db_user_lbl != null)
                {
                }
            }
        }

        private TextBox _db_pwd;

        internal TextBox db_pwd
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _db_pwd;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_db_pwd != null)
                {
                    _db_pwd.TextChanged -= db_pwd_TextChanged;
                }

                _db_pwd = value;
                if (_db_pwd != null)
                {
                    _db_pwd.TextChanged += db_pwd_TextChanged;
                }
            }
        }

        private Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer _db_pwd_lbl;

        internal Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer db_pwd_lbl
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _db_pwd_lbl;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_db_pwd_lbl != null)
                {
                }

                _db_pwd_lbl = value;
                if (_db_pwd_lbl != null)
                {
                }
            }
        }
    }
}