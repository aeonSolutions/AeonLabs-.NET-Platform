Imports System.Reflection
Imports System.Windows.Forms
Imports AeonLabs.Environment

Public Module DLLlibrary

    Public Function GetFormByName(ByVal FormName As String) As Form
        Dim T As Type = Type.GetType(FormName, True, True)
        Return CType(Activator.CreateInstance(T), Form)
    End Function

    Public Function loadExternalAssembly(ByVal state As environmentVarsCore, ByVal dllFileName As String, ByVal className As String) As Object
        Try
            Dim fullPath As String = state.libraryPath & dllFileName
            Dim asm As Assembly = Assembly.LoadFrom(fullPath)
            Dim myType As System.Type = asm.GetType(asm.GetName.Name & "." & className)
            Return Activator.CreateInstance(myType)
        Catch ex As Exception
            Return Nothing
        End Try
        Return Nothing
    End Function

End Module
