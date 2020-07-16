
Imports System.Drawing
Imports System.Windows.Forms
Imports AeonLabs.Environment

Public Class lateralSettingsForm
    Public Event RaiseEnventUpDateEnvironemnt(sender As Object, envars As environmentVarsCore)

    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or 33554432
            Return cp
        End Get
    End Property

    Private envars As environmentVarsCore
    Private lateralSettingsChildForm As lateralSettingsChild

    Public Sub New(_envars As AeonLabs.Environment.environmentVarsCore)
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        envars = _envars

        ' This call is required by the designer.
        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()
    End Sub

    Private Sub messageBoxForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        panelForm.BackColor = Color.FromArgb(50, Color.Red)
    End Sub
    Private Sub messageBoxForm_show(sender As Object, e As EventArgs) Handles MyBase.Shown

    End Sub

    Private Sub AlignForms(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged, Me.Move, Me.Layout
        If lateralSettingsChildForm Is Nothing Then
            Exit Sub
        End If
        lateralSettingsChildForm.Location = Me.PointToScreen(Point.Empty)
        lateralSettingsChildForm.Size = Me.ClientSize
    End Sub

    Private Sub selectPanelBackColor_Click(sender As Object, e As EventArgs) Handles selectPanelBackColor.Click
        If ColorPickerDialog.ShowDialog = Global.System.Windows.Forms.DialogResult.OK Then
            envars.layoutDesign.PanelBackColor = ColorPickerDialog.Color
            RaiseEvent RaiseEnventUpDateEnvironemnt(Me, envars)
        End If
    End Sub

    Private Sub MacTrackBar2_ValueChanged(sender As Object, value As Decimal) Handles MacTrackBar1.ValueChanged
        envars.layoutDesign.PanelTransparencyIndex = value
        RaiseEvent RaiseEnventUpDateEnvironemnt(Me, envars)
    End Sub
End Class

