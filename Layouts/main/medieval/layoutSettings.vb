Imports AeonLabs.Environment

Namespace AeonLabs.Layout
    Public Module LayoutSettings
        Public Const LAYOUT_VERSION As String = "1.0.0"
        Public Const LAYOUT_COMPATIBILITY_WITH_MAIN As String = "1.0.0"

        Public Function layoutCompatibilityApps() As List(Of String)
            Dim apps As New List(Of String)

            apps.Add("remoteAttendance")

            Return apps
        End Function

        Public Function layoutDesignSettings() As environmentLayoutClass
            Dim layout As New environmentLayoutClass
            layout.layoutPanel.backColor = Color.Black

            Return layout
        End Function
    End Module
End Namespace

