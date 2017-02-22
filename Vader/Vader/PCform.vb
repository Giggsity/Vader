Imports System
Imports System.IO
Imports System.Net.NetworkInformation

Public Class PCform

    Public store As String = Mainform.store
    Public register As String = Mainform.register
    Public hostname As String = Mainform.hostname

    Public filedir As String = Mainform.filedir
    Public fileloc As String = Mainform.fileloc
    Public logfile As String = Mainform.logfile
    Public timestamp As String = Mainform.timestamp


    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            My.Forms.PCform.Close()
            Mainform.resetForm()

        End Try

        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "User selected: PC", True)

    End Sub

    'check local pending downloads
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim display As String = "Pending Downloads List:" + Environment.NewLine
        Dim filelist As String() = Directory.GetFiles("\\" + hostname + "\C$\xstore\download")

        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "User selected: Local Pending Downloads", True)

        For Each file As String In filelist
            display += Environment.NewLine + Path.GetFileName(file)
        Next

        MsgBox(display)
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + display, True)

        My.Forms.PCform.Close()

    End Sub

    'properties file check
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim propfile1 As String = "\\" + hostname + "\C$\environment\system.properties"
        Dim propfile2 As String = "\\" + hostname + "\C$\xstore\base-xstore.properties"
        Dim propfile3 As String = "\\" + hostname + "\C$\xstore\system.properties"
        Dim propfile4 As String = "\\" + hostname + "\C$\xstore\updates\base-xstore.properties"
        Dim display As String = "Properties File Check: " + Environment.NewLine
        Dim messagetl As Boolean = False

        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "User selected: Properties File Check", True)

        display += Environment.NewLine + propfile1 + " has " + File.ReadAllLines(propfile1).Length.ToString + " lines."
        display += Environment.NewLine + "***Should have 38-41***"
        display += Environment.NewLine
        If File.ReadAllLines(propfile1).Length < 38 Or File.ReadAllLines(propfile1).Length > 41 Then
            messagetl = True
        End If

        display += Environment.NewLine + propfile2 + " has " + File.ReadAllLines(propfile2).Length.ToString + " lines."
        display += Environment.NewLine + "***Should have 88-95***"
        display += Environment.NewLine
        If File.ReadAllLines(propfile2).Length < 88 Or File.ReadAllLines(propfile2).Length > 95 Then
            messagetl = True
        End If

        display += Environment.NewLine + propfile3 + " has " + File.ReadAllLines(propfile3).Length.ToString + " lines."
        display += Environment.NewLine + "***Should have 88-95***"
        display += Environment.NewLine
        If File.ReadAllLines(propfile3).Length < 88 Or File.ReadAllLines(propfile3).Length > 95 Then
            messagetl = True
        End If

        display += Environment.NewLine + propfile4 + " has " + File.ReadAllLines(propfile4).Length.ToString + " lines."
        display += Environment.NewLine + "***Should have 88-95***"
        display += Environment.NewLine
        If File.ReadAllLines(propfile4).Length < 88 Or File.ReadAllLines(propfile4).Length > 95 Then
            messagetl = True
        End If

        MsgBox(display)
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + display, True)


        If messagetl Then
            MsgBox("Please send email with the copied information to the Team Leads.")
        End If

        My.Forms.PCform.Close()

    End Sub

    'copy log files
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim logloc As String = "\\" + hostname + "\C$\Xstore\log"

        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "User selected: Copy Log Files", True)

        If Not Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Desktop + "\Logs") Then
            System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Desktop + "\Logs")
        End If

        If File.Exists(logloc + "\xstore.log") Then
            My.Computer.FileSystem.CopyFile(logloc + "\xstore.log", My.Computer.FileSystem.SpecialDirectories.Desktop + "\Logs\" + hostname + "xstore.log", True)
        End If

        If File.Exists(logloc + "\repl.log") Then
            My.Computer.FileSystem.CopyFile(logloc + "\repl.log", My.Computer.FileSystem.SpecialDirectories.Desktop + "\Logs\" + hostname + "repl.log", True)
        End If

        If File.Exists(logloc + "\verifone.log") Then
            My.Computer.FileSystem.CopyFile(logloc + "\verifone.log", My.Computer.FileSystem.SpecialDirectories.Desktop + "\Logs\" + hostname + "verifone.log", True)
        End If

        If File.Exists(logloc + "\ejournal.log") Then
            My.Computer.FileSystem.CopyFile(logloc + "\ejournal.log", My.Computer.FileSystem.SpecialDirectories.Desktop + "\Logs\" + hostname + "ejournal.log", True)
        End If

        If File.Exists(logloc + "\email.log") Then
            My.Computer.FileSystem.CopyFile(logloc + "\email.log", My.Computer.FileSystem.SpecialDirectories.Desktop + "\Logs\" + hostname + "email.log", True)
        End If

        If File.Exists(logloc + "\dataloader.log") Then
            My.Computer.FileSystem.CopyFile(logloc + "\dataloader.log", My.Computer.FileSystem.SpecialDirectories.Desktop + "\Logs\" + hostname + "dataloader.log", True)
        End If

        If File.Exists(logloc + "\pos.log") Then
            My.Computer.FileSystem.CopyFile(logloc + "\Pos.log", My.Computer.FileSystem.SpecialDirectories.Desktop + "\Logs\" + hostname + "pos.log", True)
        End If

        MsgBox("Logs copied to desktop.")
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Log files copied.", True)

        My.Forms.PCform.Close()

    End Sub

    'U.A.C.
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        My.Forms.PCform.Close()
        My.Forms.UACform.Show()
    End Sub

    'clear free space
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "User selected: Clear Free Space", True)
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "List of Files Deleted to Clear Up Space:", True)
        Mainform.noFreeSpaceError()
        My.Forms.PCform.Close()
    End Sub

    Private Sub PCform_formclosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            Mainform.resetForm()
        End If

    End Sub

End Class