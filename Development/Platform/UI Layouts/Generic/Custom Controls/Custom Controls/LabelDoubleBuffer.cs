using System.Windows.Forms;

public class LabelDoubleBuffer : Label
{
    public LabelDoubleBuffer()
    {
        SuspendLayout();
        SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        // 'SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        SetStyle(ControlStyles.ResizeRedraw, true);
        SetStyle(ControlStyles.UserPaint, true);
        UpdateStyles();
        ResumeLayout();
    }
}