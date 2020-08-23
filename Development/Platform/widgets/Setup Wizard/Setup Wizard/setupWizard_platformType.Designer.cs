using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace ConstructionSiteLogistics.Setup.Gui2
{
    [DesignerGenerated()]
    public partial class setupWizard_platformType : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(setupWizard_platformType));
            _ownBtn = new CheckBox();
            _ownBtn.CheckedChanged += new EventHandler(ownBtn_CheckedChanged);
            _sharedBtn = new CheckBox();
            _sharedBtn.CheckedChanged += new EventHandler(sharedBtn_CheckedChanged);
            _ownConnectExisting = new RadioButton();
            _ownConnectExisting.CheckedChanged += new EventHandler(ownConnectExisting_CheckedChanged);
            _ownSetupNew = new RadioButton();
            _ownSetupNew.CheckedChanged += new EventHandler(ownSetupNew_CheckedChanged);
            _SharedConnectExisting = new RadioButton();
            _SharedConnectExisting.CheckedChanged += new EventHandler(SharedConnectExisting_CheckedChanged);
            _sharedSetupNew = new RadioButton();
            _sharedSetupNew.CheckedChanged += new EventHandler(sharedSetupNew_CheckedChanged);
            _PictureBox1 = new PictureBox();
            _ColorWithAlpha1 = new BlueActivity.ColorWithAlpha();
            ((System.ComponentModel.ISupportInitialize)_PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // ownBtn
            // 
            _ownBtn.AutoSize = true;
            _ownBtn.Font = new Font("Trajan Pro", 12.0F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _ownBtn.ForeColor = Color.Black;
            _ownBtn.Location = new Point(563, 582);
            _ownBtn.Margin = new Padding(4, 5, 4, 5);
            _ownBtn.Name = "_ownBtn";
            _ownBtn.Size = new Size(447, 34);
            _ownBtn.TabIndex = 16;
            _ownBtn.Text = "Own Dedicated Cloud Server";
            _ownBtn.UseVisualStyleBackColor = true;
            // 
            // sharedBtn
            // 
            _sharedBtn.AutoSize = true;
            _sharedBtn.Font = new Font("Trajan Pro", 12.0F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _sharedBtn.ForeColor = Color.Black;
            _sharedBtn.Location = new Point(563, 451);
            _sharedBtn.Margin = new Padding(4, 5, 4, 5);
            _sharedBtn.Name = "_sharedBtn";
            _sharedBtn.Size = new Size(466, 34);
            _sharedBtn.TabIndex = 15;
            _sharedBtn.Text = "Shared Cloud Server Platform";
            _sharedBtn.UseVisualStyleBackColor = true;
            // 
            // ownConnectExisting
            // 
            _ownConnectExisting.AutoSize = true;
            _ownConnectExisting.Enabled = false;
            _ownConnectExisting.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _ownConnectExisting.ForeColor = Color.Black;
            _ownConnectExisting.Location = new Point(626, 663);
            _ownConnectExisting.Margin = new Padding(4, 5, 4, 5);
            _ownConnectExisting.Name = "_ownConnectExisting";
            _ownConnectExisting.Size = new Size(379, 27);
            _ownConnectExisting.TabIndex = 14;
            _ownConnectExisting.TabStop = true;
            _ownConnectExisting.Text = "Connect to an existing platform";
            _ownConnectExisting.UseVisualStyleBackColor = true;
            // 
            // ownSetupNew
            // 
            _ownSetupNew.AutoSize = true;
            _ownSetupNew.Enabled = false;
            _ownSetupNew.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _ownSetupNew.ForeColor = Color.Black;
            _ownSetupNew.Location = new Point(626, 625);
            _ownSetupNew.Margin = new Padding(4, 5, 4, 5);
            _ownSetupNew.Name = "_ownSetupNew";
            _ownSetupNew.Size = new Size(254, 27);
            _ownSetupNew.TabIndex = 13;
            _ownSetupNew.TabStop = true;
            _ownSetupNew.Text = "SetUp a new platform";
            _ownSetupNew.UseVisualStyleBackColor = true;
            // 
            // SharedConnectExisting
            // 
            _SharedConnectExisting.AutoSize = true;
            _SharedConnectExisting.Enabled = false;
            _SharedConnectExisting.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _SharedConnectExisting.ForeColor = Color.Black;
            _SharedConnectExisting.Location = new Point(626, 532);
            _SharedConnectExisting.Margin = new Padding(4, 5, 4, 5);
            _SharedConnectExisting.Name = "_SharedConnectExisting";
            _SharedConnectExisting.Size = new Size(379, 27);
            _SharedConnectExisting.TabIndex = 12;
            _SharedConnectExisting.TabStop = true;
            _SharedConnectExisting.Text = "Connect to an existing platform";
            _SharedConnectExisting.UseVisualStyleBackColor = true;
            // 
            // sharedSetupNew
            // 
            _sharedSetupNew.AutoSize = true;
            _sharedSetupNew.Enabled = false;
            _sharedSetupNew.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _sharedSetupNew.ForeColor = Color.Black;
            _sharedSetupNew.Location = new Point(626, 495);
            _sharedSetupNew.Margin = new Padding(4, 5, 4, 5);
            _sharedSetupNew.Name = "_sharedSetupNew";
            _sharedSetupNew.Size = new Size(254, 27);
            _sharedSetupNew.TabIndex = 11;
            _sharedSetupNew.TabStop = true;
            _sharedSetupNew.Text = "SetUp a new platform";
            _sharedSetupNew.UseVisualStyleBackColor = true;
            // 
            // PictureBox1
            // 
            _PictureBox1.Image = (Image)resources.GetObject("PictureBox1.Image");
            _PictureBox1.Location = new Point(483, 48);
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
            // setupWizard_platformType
            // 
            AutoScaleDimensions = new SizeF(9.0F, 20.0F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1600, 742);
            ControlBox = false;
            Controls.Add(_ownBtn);
            Controls.Add(_sharedBtn);
            Controls.Add(_PictureBox1);
            Controls.Add(_ownConnectExisting);
            Controls.Add(_sharedSetupNew);
            Controls.Add(_SharedConnectExisting);
            Controls.Add(_ownSetupNew);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "setupWizard_platformType";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            TransparencyKey = Color.Transparent;
            ((System.ComponentModel.ISupportInitialize)_PictureBox1).EndInit();
            VisibleChanged += new EventHandler(setupWizard_1_VisibleChanged);
            Load += new EventHandler(setupWizard_1_Load);
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

        private RadioButton _ownConnectExisting;

        internal RadioButton ownConnectExisting
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ownConnectExisting;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ownConnectExisting != null)
                {
                    _ownConnectExisting.CheckedChanged -= ownConnectExisting_CheckedChanged;
                }

                _ownConnectExisting = value;
                if (_ownConnectExisting != null)
                {
                    _ownConnectExisting.CheckedChanged += ownConnectExisting_CheckedChanged;
                }
            }
        }

        private RadioButton _ownSetupNew;

        internal RadioButton ownSetupNew
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ownSetupNew;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ownSetupNew != null)
                {
                    _ownSetupNew.CheckedChanged -= ownSetupNew_CheckedChanged;
                }

                _ownSetupNew = value;
                if (_ownSetupNew != null)
                {
                    _ownSetupNew.CheckedChanged += ownSetupNew_CheckedChanged;
                }
            }
        }

        private RadioButton _SharedConnectExisting;

        internal RadioButton SharedConnectExisting
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SharedConnectExisting;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SharedConnectExisting != null)
                {
                    _SharedConnectExisting.CheckedChanged -= SharedConnectExisting_CheckedChanged;
                }

                _SharedConnectExisting = value;
                if (_SharedConnectExisting != null)
                {
                    _SharedConnectExisting.CheckedChanged += SharedConnectExisting_CheckedChanged;
                }
            }
        }

        private RadioButton _sharedSetupNew;

        internal RadioButton sharedSetupNew
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _sharedSetupNew;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_sharedSetupNew != null)
                {
                    _sharedSetupNew.CheckedChanged -= sharedSetupNew_CheckedChanged;
                }

                _sharedSetupNew = value;
                if (_sharedSetupNew != null)
                {
                    _sharedSetupNew.CheckedChanged += sharedSetupNew_CheckedChanged;
                }
            }
        }

        private CheckBox _ownBtn;

        internal CheckBox ownBtn
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ownBtn;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ownBtn != null)
                {
                    _ownBtn.CheckedChanged -= ownBtn_CheckedChanged;
                }

                _ownBtn = value;
                if (_ownBtn != null)
                {
                    _ownBtn.CheckedChanged += ownBtn_CheckedChanged;
                }
            }
        }

        private CheckBox _sharedBtn;

        internal CheckBox sharedBtn
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _sharedBtn;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_sharedBtn != null)
                {
                    _sharedBtn.CheckedChanged -= sharedBtn_CheckedChanged;
                }

                _sharedBtn = value;
                if (_sharedBtn != null)
                {
                    _sharedBtn.CheckedChanged += sharedBtn_CheckedChanged;
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