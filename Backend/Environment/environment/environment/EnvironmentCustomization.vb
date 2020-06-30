Public Class EnvironmentCustomization
    Public Property ApplicationBrandNAme As String = "Missing brand"
    Public Property businessname As String = "missing business name"

    Public Property hasLogin As Boolean = False
    Public Property hasSetup As Boolean = False

    Public Property hasLocalSettings As Boolean = False
    Public Property hasCloudSettings As Boolean = False

    Public Property hasStaticAssemblies As Boolean = True
    Public Property hasDynamicAssemblies As Boolean = True

    Public Property hasStaticDocumentTemplates As Boolean = True
    Public Property hasDynamicDocumentTemplates As Boolean = True

    Public Property websiteToLoadProgram As String = ""

    Public Property softwareAccessMode As String = ""
    Public Property expireDate As String = "" ''expire date dd/mm/yyyy

    Public Property updateServerAddr As String = ""
    Public Property crashReportServerAddr As String = ""
End Class
