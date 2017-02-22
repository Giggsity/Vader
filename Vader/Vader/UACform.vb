Public Class UACform

    Dim resourcepath As String = Mainform.resourcepath
    Dim command As String = Mainform.command
    Dim process As New Process()
    Dim username As String = "administrator"
    Dim password As String = "Laptopadmin2005"

    'disable U.A.C.
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim hostname As String = Me.TextBox1.Text
        Dim args As String = "/accepteula \\" & hostname & " -u " & username & " -p " & password & " C:\Windows\System32\cmd.exe /k " + Environ("windir") + "\System32\reg.exe ADD HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System /v EnableLUA /t REG_DWORD /d 0 /f"

        'If My.Computer.FileSystem.FileExists(errorpath) Then
        '    My.Computer.FileSystem.CopyFile(errorpath, errorlog + "\" + hostname + Date.Now.ToString("MM-dd-yyyy") + ".err", True)
        '    My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Error File (" & errorpath & ") Copied to " & errorlog & ".", True)
        'End If

        'System.IO.File.Delete(errorpath)
        Process.Start(command, args)

        System.IO.File.WriteAllText(PCform.fileloc, "")
        My.Computer.FileSystem.WriteAllText(PCform.fileloc, Environment.NewLine + "==========================================", True)
        My.Computer.FileSystem.WriteAllText(PCform.fileloc, Environment.NewLine + "User:" + vbTab + vbTab + My.User.Name, True)
        My.Computer.FileSystem.WriteAllText(PCform.fileloc, Environment.NewLine + "Hostname: " + vbTab + hostname, True)
        My.Computer.FileSystem.WriteAllText(PCform.fileloc, Environment.NewLine + "Time: " + vbTab + vbTab + PCform.timestamp, True)

        My.Computer.FileSystem.WriteAllText(PCform.fileloc, Environment.NewLine + Environment.NewLine + "UAC Disabled.", True)
        MsgBox("User Account Control is disabled.")

        My.Forms.UACform.Close()
        Mainform.resetForm()
    End Sub

    'enable U.A.C.
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        My.Forms.UACform.Close()
        Mainform.resetForm()
    End Sub
End Class