Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles

Partial Public Class PanelTransparentTextBox
    Inherits Panel
    Public Sub New()
        SetStyle(ControlStyles.SupportsTransparentBackColor Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)
        BackColor = Color.Transparent
        Dim line As New LabelDoubleBuffer With {
            .BackColor = Color.White,
            .Size = New Size(Me.Width, 2),
            .Location = New Point(0, Me.Height),
            .Dock = DockStyle.Bottom,
            .AutoSize = False
        }
        Me.Controls.Add(line)
    End Sub


End Class
