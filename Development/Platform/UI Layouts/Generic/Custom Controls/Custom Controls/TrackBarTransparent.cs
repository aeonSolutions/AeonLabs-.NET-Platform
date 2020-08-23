using System;
using System.Drawing;
using System.Windows.Forms;

   public  class TrackBarTransparent : TrackBar
    {
    public TrackBarTransparent()
        {
        SuspendLayout();
        SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        UpdateStyles();
        ResumeLayout();
        }

    private const int WM_DWMCOMPOSITIONCHANGED = 0x031A;
    private const int WM_THEMECHANGED = 0x031E;

    protected override void OnVisibleChanged(EventArgs e)
    {
        Color color = this.BackColor;
        this.BackColor = Color.FromArgb(color.R, color.G, color.B);
    }

    protected override void WndProc(ref Message m)
    {
        if (m.Msg == WM_DWMCOMPOSITIONCHANGED || m.Msg == WM_THEMECHANGED)
            OnVisibleChanged(new EventArgs());

        base.WndProc(ref m);
    }
}
