Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Partial Public Class FormCustomized
    Inherits Form
    Implements IMessageFilter


#Region "Variables"
    ''' <summary>
    ''' The opacity the form is transitioning to.
    ''' </summary>
    Private f_TargetOpacity As Double

    ''' <summary>
    ''' The time it takes to fade from 0 to 1 or the other way around.
    ''' </summary>
    Private f_FadeTime = 0.35

    ''' <summary>
    ''' The opacity that the form will transition to when the form gets focus.
    ''' </summary>
    Private f_ActiveOpacity As Double = 1

    ''' <summary>
    ''' the opacity that the form will transition to when the form doesn't have focus.
    ''' </summary>
    Private f_InactiveOpacity = 0.85

    ''' <summary>
    ''' the opacity that the form will transition to when the form is minimized.
    ''' </summary>
    Private f_MinimizedOpacity As Double = 0

    ''' <summary>
    ''' WindowsMessage that is being held until the end of a transition.
    ''' </summary>
    Private heldMessage As Message = New Message()

    ''' <summary>
    ''' Timer to aid in fade effects.
    ''' </summary>
    Private timer As Timer
#End Region

#Region "Properties"
    ''' <summary>
    ''' The opacity the form is transitioning to.
    ''' </summary>
    Public Property TargetOpacity As Double
        Set(ByVal value As Double)
            f_TargetOpacity = value
            If Not timer.Enabled Then timer.Start()
        End Set
        Get
            Return f_TargetOpacity
        End Get
    End Property

    ''' <summary>
    ''' The time it takes to fade from 1 to 0 or the other way around.
    ''' </summary>
    Public Property FadeTime As Double
        Get
            Return f_FadeTime
        End Get
        Set(ByVal value As Double)

            If value > 0 Then
                f_FadeTime = value
            Else
                Throw New ArgumentOutOfRangeException("The FadeTime must be a positive value")
            End If
        End Set
    End Property

    ''' <summary>
    ''' The opacity that the form will transition to when the form gets focus.
    ''' </summary>
    Public Property ActiveOpacity As Double
        Get
            Return f_ActiveOpacity
        End Get
        Set(ByVal value As Double)

            If value >= 0 Then
                f_ActiveOpacity = value
            Else
                Throw New ArgumentOutOfRangeException("The ActiveOpacity must be a positive value")
            End If

            If ContainsFocus Then TargetOpacity = f_ActiveOpacity
        End Set
    End Property

    ''' <summary>
    ''' the opacity that the form will transition to when the form doesn't have focus.
    ''' </summary>
    Public Property InactiveOpacity As Double
        Get
            Return f_InactiveOpacity
        End Get
        Set(ByVal value As Double)

            If value >= 0 Then
                f_InactiveOpacity = value
            Else
                Throw New ArgumentOutOfRangeException("The InactiveOpacity must be a positive value")
            End If

            If Not ContainsFocus AndAlso WindowState <> FormWindowState.Minimized Then TargetOpacity = f_InactiveOpacity
        End Set
    End Property

    ''' <summary>
    ''' the opacity that the form will transition to when the form is minimized.
    ''' </summary>
    Public Property MinimizedOpacity As Double
        Get
            Return f_MinimizedOpacity
        End Get
        Set(ByVal value As Double)

            If value >= 0 Then
                f_MinimizedOpacity = value
            Else
                Throw New ArgumentOutOfRangeException("The MinimizedOpacity must be a positive value")
            End If

            If Not ContainsFocus AndAlso WindowState <> FormWindowState.Minimized Then TargetOpacity = f_InactiveOpacity
        End Set
    End Property
