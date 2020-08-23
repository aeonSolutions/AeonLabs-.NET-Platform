using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using WinFormAnimation;

[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
public partial class loadingForm : FormCustomized 
{

    // Form overrides dispose to clean up the component list.
    [System.Diagnostics.DebuggerNonUserCode()]
    protected override void Dispose(global::System.Boolean disposing)
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
    [System.Diagnostics.DebuggerStepThrough()]
    private void InitializeComponent()
    {
        _progressbar = new CircularProgressBar.CircularProgressBar();
        _Label1 = new System.Windows.Forms.Label();
        _exitAppLink = new System.Windows.Forms.LinkLabel();
        _exitAppLink.LinkClicked += exitAppLink_LinkClicked;
        this.SuspendLayout();
        // 
        // progressbar
        // 
        this.progressbar.AnimationFunction = KnownAnimationFunctions.Liner;
        this.progressbar.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.progressbar.AnimationSpeed = 500;
        this.progressbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
        this.progressbar.Font = new System.Drawing.Font("Arial", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
        this.progressbar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
        this.progressbar.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
        this.progressbar.InnerMargin = 2;
        this.progressbar.InnerWidth = -1;
        this.progressbar.Location = new System.Drawing.Point(12, 12);
        this.progressbar.MarqueeAnimationSpeed = 2000;
        this.progressbar.Name = "progressbar";
        this.progressbar.OuterColor = System.Drawing.Color.Gray;
        this.progressbar.OuterMargin = -25;
        this.progressbar.OuterWidth = 26;
        this.progressbar.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
        this.progressbar.ProgressWidth = 25;
        this.progressbar.SecondaryFont = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
        this.progressbar.Size = new System.Drawing.Size(320, 320);
        this.progressbar.StartAngle = 270;
        this.progressbar.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
        this.progressbar.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
        this.progressbar.SubscriptText = ".23";
        this.progressbar.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
        this.progressbar.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
        this.progressbar.SuperscriptText = "°C";
        this.progressbar.TabIndex = 3;
        this.progressbar.Text = "32";
        this.progressbar.TextMargin = new System.Windows.Forms.Padding(-8, 8, 0, 0);
        this.progressbar.Value = 68;
        // 
        // Label1
        // 
        _Label1.AutoSize = true;
        _Label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        _Label1.Location = new System.Drawing.Point(382, 278);
        _Label1.Name = "_Label1";
        _Label1.Size = new System.Drawing.Size(44, 13);
        _Label1.TabIndex = 353;
        // 
        // exitAppLink
        // 
        _Label1.Text = "Label1";

        //
        //exitAppLink
        //
        _exitAppLink.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        _exitAppLink.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        _exitAppLink.LinkColor = System.Drawing.Color.LightGray;
        _exitAppLink.Location = new System.Drawing.Point(645, 418);
        _exitAppLink.Name = "_exitAppLink";
        _exitAppLink.Size = new System.Drawing.Size(143, 23);
        _exitAppLink.TabIndex = 354;
        _exitAppLink.TabStop = true;
        _exitAppLink.Text = "Exit";
        _exitAppLink.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // loadingForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.WhiteSmoke;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.ControlBox = false;
        this.Controls.Add(_exitAppLink);
        this.Controls.Add(_Label1);
        this.Controls.Add(_progressbar);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "loadingForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Form1";
        this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private CircularProgressBar.CircularProgressBar _progressbar;

    internal CircularProgressBar.CircularProgressBar progressbar
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