

Public Class Form1

    Private Sub NotifyIcon1_MouseDown(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Using my_form As New Form1()
                my_form.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub StartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartToolStripMenuItem.Click

        Dim str_lorem As String = "lorem ipsum taratatatatatata lorem ipsum" & _
            vbCrLf & "more lore ipsum here!" & _
            vbCrLf & "and even more lorem ipsum there."

        NotifyIcon1.ShowBalloonTip(1000, "Welcome    ", str_lorem, ToolTipIcon.Info)
    End Sub

    Private Sub EndToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EndToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub AleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AleToolStripMenuItem.Click
        MsgBox("Opa")
    End Sub
End Class
