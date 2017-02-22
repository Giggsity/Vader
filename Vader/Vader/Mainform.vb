Imports System.Net.NetworkInformation
Imports System.IO

Public Class Mainform

    Public store As String
    Public register As String
    Public hostname As String

    Public newping As New System.Net.NetworkInformation.Ping
    Public pingresponse As System.Net.NetworkInformation.PingReply
    Public pingtext As String
    Public canping As Boolean = False

    Public filedir As String = "\\hw-isilon-smb\IT\MajinBuu\Logs\" & Date.Now.ToString("MM-dd-yyyy")
    Public fileloc As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & Environment.UserName & ".txt"
    Public logfile As String = filedir & "\" & Environment.UserName & ".txt"

    Public timestamp As String
    Dim errorpath As String
    Dim errorlog As String = "\\hw-isilon-smb\IT\MajinBuu\CloseErrors"
    Public resourcepath As String = "\\MRCH-3010-47444\C$\Share\Updates"

    Public command As String = "C:\pstools\psexec.exe"
    Dim process As New Process()
    Public username As String = "sysadmin"
    Public password As String = "9598me_XPV"

    Private Sub setStore()
        checkDir()
        clearLog()
        setTimeStamp()

        store = Me.TextBox1.Text
        register = Me.TextBox2.Text

        checkStoreNumber(store)
        checkRegisterNumber(register)

        hostname = "HAT" & store & "R" & register
    End Sub

    Private Sub setTimeStamp()
        timestamp = TimeValue(Now) & " " & DateValue(Now)
    End Sub

    Private Sub checkDir()
        If Not Directory.Exists(filedir) Then
            System.IO.Directory.CreateDirectory(filedir)
        End If
    End Sub

    Private Sub clearLog()
        If File.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & Environment.UserName & ".txt") Then
            System.IO.File.Delete(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & Environment.UserName & ".txt")
        End If
    End Sub

    'copy log file from fileloc to logfile
    Public Sub copyLogFile()
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "==========================================" & Environment.NewLine, True)

        Dim teststring As String = My.Computer.FileSystem.ReadAllText(fileloc)
        Clipboard.SetDataObject(teststring)
        My.Computer.FileSystem.WriteAllText(logfile, teststring, True)

    End Sub

    Private Sub checkStoreNumber(ByVal s As String)
        Dim length As Integer = Len(store)
        While length < 4
            store = "0" & store
            length = Len(store)
            If length = 4 Then
                Exit While
            End If
        End While

        If length >= 5 Then
            MsgBox("Store Number Incorrect.")
        End If

    End Sub

    Private Sub checkRegisterNumber(ByVal s As String)
        Dim length As Integer = Len(register)
        While length < 2
            register = "0" & register
            length = Len(register)
            If length = 2 Then
                Exit While
            End If
        End While

        If length >= 3 Then
            MsgBox("Register Number Incorrect.")
        End If
    End Sub

    Private Sub incorrectFormatError()
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Backup Incorrect Format.", True)

        If File.Exists("\\" + hostname + "\C$\Xstoredb\backup\xstore.bak") Then
            System.IO.File.Delete("\\" + hostname + "\C$\Xstoredb\backup\xstore.bak")
        End If
    End Sub

    Public Sub noFreeSpaceError()
        If File.Exists("\\" + hostname + "\C$\Temp\Xstore.bak") Then
            My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Deleting \\" + hostname + "\C$\Temp\Xstore.bak", True)
            System.IO.File.Delete("\\" + hostname + "\C$\Temp\Xstore.bak")
        End If

        If File.Exists("\\" + hostname + "\C$\Temp\Xstore.bak.gz") Then
            My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Deleting \\" + hostname + "\C$\Temp\Xstore.bak.gz", True)
            System.IO.File.Delete("\\" + hostname + "\C$\Temp\Xstore.bak.gz")
        End If

        If Directory.Exists("\\" + hostname + "\C$\Xstoredb\backup") Then
            For Each f As String In Directory.GetFiles("\\" + hostname + "\C$\Xstoredb\backup", "*.zip")
                My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Deleting " + f, True)
                File.Delete(f)
            Next
        End If

        If Directory.Exists("\\" + hostname + "\C$\Xstoredb\backup") Then
            For Each f As String In Directory.GetFiles("\\" + hostname + "\C$\Xstoredb\backup", "*.zip.*")
                My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Deleting " + f, True)
                File.Delete(f)
            Next
        End If

        If Directory.Exists("\\" + hostname + "\C$\Temp") Then
            For Each f As String In Directory.GetFiles("\\" + hostname + "\C$\temp", "*.zip")
                My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Deleting " + f, True)
                File.Delete(f)
            Next
        End If
    End Sub

    Private Sub keystoreError()
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Unable to update keystore.", True)

        My.Computer.FileSystem.CopyFile(resourcepath + "\.truststore", "\\" + hostname + "\C$\xstore\res\ssl\.truststore", True)
        My.Computer.FileSystem.CopyFile(resourcepath + "\.keystore", "\\" + hostname + "\C$\environment\ui\res\ssl\.keystore", True)
        My.Computer.FileSystem.CopyFile(resourcepath + "\.keystore", "\\" + hostname + "\C$\xstore\res\ssl\.keystore", True)

    End Sub

    Private Sub noSpaceLeftError()
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "No space left on device.", True)

        If File.Exists("\\" + hostname + "\C$\environment\wwwroot\dbbackup\xstore.bak.gz") Then
            System.IO.File.Delete("\\" + hostname + "\C$\environment\wwwroot\dbbackup\xstore.bak.gz")
        End If
    End Sub

    Private Sub decompressingError()
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Processing of download files failed.", True)

        If File.Exists("\\" + hostname + "\C$\Xstoredb\backup\preupd.bak.gz") Then
            System.IO.File.Delete("\\" + hostname + "\C$\Xstoredb\backup\preupd.bak.gz")
        End If
    End Sub

    Private Sub downloadFailedError()
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Error decompressing file.", True)

        If Not Directory.Exists("\\" + hostname + "\C$\xstore\download\FailedMNT") Then
            System.IO.Directory.CreateDirectory("\\" + hostname + "\C$\xstore\download\FailedMNT")
        End If

        For Each f As String In Directory.GetFiles("\\" + hostname + "\C$\xstore\download\", "*.mnt")
            My.Computer.FileSystem.CopyFile(f, "\\" + hostname + "\C$\xstore\download\FailedMNT\Failed.mnt", True)
        Next

        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "==================================================" & Environment.NewLine, True)
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "==Please Notify POS Specialist That You Ran This==" & Environment.NewLine, True)
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "==================================================" & Environment.NewLine, True)

    End Sub

    Private Sub cyclicRedundancyError()
        Dim checkdisk As String = "/accepteula \\" & hostname & " -u " & username & " -p " & password & " chkdsk /f /r"
        Dim shutdown As String = "/accepteula \\" & hostname & " -u " & username & " -p " & password & " shutdown /r /f"

        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Cyclic Redundancy Error.", True)

        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Starting Check Disk.", True)
        Process.Start(command, checkdisk)
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Initiating Reboot.", True)
        Process.Start(command, shutdown)

        Environment.Exit(0)
    End Sub

    Public Sub checkPing()
        If pingresponse.Status = IPStatus.Success Then
            pingtext = "Reply from " & pingresponse.Address.ToString & ": BYTES=" & pingresponse.Buffer.Length & " TIME<" & pingresponse.RoundtripTime & "ms TTL=" & pingresponse.Options.Ttl
            My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "IP Adress:" + vbTab + pingresponse.Address.ToString, True)
            My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + Environment.NewLine + pingtext + Environment.NewLine, True)
            canping = True
        Else
            MsgBox("Ping Failed.")
            canping = False
        End If

    End Sub

    Private Sub checkErrorFile()
        If System.IO.File.Exists(errorpath) Then
            For Each line As String In File.ReadLines(errorpath)

                If line.Contains("execute-dataloader-trickle") Then
                    MsgBox("Trickle Error")
                    My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Trickle Error.", True)
                End If

                If line.Contains("build-pospoll") Then
                    MsgBox("Error 32 - Build POSPoll")
                    My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Error 32 - Build POSPoll Error.", True)
                End If

                If line.Contains("Error compressing file") And line.Contains("zip-db-backup-pre-upd") Then
                    MsgBox("Compression Error")
                    My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Compression Error.", True)
                End If

                If line.Contains("HTTPSConnectionPool") Then
                    MsgBox("HTTPS Connection Error")
                    My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "HTTPS Connection Error.", True)
                End If

                If line.Contains("401/Authorization Failed") Then
                    MsgBox("Authorization Error")
                    My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "401/Authorization Failed.", True)
                End If

                If line.Contains("ProcessDeployments") Then
                    MsgBox("Process Deployments Error")
                    My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Process Deployments Error.", True)
                End If

                If line.Contains("ALTER DATABASE is not permitted while a database is in the Restoring state") Then
                    MsgBox("Restore DB Error")
                    My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Restore DB Error.", True)
                End If

                If line.Contains("incorrectly formatted") Then
                    MsgBox("Incorrectly Formatted")
                    incorrectFormatError()
                End If

                If line.Contains("Not enough free space") Then
                    MsgBox("Not Enough Free Space")
                    noFreeSpaceError()
                End If

                If line.Contains("Unable to update keystore") Then
                    MsgBox("Unable to update keystore")
                    keystoreError()
                End If

                If line.Contains("No space left on device") Then
                    MsgBox("No space left on device")
                    noSpaceLeftError()
                End If

                If line.Contains("Error decompressing file") Then
                    MsgBox("Error decompressing file")
                    decompressingError()
                End If

                If line.Contains("Processing of download files failed") Then
                    MsgBox("Processing of download files failed")
                    downloadFailedError()
                End If

                If line.Contains("failed: 23") Then
                    MsgBox("Cyclic Redundancy Error")
                    cyclicRedundancyError()
                End If

            Next

            logoff()

        Else
            MsgBox("No Error File Found")
            My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "No Error File Found.", True)
        End If

    End Sub

    Private Sub logoff()
        Dim args As String = "/accepteula \\" & hostname & " -u " & username & " -p " & password & " -i \\" & hostname & "\C$\UTIL\LOGOUT.EXE"

        If My.Computer.FileSystem.FileExists(errorpath) Then
            My.Computer.FileSystem.CopyFile(errorpath, errorlog + "\" + hostname + Date.Now.ToString("MM-dd-yyyy") + ".err", True)
            My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Error File (" & errorpath & ") Copied to " & errorlog & ".", True)
        End If

        System.IO.File.Delete(errorpath)
        Process.Start(command, args)

        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Initiating Logoff.", True)

    End Sub

    Public Sub resetForm()
        copyLogFile()
        My.Forms.Mainform.Show()
    End Sub

    'runs close fail
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        setStore()
        Me.Hide()

        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "==========================================", True)
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "User:" + vbTab + vbTab + My.User.Name, True)
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Store #: " + vbTab + store, True)
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Time: " + vbTab + vbTab + timestamp, True)

        errorpath = "\\" + hostname + "\C$\environment\marker\close.err"

        Try
            pingresponse = newping.Send(hostname, 1000)
            checkPing()
            If canping Then
                checkErrorFile()
            End If

        Catch ex As System.Net.NetworkInformation.PingException
            pingtext = "Ping Failed"
            My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + Environment.NewLine + pingtext, True)
            MsgBox(pingtext)
        End Try

        copyLogFile()
        Me.Close()
    End Sub

    'opens PCform
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        setStore()
        My.Forms.PCform.Show()
        My.Forms.Mainform.Hide()
    End Sub

    'opens Printerform
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        setStore()
        My.Forms.Printerform.Show()
        My.Forms.Mainform.Hide()
    End Sub

    'opens Firewallform
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        setStore()
        My.Forms.Firewallform.Show()
        My.Forms.Mainform.Hide()
    End Sub

    'copies files for replacement
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        setStore()

        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "==========================================", True)
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "User:" + vbTab + vbTab + My.User.Name, True)
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Store #: " + vbTab + store, True)
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Time: " + vbTab + vbTab + timestamp, True)

        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "User selected: Replacement", True)
        Dim temploc As String = "\\" + hostname + "\C$\temp\lids"
        Dim replacementpath As String = "\\MRCH-3010-47444\C$\Share"

        If Not Directory.Exists(temploc) Then
            System.IO.Directory.CreateDirectory(temploc)
        End If

        My.Computer.FileSystem.CopyFile(replacementpath + "\replacement\Configurator-1.0.13.exe", "\\" + hostname + "\C$\temp\Configurator-1.0.13.exe", True)
        My.Computer.FileSystem.CopyFile(replacementpath + "\replacement\shenron.bat", "\\" + hostname + "\C$\temp\shenron.bat", True)
        My.Computer.FileSystem.CopyFile(replacementpath + "\lids\lids.bat", "\\" + hostname + "\C$\temp\lids\lids.bat", True)
        My.Computer.FileSystem.CopyFile(replacementpath + "\lids\lids1.sql", "\\" + hostname + "\C$\temp\lids\lids1.sql", True)
        My.Computer.FileSystem.CopyFile(replacementpath + "\lids\lids2.sql", "\\" + hostname + "\C$\temp\lids\lids2.sql", True)
        My.Computer.FileSystem.CopyFile(replacementpath + "\lids\lids3.sql", "\\" + hostname + "\C$\temp\lids\lids3.sql", True)

        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + Environment.NewLine + "Replacement Files Sent.", True)
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "C:\Temp = Configurator and Shenron.", True)
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "C:\Temp\Lids = Lids.bat and SQL files.", True)

        copyLogFile()
        Me.Close()
    End Sub

    'opens hidden form
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        setStore()
        My.Forms.PasswordForm.Show()
        My.Forms.Mainform.Hide()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        My.Forms.Contactform.Show()
        My.Forms.Mainform.Hide()
    End Sub
End Class