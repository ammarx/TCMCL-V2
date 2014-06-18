Imports System.IO

Public Class CrashReader
    Implements IComparer

    Public Shared ErrorStatus As Boolean = False
    Public Shared PathOfNewError As String = ""
    Public Shared OldError As String = ""

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
        Try
            Dim File1 As FileInfo
            Dim File2 As FileInfo

            File1 = DirectCast(x, FileInfo)
            File2 = DirectCast(y, FileInfo)

            Compare = DateTime.Compare(File1.LastWriteTime, File2.LastWriteTime)

            Return DateTime.Compare(DirectCast(x, IO.FileInfo).CreationTime, DirectCast(y, IO.FileInfo).CreationTime)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Sub CrashLogLookup()
        Try
            Dim dirinfo As DirectoryInfo
            Dim allFiles() As FileInfo
            Try
                SettingsReaderWriter.getlatestcrash()
                OldError = SettingsReaderWriter.latestcrash
            Catch ex As Exception

            End Try

            dirinfo = New DirectoryInfo((MainMenu.crashreportfolder))

            allFiles = dirinfo.GetFiles("*.txt")
            Array.Sort(allFiles, New CrashReader)
            For Each fl As FileInfo In allFiles
                fl.FullName.ToString()
                If Not fl.FullName.ToString() = vbNullString Then
                    PathOfNewError = fl.FullName.ToString()

                End If
            Next

            If OldError = PathOfNewError Then

            Else

                SettingsReaderWriter.latestcrash = PathOfNewError
                SettingsReaderWriter.setlatestcrash()
                SettingsReaderWriter.SaveSettings()

                If PathOfNewError = vbNullString Then
                    'Do nothing...
                Else
                    ErrorStatus = True
                End If

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub CrashReader_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim fileReader As System.IO.StreamReader
            fileReader = My.Computer.FileSystem.OpenTextFileReader(PathOfNewError)
            Dim stringReader As String
            stringReader = fileReader.ReadToEnd()

            TransparentRichTextBox1.Text = stringReader

            If stringReader.Contains("com.mojang.util.UUIDTypeAdapter.fromUUID") Then
                Tips.Text = "Tips: This error is thrown when an offline launcher such as this one trys to join a premuim server." + Environment.NewLine + "The only way to fix this is by purchasing Minecraft and using their launcher." + Environment.NewLine + "You can purchase Minecraft at www.minecraft.net/store"
            ElseIf stringReader.Contains("net.minecraftforge") Then
                Tips.Text = "Tips: This error is thrown when there is a problem with Forge Mod Loader or a Mod using Forge Mod Loader." + Environment.NewLine + "If you have multiple Mods in the .minecraft/mods folder try removing them one by one and starting up minecraft again, you might be able to find out what is causing it."
            ElseIf stringReader.Contains("tabbychat.core") Then
                Tips.Text = "Tips: This error is due to the Mod TabbyChat, if you're unable to start Minecraft just remove it."
            ElseIf stringReader.Contains("ResourceUtils.getResourcePackFile") Then
                Tips.Text = "Tips: This error is has to do with ResourcePacks, it has been known to happen when using a buggy or outdated optifine mod."

            Else
                Tips.Text = "Tips: No tips available."

            End If
        Catch ex As Exception
            TransparentRichTextBox1.Text = "Unable to get the latest logs, weird"

        End Try

    End Sub

    Private Sub Closebtn_Click(sender As Object, e As EventArgs) Handles Closebtn.Click
        Me.Dispose()

    End Sub

    Private Sub Closebtn_MouseEnter(sender As Object, e As EventArgs) Handles Closebtn.MouseEnter
        Closebtn.BackgroundImage = My.Resources.CloseHover

    End Sub

    Private Sub Closebtn_MouseLeave(sender As Object, e As EventArgs) Handles Closebtn.MouseLeave
        Closebtn.BackgroundImage = My.Resources.Close

    End Sub

End Class