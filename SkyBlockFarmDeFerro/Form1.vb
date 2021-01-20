Public Class Form1
    Public Declare Sub keybd_event Lib "user32" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Integer, ByVal dwExtraInfo As Integer)

    Private Const KEYEVENTF_KEYDOWN As Integer = &H0
    Private Const KEYEVENTF_KEYUP As Integer = &H2

    Private Sub Shifter_Tick(sender As Object, e As EventArgs) Handles Shifter.Tick
        keybd_event(CByte(Keys.ShiftKey), 0, KEYEVENTF_KEYDOWN, 0)
        keybd_event(CByte(Keys.ShiftKey), 0, KEYEVENTF_KEYUP, 0)
        PictureBox1.BackColor = Color.Green
        Label1.Text = "Ligado"
    End Sub

    Private Sub AntiBotter_Tick(sender As Object, e As EventArgs) Handles AntiBotter.Tick
        Dim rng As New Random
        Select Case rng.Next(1, 5)
            Case 1
                My.Computer.Keyboard.SendKeys("W")
            Case 2
                My.Computer.Keyboard.SendKeys("A")
            Case 3
                My.Computer.Keyboard.SendKeys("S")
            Case 4
                My.Computer.Keyboard.SendKeys("D")
        End Select
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Shifter.Start()
        AntiBotter.Start()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Shifter.Stop()
        AntiBotter.Stop()
        PictureBox1.BackColor = Color.Red
        Label1.Text = "Desligado"
    End Sub
End Class
