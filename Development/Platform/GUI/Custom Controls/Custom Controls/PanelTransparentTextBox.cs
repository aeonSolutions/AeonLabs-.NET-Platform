using System.Drawing;
using System.Windows.Forms;

public partial class PanelTransparentTextBox : Panel
{
    public PanelTransparentTextBox()
    {
        SuspendLayout();
        SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        // ' SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        SetStyle(ControlStyles.ResizeRedraw, true);
        SetStyle(ControlStyles.UserPaint, true);
        UpdateStyles();
        base.BackColor = Color.Transparent;
        var line = new LabelDoubleBuffer()
        {
            BackColor = Color.White,
            Size = new Size(Width, 2),
            Location = new Point(0, Height),
            Dock = DockStyle.Bottom,
            AutoSize = false
        };
        Controls.Add(line);
        ResumeLayout();
    }
}