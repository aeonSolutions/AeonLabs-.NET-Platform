using System.Drawing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

public partial class MessageBoxChild
{
    public MessageBoxChild()
    {
        base.Load += message_box_frm_load;
        base.Shown += message_box_frm_show;
    }

    public MessageBoxChild(global::System.String _message, global::System.String _title, MessageBoxButtons _buttons, MessageBoxIcon _icon, global::System.Int32 posx = -1, global::System.Int32 posy = -1, AeonLabs.Environment.environmentVarsCore _state = default)
    {
        base.Load += message_box_frm_load;
        base.Shown += message_box_frm_show;
        this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        this.SetStyle(ControlStyles.UserPaint, true);

        // This call is required by the designer.
        this.SuspendLayout();
        InitializeComponent();
        this.ResumeLayout();
        titleMsg = _title;
        messageText = _message;
        iconImage = _icon;
        buttons = _buttons;
        if (IsNothing(_state))
        {
            enVars = new AeonLabs.Environment.environmentVarsCore();
            enVars.loadEnvironmentcoreDefaults();
        }
        else
        {
            enVars = _state;
        }

        title.Font = new Font(enVars.layoutDesign.fontTitle.Families(0), enVars.layoutDesign.DialogTitleFontSize, FontStyle.Bold);
        message.Font = new Font(enVars.layoutDesign.fontText.Families(0), enVars.layoutDesign.RegularTextFontSize, FontStyle.Regular);
        ContinueBtn.Font = new Font(enVars.layoutDesign.fontTitle.Families(0), enVars.layoutDesign.buttonFontSize, FontStyle.Bold);
        cancelBtn.Font = new Font(enVars.layoutDesign.fontTitle.Families(0), enVars.layoutDesign.buttonFontSize, FontStyle.Bold);
        ContinueBtn.BackColor = Color.FromArgb(200, Color.Black);
        ContinueBtn.Parent = AlphaGradientPanel1;
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
                Me.ContinueBtn.Location = New Point(40, Me.Height - 10 - Me.ContinueBtn.Height)

         */
        cancelBtn.BackColor = Color.FromArgb(200, Color.Black);
        cancelBtn.Parent = AlphaGradientPanel1;
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
                Me.cancelBtn.Location = New Point(Me.Width - 40 - Me.cancelBtn.Width, Me.Height - 10 - Me.cancelBtn.Height)

         */
    }

    private global::System.String titleMsg;
    private global::System.String messageText;
    private MessageBoxIcon iconImage;
    private MessageBoxButtons buttons;
    private AeonLabs.Environment.environmentVarsCore enVars = new AeonLabs.Environment.environmentVarsCore();

    protected new override CreateParams CreateParams
    {
        get
        {
            CreateParams cp = base.CreateParams;
            cp.ExStyle = cp.ExStyle | 33554432;
            return cp;
        }
    }

