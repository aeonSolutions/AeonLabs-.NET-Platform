using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

public partial class FormCustomized : Form, IMessageFilter
{
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */    /// <summary>
    /// Creates a new FormCustomized.
    /// </summary>
    public FormCustomized()
    {
        timerInactivity = new Timer();


        // Causes the form to fade in.
        this.Load += FormCustomized_Load;

        // Fade out the form when it losses focus.
        this.Deactivate += FormCustomized_Deactivate;

        // Fade in the form when it gaines focus.
        this.Activated += FormCustomized_Activated;
        isFormLoading = true;
        SuspendLayout();
        SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        // ' SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        SetStyle(ControlStyles.ResizeRedraw, true);
        SetStyle(ControlStyles.UserPaint, true);
        UpdateStyles();
        ResumeLayout();

        // fade in / out FX
        FadeFxTimer = new Timer();
        FadeFxTimer.Interval = 25;
        FadeFxTimer.Tick += new EventHandler(timer_Tick);
        Deactivate += new EventHandler(FormCustomized_Deactivate);
        Activated += new EventHandler(FormCustomized_Activated);
        Load += new EventHandler(FormCustomized_Load);
        enableFadeFXandInacivityDetection();
    }


    /* TODO ERROR: Skipped RegionDirectiveTrivia */    /// <summary>
    /// The opacity the form is transitioning to.
    /// </summary>
    private double f_TargetOpacity;

    /// <summary>
    /// The time it takes to fade from 0 to 1 or the other way around.
    /// </summary>
    private object f_FadeTime = 0.5;

    /// <summary>
    /// The opacity that the form will transition to when the form gets focus.
    /// </summary>
    private double f_ActiveOpacity = 1;

    /// <summary>
    /// the opacity that the form will transition to when the form doesn't have focus.
    /// </summary>
    private object f_InactiveOpacity = 0.85;

    /// <summary>
    /// the opacity that the form will transition to when the form is minimized.
    /// </summary>
    private double f_MinimizedOpacity = 0;

    /// <summary>
    /// WindowsMessage that is being held until the end of a transition.
    /// </summary>
    private Message heldMessage = new Message();

    /// <summary>
    /// Timer to aid in fade effects.
    /// </summary>
    private Timer FadeFxTimer;

    /// inactivity timer code auto logout
    private Stopwatch inActivity = null;
    private Timer _timerInactivity;

