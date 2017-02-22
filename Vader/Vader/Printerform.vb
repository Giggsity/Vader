Imports System.IO

Public Class Printerform
    Public store As String = Mainform.store
    Public register As String = Mainform.register
    Public hostname As String = Mainform.hostname

    Public command As String = Mainform.command
    Dim cmd As New Process()
    Public username As String = Mainform.username
    Public password As String = Mainform.password

    Public resourcepath As String = Mainform.resourcepath

    Public filedir As String = Mainform.filedir
    Public fileloc As String = Mainform.fileloc
    Public logfile As String = Mainform.logfile
    Public timestamp As String = Mainform.timestamp

    Private Sub Printerform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "User selected: Printers", True)

    End Sub

    Private Sub PCform_formclosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            Mainform.resetForm()
        End If

    End Sub

    '401n driver
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim args As String = "/accepteula \\" & hostname & " -u " & username & " -p " & password & " -i \\" & hostname & "\C$\Temp\401PrintDriver.exe"

        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "User selected: 401n Driver", True)

        My.Computer.FileSystem.CopyFile(resourcepath + "\401PrintDriver.exe", "\\" & hostname & "\C$\Temp\401PrintDriver.exe", True)
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "401n Printer Driver copied to C\Temp.", True)

        cmd = Process.Start(command, args)
        cmd.WaitForExit()
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Printer driver installed.", True)

        My.Forms.Printerform.Close()

    End Sub

    '402 driver
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim args As String = "/accepteula \\" & hostname & " -u " & username & " -p " & password & " -i \\" & hostname & "\C$\Temp\402PrintDriver.exe"

        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "User selected: 402n Driver", True)

        My.Computer.FileSystem.CopyFile(resourcepath + "\402PrintDriver.exe", "\\" & hostname & "\C$\Temp\402PrintDriver.exe", True)
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "402n Printer Driver copied to C\Temp.", True)

        cmd = Process.Start(command, args)
        cmd.WaitForExit()
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Printer driver extracted.", True)
        MsgBox("Printer driver extracted. Please follow KB014 to finish installation.")

        My.Forms.Printerform.Close()
    End Sub

    'print spooler restart
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim args As String = "/accepteula \\" & hostname & " -u " & username & " -p " & password & " net stop spooler"

        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "User selected: Spooler Restart", True)

        cmd = Process.Start(command, args)
        cmd.WaitForExit()
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Print spooler stopped.", True)

        If Directory.Exists("\\" + hostname + "\C$\Windows\system32\spool\printers") Then
            For Each f As String In Directory.GetFiles("\\" + hostname + "\C$\Windows\system32\spool\printers", "*.*")
                My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Deleting " + f, True)
                File.Delete(f)
            Next
        End If

        args = "/accepteula \\" & hostname & " -u " & username & " -p " & password & " net start spooler"
        cmd = Process.Start(command, args)
        cmd.WaitForExit()
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Print spooler started.", True)

        'C:\pstools\psexec.exe /accepteula \\%hostname% -u sysadmin -p 9598me_XPV diskpart

        My.Forms.Printerform.Close()
    End Sub

    '401n printer firmware
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim args As String = "/accepteula \\" & hostname & " -u " & username & " -p " & password & " -i \\" & hostname & "\C$\Temp\M401Firmware.exe"

        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "User selected: 401n Printer Firmware", True)

        My.Computer.FileSystem.CopyFile(resourcepath + "\M401Firmware.exe", "\\" & hostname & "\C$\Temp\M401Firmware.exe", True)
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "401n Printer Firmware copied to C\Temp.", True)

        cmd = Process.Start(command, args)
        cmd.WaitForExit()
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "Printer firmware installed.", True)

        My.Forms.Printerform.Close()
    End Sub

    'uninstall 401n printer
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim args As String = "/accepteula \\" & hostname & " -u " & username & " -p " & password & " -i \\" & hostname & "printui.exe /dl /n HP LaserJet 400 M401 PCL 6"

        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "User selected: Uninstall 401n", True)

        cmd = Process.Start(command, args)
        cmd.WaitForExit()
        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "401n Printer Uninstalled.", True)

        My.Forms.Printerform.Close()
    End Sub

    'TM88 driver update
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim args As String = "/accepteula \\" & hostname & " -u " & username & " -p " & password & " -i \\" & hostname & "\C$\xstore\res\hardware\epson\32bit_windows\Setup.exe"

        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "User selected: TM88 Driver Update", True)

        cmd = Process.Start(command, args)
        cmd.WaitForExit()

        args = "/accepteula \\" & hostname & " -u " & username & " -p " & password & " -i msiexec.exe /x \\" & hostname & "\C$\xstore\res\hardware\epson\32bit_windows\PCS32.msi /qn"
        cmd = Process.Start(command, args)
        cmd.WaitForExit()

        args = "/accepteula \\" & hostname & " -u " & username & " -p " & password & " -i msiexec.exe /i \\" & hostname & "\C$\xstore\res\hardware\epson\32bit_windows\PCS32.msi /qn"
        cmd = Process.Start(command, args)
        cmd.WaitForExit()

        My.Computer.FileSystem.WriteAllText(fileloc, Environment.NewLine + "TM88 Driver Updated.", True)

        My.Forms.Printerform.Close()
    End Sub
End Class