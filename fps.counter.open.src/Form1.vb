Public Class Form1
    Private Declare Function InvalidateRect Lib "user32" (ByVal hwnd As IntPtr, ByVal lpRect As IntPtr, ByVal bErase As Boolean) As Boolean

    Private Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub tmrFPSCounter_Tick(sender As Object, e As EventArgs) Handles tmrFPSCounter.Tick
        Try
            If GetTickCount() - FPS_LastCheck >= 1000 Then
                FPS_Current = FPS_Count
                FPS_Count = 0 ' set the counter
                FPS_LastCheck = GetTickCount()

                ' highest FPS
                If FPS_Current > FPS_Highest Then
                    FPS_Highest = FPS_Current
                End If
            End If

            FPS_Count = FPS_Count + 1
        Catch ex As Exception
            'dont msgbox otherwise if error occurs you'l get spammed to death.
        End Try
    End Sub

    Private Sub tmrDrawFPSCounter_Tick(sender As Object, e As EventArgs) Handles tmrDrawFPSCounter.Tick
        Try
            Dim C1 As Graphics = Graphics.FromHwnd(New IntPtr(FindWindow("BlackDesert -", "BlackDesert -")))

            Dim fontObj As Font
            fontObj = New System.Drawing.Font("Tahoma", 12, FontStyle.Regular)

            C1.DrawString(FPS_Current & " FPS", fontObj, Brushes.Lime, 10, 10)
        Catch ex As Exception

        End Try
    End Sub
End Class
