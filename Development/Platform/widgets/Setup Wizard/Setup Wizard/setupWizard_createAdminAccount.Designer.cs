using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace ConstructionSiteLogistics.Setup.Gui2
{
    [DesignerGenerated()]
    public partial class setupWizard_createAdminAccount : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(setupWizard_createAdminAccount));
            _PictureBox3 = new PictureBox();
            _PictureBox3.Click += new EventHandler(PictureBox3_Click);
            _id_verify_lbl = new ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer();
            _id_verify = new TextBox();
            _id_verify.TextChanged += new EventHandler(id_verify_TextChanged);
            _id_lbl = new ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer();
            _id = new TextBox();
            _id.TextChanged += new EventHandler(id_TextChanged);
            _full_name_lbl = new ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer();
            _full_name = new TextBox();
            _full_name.TextChanged += new EventHandler(full_name_TextChanged);
            _ColorWithAlpha1 = new BlueActivity.ColorWithAlpha();
            ((System.ComponentModel.ISupportInitialize)_PictureBox3).BeginInit();
            SuspendLayout();
            // 
            // PictureBox3
            // 
            _PictureBox3.Image = (Image)resources.GetObject("PictureBox3.Image");
            _PictureBox3.Location = new Point(459, 230);
            _PictureBox3.Margin = new Padding(4, 5, 4, 5);
            _PictureBox3.Name = "_PictureBox3";
            _PictureBox3.Size = new Size(182, 180);
            _PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            _PictureBox3.TabIndex = 19;
            _PictureBox3.TabStop = false;
            // 
            // id_verify_lbl
            // 
            _id_verify_lbl.AutoSize = true;
            _id_verify_lbl.BackColor = Color.Transparent;
            _id_verify_lbl.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _id_verify_lbl.ForeColor = Color.Black;
            _id_verify_lbl.Location = new Point(674, 350);
            _id_verify_lbl.Margin = new Padding(4, 0, 4, 0);
            _id_verify_lbl.Name = "_id_verify_lbl";
            _id_verify_lbl.Size = new Size(301, 23);
            _id_verify_lbl.TabIndex = 18;
            _id_verify_lbl.Text = "Verify authentication code";
            // 
            // id_verify
            // 
            _id_verify.Font = new Font("Arial", 9.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _id_verify.Location = new Point(678, 378);
            _id_verify.Margin = new Padding(4, 5, 4, 5);
            _id_verify.Name = "_id_verify";
            _id_verify.Size = new Size(352, 28);
            _id_verify.TabIndex = 17;
            // 
            // id_lbl
            // 
            _id_lbl.AutoSize = true;
            _id_lbl.BackColor = Color.Transparent;
            _id_lbl.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _id_lbl.ForeColor = Color.Black;
            _id_lbl.Location = new Point(674, 285);
            _id_lbl.Margin = new Padding(4, 0, 4, 0);
            _id_lbl.Name = "_id_lbl";
            _id_lbl.Size = new Size(235, 23);
            _id_lbl.TabIndex = 16;
            _id_lbl.Text = "Authentication code";
            // 
            // id
            // 
            _id.Font = new Font("Arial", 9.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _id.Location = new Point(678, 313);
            _id.Margin = new Padding(4, 5, 4, 5);
            _id.Name = "_id";
            _id.Size = new Size(352, 28);
            _id.TabIndex = 15;
            // 
            // full_name_lbl
            // 
            _full_name_lbl.AutoSize = true;
            _full_name_lbl.BackColor = Color.Transparent;
            _full_name_lbl.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _full_name_lbl.ForeColor = Color.Black;
            _full_name_lbl.Location = new Point(674, 222);
            _full_name_lbl.Margin = new Padding(4, 0, 4, 0);
            _full_name_lbl.Name = "_full_name_lbl";
            _full_name_lbl.Size = new Size(113, 23);
            _full_name_lbl.TabIndex = 11;
            _full_name_lbl.Text = "Full name";
            // 
            // full_name
            // 
            _full_name.Font = new Font("Arial", 9.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _full_name.Location = new Point(678, 248);
            _full_name.Margin = new Padding(4, 5, 4, 5);
            _full_name.Name = "_full_name";
            _full_name.Size = new Size(352, 28);
            _full_name.TabIndex = 10;
            // 
            // ColorWithAlpha1
            // 
            _ColorWithAlpha1.Alpha = 150;
            _ColorWithAlpha1.Color = Color.Black;
            _ColorWithAlpha1.Parent = null;
            // 
            // setupWizard_createAdminAccount
            // 
            AutoScaleDimensions = new SizeF(9.0F, 20.0F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1600, 742);
            ControlBox = false;
            Controls.Add(_PictureBox3);
            Controls.Add(_id_verify_lbl);
            Controls.Add(_id_verify);
            Controls.Add(_full_name);
            Controls.Add(_id_lbl);
            Controls.Add(_full_name_lbl);
            Controls.Add(_id);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "setupWizard_createAdminAccount";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            TransparencyKey = Color.Transparent;
            ((System.ComponentModel.ISupportInitialize)_PictureBox3).EndInit();
            VisibleChanged += new EventHandler(setupWizard_1_VisibleChanged);
            Load += new EventHandler(setupWizard_1_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        private Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer _full_name_lbl;

        internal Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer full_name_lbl
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _full_name_lbl;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_full_name_lbl != null)
                {
                }

                _full_name_lbl = value;
                if (_full_name_lbl != null)
                {
                }
            }
        }

        private TextBox _full_name;

        internal TextBox full_name
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _full_name;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_full_name != null)
                {
                    _full_name.TextChanged -= full_name_TextChanged;
                }

                _full_name = value;
                if (_full_name != null)
                {
                    _full_name.TextChanged += full_name_TextChanged;
                }
            }
        }

        private Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer _id_verify_lbl;

        internal Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer id_verify_lbl
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _id_verify_lbl;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_id_verify_lbl != null)
                {
                }

                _id_verify_lbl = value;
                if (_id_verify_lbl != null)
                {
                }
            }
        }

        private TextBox _id_verify;

        internal TextBox id_verify
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _id_verify;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_id_verify != null)
                {
                    _id_verify.TextChanged -= id_verify_TextChanged;
                }

                _id_verify = value;
                if (_id_verify != null)
                {
                    _id_verify.TextChanged += id_verify_TextChanged;
                }
            }
        }

        private Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer _id_lbl;

        internal Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer id_lbl
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _id_lbl;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_id_lbl != null)
                {
                }

                _id_lbl = value;
                if (_id_lbl != null)
                {
                }
            }
        }

        private TextBox _id;

        internal TextBox id
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _id;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_id != null)
                {
                    _id.TextChanged -= id_TextChanged;
                }

                _id = value;
                if (_id != null)
                {
                    _id.TextChanged += id_TextChanged;
                }
            }
        }

        private PictureBox _PictureBox3;

        internal PictureBox PictureBox3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PictureBox3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PictureBox3 != null)
                {
                    _PictureBox3.Click -= PictureBox3_Click;
                }

                _PictureBox3 = value;
                if (_PictureBox3 != null)
                {
                    _PictureBox3.Click += PictureBox3_Click;
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