using System.Windows.Forms;

public class PictureBoxDoubleBuffer : PictureBox
{
    public PictureBoxDoubleBuffer()
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