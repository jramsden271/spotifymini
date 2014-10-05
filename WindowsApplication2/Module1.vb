



Module Module1

    Public Function XPosition(ByVal PositionModeAsPercentage As Integer) As Integer
        Dim TempVal As Integer
        Dim LeftBorder As Integer
        Dim RightBorder As Integer
        LeftBorder = Form1.LeftPosition
        RightBorder = Form1.RightGap
        PositionModeAsPercentage = Math.Min(100, Math.Max(0, PositionModeAsPercentage)) 'ie between 0 and 100
        TempVal = 0.01 * (Screen.PrimaryScreen.Bounds.Width - LeftBorder - RightBorder - Form1.Width) * PositionModeAsPercentage + LeftBorder
        Return TempVal
    End Function

    Public Sub EndProgram(ByVal hide0exit1 As Integer)
        Form1.Opacity *= (1 - Form1.Height ^ -0.35)
        Form1.Top += 1
        If Form1.Opacity < 0.01 Then
            If Hide0Exit1 = 0 Then
                Form1.WindowState = FormWindowState.Minimized
                Form1.ShowInTaskbar = True
                Form1.Opacity = 1
                If Form1.Form1WindowState = 0 Then : Form1.Top = Form1.ScreenHeight - Form1.ShrinkHeight - Form1.BottomGap
                ElseIf Form1.Top = Form1.ScreenHeight - Form1.GrowHeight - Form1.BottomGap Then
                End If
                Form1.TimerExit.Enabled = False
            ElseIf hide0exit1 = 1 Then : End
            End If
        End If
    End Sub

    Public Function MouseOverForm(ByVal InputForm As Form) As Boolean


    End Function


End Module

Public Class SearchBox
    Public Sub HideTextbox()
        Call Form1.ShrinkMe()
        Form1.TextBox1.Text = ""
    End Sub
End Class