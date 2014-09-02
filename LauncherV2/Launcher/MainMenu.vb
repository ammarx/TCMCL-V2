Imports System.IO

Public Class MainMenu
    Public Shared assetsDir As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/.minecraft/assets"
    Public Shared assetsDirLegacy As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/.minecraft/assets\virtual\legacy"
    Public Shared dot_minecraft As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/.minecraft/"

    Public Shared versionsfolder As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/.minecraft/versions"
    Public Shared options_txt As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/.minecraft/options.txt"
    Public Shared arguments_txt As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/.minecraft/TagCraftMC Files/Arguments/Arguments.txt"
    Public Shared arguments_launch_txt As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/.minecraft/TagCraftMC Files/Arguments/Arguments_launch.txt"
    Public Shared crashreportfolder As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/.minecraft/crash-reports"
    Public Shared Launch_jar As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + """/.minecraft/TagCraftMC Files/Arguments/Launch.jar"""
    Public Shared Launch_exe As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/.minecraft/TagCraftMC Files/Arguments/Launch.exe"

    Public Shared responseFromServer_For_UUID As String
    Public Shared XML_UUID As String

    Public Shared MojangUUID_API_URL As String = "https://api.mojang.com/profiles/minecraft"
    Public Shared clientversions_URL As String = "http://files.tagcraftmc.com/launcher/clientversions.html"
    Public Shared minecraftnews_URL As String = "http://files.tagcraftmc.com/launcher/minecraftnews.html"

    Public Shared Launcher_Version As String = "version 1.52"

    Public Sub PopulateVersionSelector()
        Dim di As New DirectoryInfo(versionsfolder)
        For Each subdi As DirectoryInfo In di.GetDirectories
            VersionSelector.Items.Add(subdi.Name)
        Next

    End Sub

    Public Sub CrashLabelVisibility()
        If CrashReader.ErrorStatus = True Then
            CrashLabel.Visible = True
        End If
    End Sub

    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.KeyPreview = True
        BGWorker_News.RunWorkerAsync()
        UpdateLauncher.BGWorker_LookupUpdate.RunWorkerAsync()

        OldFile.DeleteOnLoad()
        CrashReader.CrashLogLookup()
        CrashLabelVisibility()

        PopulateVersionSelector()

        SettingsReaderWriter.getusername()
        SettingsReaderWriter.getversionnumber()
        SettingsReaderWriter.getrememberaccount()
        SettingsReaderWriter.getmemory()
        SettingsReaderWriter.getruntimecatch()
        SettingsReaderWriter.getAccessToken()

        Username.Text = SettingsReaderWriter.username
        VersionSelector.Text = SettingsReaderWriter.versionnumber
        RememberMe.Checked = SettingsReaderWriter.rememberaccount

        Counter_Advert_Loader()

    End Sub

    Private Sub Launch_Click(sender As Object, e As EventArgs) Handles Launch.Click

        SettingsReaderWriter.getUUIDMode()
        ' UUID Mode is only in get mode because internet connection is required for further data.
        SettingsReaderWriter.username = Username.Text
        SettingsReaderWriter.versionnumber = VersionSelector.Text
        SettingsReaderWriter.rememberaccount = RememberMe.CheckState
        SettingsReaderWriter.runtimecatch = True

        SettingsReaderWriter.setusername()
        SettingsReaderWriter.setversionnumber()
        SettingsReaderWriter.setrememberaccount()
        SettingsReaderWriter.setruntimecatch()


        SettingsReaderWriter.SaveSettings()
        '----------------------------Start Minecraft-------------------------

        BGWorker_Launch.RunWorkerAsync()

    End Sub

    Private Sub Options_Click(sender As Object, e As EventArgs) Handles Options.Click
        OptionsWindow.Show()

    End Sub

    Private Sub Website_Click(sender As Object, e As EventArgs) Handles Website.Click
        System.Diagnostics.Process.Start("http://www.tagcraftmc.com/")

    End Sub

    Private Sub Help_Click(sender As Object, e As EventArgs) Handles Help.Click
        System.Diagnostics.Process.Start("http://www.tagcraftmc.com/launcherhelp")

    End Sub

    Private Sub ExitLauncher_Click(sender As Object, e As EventArgs) Handles ExitLauncher.Click
        End

    End Sub

    Private Sub BGWorker_Launch_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BGWorker_Launch.DoWork
        Try
            If SettingsReaderWriter.UUIDMode = False Then
                SettingsReaderWriter.UUID = "OFFLINE_MODE_UUID"
                SettingsReaderWriter.setUUID()

                SettingsReaderWriter.SaveSettings()

            End If
            If SettingsReaderWriter.UUIDMode = True Then
                UUIDLoader.GetUUIDFromServer()
                UUIDLoader.Convert_responseFromServer_For_UUID_To_XML()
                UUIDLoader.Get_UUID_From_XML()

                SettingsReaderWriter.setUUID()
                SettingsReaderWriter.SaveSettings()

            End If

        Catch ex As Exception
            SettingsReaderWriter.UUID = "OFFLINE_MODE_UUID"
            SettingsReaderWriter.setUUID()

            SettingsReaderWriter.SaveSettings()

        End Try
        TagAPIx.Class1.optionreader(SettingsReaderWriter.versionnumber)
        TagAPIx.Class1.main()
        TagAPIx.Class1.extractfile()
        Try
            FinalArgumentBuilder()
            WriteArgumentToText()
            ResourcesDownloader.ReadJsonForURL()
            
            
        Catch ex As Exception
            MsgBox(Environment.StackTrace)
        End Try

    End Sub

    Public Sub Counter_Advert_Loader()
        If SettingsReaderWriter.runtimecatch = False Then
            WebBrowser1.Navigate(New Uri("http://www.tagcraftmc.com/launcherhits"))
        ElseIf SettingsReaderWriter.runtimecatch = True Then
            WebBrowser1.Navigate(New Uri("http://www.tagcraftmc.com/launcherads"))
        End If

    End Sub

    '    Public Sub ReadArguments()
    '       Using sr As New StreamReader(arguments_txt + SettingsReaderWriter.versionnumber + ".txt")
    '          Arguments = sr.ReadToEnd()
    '     End Using
    '
    'End Sub

    Private Sub CrashLabel_Click(sender As Object, e As EventArgs) Handles CrashLabel.Click
        CrashReader.Show()

    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        Username.Cut()

    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        Username.Copy()

    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        Username.Paste()

    End Sub

    Private Sub BGWorker_News_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BGWorker_News.DoWork
        NewsLoader.newsupdate()

    End Sub

    Private Sub BGWorker_News_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BGWorker_News.RunWorkerCompleted
        If NewsLoader.UpdateNoNet = True Then
            TransparentRichTextBox2.Text = "Unable to get the news, sorry"
        Else
            TransparentRichTextBox2.Rtf = NewsLoader.UpdatesInfoResult
        End If

    End Sub

    Private Sub BGWorker_Launch_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BGWorker_Launch.RunWorkerCompleted
        If ResourcesDownloader.UrlStatus = True Then
            'download starts here...
            ResourcesDownloader.Show()
            Exit Sub

        Else

        End If

        RunMineCraft()

    End Sub

    Private Sub MCUpdates_Click(sender As Object, e As EventArgs) Handles MCUpdates.Click
        MCUpdateDownloader.Show()

    End Sub

  
End Class
