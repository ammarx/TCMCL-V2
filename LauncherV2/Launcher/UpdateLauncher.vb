Imports System.Net
Imports Ionic.Zip

Public Class UpdateLauncher
    Dim changelogforupdates As String
    Dim timeLeftAverage As Double
    Dim timeLeft As TimeSpan
    Dim WithEvents WC As New WebClient
    Dim client As WebClient = New WebClient()
    Dim SW As Stopwatch
    Dim LauncherVersion As Boolean
    Dim Show_Window As Boolean = False

    Dim URL As String
    Dim result As String


    Private Sub UpdateLauncher_Load(sender As Object, e As EventArgs) Handles Me.Load
        Label2.Text = Me.Result
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        updatetext()
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Try
            TransparentRichTextBox1.Text = changelogforupdates

        Catch ex As Exception
            '
        End Try
    End Sub

    Public Sub updatetext()
        Dim client As WebClient = New WebClient()
        Try
            Dim URL As String = "http://files.tagcraftmc.com/launcher/clientversioninfo.html?t=" + DateTime.Now.ToLocalTime()
            changelogforupdates = client.DownloadString(URL).Replace("\red0\green0\blue0", "\red255\green255\blue255")

        Catch ex As Exception
            '
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            MainMenu.Enabled = False
            WC.DownloadFileAsync(New Uri("http://files.tagcraftmc.com/launcher/client/latest.zip"), "ClientUpdate.zip")
            ProgressBar1.Visible = True
            Button1.Enabled = False
            Button2.Enabled = False
            SW = Stopwatch.StartNew
        Catch ex As Exception

        End Try
    End Sub

    Private Sub WC_DownloadProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs) Handles WC.DownloadProgressChanged
        Label7.Text = "Update Status: Downloading"
        ProgressBar1.Value = e.ProgressPercentage

        'lblpct.Text = e.ProgressPercentage.ToString + "%"
        'lblsize.Text = (Convert.ToDouble(e.BytesReceived) / 1048576).ToString("0.00") & " MB" & "  /  " & (Convert.ToDouble(e.TotalBytesToReceive) / 1048576).ToString("0.00") & " MB"
        Label5.Text = "Speed: " & (e.BytesReceived / SW.ElapsedMilliseconds).ToString("0.00") & " KB/s"

        timeLeftAverage = (SW.ElapsedMilliseconds / 1000 / e.BytesReceived)
        timeLeft = TimeSpan.FromSeconds(timeLeftAverage * (e.TotalBytesToReceive - e.BytesReceived))
        Label6.Text = String.Format("ETA: {0:00}:{1:00}:{2:00}", timeLeft.TotalHours, timeLeft.Minutes, timeLeft.Seconds)
    End Sub

    Private Sub WC_DownloadCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles WC.DownloadFileCompleted
        If ProgressBar1.Value = 100 Then
            SW.Stop()
            'rename file
            Try
                My.Computer.FileSystem.RenameFile("launcher.exe", "launcher.old.exe")
                My.Computer.FileSystem.RenameFile("TagAPI.dll", "TagAPI.old.dll")
            Catch ex As Exception

            End Try
            'moved to background worker.
            BackgroundWorker2.RunWorkerAsync()

        Else

        End If

    End Sub

    Public Sub runlauncher()
        Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/.minecraft/launcher.exe")
    End Sub

    Public Sub extractzipfile()
        Try

            Dim ZipToUnpack As String = "ClientUpdate.zip"
            Dim TargetDir As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/.minecraft/"
            Console.WriteLine("Extracting file {0} to {1}", ZipToUnpack, TargetDir)
            Using zip1 As ZipFile = ZipFile.Read(ZipToUnpack)
                Dim e As ZipEntry
                For Each e In zip1
                    e.Extract(TargetDir, ExtractExistingFileAction.OverwriteSilently)
                Next
            End Using

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        extractzipfile()
    End Sub

    Private Sub BackgroundWorker2_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        Label7.Text = "Update Status: Completed"
        MsgBox("The Launcher will now restart for the update to take effect.", MsgBoxStyle.Exclamation, "Launcher Download Complete")
        runlauncher()
        End
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        TransparentRichTextBox1.Copy()
    End Sub

    Public Sub CheckUpdate()
        Dim client As WebClient = New WebClient()
        If InternetConnection() = False Then
            ' LauncherVersion = True

        Else
            Try
                URL = "http://files.tagcraftmc.com/launcher/clientversions.html?t=" + DateTime.Now.ToLocalTime()
                result = (LCase(client.DownloadString(URL)))
                'Debug.Print("DEBUG CHECK STRING DOWNLOAD: {0}", result)
                If (LCase(MainMenu.Launcher_Version) = result) Then 'lower case it all incase I am drunk and do VeRsIoN 9001
                    Show_Window = False

                    LauncherVersion = True
                    'Debug.Print("Worked")
                Else
                    Show_Window = True

                    LauncherVersion = False
                    'Debug.Print("Failed")
                End If

            Catch ex As Exception

                LauncherVersion = False
                'Debug.Print("Crash")

            End Try
        End If


    End Sub

    Private Function InternetConnection() As Boolean
        Dim req As System.Net.WebRequest = System.Net.WebRequest.Create("http://files.tagcraftmc.com/launcher/clientversions.html?t=" + DateTime.Now.ToLocalTime())
        Dim resp As System.Net.WebResponse
        Try
            resp = req.GetResponse()
            resp.Close()
            req = Nothing
            Return True
        Catch ex As Exception
            req = Nothing
            Return False
        End Try
    End Function

    Private Sub BGWorker_LookupUpdate_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BGWorker_LookupUpdate.DoWork
        CheckUpdate()
    End Sub

    Private Sub BGWorker_LookupUpdate_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BGWorker_LookupUpdate.RunWorkerCompleted
        If Show_Window = False Then

        End If

        If Show_Window = True Then
            Me.Show()
        End If

    End Sub
End Class