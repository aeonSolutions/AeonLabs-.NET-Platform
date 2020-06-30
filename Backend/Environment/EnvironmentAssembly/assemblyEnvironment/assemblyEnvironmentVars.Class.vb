Imports System.Drawing
Imports System.Windows.Forms

Public Class assemblyEnvironmentVarsClass

    Public Property MenuPanelBackColor As Color
    Public Property menu As assemblyMenuClass




    '' ???????
    Structure subMenuDesignPropertiesClass
        Public Property height As Integer
        Public Property width As Integer
        Public Property widthClosed As Integer
        Public Property bkColor As Color
        Public Property border As Boolean
    End Structure






    Public Class assemblyMenuClass
        Public Property menuItem As New List(Of assemblymenuItemClass)
        Public Property menuSort As New List(Of Integer)
    End Class

    Public Class assemblymenuItemClass
        'settings for loading contents
        Public Property nameSpaceString As String         ' Note that I´m in namespace  "ConsoleApplication1.MyClassA"
        Public Property assemblyFilename As String
        Public Property contentToLoadForm As System.Windows.Forms.Form
        Public Property showAsDialog As Boolean

        'settings for executing internal code tasks
        Public Property tasks As New List(Of String)

        'settings for design 
        Public Property menuUID As String
        Public Property menuTitle As String               ' menu title string for translations
        Public Property menuIndex As Integer              '1 is the first on TOP; 0 is disabled
        Public Property subMenuIndex As Integer = -1      '1 is the first on TOP; false means is a menu 
        Public Property menuDesignProperties As subMenuDesignPropertiesClass

        Public Property notifications As Integer          ' number of notification pending on menu item
        Public Property icon As String

        Public Property subMenuPanel As Panel
        Public Property iconPicHolder As List(Of PictureBox)

        'menu wrapper
        Public Property menuWrapperPanel As Panel
        Public Property state As Boolean
        Public Property menuWrapperOpenHeight As Integer
    End Class

End Class
