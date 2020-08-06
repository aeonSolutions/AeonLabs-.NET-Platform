using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace ConstructionSiteLogistics.Setup.Gui2
{
    [DesignerGenerated()]
    public partial class setupWizard_DiagnosticsCrashData : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(setupWizard_DiagnosticsCrashData));
            _about_diagnostics = new LinkLabel();
            _about_diagnostics.LinkClicked += new LinkLabelLinkClickedEventHandler(about_diagnostics_LinkClicked);
            _share = new CheckBox();
            _share.CheckedChanged += new EventHandler(share_CheckedChanged);
            _send = new CheckBox();
            _send.CheckedChanged += new EventHandler(send_CheckedChanged);
            _PictureBox1 = new PictureBox();
            _ColorWithAlpha1 = new BlueActivity.ColorWithAlpha();
            _share_details = new ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer();
            _send_details = new ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer();
            ((System.ComponentModel.ISupportInitialize)_PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // about_diagnostics
            // 
            _about_diagnostics.AutoSize = true;
            _about_diagnostics.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _about_diagnostics.Location = new Point(707, 677);
            _about_diagnostics.Margin = new Padding(4, 0, 4, 0);
            _about_diagnostics.Name = "_about_diagnostics";
            _about_diagnostics.Size = new Size(357, 23);
            _about_diagnostics.TabIndex = 13;
            _about_diagnostics.TabStop = true;
            _about_diagnostics.Text = "About Diagnostics and Privacy ...";
            // 
            // share
            // 
            _share.AutoSize = true;
            _share.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _share.ForeColor = Color.Black;
            _share.Location = new Point(523, 549);
            _share.Margin = new Padding(4, 5, 4, 5);
            _share.Name = "_share";
            _share.Size = new Size(427, 27);
            _share.TabIndex = 11;
            _share.Text = "Share crash data with app developers";
            _share.UseVisualStyleBackColor = true;
            // 
            // send
            // 
            _send.AutoSize = true;
            _send.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _send.ForeColor = Color.Black;
            _send.Location = new Point(523, 417);
            _send.Margin = new Padding(4, 5, 4, 5);
            _send.Name = "_send";
            _send.Size = new Size(353, 27);
            _send.TabIndex = 9;
            _send.Text = "Send diagnostics && usage data";
            _send.UseVisualStyleBackColor = true;
            // 
            // PictureBox1
            // 
            _PictureBox1.Image = (Image)resources.GetObject("PictureBox1.Image");
            _PictureBox1.Location = new Point(564, 14);
            _PictureBox1.Margin = new Padding(4, 5, 4, 5);
            _PictureBox1.Name = "_PictureBox1";
            _PictureBox1.Size = new Size(459, 394);
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
            // share_details
            // 
            _share_details.Font = new Font("Trajan Pro", 8.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _share_details.ForeColor = Color.Black;
            _share_details.ImageAlign = ContentAlignment.TopLeft;
            _share_details.Location = new Point(544, 581);
            _share_details.Name = "_share_details";
            _share_details.Size = new Size(479, 96);
            _share_details.TabIndex = 15;
            _share_details.Text = "Help app developers improve their apps by allowing us to share crash data with th" + "em.";
            // 
            // send_details
            // 
            _send_details.Font = new Font("Trajan Pro", 8.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _send_details.ForeColor = Color.Black;
            _send_details.ImageAlign = ContentAlignment.TopLeft;
            _send_details.Location = new Point(544, 449);
            _send_details.Name = "_send_details";
            _send_details.Size = new Size(520, 95);
            _send_details.TabIndex = 14;
            _send_details.Text = "Help us improve the products and services by automatically sending diagnostics an" + "d usage data. Diagnostic my include locations.";
            // 
            // setupWizard_DiagnosticsCrashData
            // 
            AutoScaleDimensions = new SizeF(9.0F, 20.0F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1600, 742);
            ControlBox = false;
            Controls.Add(_share_details);
            Controls.Add(_send_details);
            Controls.Add(_PictureBox1);
            Controls.Add(_about_diagnostics);
            Controls.Add(_send);
            Controls.Add(_share);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "setupWizard_DiagnosticsCrashData";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            TransparencyKey = Color.Transparent;
            ((System.ComponentModel.ISupportInitialize)_PictureBox1).EndInit();
            Load += new EventHandler(setupWizard_1_Load);
            VisibleChanged += new EventHandler(setupWizard_1_VisibleChanged);
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

        private LinkLabel _about_diagnostics;

        internal LinkLabel about_diagnostics
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _about_diagnostics;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_about_diagnostics != null)
                {
                    _about_diagnostics.LinkClicked -= about_diagnostics_LinkClicked;
                }

                _about_diagnostics = value;
                if (_about_diagnostics != null)
                {
                    _about_diagnostics.LinkClicked += about_diagnostics_LinkClicked;
                }
            }
        }

        private CheckBox _share;

        internal CheckBox share
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _share;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_share != null)
                {
                    _share.CheckedChanged -= share_CheckedChanged;
                }

                _share = value;
                if (_share != null)
                {
                    _share.CheckedChanged += share_CheckedChanged;
                }
            }
        }

        private CheckBox _send;

        internal CheckBox send
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
                    _send.CheckedChanged -= send_CheckedChanged;
                }

                _send = value;
                if (_send != null)
                {
                    _send.CheckedChanged += send_CheckedChanged;
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

        private Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer _share_details;

        internal Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer share_details
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _share_details;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_share_details != null)
                {
                }

                _share_details = value;
                if (_share_details != null)
                {
                }
            }
        }

        private Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer _send_details;

        internal Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer send_details
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _send_details;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_send_details != null)
                {
                }

                _send_details = value;
                if (_send_details != null)
                {
                }
            }
        }
    }
}