#End Region
    ''LOADING FORM GRAPHICS PERFORMANCE
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or 33554432
            Return cp
        End Get
    End Property

    Public Function PreFilterMessage(ByRef m As Message) As Boolean Implements IMessageFilter.PreFilterMessage
        If m.Msg = &H20A Then
            Dim pos As Point = New Point(m.LParam.ToInt32())
            Dim hWnd As IntPtr = WindowFromPoint(pos)

            If hWnd <> IntPtr.Zero AndAlso hWnd <> m.HWnd AndAlso Control.FromHandle(hWnd) IsNot Nothing Then
                SendMessage(hWnd, m.Msg, m.WParam, m.LParam)
                Return True
            End If
        End If

        Return False
    End Function

    <DllImport("user32.dll")>
    Private Shared Function WindowFromPoint(ByVal pt As Point) As IntPtr
    End Function
    <DllImport("user32.dll")>
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wp As IntPtr, ByVal lp As IntPtr) As IntPtr
    End Function

    ''' <summary>
    ''' Creates a new FormCustomized.
    ''' </summary>
    Public Sub New()
        SuspendLayout()

        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        timer = New Timer()
        timer.Interval = 25
        AddHandler timer.Tick, New EventHandler(AddressOf timer_Tick)
        AddHandler Deactivate, New EventHandler(AddressOf FormCustomized_Deactivate)
        AddHandler Activated, New EventHandler(AddressOf FormCustomized_Activated)
        AddHandler Load, New EventHandler(AddressOf FormCustomized_Load)
    End Sub

    ''' <summary>
    ''' Turns off opacitiy fading.
    ''' </summary>
    Public Sub DisableFade()
        f_ActiveOpacity = 1
        f_InactiveOpacity = 1
        f_MinimizedOpacity = 1
    End Sub

    ''' <summary>
    ''' Turns on opacitiy fading.
    ''' </summary>
    Public Sub EnableFadeDefaults()
        f_ActiveOpacity = 1
        f_InactiveOpacity = 0.85
        f_MinimizedOpacity = 0
        f_FadeTime = 0.35
    End Sub

#Region "WindowsMessageCodes"
    Private Const WM_SYSCOMMAND = &H112
    Private Const WM_COMMAND = &H111
    Private Const SC_MINIMIZE = &HF020
    Private Const SC_RESTORE = &HF120
    Private Const SC_CLOSE = &HF060
#End Region

    ''' <summary>
    ''' Intercepts WindowMessages before they are processed.
    ''' </summary>
    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = FormCustomized.WM_SYSCOMMAND OrElse m.Msg = FormCustomized.WM_COMMAND Then
            'Fade to zero on minimze
            If m.WParam = CType(FormCustomized.SC_MINIMIZE, IntPtr) Then
                If heldMessage.WParam <> CType(FormCustomized.SC_MINIMIZE, IntPtr) Then
                    heldMessage = m
                    TargetOpacity = f_MinimizedOpacity
                Else
                    heldMessage = New Message()
                    TargetOpacity = f_ActiveOpacity
                End If

                Return

                'Fade in if the window is restored from the taskbar
            ElseIf m.WParam = CType(FormCustomized.SC_RESTORE, IntPtr) AndAlso WindowState = FormWindowState.Minimized Then
                MyBase.WndProc(m)
                TargetOpacity = f_ActiveOpacity
                Return

                'Fade out if the window is closed.
            ElseIf m.WParam = CType(FormCustomized.SC_CLOSE, IntPtr) Then
                heldMessage = m
                TargetOpacity = f_MinimizedOpacity
                Return
            End If
        End If

        MyBase.WndProc(m)
    End Sub

    'Causes the form to fade in.
    Private Sub FormCustomized_Load(ByVal sender As Object, ByVal e As EventArgs)
        Opacity = f_MinimizedOpacity
        TargetOpacity = f_ActiveOpacity
    End Sub

    'Performs fade increment.
    Private Sub timer_Tick(ByVal sender As Object, ByVal e As EventArgs)
        Dim fadeChangePerTick = timer.Interval * 1.0 / 1000 / f_FadeTime

        'Check to see if it is time to stop the timer
        If Math.Abs(f_TargetOpacity - Opacity) < fadeChangePerTick Then
            'There is an ugly black flash if you set the Opacity to 1.0
            If f_TargetOpacity = 1 Then
                Opacity = 0.999
            Else
                Opacity = f_TargetOpacity
            End If
            'Process held Windows Message.
            MyBase.WndProc(heldMessage)
            heldMessage = New Message()
            'Stop the timer to save processor.
            timer.Stop()
        ElseIf f_TargetOpacity > Opacity Then
            Opacity += fadeChangePerTick
        ElseIf f_TargetOpacity < Opacity Then
            Opacity -= fadeChangePerTick
        End If
    End Sub

    'Fade out the form when it losses focus.
    Private Sub FormCustomized_Deactivate(ByVal sender As Object, ByVal e As EventArgs)
        TargetOpacity = f_InactiveOpacity
    End Sub

    'Fade in the form when it gaines focus.
    Private Sub FormCustomized_Activated(ByVal sender As Object, ByVal e As EventArgs)
        TargetOpacity = f_ActiveOpacity
    End Sub

End Class