    private void message_box_frm_load(global::System.Object sender, EventArgs e)
    {
        SuspendLayout();
        title.Text = titleMsg;
        var fontToMeasure = new Font(enVars.layoutDesign.fontTitle.Families(0), enVars.layoutDesign.DialogTitleFontSize, Drawing.FontStyle.Regular);
        var sizeOfString = new SizeF();
        Graphics g = this.CreateGraphics;
        sizeOfString = g.MeasureString(titleMsg, fontToMeasure);
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
                Me.title.Location = New Point(Me.Width / 2 - sizeOfString.Width / 2, Me.title.Location.Y)

         */
        fontToMeasure = new Font(enVars.layoutDesign.fontTitle.Families(0), enVars.layoutDesign.RegularTextFontSize, Drawing.FontStyle.Regular);
        sizeOfString = new SizeF();
        g = this.CreateGraphics;
        sizeOfString = g.MeasureString("_", fontToMeasure);
        message.Text = messageText;
        ;
#error Cannot convert LocalDeclarationStatementSyntax - see comment for details
        /* Cannot convert LocalDeclarationStatementSyntax, System.ArgumentNullException: Value cannot be null.
        Parameter name: destination
           at Microsoft.CodeAnalysis.VisualBasic.VisualBasicCompilation.ClassifyConversion(ITypeSymbol source, ITypeSymbol destination)
           at ICSharpCode.CodeConverter.CSharp.TypeConversionAnalyzer.TryAnalyzeCsConversion(ExpressionSyntax vbNode, ITypeSymbol csType, ITypeSymbol csConvertedType, Conversion vbConversion, ITypeSymbol vbConvertedType, ITypeSymbol vbType, VisualBasicCompilation vbCompilation, Boolean isConst, TypeConversionKind& typeConversionKind)
           at ICSharpCode.CodeConverter.CSharp.TypeConversionAnalyzer.AnalyzeConversion(ExpressionSyntax vbNode, Boolean alwaysExplicit, Boolean isConst, ITypeSymbol forceSourceType, ITypeSymbol forceTargetType)
           at ICSharpCode.CodeConverter.CSharp.TypeConversionAnalyzer.AddExplicitConversion(ExpressionSyntax vbNode, ExpressionSyntax csNode, Boolean addParenthesisIfNeeded, Boolean defaultToCast, Boolean isConst, ITypeSymbol forceSourceType, ITypeSymbol forceTargetType)
           at ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertEqualsValueClauseSyntaxAsync>d__24.MoveNext()
        --- End of stack trace from previous location where exception was thrown ---
           at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
           at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
           at System.Runtime.CompilerServices.TaskAwaiter.ValidateEnd(Task task)
           at ICSharpCode.CodeConverter.CSharp.CommonConversions.<SplitVariableDeclarationsAsync>d__22.MoveNext()
        --- End of stack trace from previous location where exception was thrown ---
           at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
           at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
           at ICSharpCode.CodeConverter.CSharp.MethodBodyExecutableStatementVisitor.<SplitVariableDeclarationsAsync>d__59.MoveNext()
        --- End of stack trace from previous location where exception was thrown ---
           at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
           at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
           at ICSharpCode.CodeConverter.CSharp.MethodBodyExecutableStatementVisitor.<VisitLocalDeclarationStatement>d__31.MoveNext()
        --- End of stack trace from previous location where exception was thrown ---
           at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
           at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
           at ICSharpCode.CodeConverter.CSharp.HoistedNodeStateVisitor.<AddLocalVariablesAsync>d__6.MoveNext()
        --- End of stack trace from previous location where exception was thrown ---
           at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
           at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
           at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<DefaultVisitInnerAsync>d__3.MoveNext()

        Input:

                Dim numLines As Integer = CInt(Me.messageText.Length / (Me.message.Width / sizeOfString.Width)) + 1

         */
        ;
#error Cannot convert AssignmentStatementSyntax - see comment for details
        /* Cannot convert AssignmentStatementSyntax, System.ArgumentNullException: Value cannot be null.
        Parameter name: destination
           at Microsoft.CodeAnalysis.VisualBasic.VisualBasicCompilation.ClassifyConversion(ITypeSymbol source, ITypeSymbol destination)
           at ICSharpCode.CodeConverter.CSharp.TypeConversionAnalyzer.TryAnalyzeCsConversion(ExpressionSyntax vbNode, ITypeSymbol csType, ITypeSymbol csConvertedType, Conversion vbConversion, ITypeSymbol vbConvertedType, ITypeSymbol vbType, VisualBasicCompilation vbCompilation, Boolean isConst, TypeConversionKind& typeConversionKind)
           at ICSharpCode.CodeConverter.CSharp.TypeConversionAnalyzer.AnalyzeConversion(ExpressionSyntax vbNode, Boolean alwaysExplicit, Boolean isConst, ITypeSymbol forceSourceType, ITypeSymbol forceTargetType)
           at ICSharpCode.CodeConverter.CSharp.TypeConversionAnalyzer.AddExplicitConversion(ExpressionSyntax vbNode, ExpressionSyntax csNode, Boolean addParenthesisIfNeeded, Boolean defaultToCast, Boolean isConst, ITypeSymbol forceSourceType, ITypeSymbol forceTargetType)
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
                Me.message.Height = numLines * sizeOfString.Height

         */
        if (iconImage.Equals(MessageBoxIcon.Information))
        {
            try
            {
                iconBox.Image = Image.FromFile(enVars.imagesPath + Convert.ToString("information.png"));
            }
            catch (Exception ex)
            {
            }
        }
        else if (iconImage.Equals(MessageBoxIcon.Question))
        {
            try
            {
                iconBox.Image = Image.FromFile(enVars.imagesPath + Convert.ToString("question.png"));
            }
            catch (Exception ex)
            {
            }
        }
        else if (iconImage.Equals(MessageBoxIcon.Warning))
        {
            try
            {
                iconBox.Image = Image.FromFile(enVars.imagesPath + Convert.ToString("warning.png"));
            }
            catch (Exception ex)
            {
            }
        }
        else if (iconImage.Equals(MessageBoxIcon.Exclamation))
        {
            try
            {
                iconBox.Image = Image.FromFile(enVars.imagesPath + Convert.ToString("exclamation.png"));
            }
            catch (Exception ex)
            {
            }
        }
        else if (iconImage.Equals(MessageBoxIcon.Error))
        {
            try
            {
                iconBox.Image = Image.FromFile(enVars.imagesPath + Convert.ToString("error.png"));
            }
            catch (Exception ex)
            {
            }
        }

        iconBox.SizeMode = PictureBoxSizeMode.StretchImage;
        Threading.Thread.CurrentThread.CurrentUICulture = Globalization.CultureInfo.GetCultureInfo(enVars.currentLang);
        if (buttons.Equals(MessageBoxButtons.OK))
        {
            ContinueBtn.Visible = true;
            cancelBtn.Visible = false;
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
                        Me.ContinueBtn.Location = New Point(Me.Width / 2 - Me.ContinueBtn.Width / 2, Me.ContinueBtn.Location.Y)

             */
        }
        else if (buttons.Equals(MessageBoxButtons.OKCancel))
        {
            ContinueBtn.Text = My.Resources.strings.ok;
            ContinueBtn.Visible = true;
            cancelBtn.Text = My.Resources.strings.cancel;
            cancelBtn.Visible = true;
        }
        else if (buttons.Equals(MessageBoxButtons.YesNo))
        {
            ContinueBtn.Text = My.Resources.strings.yes;
            ContinueBtn.Visible = true;
            cancelBtn.Text = My.Resources.strings.no;
            cancelBtn.Visible = true;
        }
        else if (buttons.Equals(MessageBoxButtons.RetryCancel))
        {
            ContinueBtn.Text = My.Resources.strings.retry;
            ContinueBtn.Visible = true;
            cancelBtn.Text = My.Resources.strings.cancel;
            cancelBtn.Visible = true;
        }

        ResumeLayout();
        Refresh();
    }

