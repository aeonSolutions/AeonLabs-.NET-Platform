Imports System.Drawing.Text
Imports System.IO
Imports AeonLabs.Environment.Assembly.assemblyEnvironmentVarsClass

Public Class environmentLayoutClass

    Public Property menu As New assemblyMenuClass

    'MAIN LAYOUT design scheme
    Public Property MENU_BACK_COLOR As Color = Color.Black
    Public Property MENU_CLOSED_STATE As Integer = 40
    Public Property MENU_OPEN_STATE As Integer = 400

    'widgets & plugIns design scheme
    Public Property labelForeColor As Color
    Public Property linkLabelForeColor As Color
    Public Property buttonForecolor As Color
    Public Property editTextBackColor As Color
    Public Property controlWithSelectionBackcolor As Color
    Public Property buttonBackcolor As Color

    Public Property borderColor As Color

    Public Property PanelBackColor As Color
    Public Property PanelTransparencyIndex As Double

    ' Time interval to change background image on main form
    Public Property RandomBackgroundTimeInterval As New TimeSpan(0, 15, 0) '15 min timeout - integer (Hours, Minutes, Seconds) 
    'fonts
    Public fontText, fontTitle As New PrivateFontCollection()
    Public Property fontTitleFile As String = "TrajanPro.ttf"
    Public Property fontTextFile As String = "Roboto-Medium.ttf"

    'font text size
    Public Property menuTitleFontSize As Integer = 10
    Public Property subMenuTitleFontSize As Integer = 8
    Public Property buttonFontSize As Integer = 12
    Public Property SmallTextFontSize As Integer = 7
    Public Property RegularTextFontSize As Integer = 9
    Public Property DialogTitleFontSize As Integer = 12
    Public Property groupBoxTitleFontSize As Integer = 8
    'main color schemes
    Public Property buttonColor As Color = Color.DarkOrange
    Public Property dividerColor As Color = Color.FromArgb(253, 186, 49)
    Public Property colorMainMenu As Color = Color.FromArgb(35, 40, 45)
    Public Property colorMainPageHeader As Color = Color.FromArgb(253, 186, 49)

    Public Sub loadDefaults(envars As environmentVarsCore)
        'ToDo check default font files are present
        Dim FontFileName = New FileInfo(envars.fontsPath & fontTitleFile)
        FontFileName.Refresh()
        If FontFileName.Exists Then
            envars.layoutDesign.fontTitle.AddFontFile(envars.fontsPath & fontTitleFile)
        Else
            MessageBox.Show("font file not found. reinstall the program")
            Throw New Exception("font file not found")
        End If

        FontFileName = New FileInfo(envars.fontsPath & fontTextFile)
        FontFileName.Refresh()
        If FontFileName.Exists Then
            envars.layoutDesign.fontText.AddFontFile(envars.fontsPath & fontTextFile)
        Else
            MessageBox.Show("font file not found. reinstall the program")
            Throw New Exception("font file not found")
        End If
    End Sub
End Class
