Imports AeonLabs.Environment.Assembly.assemblyEnvironmentVarsClass

Public Class environmentLayoutClass
    Public Property layoutPanel As layoutPanelClass
    Public Property layoutText As layoutTextClass

    Public Property menu As assemblyMenuClass

    Public Class layoutPanelClass
        Public Property foreColor As Color
        Public Property backColor As Color
        Public Property transparencyIndex As Double
    End Class

    Public Class layoutTextClass
        Public Property foreColor As Color
        Public Property backColor As Color
        Public Property transparencyIndex As Double
    End Class
End Class
