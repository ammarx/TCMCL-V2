Imports System.IO

Public Class MainMenu
    Public Shared assetsDir As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/.minecraft/assets"
    Public Shared assetsDirLegacy As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/.minecraft/assets\virtual\legacy"
    Public Shared dot_minecraft As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/.minecraft/"

    Public Shared versionsfolder As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/.minecraft/versions"
    Public Shared options_txt As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/.minecraft/options.txt"

    Public Shared pre_arguments_txt As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/.minecraft/TagCraftMC Files/Arguments/Pre-Arguments.txt"
    Public Shared arguments_txt As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/.minecraft/TagCraftMC Files/Arguments/Arguments.txt"
    Public Shared arguments_launch_txt As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/.minecraft/TagCraftMC Files/Arguments/Arguments_launch.txt"
    Public Shared crashreportfolder As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/.minecraft/crash-reports"
    'Public Shared Launch_jar As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + """/.minecraft/TagCraftMC Files/Arguments/Launch.jar"""
    Public Shared Launch_exe As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/.minecraft/TagCraftMC Files/Arguments/Launch.exe"
    Public Shared TCMC_FILES As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/.minecraft/TagCraftMC Files/"
    Public Shared Local_TagCraftMC As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/TagCraftMC/"

    Public Shared responseFromServer_For_UUID As String
    Public Shared XML_UUID As String
    Public Shared inheritsFrom As Boolean = False
    Public Shared inheritsFrom_Value As String

    Public Shared MojangUUID_API_URL As String = "https://api.mojang.com/profiles/minecraft"
    Public Shared clientversions_URL As String = "http://files.tagcraftnetwork.com/launcher/clientversions_new.html"
    Public Shared minecraftnews_URL As String = "http://files.tagcraftnetwork.com/launcher/minecraftnews.html"

    Public Shared Launcher_Version As String = "version 1.80"

    Public Sub PopulateVersionSelector()
        Try
            Dim di As New DirectoryInfo(versionsfolder)
            For Each subdi As DirectoryInfo In di.GetDirectories
                VersionSelector.Items.Add(subdi.Name)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub CrashLabelVisibility()
        If CrashReader.ErrorStatus = True Then
            CrashLabel.Visible = True
        End If
    End Sub

    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Me.Text = "Minecraft Launcher " + Launcher_Version.Replace("version ", "")

        Catch ex As Exception

        End Try
        
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


        VersionSelector.Text = SettingsReaderWriter.versionnumber
        RememberMe.Checked = SettingsReaderWriter.rememberaccount

        If RememberMe.Checked = True Then
            Username.Text = SettingsReaderWriter.username
        ElseIf RememberMe.Checked = False Then
            'dont show ma name..
        End If

        Counter_Advert_Loader()

        'Create folders... failsafe.
        CreateFolderFiles.CreateTCMC_Folder()
        CreateFolderFiles.CreateTCMC_Folder_Arguments()
        CreateFolderFiles.CreateTCMC_Folder_Arguments_logs()
        'CreateTCMC_Folder_Settings()
        'CreateTCMC_Folder_Settings_versions()
        CreateFolderFiles.CreateTCMC_File_Arguments()
        CreateFolderFiles.CreateTCMC_File_Arguments_launch()
        CreateFolderFiles.CreateTCMC_File_Pre_Arguments()

    End Sub

    Private Sub Username_KeyDown(sender As Object, e As KeyEventArgs) Handles Username.KeyDown
        If e.KeyCode = Keys.Enter Then
            Start_Launch()
        End If

    End Sub

    Public Sub Start_Launch()

        'Create folders... failsafe.
        CreateFolderFiles.CreateTCMC_Folder()
        CreateFolderFiles.CreateTCMC_Folder_Arguments()
        CreateFolderFiles.CreateTCMC_Folder_Arguments_logs()
        'CreateTCMC_Folder_Settings()
        'CreateTCMC_Folder_Settings_versions()
        CreateFolderFiles.CreateTCMC_File_Arguments()
        CreateFolderFiles.CreateTCMC_File_Arguments_launch()

        If Username.Text = "" Then
            MessageBox.Show("To launch Minecraft you must select a player name you wish to play with.", "Please select a Player Name", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If VersionSelector.SelectedItem = "" Then
            MessageBox.Show("To launch Minecraft you must select a version you wish to play.", "Please select a Minecraft Version", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Launch.Enabled = False
        Options.Enabled = False
        Website.Enabled = False
        Help.Enabled = False
        MCUpdates.Enabled = False
        Username.Enabled = False
        VersionSelector.Enabled = False

        SettingsReaderWriter.getUUIDMode()
        SettingsReaderWriter.getUserDefinedUUID()

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

    Private Sub Launch_Click(sender As Object, e As EventArgs) Handles Launch.Click
        Start_Launch()
       
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
            If (DateTime.Today.Day.ToString() = "1" And DateTime.Today.Month.ToString() = "1") Then
                SettingsReaderWriter.UUID = "4db1fbf4-30f3-4449-8dea-7663e108a1d2"
                SettingsReaderWriter.setUUID()

                SettingsReaderWriter.SaveSettings()

            Else

                If SettingsReaderWriter.UserDefinedUUID.Trim = vbNullString Then

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

                Else
                    SettingsReaderWriter.UUID = SettingsReaderWriter.UserDefinedUUID
                    SettingsReaderWriter.setUUID()

                    SettingsReaderWriter.SaveSettings()

                End If
            End If


        Catch ex As Exception
            SettingsReaderWriter.UUID = "OFFLINE_MODE_UUID"
            SettingsReaderWriter.setUUID()

            SettingsReaderWriter.SaveSettings()

        End Try
        inheritsFromCheck.getINHstatus()

        Dim oldversionnumber As String = SettingsReaderWriter.versionnumber
        Dim newversionnumber As String = ""

        If (inheritsFrom = False) Then
            TagAPIx.Class1.isItinh(False)
            TagAPIx.Class1.optionreader(SettingsReaderWriter.versionnumber)
            TagAPIx.Class1.main()
            TagAPIx.Class1.extractfile()
        End If

        If (inheritsFrom = True) Then
            SettingsReaderWriter.versionnumber = inheritsFrom_Value
            SettingsReaderWriter.SaveSettings()

            TagAPIx.Class1.isItinh(True)
            TagAPIx.Class1.optionreader(SettingsReaderWriter.versionnumber)
            TagAPIx.Class1.main()
            TagAPIx.Class1.extractfile()

            'recall this again to build regular arguments..
            newversionnumber = SettingsReaderWriter.versionnumber
            'MsgBox(newversionnumber.ToString)
            SettingsReaderWriter.versionnumber = oldversionnumber
            SettingsReaderWriter.SaveSettings()

            TagAPIx.Class1.isItinh(False)
            TagAPIx.Class1.optionreader(SettingsReaderWriter.versionnumber)
            TagAPIx.Class1.main()
            'TagAPIx.Class1.extractfile()
            ' make sure you copy the files to the correct location.
            Try
                My.Computer.FileSystem.CopyDirectory(MainMenu.versionsfolder + "\" + newversionnumber + "\" + newversionnumber + "_TagCraftMC", MainMenu.versionsfolder + "\" + SettingsReaderWriter.versionnumber + "\" + SettingsReaderWriter.versionnumber + "_TagCraftMC", True)

            Catch ex As Exception

            End Try
            
            ' after this copy text of both txt files together and we are good to go..


            Try
                'VbCrLf
                Dim line1 As String = ""
                Dim line2 As String = ""
                Dim linefinal As String = ""

                Using sr As StreamReader = File.OpenText(pre_arguments_txt)

                    line1 = sr.ReadLine()

                End Using


                Using sr As StreamReader = File.OpenText(arguments_txt)

                    line2 = sr.ReadLine()

                End Using

                Dim objWriter As New System.IO.StreamWriter(arguments_txt)

                objWriter.Write(line1 + line2)
                objWriter.Close()


            Catch ex As Exception

            End Try

        End If


        Try
            FinalArgumentBuilder()
            WriteArgumentToText()
            'ResourcesDownloader.ReadJsonForURL()
            'going to disable this... too much trouble.

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
        Try
            If NewsLoader.UpdateNoNet = True Then
                TransparentRichTextBox2.Text = "Unable to get the news, sorry"
            Else
                TransparentRichTextBox2.Rtf = NewsLoader.UpdatesInfoResult
            End If

        Catch ex As Exception
            TransparentRichTextBox2.Text = "Unable to get the news, sorry"

        End Try        
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
    Private Sub Options_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Options.MouseEnter

        Options.BackgroundImage = My.Resources.OptionsHover

    End Sub
    Private Sub Options_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Options.MouseLeave

        Options.BackgroundImage = My.Resources.Options

    End Sub
    Private Sub Help_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Help.MouseEnter

        Help.BackgroundImage = My.Resources.HelpandInfoHover

    End Sub
    Private Sub Help_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Help.MouseLeave

        Help.BackgroundImage = My.Resources.HelpandInfo

    End Sub
    Private Sub Website_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Website.MouseEnter

        Website.BackgroundImage = My.Resources.VisitHover

    End Sub
    Private Sub Website_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Website.MouseLeave

        Website.BackgroundImage = My.Resources.Visit

    End Sub
    Private Sub MCUpdates_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCUpdates.MouseEnter

        MCUpdates.BackgroundImage = My.Resources.MinecraftUpdatesHover

    End Sub
    Private Sub MCUpdates_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCUpdates.MouseLeave

        MCUpdates.BackgroundImage = My.Resources.MinecraftUpdates

    End Sub
    Private Sub ExitLauncher_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitLauncher.MouseEnter

        ExitLauncher.BackgroundImage = My.Resources.ExitHover

    End Sub
    Private Sub ExitLauncher_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitLauncher.MouseLeave

        ExitLauncher.BackgroundImage = My.Resources.Exit_

    End Sub
    Private Sub Launch_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Launch.MouseEnter

        Launch.BackgroundImage = My.Resources.LaunchHover

    End Sub
    Private Sub Launch_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Launch.MouseLeave

        Launch.BackgroundImage = My.Resources.Launch

    End Sub

    Private Sub Remember_Me_Label_Click(sender As Object, e As EventArgs) Handles Remember_Me_Label.Click
        If RememberMe.Checked = True Then
            RememberMe.Checked = False
        ElseIf RememberMe.Checked = False Then
            RememberMe.Checked = True

        End If

    End Sub
End Class
