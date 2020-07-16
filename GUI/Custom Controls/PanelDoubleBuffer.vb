Imports System.Windows.Forms

Public Class PanelDoubleBuffer
    Inherits Panel

    'MAIN LAYOUT design scheme
    Public Property PANEL_CLOSED_STATE_DIM As Integer = 40
    Public Property PANEL_OPEN_STATE_DIM As Integer = 400

    Public Sub New()

        SuspendLayout()

        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.UserPaint, True)

        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        SetStyle(ControlStyles.ResizeRedraw, True)
        Me.UpdateStyles()

        ResumeLayout()
    End Sub
End Class
