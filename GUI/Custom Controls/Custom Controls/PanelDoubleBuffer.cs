using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class PanelDoubleBuffer : Panel
{

    // MAIN LAYOUT design scheme
    public int PANEL_CLOSED_STATE_DIM { get; set; } = 40;
    public int PANEL_OPEN_STATE_DIM { get; set; } = 400;
    public bool ShowVerticalScrolBar { get; set; } = false;
    public bool ShowHorizontalScrolBar { get; set; } = false;

    public PanelDoubleBuffer()
    {
        SuspendLayout();
        SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        SetStyle(ControlStyles.UserPaint, true);
        SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        SetStyle(ControlStyles.ResizeRedraw, true);
        UpdateStyles();
        bool t = ShowHorizontalScrolBar;
        ResumeLayout();
    }

    [DllImport("user32.dll")]
    private static extern bool ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);

    public int SB_HORZ { get; set; } = ShowHorizontalScrolBar;
    public int SB_VERT { get; set; } = ShowVerticalScrolBar;
    public int SB_CTL { get; set; } = 2;
    public int SB_BOTH { get; set; } = 3;

    protected override void WndProc(ref Message m)
    {
        if (m.Msg == 0x85)
        {
            ShowScrollBar(Handle, SB_BOTH, false);
        }

        base.WndProc(ref m);
    }

    [DllImport("user32.dll")]
    private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

    private const int WM_SETREDRAW = 0xB;

    private void PanelView_Scroll(object sender, ScrollEventArgs e)
    {
        Control control = sender as Control;
        if (control is object)
        {
            if (e.Type == ScrollEventType.ThumbTrack)
            {
                SendMessage(control.Handle, WM_SETREDRAW, 1, 0);
                control.Refresh();
                SendMessage(control.Handle, WM_SETREDRAW, 0, 0);
            }
            else
            {
                SendMessage(control.Handle, WM_SETREDRAW, 1, 0);
                control.Invalidate();
            }
        }
    }
}