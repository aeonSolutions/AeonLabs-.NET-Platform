using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace AeonLabs.Loading
{
    [DesignerGenerated()]
    public partial class loadingForm : Form
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
            _progressbar = new CircularProgressBar.CircularProgress.CircularProgressBar();
            _Label1 = new Label();
            _exitAppLink = new LinkLabel();
            _exitAppLink.LinkClicked += new LinkLabelLinkClickedEventHandler(exitAppLink_LinkClicked);
            SuspendLayout();
            // 
            // progressbar
            // 
            _progressbar.AutoSize = true;
            _progressbar.BackColor = Color.WhiteSmoke;
            _progressbar.Bar1.ActiveColor = Color.White;
            _progressbar.Bar1.BorderColor = Color.DarkRed;
            _progressbar.Bar1.Enabled = true;
            _progressbar.Bar1.FinishColor = Color.Honeydew;
            _progressbar.Bar1.InactiveColor = Color.DarkGray;
            _progressbar.Bar2.ActiveColor = Color.LightSeaGreen;
            _progressbar.Bar2.BorderColor = Color.Black;
            _progressbar.Bar2.FinishColor = Color.LightGreen;
            _progressbar.Bar2.InactiveColor = Color.LightGray;
            _progressbar.Bar3.ActiveColor = Color.LightSeaGreen;
            _progressbar.Bar3.BorderColor = Color.Black;
            _progressbar.Bar3.FinishColor = Color.LightGreen;
            _progressbar.Bar3.InactiveColor = Color.LightGray;
            _progressbar.Bar4.ActiveColor = Color.LightSeaGreen;
            _progressbar.Bar4.BorderColor = Color.Black;
            _progressbar.Bar4.FinishColor = Color.LightGreen;
            _progressbar.Bar4.InactiveColor = Color.LightGray;
            _progressbar.Bar5.ActiveColor = Color.LightSeaGreen;
            _progressbar.Bar5.BorderColor = Color.Black;
            _progressbar.Bar5.FinishColor = Color.LightGreen;
            _progressbar.Bar5.InactiveColor = Color.LightGray;
            _progressbar.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _progressbar.ForeColor = Color.Black;
            _progressbar.Image = null;
            _progressbar.Location = new Point(350, 175);
            _progressbar.MaximumSize = new Size(100, 100);
            _progressbar.MinimumSize = new Size(20, 20);
            _progressbar.Name = "_progressbar";
            _progressbar.Size = new Size(100, 100);
            _progressbar.TabIndex = 352;
            _progressbar.TextShadowColor = Color.White;
            // 
            // Label1
            // 
            _Label1.AutoSize = true;
            _Label1.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label1.Location = new Point(382, 278);
            _Label1.Name = "_Label1";
            _Label1.Size = new Size(44, 13);
            _Label1.TabIndex = 353;
            _Label1.Text = "Label1";
            // 
            // exitAppLink
            // 
            _exitAppLink.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _exitAppLink.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _exitAppLink.LinkColor = Color.LightGray;
            _exitAppLink.Location = new Point(645, 418);
            _exitAppLink.Name = "_exitAppLink";
            _exitAppLink.Size = new Size(143, 23);
            _exitAppLink.TabIndex = 354;
            _exitAppLink.TabStop = true;
            _exitAppLink.Text = "Exit";
            _exitAppLink.TextAlign = ContentAlignment.MiddleRight;
            // 
            // loadingForm
            // 
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(_exitAppLink);
            Controls.Add(_Label1);
            Controls.Add(_progressbar);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "loadingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += new EventHandler(loadingForm_Load);
            Shown += new EventHandler(loadingForm_shown);
            ResumeLayout(false);
            PerformLayout();
        }

        private CircularProgressBar.CircularProgress.CircularProgressBar _progressbar;

        internal CircularProgressBar.CircularProgress.CircularProgressBar progressbar
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _progressbar;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_progressbar != null)
                {
                }

                _progressbar = value;
                if (_progressbar != null)
                {
                }
            }
        }

        private Label _Label1;

        internal Label Label1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label1 != null)
                {
                }

                _Label1 = value;
                if (_Label1 != null)
                {
                }
            }
        }

        private LinkLabel _exitAppLink;

        internal LinkLabel exitAppLink
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _exitAppLink;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_exitAppLink != null)
                {
                    _exitAppLink.LinkClicked -= exitAppLink_LinkClicked;
                }

                _exitAppLink = value;
                if (_exitAppLink != null)
                {
                    _exitAppLink.LinkClicked += exitAppLink_LinkClicked;
                }
            }
        }
    }
}