    private Timer timerInactivity
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _timerInactivity;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_timerInactivity != null)
            {
                /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                /* TODO ERROR: Skipped RegionDirectiveTrivia */
                _timerInactivity.Tick -= timerInactivity_tick;
            }

            _timerInactivity = value;
            if (_timerInactivity != null)
            {
                _timerInactivity.Tick += timerInactivity_tick;
            }
        }
    }

    public TimeSpan InactivityTimeOut { get; set; } = new TimeSpan(0, 15, 0);

    public event InactivityDetectedEventHandler InactivityDetected;

    public delegate void InactivityDetectedEventHandler(object sender);

    private bool isFormLoading = true;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */    /// <summary>
    /// The opacity the form is transitioning to.
    /// </summary>
    public double TargetOpacity
    {
        set
        {
            f_TargetOpacity = value;
        }

        get
        {
            return f_TargetOpacity;
        }
    }

    /// <summary>
    /// The time it takes to fade from 1 to 0 or the other way around.
    /// </summary>
    public double FadeTime
    {
        get
        {
            return Conversions.ToDouble(f_FadeTime);
        }

        set
        {
            if (value > 0)
            {
                f_FadeTime = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("The FadeTime must be a positive value");
            }
        }
    }

    /// <summary>
    /// The opacity that the form will transition to when the form gets focus.
    /// </summary>
    public double ActiveOpacity
    {
        get
        {
            return f_ActiveOpacity;
        }

        set
        {
            if (value >= 0)
            {
                f_ActiveOpacity = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("The ActiveOpacity must be a positive value");
            }

            if (ContainsFocus)
            {
                TargetOpacity = f_ActiveOpacity;
            }
        }
    }

    /// <summary>
    /// the opacity that the form will transition to when the form doesn't have focus.
    /// </summary>
    public double InactiveOpacity
    {
        get
        {
            return Conversions.ToDouble(f_InactiveOpacity);
        }

        set
        {
            if (value >= 0)
            {
                f_InactiveOpacity = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("The InactiveOpacity must be a positive value");
            }

            if (!ContainsFocus && WindowState != FormWindowState.Minimized)
            {
                TargetOpacity = Conversions.ToDouble(f_InactiveOpacity);
            }
        }
    }

    /// <summary>
    /// the opacity that the form will transition to when the form is minimized.
    /// </summary>
    public double MinimizedOpacity
    {
        get
        {
            return f_MinimizedOpacity;
        }

        set
        {
            if (value >= 0)
            {
                f_MinimizedOpacity = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("The MinimizedOpacity must be a positive value");
            }

            if (!ContainsFocus && WindowState != FormWindowState.Minimized)
            {
                TargetOpacity = Conversions.ToDouble(f_InactiveOpacity);
            }
        }
    }
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public bool PreFilterMessage(ref Message m)
    {
        if (m.Msg == 0x20A)
        {
            var pos = new Point(m.LParam.ToInt32());
            var hWnd = WindowFromPoint(pos);
            if (hWnd != IntPtr.Zero && hWnd != m.HWnd && FromHandle(hWnd) is object)
            {
                SendMessage(hWnd, m.Msg, m.WParam, m.LParam);
                return true;
            }
        }

        return false;
    }

    [DllImport("user32.dll")]
    private static extern IntPtr WindowFromPoint(Point pt);
    [DllImport("user32.dll")]
    private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public void enableFadeFXandInacivityDetection()
    {
        inActivity = new Stopwatch();
        // inactivity detection
        resetActivity();
        timerInactivity.Interval = 60 * 1000; // check every 1 second for new messages from the OS
        timerInactivity.Start();
        inActivity.Reset();
        inActivity.Start();

        // fade FX
        if (!FadeFxTimer.Enabled)
            FadeFxTimer.Start();
    }

    /// <summary>
    /// Turns off opacitiy fading.
    /// </summary>
    public void DisableFade()
    {
        f_ActiveOpacity = 1;
        f_InactiveOpacity = 1;
        f_MinimizedOpacity = 1;
    }

    /// <summary>
    /// Turns on opacitiy fading.
    /// </summary>
    public void EnableFadeDefaults()
    {
        f_ActiveOpacity = 1;
        f_InactiveOpacity = 0.85;
        f_MinimizedOpacity = 0;
        f_FadeTime = 0.1;
    }

    private void timerInactivity_tick(object sender, EventArgs e)
    {
        if (inActivity.Elapsed > InactivityTimeOut)
        {
            InactivityDetected?.Invoke(this);
        }
    }
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private const int WM_SYSCOMMAND = 0x112;
    private const int WM_COMMAND = 0x111;
    private const int SC_MINIMIZE = 0xF020;
    private const int SC_RESTORE = 0xF120;
    private const int SC_CLOSE = 0xF060;
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public bool mbDoPaintBackground { get; set; }

    private const int CUSTOM_WM_SYSCOMMAND = 0x112;
    private const int WM_MAXBUTTONSomethingSomething = 0xF030;  // 61488
    private const int WM_MINBUTTONSomethingSomething = 0xF120;   // 61728

    /// <summary>
    /// Intercepts WindowMessages before they are processed.
    /// </summary>
    protected override void WndProc(ref Message m)
    {
        // Traps specifically for "Maximize" button
        try
        {
            if (m.Msg == CUSTOM_WM_SYSCOMMAND)     // to address flickering on maximize form
            {
                // Handle running on 64-bit platforms
                long param;
                if (IntPtr.Size == 4)
                {
                    param = m.WParam.ToInt32();
                }
                else
                {
                    param = m.WParam.ToInt64();
                }

                if (Conversions.ToInteger(param) == WM_MAXBUTTONSomethingSomething)
                {
                    mbDoPaintBackground = false;
                }
                else if (Conversions.ToInteger(param) == WM_MINBUTTONSomethingSomething)
                {
                    mbDoPaintBackground = false;
                }
            }
            else if (m.Msg == WM_SYSCOMMAND || m.Msg == WM_COMMAND)
            {
                // Fade to zero on minimze
                if (m.WParam == (IntPtr)SC_MINIMIZE)
                {
                    if (heldMessage.WParam != (IntPtr)SC_MINIMIZE)
                    {
                        heldMessage = m;
                        TargetOpacity = f_MinimizedOpacity;
                    }
                    else
                    {
                        heldMessage = new Message();
                        TargetOpacity = f_ActiveOpacity;
                    }

                    return;
                }
                // Fade in if the window is restored from the taskbar
                else if (m.WParam == (IntPtr)SC_RESTORE && WindowState == FormWindowState.Minimized)
                {
                    base.WndProc(ref m);
                    TargetOpacity = f_ActiveOpacity;
                    return;
                }

                // Fade out if the window is closed.
                else if (m.WParam == (IntPtr)SC_CLOSE)
                {
                    heldMessage = m;
                    TargetOpacity = f_MinimizedOpacity;
                    return;
                }
            }
        }
        catch (Exception ex)
        {
        }
        // Listen for operating system messages to the application. If the form to expire is moved, mousemove detected, keydown detected it will stay open
        // When no message is sent from the OS within 30 seconds the form will expire.
        resetActivity();
        base.WndProc(ref m);
    }

    public void resetActivity()
    {
        if (inActivity is null)
        {
            return;
        }

        inActivity.Reset();
        inActivity.Start();
    }

    private void FormCustomized_Load(object sender, EventArgs e)
    {
        if (!FadeFxTimer.Enabled)
        {
            return;
        }

        Opacity = f_MinimizedOpacity;
        TargetOpacity = f_ActiveOpacity;
    }

    // Performs fade increment.
    private void timer_Tick(object sender, EventArgs e)
    {
        var fadeChangePerTick = Operators.DivideObject(FadeFxTimer.Interval * 1.0 / 1000, f_FadeTime);

        // Check to see if it is time to stop the timer
        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectLess(Math.Abs(f_TargetOpacity - Opacity), fadeChangePerTick, false)))
        {
            // There is an ugly black flash if you set the Opacity to 1.0
            if (f_TargetOpacity == 1)
            {
                Opacity = 0.99999999999;
            }
            else
            {
                Opacity = f_TargetOpacity;
            }
            // Process held Windows Message.
            base.WndProc(ref heldMessage);
            heldMessage = new Message();
            // Stop the timer to save processor.
            isFormLoading = false;
            FadeFxTimer.Stop();
        }
        else if (f_TargetOpacity > Opacity)
        {
            Opacity += fadeChangePerTick;
        }
        else if (f_TargetOpacity < Opacity)
        {
            Opacity -= fadeChangePerTick;
        }
    }

    private void FormCustomized_Deactivate(object sender, EventArgs e)
    {
        if (isFormLoading)
        {
            return;
        }

        TargetOpacity = Conversions.ToDouble(f_InactiveOpacity);
    }

    private void FormCustomized_Activated(object sender, EventArgs e)
    {
        if (isFormLoading)
        {
            return;
        }

        TargetOpacity = f_ActiveOpacity;
    }
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}