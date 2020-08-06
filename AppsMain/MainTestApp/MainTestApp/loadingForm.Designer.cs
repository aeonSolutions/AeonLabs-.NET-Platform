using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
public partial class loadingForm : System.Windows.Forms.Form
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
        _progressbar = new CircularProgressBar.CircularProgress.CircularProgressBar();
        _Label1 = new System.Windows.Forms.Label();
        _exitAppLink = new System.Windows.Forms.LinkLabel();
        _exitAppLink.LinkClicked += exitAppLink_LinkClicked;
        this.SuspendLayout();
        // 
        // progressbar
        // 
        _progressbar.AutoSize = true;
        _progressbar.BackColor = System.Drawing.Color.WhiteSmoke;
        _progressbar.Bar1.ActiveColor = System.Drawing.Color.White;
        _progressbar.Bar1.BorderColor = System.Drawing.Color.DarkRed;
        _progressbar.Bar1.Enabled = true;
        _progressbar.Bar1.FinishColor = System.Drawing.Color.Honeydew;
        _progressbar.Bar1.InactiveColor = System.Drawing.Color.DarkGray;
        _progressbar.Bar2.ActiveColor = System.Drawing.Color.LightSeaGreen;
        _progressbar.Bar2.BorderColor = System.Drawing.Color.Black;
        _progressbar.Bar2.FinishColor = System.Drawing.Color.LightGreen;
        _progressbar.Bar2.InactiveColor = System.Drawing.Color.LightGray;
        _progressbar.Bar3.ActiveColor = System.Drawing.Color.LightSeaGreen;
        _progressbar.Bar3.BorderColor = System.Drawing.Color.Black;
        _progressbar.Bar3.FinishColor = System.Drawing.Color.LightGreen;
        _progressbar.Bar3.InactiveColor = System.Drawing.Color.LightGray;
        _progressbar.Bar4.ActiveColor = System.Drawing.Color.LightSeaGreen;
        _progressbar.Bar4.BorderColor = System.Drawing.Color.Black;
        _progressbar.Bar4.FinishColor = System.Drawing.Color.LightGreen;
        _progressbar.Bar4.InactiveColor = System.Drawing.Color.LightGray;
        _progressbar.Bar5.ActiveColor = System.Drawing.Color.LightSeaGreen;
        _progressbar.Bar5.BorderColor = System.Drawing.Color.Black;
        _progressbar.Bar5.FinishColor = System.Drawing.Color.LightGreen;
        _progressbar.Bar5.InactiveColor = System.Drawing.Color.LightGray;
        ;
#error Cannot convert AssignmentStatementSyntax - see comment for details
        /* Cannot convert AssignmentStatementSyntax, System.InvalidCastException: Unable to cast object of type 'Microsoft.CodeAnalysis.CSharp.Syntax.EmptyStatementSyntax' to type 'Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax'.
           at ICSharpCode.CodeConverter.CSharp.MethodBodyExecutableStatementVisitor.<VisitAssignmentStatement>d__35.MoveNext()
        --- End of stack trace from previous location where exception was thrown ---
           at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
           at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
           at ICSharpCode.CodeConverter.CSharp.HoistedNodeStateVisitor.<AddLocalVariablesAsync>d__6.MoveNext()
        --- End of stack trace from previous location where exception was thrown ---
           at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
           at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
           at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<DefaultVisitInnerAsync>d__3.MoveNext()

        Input:
                Me.progressbar.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

         */
        _progressbar.ForeColor = System.Drawing.Color.Black;
        _progressbar.Image = default;
        _progressbar.Location = new System.Drawing.Point(350, 175);
        _progressbar.MaximumSize = new System.Drawing.Size(100, 100);
        _progressbar.MinimumSize = new System.Drawing.Size(20, 20);
        _progressbar.Name = "_progressbar";
        _progressbar.Size = new System.Drawing.Size(100, 100);
        _progressbar.TabIndex = 352;
        _progressbar.TextShadowColor = System.Drawing.Color.White;
        // 
        // Label1
        // 
        _Label1.AutoSize = true;
        ;
#error Cannot convert AssignmentStatementSyntax - see comment for details
        /* Cannot convert AssignmentStatementSyntax, System.InvalidCastException: Unable to cast object of type 'Microsoft.CodeAnalysis.CSharp.Syntax.EmptyStatementSyntax' to type 'Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax'.
           at ICSharpCode.CodeConverter.CSharp.MethodBodyExecutableStatementVisitor.<VisitAssignmentStatement>d__35.MoveNext()
        --- End of stack trace from previous location where exception was thrown ---
           at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
           at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
           at ICSharpCode.CodeConverter.CSharp.HoistedNodeStateVisitor.<AddLocalVariablesAsync>d__6.MoveNext()
        --- End of stack trace from previous location where exception was thrown ---
           at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
           at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
           at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<DefaultVisitInnerAsync>d__3.MoveNext()

        Input:
                Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

         */
        _Label1.Location = new System.Drawing.Point(382, 278);
        _Label1.Name = "_Label1";
        _Label1.Size = new System.Drawing.Size(44, 13);
        _Label1.TabIndex = 353;
        // 
        // exitAppLink
        // 
        _Label1.Text = "Label1";
        ;
#error Cannot convert AssignmentStatementSyntax - see comment for details
        /* Cannot convert AssignmentStatementSyntax, System.InvalidCastException: Unable to cast object of type 'Microsoft.CodeAnalysis.CSharp.Syntax.EmptyStatementSyntax' to type 'Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax'.
           at ICSharpCode.CodeConverter.CSharp.MethodBodyExecutableStatementVisitor.<VisitAssignmentStatement>d__35.MoveNext()
        --- End of stack trace from previous location where exception was thrown ---
           at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
           at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
           at ICSharpCode.CodeConverter.CSharp.HoistedNodeStateVisitor.<AddLocalVariablesAsync>d__6.MoveNext()
        --- End of stack trace from previous location where exception was thrown ---
           at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
           at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
           at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<DefaultVisitInnerAsync>d__3.MoveNext()

        Input:
                '
                'exitAppLink
                '
                Me.exitAppLink.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)

         */
        ;
#error Cannot convert AssignmentStatementSyntax - see comment for details
        /* Cannot convert AssignmentStatementSyntax, System.InvalidCastException: Unable to cast object of type 'Microsoft.CodeAnalysis.CSharp.Syntax.EmptyStatementSyntax' to type 'Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax'.
           at ICSharpCode.CodeConverter.CSharp.MethodBodyExecutableStatementVisitor.<VisitAssignmentStatement>d__35.MoveNext()
        --- End of stack trace from previous location where exception was thrown ---
           at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
           at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
           at ICSharpCode.CodeConverter.CSharp.HoistedNodeStateVisitor.<AddLocalVariablesAsync>d__6.MoveNext()
        --- End of stack trace from previous location where exception was thrown ---
           at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
           at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
           at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<DefaultVisitInnerAsync>d__3.MoveNext()

        Input:
                Me.exitAppLink.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

         */
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