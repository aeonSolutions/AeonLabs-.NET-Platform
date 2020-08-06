using System.Windows.Forms;

public partial class TransparentRichTextBox : RichTextBox
{
    public TransparentRichTextBox()
    {
        DoubleBuffered = true;
        // 'this set forecolor to transparent not sure why
        // 'SetStyle(ControlStyles.SupportsTransparentBackColor Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)
        // 'BackColor = Color.Transparent
    }

    protected override CreateParams CreateParams
    {
        get
        {
            var CP = base.CreateParams;
            CP.ExStyle = CP.ExStyle | 0x20;
            return CP;
        }
    }
}