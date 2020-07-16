Imports AeonLabs.Environment

Public Class updateEnvironmentClass
    Public Shared Event UpDateEnvironemnt(sender As Object, envars As environmentVarsCore)

    Public Sub RaiseEnventUpDateEnvironemnt(sender As Object, envars As environmentVarsCore)
        RaiseEvent UpDateEnvironemnt(sender, envars)
    End Sub

    Public Sub New()

    End Sub
End Class