    private void message_box_frm_show(global::System.Object sender, EventArgs e)
    {
    }

    private void cancelBtn_Click(global::System.Object sender, EventArgs e)
    {
        if (buttons.Equals(MessageBoxButtons.OK))
        {
            this.DialogResult = Windows.Forms.DialogResult.Cancel;
        }
        else if (buttons.Equals(MessageBoxButtons.OKCancel))
        {
            this.DialogResult = Windows.Forms.DialogResult.Cancel;
        }
        else if (buttons.Equals(MessageBoxButtons.YesNo))
        {
            this.DialogResult = Windows.Forms.DialogResult.No;
        }
        else if (buttons.Equals(MessageBoxButtons.RetryCancel))
        {
            this.DialogResult = Windows.Forms.DialogResult.Cancel;
        }

        this.Close();
    }

    private void ContinueBtn_Click(global::System.Object sender, EventArgs e)
    {
        if (buttons.Equals(MessageBoxButtons.OK))
        {
            this.DialogResult = Windows.Forms.DialogResult.OK;
        }
        else if (buttons.Equals(MessageBoxButtons.OKCancel))
        {
            this.DialogResult = Windows.Forms.DialogResult.OK;
        }
        else if (buttons.Equals(MessageBoxButtons.YesNo))
        {
            this.DialogResult = Windows.Forms.DialogResult.Yes;
        }
        else if (buttons.Equals(MessageBoxButtons.RetryCancel))
        {
            this.DialogResult = Windows.Forms.DialogResult.Retry;
        }

        this.Close();
    }

    private void AlphaGradientPanel1_Paint(global::System.Object sender, PaintEventArgs e)
    {
    }
}