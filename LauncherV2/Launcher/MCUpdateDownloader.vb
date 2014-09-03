Imports System.Net
Imports System.IO
Imports Ionic.Zip

Public Class MCUpdateDownloader
    Dim versioninfo As String
    Dim timeLeftAverage As Double
    Dim timeLeft As TimeSpan
    Dim WithEvents WC As New WebClient
    Dim client As WebClient = New WebClient()
    Dim reader As StreamReader
    Dim newtext As String
    Dim selectedversion As String
    Dim SW As Stopwatch
    Dim statusoflbl As Integer

    Public Sub ReadtxtFile()
        Me.FetchDataFromServer_BGWorker.RunWorkerAsync()

    End Sub

    Private Sub cbversions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbversions.SelectedIndexChanged
        Try
            selectedversion = cbversions.SelectedItem.ToString
            VersionPicture.ImageLocation = "http://files.tagcraftnetwork.com/launcher/images/" + cbversions.SelectedItem.ToString + ".png"
            UpdateVersionBox_BGWorker.RunWorkerAsync()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbversions_MouseHover(sender As Object, e As EventArgs) Handles cbversions.MouseHover
        Try
            VersionPicture.ImageLocation = "http://files.tagcraftnetwork.com/launcher/images/" + cbversions.SelectedItem.ToString + ".png"

        Catch ex As Exception
            'unable to load the image
        End Try

    End Sub

    Private Sub btnstart_Click(sender As Object, e As EventArgs) Handles btnstart.Click
        Try
            WC.DownloadFileAsync(New Uri("http://files.tagcraftnetwork.com/launcher/minecraft/" + cbversions.SelectedItem.ToString + ".zip"), "MinecraftUpdate.zip")
            btnstart.Text = "Downloading"
            btnstart.Enabled = False
            btncancel.Enabled = True
            lblstatus.Text = "Processing Request"
            SW = Stopwatch.StartNew
        Catch ex As Exception
            MessageBox.Show("Please choose a verions you wish to download", "Errror: Version not selected")
        End Try

    End Sub

    Private Sub WC_DownloadProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs) Handles WC.DownloadProgressChanged
        lblstatus.Text = "Downloading"
        ProgressBar1.Value = e.ProgressPercentage

        lblpct.Text = e.ProgressPercentage.ToString + "%"
        lblsize.Text = (Convert.ToDouble(e.BytesReceived) / 1048576).ToString("0.00") & " MB" & "  /  " & (Convert.ToDouble(e.TotalBytesToReceive) / 1048576).ToString("0.00") & " MB"
        lblspeed.Text = (e.BytesReceived / SW.ElapsedMilliseconds).ToString("0.00") & " KB/s"

        timeLeftAverage = (SW.ElapsedMilliseconds / 1000 / e.BytesReceived)
        timeLeft = TimeSpan.FromSeconds(timeLeftAverage * (e.TotalBytesToReceive - e.BytesReceived))
        lbleta.Text = String.Format("{0:00}:{1:00}:{2:00}", timeLeft.TotalHours, timeLeft.Minutes, timeLeft.Seconds)

    End Sub

    Public Sub extractzipfile()
        Try
            Dim ZipToUnpack As String = "MinecraftUpdate.zip"
            Dim TargetDir As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/.minecraft/"
            Console.WriteLine("Extracting file {0} to {1}", ZipToUnpack, TargetDir)
            Using zip1 As ZipFile = ZipFile.Read(ZipToUnpack)
                Dim e As ZipEntry
                For Each e In zip1
                    e.Extract(TargetDir, ExtractExistingFileAction.OverwriteSilently)
                Next
                statusoflbl = 1
            End Using

        Catch ex As Exception

        End Try

    End Sub

    Public Sub RefreshMainMenuVersionSelector()
        MainMenu.VersionSelector.Items.Clear()

        Dim di As New DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/.minecraft/versions")
        For Each subdi As DirectoryInfo In di.GetDirectories
            MainMenu.VersionSelector.Items.Add(subdi.Name)
        Next

        MainMenu.VersionSelector.Text = SettingsReaderWriter.versionnumber

    End Sub

    Private Sub WC_DownloadCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles WC.DownloadFileCompleted
        If ProgressBar1.Value = 100 Then
            btnstart.Text = "Download and Install"
            btnstart.Enabled = True
            btncancel.Enabled = False
            lblspeed.Text = "0 KB/s"
            lblstatus.Text = "Download Finished"
            SW.Stop()
            ExtractZip_BGWorker.RunWorkerAsync()
            lblstatus.Text = "Installing"
        ElseIf lblstatus.Text = "Canceled" Then
            'nothing
        Else
            lblstatus.Text = "Failed"
            lblspeed.Text = "0 KB/s"
            btncancel.Enabled = False
            btnstart.Enabled = True
            SW.Stop()
        End If

    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        WC.CancelAsync()
        ProgressBar1.Value = 0
        lblpct.Text = "0%"
        lblsize.Text = "0 MB / 0 MB"
        lblstatus.Text = "Canceled"
        lblspeed.Text = "0 KB/s"
        lbleta.Text = "00:00:00"
        btncancel.Enabled = False
        btnstart.Enabled = True
        btnstart.Text = "Download and Install"
        SW.Stop()

    End Sub

    Private Sub MCUpdateDownloader_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            ReadtxtFile()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub FetchDataFromServer_BGWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles FetchDataFromServer_BGWorker.DoWork
        Try

            reader = New StreamReader(client.OpenRead("http://files.tagcraftnetwork.com/launcher/minecraftversions.html?t=" + DateTime.Now.ToLocalTime()))

        Catch ex As Exception

        End Try

    End Sub

    Private Sub FetchDataFromServer_BGWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles FetchDataFromServer_BGWorker.RunWorkerCompleted
        Try

            While (reader.Peek() > -1)
                cbversions.Enabled = True
                cbversions.Items.Add(reader.ReadLine)
                newtext = cbversions.Items.Item(0)
                cbversions.Text = newtext

            End While

            reader.Close()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ExtractZip_BGWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles ExtractZip_BGWorker.DoWork
        extractzipfile()

    End Sub

    Private Sub ExtractZip_BGWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles ExtractZip_BGWorker.RunWorkerCompleted
        If statusoflbl = 1 Then
            lblstatus.Text = "Install Finished"
        ElseIf statusoflbl = 0 Then
            lblstatus.Text = "Install Failed"
        End If

        RefreshMainMenuVersionSelector()

    End Sub

    Public Sub updateversioninfo()
        Dim client As WebClient = New WebClient()
        Try
            Dim URL As String = "http://files.tagcraftnetwork.com/launcher/info/" + selectedversion + ".html?t=" + DateTime.Now.ToLocalTime()
            versioninfo = client.DownloadString(URL).Replace("\red0\green0\blue0", "\red255\green255\blue255")

        Catch ex As Exception
            '
        End Try

    End Sub

    Private Sub UpdateVersionBox_BGWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles UpdateVersionBox_BGWorker.RunWorkerCompleted
        Try
            TransparentRichTextBox1.Rtf = versioninfo

        Catch ex As Exception
            '
        End Try

    End Sub

    Private Sub UpdateVersionBox_BGWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles UpdateVersionBox_BGWorker.DoWork
        updateversioninfo()

    End Sub
End Class