Public Class Firewallform
    Public fileloc As String = Mainform.fileloc
    Public store As String = Mainform.store
    Public register As String = Mainform.register
    Public timestamp As String = Mainform.timestamp
    Public hostname As String = Mainform.hostname
    Public firetype As Integer = 0

    Dim username As String = "admin"
    Dim password As String = "L1d52o1o"
    Dim command As String = "\\hw-isilon-smb\IT\SuperSaiyan\B\plink.exe"
    Dim args As String = "hwl" & store & " -1 " & username & " -pw " & password & " -m \\hw-isilon-smb\IT\SuperSaiyan\B\"
    Dim cmd As New Process()

    Private Sub Firewallform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = store
        Label2.Text = register

        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "==========================================", True)
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "User:" + vbTab + vbTab + My.User.Name, True)
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Store #: " + vbTab + store, True)
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Time: " + vbTab + vbTab + timestamp, True)
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "==========================================", True)
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + Environment.NewLine + "User selected: Firewalls", True)

        Try
            Mainform.pingresponse = Mainform.newping.Send(hostname, 1000)
            Mainform.checkPing()

        Catch ex As System.Net.NetworkInformation.PingException
            Mainform.pingtext = "Ping Failed"
            My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + Mainform.pingtext, True)
            MsgBox(Mainform.pingtext)

        End Try
    End Sub

    Private Sub Firewallform_formclosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            Mainform.resetForm()
        End If

    End Sub

    'drop firewall
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        checkFireType()
        args = args & firetype & "FireDis.txt"
        cmd = Process.Start(command, args)
        cmd.WaitForExit()
    End Sub

    'raise firewall
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        checkFireType()
        args = args & firetype & "FireEn.txt"
        cmd = Process.Start(command, args)
        cmd.WaitForExit()
    End Sub

    Private Sub checkFireType()
        If RadioButton1.Checked Then
            firetype = 80
        End If

        If RadioButton2.Checked Then
            firetype = 90
        End If
    End Sub
End Class