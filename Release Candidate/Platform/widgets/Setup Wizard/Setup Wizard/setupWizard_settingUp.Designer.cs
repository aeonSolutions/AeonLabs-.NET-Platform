using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace ConstructionSiteLogistics.Setup.Gui2
{
    [DesignerGenerated()]
    public partial class setupWizard_settingUp : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(setupWizard_settingUp));
            _PictureBox1 = new PictureBox();
            _progress_status_text = new ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer();
            _ProgressBar = new ProgressBar();
            _PictureBox2 = new PictureBox();
            _Timer = new Timer(components);
            _Timer.Tick += new EventHandler(Timer_Tick);
            _ColorWithAlpha1 = new BlueActivity.ColorWithAlpha();
            ((System.ComponentModel.ISupportInitialize)_PictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_PictureBox2).BeginInit();
            SuspendLayout();
            // 
            // PictureBox1
            // 
            _PictureBox1.Image = (Image)resources.GetObject("PictureBox1.Image");
            _PictureBox1.Location = new Point(444, 48);
            _PictureBox1.Margin = new Padding(4, 5, 4, 5);
            _PictureBox1.Name = "_PictureBox1";
            _PictureBox1.Size = new Size(629, 452);
            _PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            _PictureBox1.TabIndex = 2;
            _PictureBox1.TabStop = false;
            // 
            // progress_status_text
            // 
            _progress_status_text.AutoSize = true;
            _progress_status_text.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _progress_status_text.ForeColor = Color.Black;
            _progress_status_text.Location = new Point(728, 671);
            _progress_status_text.Margin = new Padding(4, 0, 4, 0);
            _progress_status_text.Name = "_progress_status_text";
            _progress_status_text.Size = new Size(138, 23);
            _progress_status_text.TabIndex = 11;
            _progress_status_text.Text = "Setting up ...";
            // 
            // ProgressBar
            // 
            _ProgressBar.Location = new Point(683, 573);
            _ProgressBar.Margin = new Padding(4, 5, 4, 5);
            _ProgressBar.Name = "_ProgressBar";
            _ProgressBar.Size = new Size(150, 22);
            _ProgressBar.TabIndex = 13;
            // 
            // PictureBox2
            // 
            _PictureBox2.Image = (Image)resources.GetObject("PictureBox2.Image");
            _PictureBox2.Location = new Point(667, 656);
            _PictureBox2.Margin = new Padding(4, 5, 4, 5);
            _PictureBox2.Name = "_PictureBox2";
            _PictureBox2.Size = new Size(53, 54);
            _PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            _PictureBox2.TabIndex = 12;
            _PictureBox2.TabStop = false;
            // 
            // Timer
            // 
            _Timer.Enabled = true;
            _Timer.Interval = 20;
            // 
            // ColorWithAlpha1
            // 
            _ColorWithAlpha1.Alpha = 150;
            _ColorWithAlpha1.Color = Color.Black;
            _ColorWithAlpha1.Parent = null;
            // 
            // setupWizard_settingUp
            // 
            AutoScaleDimensions = new SizeF(9.0F, 20.0F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1600, 742);
            ControlBox = false;
            Controls.Add(_ProgressBar);
            Controls.Add(_PictureBox2);
            Controls.Add(_PictureBox1);
            Controls.Add(_progress_status_text);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "setupWizard_settingUp";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            TransparencyKey = Color.Transparent;
            ((System.ComponentModel.ISupportInitialize)_PictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)_PictureBox2).EndInit();
            VisibleChanged += new EventHandler(setupWizard_VisibleChanged);
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

        private Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer _progress_status_text;

        internal Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer progress_status_text
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _progress_status_text;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_progress_status_text != null)
                {
                }

                _progress_status_text = value;
                if (_progress_status_text != null)
                {
                }
            }
        }

        private PictureBox _PictureBox2;

        internal PictureBox PictureBox2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PictureBox2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PictureBox2 != null)
                {
                }

                _PictureBox2 = value;
                if (_PictureBox2 != null)
                {
                }
            }
        }

        private Timer _Timer;

        internal Timer Timer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Timer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Timer != null)
                {
                    _Timer.Tick -= Timer_Tick;
                }

                _Timer = value;
                if (_Timer != null)
                {
                    _Timer.Tick += Timer_Tick;
                }
            }
        }

        private ProgressBar _ProgressBar;

        internal ProgressBar ProgressBar
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ProgressBar;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ProgressBar != null)
                {
                }

                _ProgressBar = value;
                if (_ProgressBar != null)
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