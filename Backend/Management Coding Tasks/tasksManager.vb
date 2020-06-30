Public Class tasksManagerClass
    Public Const TO_START As Boolean = -1
    Public Const BUSY As Boolean = 1
    Public Const FINISHED As Boolean = 0

    Public Event tasksCompleted(sender As Object)


    Private tasks As Dictionary(Of String, Integer)
    Private WithEvents timer As Timer


    Public Sub New()
        tasks = New Dictionary(Of String, Integer)
    End Sub

    Public Sub registerTask(name As String, status As Integer)
        tasks.Add(name, status)
    End Sub

    Public Sub startListening()
        timer = New Timer
        timer.Interval = 100
        timer.Start()

    End Sub

    Public Sub unload()
        If timer IsNot Nothing Then
            timer.Stop()
        End If
    End Sub
    Private Sub timer_tick(ByVal sender As Object, ByVal e As EventArgs) Handles timer.Tick
        If getTasksStatus.Equals(FINISHED) Then
            RaiseEvent tasksCompleted(Me)
            timer.Stop()
        End If
    End Sub

    Public Sub setStatus(name As String, status As Integer)
        tasks(name) = status
    End Sub

    Public Function getTasksStatus() As Integer
        For i = 0 To tasks.Count - 1
            If tasks.ElementAt(i).Value.Equals(TO_START) Or tasks.ElementAt(i).Value.Equals(BUSY) Then
                Return BUSY
            End If
        Next i
        Return FINISHED
    End Function
End Class
