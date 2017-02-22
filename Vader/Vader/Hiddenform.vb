Public Class Hiddenform
    Public store As String = Mainform.store
    Public register As String = Mainform.register
    Public hostname As String = Mainform.hostname

    Public filedir As String = Mainform.filedir
    Public fileloc As String = Mainform.fileloc
    Public logfile As String = Mainform.logfile
    Public timestamp As String = Mainform.timestamp

    Public command As String = Mainform.command
    Public resourcepath As String = Mainform.resourcepath
    Public username As String = Mainform.username
    Public password As String = Mainform.password

    Private Sub Hiddenform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = store
        Label2.Text = register

        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "==========================================", True)
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "User:" + vbTab + vbTab + My.User.Name, True)
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Store #: " + vbTab + store, True)
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Time: " + vbTab + vbTab + timestamp, True)

        Try
            Mainform.pingresponse = Mainform.newping.Send(hostname, 1000)
            Mainform.checkPing()

        Catch ex As System.Net.NetworkInformation.PingException
            Mainform.pingtext = "Ping Failed"
            My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + Mainform.pingtext, True)
            MsgBox(Mainform.pingtext)

        End Try

        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Hidden Admin Options Selected", True)
    End Sub

    Private Sub Hiddenform_formclosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            Mainform.resetForm()
        End If

    End Sub

    'Update Adobe
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "User Selected: Adobe Update", True)
        Dim args As String = "/accepteula \\" & hostname & " -u " & username & " -p " & password & " java -jar \\" & "C:\Temp\Xstore-Adobe11-03312016-100644.jar"

        If My.Computer.FileSystem.FileExists(resourcepath + "\xstore-adobe11-03312016-100644.jar") Then
            My.Computer.FileSystem.CopyFile(resourcepath + "\xstore-adobe11-03312016-100644.jar", "\\" + hostname + "\C$\temp\xstore-adobe11-03312016-100644.jar", True)
            My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Adobe Update Copied", True)
        End If

        Process.Start(command, args)
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Adobe Update Run on " + hostname, True)

        Me.Close()
        Mainform.resetForm()
    End Sub

    'Update IE
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "User Selected: IE 11 Update", True)
        Dim args As String = "/accepteula \\" & hostname & " -u " & username & " -p " & password & " java -jar \\" & hostname & "\C$\Temp\xstore-ie11-update-20160217-150100.jar"

        If My.Computer.FileSystem.FileExists(resourcepath + "\xstore-ie11-update-20160217-150100.jar") Then
            My.Computer.FileSystem.CopyFile(resourcepath + "\xstore-ie11-update-20160217-150100.jar", "\\" + hostname + "\C$\temp\xstore-ie11-update-20160217-150100.jar", True)
            My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "IE 11 Update Copied", True)
        End If

        Process.Start(command, args)
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "IE 11 Update Run on " + hostname, True)

        Me.Close()
        Mainform.resetForm()
    End Sub

    'Update to Service Pack 1
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "User Selected: Service Pack 1 Update", True)
        Dim args As String = "/accepteula \\" & hostname & " -u " & username & " -p " & password & " java -jar \\" & hostname & "\C$\Temp\xstore-sp1-update-20160204-114700.jar"

        If My.Computer.FileSystem.FileExists(resourcepath + "\xstore-sp1-update-20160204-114700.jar") Then
            My.Computer.FileSystem.CopyFile(resourcepath + "\xstore-sp1-update-20160204-114700.jar", "\\" + hostname + "\C$\temp\xstore-sp1-update-20160204-114700.jar", True)
            My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Service Pack 1 Update Copied", True)
        End If

        Process.Start(command, args)
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Service Pack 1 Update Run on " + hostname, True)

        Me.Close()
        Mainform.resetForm()
    End Sub

    'Update XEnvironment
    Private Sub Button4_Click(sender As Object, e As EventArgs)

    End Sub
End Class