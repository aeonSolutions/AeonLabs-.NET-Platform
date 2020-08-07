using AeonLabs.Environment;
using System;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

public partial class MessageBoxChild : FormCustomized 
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
        if (_state==null)
        {
            enVars = new AeonLabs.Environment.environmentVarsCore();
            enVars.loadEnvironmentcoreDefaults();
        }
        else
        {
            enVars = _state;
        }

        title.Font = new Font(enVars.layoutDesign.fontTitle.Families[0], enVars.layoutDesign.DialogTitleFontSize, FontStyle.Bold);
        message.Font = new Font(enVars.layoutDesign.fontText.Families[0], enVars.layoutDesign.RegularTextFontSize, FontStyle.Regular);
        ContinueBtn.Font = new Font(enVars.layoutDesign.fontTitle.Families[0], enVars.layoutDesign.buttonFontSize, FontStyle.Bold);
        cancelBtn.Font = new Font(enVars.layoutDesign.fontTitle.Families[0], enVars.layoutDesign.buttonFontSize, FontStyle.Bold);
        ContinueBtn.BackColor = Color.FromArgb(200, Color.Black);
        ContinueBtn.Parent = AlphaGradientPanel1;
        ContinueBtn.Location = new Point(40, this.Height - 10 - this.ContinueBtn.Height);
        cancelBtn.BackColor = Color.FromArgb(200, Color.Black);
        cancelBtn.Parent = AlphaGradientPanel1;
        cancelBtn.Location = new Point(this.Width - 40 - this.cancelBtn.Width, this.Height - 10 - this.cancelBtn.Height);

    }

    private global::System.String titleMsg;
    private global::System.String messageText;
    private MessageBoxIcon iconImage;
    private MessageBoxButtons buttons;
    private environmentVarsCore enVars = new environmentVarsCore();
    public ResourceManager resources = new ResourceManager("strings", typeof(MessageBoxChild ).Assembly);

    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams cp = base.CreateParams;
            cp.ExStyle = cp.ExStyle | 33554432;
            return cp;
        }
    }

    private void message_box_frm_load(global::System.Object sender, System.EventArgs e)
    {
        SuspendLayout();
        title.Text = titleMsg;
        var fontToMeasure = new Font(enVars.layoutDesign.fontTitle.Families[0], enVars.layoutDesign.DialogTitleFontSize, System.Drawing.FontStyle.Regular);
        SizeF sizeOfString = new SizeF();
        sizeOfString = TextRenderer.MeasureText(titleMsg, fontToMeasure);
        title.Location = new Point(Convert.ToInt32(this.Width / 2 - sizeOfString.Width / 2), this.title.Location.Y);

        fontToMeasure = new Font(enVars.layoutDesign.fontTitle.Families[0], enVars.layoutDesign.RegularTextFontSize, System.Drawing.FontStyle.Regular);
        sizeOfString = TextRenderer.MeasureText("_", fontToMeasure);

        message.Text = messageText;

        int numLines = Convert.ToInt32(this.messageText.Length / (this.message.Width / sizeOfString.Width)) + 1;
        this.message.Height = Convert.ToInt32(numLines * sizeOfString.Height);


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
        System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(enVars.currentLang);
        if (buttons.Equals(MessageBoxButtons.OK))
        {
            ContinueBtn.Visible = true;
            cancelBtn.Visible = false;

            ContinueBtn.Location = new Point(Convert.ToInt32 (this.Width / 2 - this.ContinueBtn.Width / 2), this.ContinueBtn.Location.Y);
        }
        else if (buttons.Equals(MessageBoxButtons.OKCancel))
        {
            ContinueBtn.Text = resources.GetString("ok");
            ContinueBtn.Visible = true;
            cancelBtn.Text = resources.GetString("cancel");
            cancelBtn.Visible = true;
        }
        else if (buttons.Equals(MessageBoxButtons.YesNo))
        {
            ContinueBtn.Text = resources.GetString("yes");
            ContinueBtn.Visible = true;
            cancelBtn.Text = resources.GetString("no");
            cancelBtn.Visible = true;
        }
        else if (buttons.Equals(MessageBoxButtons.RetryCancel))
        {
            ContinueBtn.Text = resources.GetString("retry");
            ContinueBtn.Visible = true;
            cancelBtn.Text = resources.GetString("cancel");
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
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        else if (buttons.Equals(MessageBoxButtons.OKCancel))
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        else if (buttons.Equals(MessageBoxButtons.YesNo))
        {
            this.DialogResult = System.Windows.Forms.DialogResult.No;
        }
        else if (buttons.Equals(MessageBoxButtons.RetryCancel))
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        this.Close();
    }

    private void ContinueBtn_Click(global::System.Object sender, EventArgs e)
    {
        if (buttons.Equals(MessageBoxButtons.OK))
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        else if (buttons.Equals(MessageBoxButtons.OKCancel))
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        else if (buttons.Equals(MessageBoxButtons.YesNo))
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
        }
        else if (buttons.Equals(MessageBoxButtons.RetryCancel))
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Retry;
        }

        this.Close();
    }

    private void AlphaGradientPanel1_Paint(global::System.Object sender, PaintEventArgs e)
    {
    }
}