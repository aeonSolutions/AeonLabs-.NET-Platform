Imports AeonLabs.Environment

Public Class lateralSettingsChild
    Private envars As environmentVarsCore
    Private updateEnvironment As new updateEnvironmentClass


    Public Sub New(_envars As environmentVarsCore)
        envars = _envars

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub lateralSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub selectPanelBackColor_Click(sender As Object, e As EventArgs) Handles selectPanelBackColor.Click
        If ColorDialog.ShowDialog = DialogResult.OK Then
            envars.layoutDesign.PanelBackColor = ColorDialog.Color
            updateEnvironment.RaiseEnventUpDateEnvironemnt(Me, envars)
        End If
    End Sub

    Private Sub MacTrackBar2_ValueChanged(sender As Object, value As Decimal) Handles MacTrackBar1.ValueChanged
        envars.layoutDesign.PanelTransparencyIndex = value
        updateEnvironment.RaiseEnventUpDateEnvironemnt(Me, envars)
    End Sub
End Class
