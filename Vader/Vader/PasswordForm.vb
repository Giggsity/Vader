Public Class PasswordForm
    Dim password As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        password = Me.TextBox1.Text

        If password = "Boba Fett" Then
            Me.Hide()
            My.Forms.Hiddenform.Show()
        Else
            MsgBox("Password is incorrect.")
        End If
    End Sub

    Private Sub Passwordform_formclosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            Mainform.resetForm()
        End If

    End Sub
End Class