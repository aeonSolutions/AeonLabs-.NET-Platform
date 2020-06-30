Imports System.Windows.Forms

Public Class PictureBoxDoubleBuffer
    Inherits PictureBox
    Public Sub New()
        Me.DoubleBuffered = True
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)
        Me.UpdateStyles()
    End Sub
End Class
