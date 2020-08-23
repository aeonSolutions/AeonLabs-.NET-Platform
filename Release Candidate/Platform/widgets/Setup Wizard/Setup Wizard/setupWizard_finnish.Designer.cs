using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace ConstructionSiteLogistics.Setup.Gui2
{
    [DesignerGenerated()]
    public partial class setupWizard_finnish : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(setupWizard_finnish));
            _btnContinueTxt = new ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer();
            _btnContinueTxt.Click += btnContinueTxt_Click;
            _btnContinue = new PictureBox();
            _btnContinue.Click += new EventHandler(btnContinue_Click);
            _PictureBox1 = new PictureBox();
            _ColorWithAlpha1 = new BlueActivity.ColorWithAlpha();
            ((System.ComponentModel.ISupportInitialize)_btnContinue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnContinueTxt
            // 
            _btnContinueTxt.AutoSize = true;
            _btnContinueTxt.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnContinueTxt.ForeColor = Color.Black;
            _btnContinueTxt.Location = new Point(709, 706);
            _btnContinueTxt.Margin = new Padding(4, 0, 4, 0);
            _btnContinueTxt.Name = "_btnContinueTxt";
            _btnContinueTxt.Size = new Size(145, 23);
            _btnContinueTxt.TabIndex = 8;
            _btnContinueTxt.Text = "Start the App";
            _btnContinueTxt.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnContinue
            // 
            _btnContinue.Image = (Image)resources.GetObject("btnContinue.Image");
            _btnContinue.Location = new Point(740, 647);
            _btnContinue.Margin = new Padding(4, 5, 4, 5);
            _btnContinue.Name = "_btnContinue";
            _btnContinue.Size = new Size(53, 54);
            _btnContinue.SizeMode = PictureBoxSizeMode.StretchImage;
            _btnContinue.TabIndex = 6;
            _btnContinue.TabStop = false;
            // 
            // PictureBox1
            // 
            _PictureBox1.Image = (Image)resources.GetObject("PictureBox1.Image");
            _PictureBox1.Location = new Point(396, 54);
            _PictureBox1.Margin = new Padding(4, 5, 4, 5);
            _PictureBox1.Name = "_PictureBox1";
            _PictureBox1.Size = new Size(750, 542);
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
            // setupWizard_finnish
            // 
            AutoScaleDimensions = new SizeF(9.0F, 20.0F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1600, 742);
            ControlBox = false;
            Controls.Add(_btnContinueTxt);
            Controls.Add(_btnContinue);
            Controls.Add(_PictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "setupWizard_finnish";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            TransparencyKey = Color.Transparent;
            ((System.ComponentModel.ISupportInitialize)_btnContinue).EndInit();
            ((System.ComponentModel.ISupportInitialize)_PictureBox1).EndInit();
            Load += new EventHandler(setupWizard_1_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        private Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer _btnContinueTxt;

        internal Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer btnContinueTxt
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnContinueTxt;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnContinueTxt != null)
                {
                    _btnContinueTxt.Click -= btnContinueTxt_Click;
                }

                _btnContinueTxt = value;
                if (_btnContinueTxt != null)
                {
                    _btnContinueTxt.Click += btnContinueTxt_Click;
                }
            }
        }

        private PictureBox _btnContinue;

        internal PictureBox btnContinue
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnContinue;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnContinue != null)
                {
                    _btnContinue.Click -= btnContinue_Click;
                }

                _btnContinue = value;
                if (_btnContinue != null)
                {
                    _btnContinue.Click += btnContinue_Click;
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