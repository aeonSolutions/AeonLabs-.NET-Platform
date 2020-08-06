using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
public partial class MessageBoxChild : System.Windows.Forms.Form
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
        _AlphaGradientPanel1 = new BlueActivity.AlphaGradientPanel();
        _AlphaGradientPanel1.Paint += AlphaGradientPanel1_Paint;
        _ColorWithAlpha1 = new BlueActivity.ColorWithAlpha();
        _cancelBtn = new System.Windows.Forms.Button();
        _cancelBtn.Click += cancelBtn_Click;
        _ContinueBtn = new System.Windows.Forms.Button();
        _ContinueBtn.Click += ContinueBtn_Click;
        _iconBox = new System.Windows.Forms.PictureBox();
        _PanelMessage = new System.Windows.Forms.Panel();
        _message = new System.Windows.Forms.Label();
        _title = new System.Windows.Forms.Label();
        _AlphaGradientPanel1.SuspendLayout();
        ;
#error Cannot convert ExpressionStatementSyntax - see comment for details
        /* Cannot convert ExpressionStatementSyntax, System.InvalidCastException: Unable to cast object of type 'Microsoft.CodeAnalysis.CSharp.Syntax.EmptyStatementSyntax' to type 'Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax'.
           at ICSharpCode.CodeConverter.CSharp.MethodBodyExecutableStatementVisitor.<VisitExpressionStatement>d__34.MoveNext()
        --- End of stack trace from previous location where exception was thrown ---
           at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
           at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
           at ICSharpCode.CodeConverter.CSharp.HoistedNodeStateVisitor.<AddLocalVariablesAsync>d__6.MoveNext()
        --- End of stack trace from previous location where exception was thrown ---
           at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
           at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
           at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<DefaultVisitInnerAsync>d__3.MoveNext()

        Input:
                CType(Me.iconBox, System.ComponentModel.ISupportInitialize).BeginInit()

         */
        _PanelMessage.SuspendLayout();
        this.SuspendLayout();
        // 
        // AlphaGradientPanel1
        // 
        _AlphaGradientPanel1.BackColor = System.Drawing.Color.Transparent;
        _AlphaGradientPanel1.Border = false;
        _AlphaGradientPanel1.BorderColor = System.Drawing.SystemColors.ActiveBorder;
        _AlphaGradientPanel1.Colors.Add(_ColorWithAlpha1);
        _AlphaGradientPanel1.ContentPadding = new System.Windows.Forms.Padding(0);
        _AlphaGradientPanel1.Controls.Add(_cancelBtn);
        _AlphaGradientPanel1.Controls.Add(_ContinueBtn);
        _AlphaGradientPanel1.Controls.Add(_iconBox);
        _AlphaGradientPanel1.Controls.Add(_PanelMessage);
        _AlphaGradientPanel1.Controls.Add(_title);
        _AlphaGradientPanel1.CornerRadius = 20;
        _AlphaGradientPanel1.Corners = BlueActivity.Corner.None;
        _AlphaGradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
        _AlphaGradientPanel1.Gradient = false;
        _AlphaGradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
        _AlphaGradientPanel1.GradientOffset = 1.0F;
        _AlphaGradientPanel1.GradientSize = new System.Drawing.Size(0, 0);
        _AlphaGradientPanel1.GradientWrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
        _AlphaGradientPanel1.Grayscale = false;
        _AlphaGradientPanel1.Image = default;
        _AlphaGradientPanel1.ImageAlpha = 75;
        _AlphaGradientPanel1.ImagePadding = new System.Windows.Forms.Padding(5);
        _AlphaGradientPanel1.ImagePosition = BlueActivity.ImagePosition.BottomRight;
        _AlphaGradientPanel1.ImageSize = new System.Drawing.Size(48, 48);
        _AlphaGradientPanel1.Location = new System.Drawing.Point(0, 0);
        _AlphaGradientPanel1.Margin = new System.Windows.Forms.Padding(2);
        _AlphaGradientPanel1.Name = "_AlphaGradientPanel1";
        _AlphaGradientPanel1.Rounded = true;
        _AlphaGradientPanel1.Size = new System.Drawing.Size(400, 160);
        _AlphaGradientPanel1.TabIndex = 351;
        // 
        // ColorWithAlpha1
        // 
        _ColorWithAlpha1.Alpha = 0;
        _ColorWithAlpha1.Color = System.Drawing.Color.YellowGreen;
        // 
        // cancelBtn
        // 
        _ColorWithAlpha1.Parent = _AlphaGradientPanel1;
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
                'cancelBtn
                '
                Me.cancelBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)

         */
        _cancelBtn.Cursor = System.Windows.Forms.Cursors.Hand;
        _cancelBtn.FlatAppearance.BorderSize = 0;
        _cancelBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
        _cancelBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
        _cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
                Me.cancelBtn.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

         */
        _cancelBtn.ForeColor = System.Drawing.Color.White;
        _cancelBtn.Location = new System.Drawing.Point(271, 127);
        _cancelBtn.Margin = new System.Windows.Forms.Padding(2);
        _cancelBtn.Name = "_cancelBtn";
        _cancelBtn.Size = new System.Drawing.Size(105, 25);
        _cancelBtn.TabIndex = 354;
        _cancelBtn.Text = "Cancelar";
        // 
        // ContinueBtn
        // 
        _cancelBtn.UseVisualStyleBackColor = true;
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
                'ContinueBtn
                '
                Me.ContinueBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)

         */
        _ContinueBtn.Cursor = System.Windows.Forms.Cursors.Hand;
        _ContinueBtn.FlatAppearance.BorderSize = 0;
        _ContinueBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
                Me.ContinueBtn.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

         */
        _ContinueBtn.ForeColor = System.Drawing.Color.White;
        _ContinueBtn.Location = new System.Drawing.Point(15, 127);
        _ContinueBtn.Margin = new System.Windows.Forms.Padding(2);
        _ContinueBtn.Name = "_ContinueBtn";
        _ContinueBtn.Size = new System.Drawing.Size(105, 25);
        _ContinueBtn.TabIndex = 353;
        _ContinueBtn.Text = "Continuar";
        _ContinueBtn.UseVisualStyleBackColor = true;
        // 
        // iconBox
        // 
        _iconBox.BackColor = System.Drawing.Color.Transparent;
        _iconBox.Location = new System.Drawing.Point(23, 54);
        _iconBox.Name = "_iconBox";
        _iconBox.Size = new System.Drawing.Size(53, 53);
        _iconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        _iconBox.TabIndex = 0;
        _iconBox.TabStop = false;
        // 
        // PanelMessage
        // 
        _PanelMessage.AutoScroll = true;
        _PanelMessage.Controls.Add(_message);
        _PanelMessage.Location = new System.Drawing.Point(103, 41);
        _PanelMessage.Margin = new System.Windows.Forms.Padding(2);
        _PanelMessage.Name = "_PanelMessage";
        _PanelMessage.Size = new System.Drawing.Size(293, 77);
        // 
        // message
        // 
        _PanelMessage.TabIndex = 350;
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
                'message
                '
                Me.message.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)

         */
        _message.BackColor = System.Drawing.Color.Transparent;
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
                Me.message.Font = New System.Drawing.Font("Bookman Old Style", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

         */
        _message.ForeColor = System.Drawing.Color.White;
        _message.Location = new System.Drawing.Point(2, 1);
        _message.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        _message.Name = "_message";
        _message.Size = new System.Drawing.Size(254, 77);
        _message.TabIndex = 0;
        // 
        // title
        // 
        _message.Text = "message";
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
                'title
                '
                Me.title.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)

         */
        _title.AutoSize = true;
        _title.BackColor = System.Drawing.Color.Transparent;
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
                Me.title.Font = New System.Drawing.Font("Trajan Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

         */
        _title.ForeColor = System.Drawing.Color.White;
        _title.Location = new System.Drawing.Point(178, 11);
        _title.Name = "_title";
        _title.Size = new System.Drawing.Size(55, 20);
        _title.TabIndex = 1;
        _title.Text = "Title";
        _title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // MessageBoxChild
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(96.0F, 96.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        this.BackColor = System.Drawing.Color.Gainsboro;
        this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
        this.ClientSize = new System.Drawing.Size(400, 160);
        this.ControlBox = false;
        this.Controls.Add(_AlphaGradientPanel1);
        this.DoubleBuffered = true;
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
                Me.Font = New System.Drawing.Font("Microsoft Yi Baiti", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

         */
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Margin = new System.Windows.Forms.Padding(2);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "MessageBoxChild";
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Form1";
        this.TransparencyKey = System.Drawing.Color.Gainsboro;
        _AlphaGradientPanel1.ResumeLayout(false);
        _AlphaGradientPanel1.PerformLayout();
        ;
#error Cannot convert ExpressionStatementSyntax - see comment for details
        /* Cannot convert ExpressionStatementSyntax, System.InvalidCastException: Unable to cast object of type 'Microsoft.CodeAnalysis.CSharp.Syntax.EmptyStatementSyntax' to type 'Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax'.
           at ICSharpCode.CodeConverter.CSharp.MethodBodyExecutableStatementVisitor.<VisitExpressionStatement>d__34.MoveNext()
        --- End of stack trace from previous location where exception was thrown ---
           at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
           at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
           at ICSharpCode.CodeConverter.CSharp.HoistedNodeStateVisitor.<AddLocalVariablesAsync>d__6.MoveNext()
        --- End of stack trace from previous location where exception was thrown ---
           at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
           at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
           at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<DefaultVisitInnerAsync>d__3.MoveNext()

        Input:
                CType(Me.iconBox, System.ComponentModel.ISupportInitialize).EndInit()

         */
        _PanelMessage.ResumeLayout(false);
        this.ResumeLayout(false);
    }

    private Windows.Forms.Panel _PanelMessage;

    internal Windows.Forms.Panel PanelMessage
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _PanelMessage;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_PanelMessage != null)
            {
            }

            _PanelMessage = value;
            if (_PanelMessage != null)
            {
            }
        }
    }

    private Label _message;

    internal Label message
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _message;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_message != null)
            {
            }

            _message = value;
            if (_message != null)
            {
            }
        }
    }

    private Windows.Forms.PictureBox _iconBox;

    internal Windows.Forms.PictureBox iconBox
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _iconBox;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_iconBox != null)
            {
            }

            _iconBox = value;
            if (_iconBox != null)
            {
            }
        }
    }

    private Label _title;

    internal Label title
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _title;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_title != null)
            {
            }

            _title = value;
            if (_title != null)
            {
            }
        }
    }

    private BlueActivity.AlphaGradientPanel _AlphaGradientPanel1;

    internal BlueActivity.AlphaGradientPanel AlphaGradientPanel1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _AlphaGradientPanel1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_AlphaGradientPanel1 != null)
            {
                _AlphaGradientPanel1.Paint -= AlphaGradientPanel1_Paint;
            }

            _AlphaGradientPanel1 = value;
            if (_AlphaGradientPanel1 != null)
            {
                _AlphaGradientPanel1.Paint += AlphaGradientPanel1_Paint;
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

    private Windows.Forms.Button _ContinueBtn;

    internal Windows.Forms.Button ContinueBtn
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ContinueBtn;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ContinueBtn != null)
            {
                _ContinueBtn.Click -= ContinueBtn_Click;
            }

            _ContinueBtn = value;
            if (_ContinueBtn != null)
            {
                _ContinueBtn.Click += ContinueBtn_Click;
            }
        }
    }

    private Windows.Forms.Button _cancelBtn;

    internal Windows.Forms.Button cancelBtn
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cancelBtn;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cancelBtn != null)
            {
                _cancelBtn.Click -= cancelBtn_Click;
            }

            _cancelBtn = value;
            if (_cancelBtn != null)
            {
                _cancelBtn.Click += cancelBtn_Click;
            }
        }
    }
}