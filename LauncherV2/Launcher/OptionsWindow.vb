Imports System.IO

Public Class OptionsWindow


    Public Sub fullbrightWriter()
        Dim line As String
        Try

            Dim reader As New StreamReader(MainMenu.options_txt)

            Dim a As String
            Dim b As String = ""


            Do
                a = reader.ReadLine
                Try
                    If a.Contains("gamma:") Then
                        b = a
                    End If
                Catch ex As Exception
                    'a is nothing now...
                End Try

            Loop Until a Is Nothing

            reader.Close()

            Using sr As New StreamReader(MainMenu.options_txt)
                line = sr.ReadToEnd()
            End Using

            If FullBright.Text = "Enabled" Then

                Dim objReader As New StreamWriter(MainMenu.options_txt)

                objReader.Write(line.Replace(b, "gamma:10.0"))
                objReader.Close()

            ElseIf FullBright.Text = "Disabled" Then
                Dim objReader As New StreamWriter(MainMenu.options_txt)

                objReader.Write(line.Replace(b, "gamma:0.0"))
                objReader.Close()


            End If


        Catch ex As Exception

        End Try
    End Sub

    Public Sub advitmtooltipWriter()
        Dim line As String
        Try

            Dim reader As New StreamReader(MainMenu.options_txt)

            Dim a As String
            Dim b As String = ""


            Do
                a = reader.ReadLine
                Try
                    If a.Contains("advancedItemTooltips:") Then
                        b = a
                    End If
                Catch ex As Exception
                    'a is nothing now...
                End Try

            Loop Until a Is Nothing

            reader.Close()

            Using sr As New StreamReader(MainMenu.options_txt)
                line = sr.ReadToEnd()
            End Using

            If AdvItmToolTips.Text = "Enabled" Then

                Dim objReader As New StreamWriter(MainMenu.options_txt)

                objReader.Write(line.Replace(b, "advancedItemTooltips:true"))
                objReader.Close()

            ElseIf AdvItmToolTips.Text = "Disabled" Then
                Dim objReader As New StreamWriter(MainMenu.options_txt)

                objReader.Write(line.Replace(b, "advancedItemTooltips:false"))
                objReader.Close()


            End If

        Catch ex As Exception

        End Try


    End Sub

    Public Sub helditemtooltipWriter()
        Dim line As String
        Try

            Dim reader As New StreamReader(MainMenu.options_txt)

            Dim a As String
            Dim b As String = ""


            Do
                a = reader.ReadLine
                Try
                    If a.Contains("heldItemTooltips:") Then
                        b = a
                    End If
                Catch ex As Exception
                    'a is nothing now...
                End Try

            Loop Until a Is Nothing

            reader.Close()

            Using sr As New StreamReader(MainMenu.options_txt)
                line = sr.ReadToEnd()
            End Using

            If HldItmToolTips.Text = "Enabled" Then

                Dim objReader As New StreamWriter(MainMenu.options_txt)

                objReader.Write(line.Replace(b, "heldItemTooltips:true"))
                objReader.Close()

            ElseIf HldItmToolTips.Text = "Disabled" Then
                Dim objReader As New StreamWriter(MainMenu.options_txt)

                objReader.Write(line.Replace(b, "heldItemTooltips:false"))
                objReader.Close()


            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub ReadMCOptions()
        Dim reader As New StreamReader(MainMenu.options_txt)

        Dim a As String

        Do
            a = reader.ReadLine

            Try
                If a = ("gamma:10.0") Then
                    FullBright.Text = "Enabled"

                Else
                    ' do nothing!
                End If
                If a = ("advancedItemTooltips:true") Then
                    AdvItmToolTips.Text = "Enabled"

                Else
                    ' do nothing!
                End If

                If a = ("heldItemTooltips:true") Then
                    HldItmToolTips.Text = "Enabled"

                Else
                    ' do nothing!
                End If


            Catch ex As Exception
                'a is nothing now...
            End Try

        Loop Until a Is Nothing

        reader.Close()

    End Sub

    Public Sub WriteMCOptions()
        fullbrightWriter()
        advitmtooltipWriter()
        helditemtooltipWriter()

    End Sub

    Public Sub ReadLauncherOptions()
        SettingsReaderWriter.getdebugmode()
        SettingsReaderWriter.getmemory()
        SettingsReaderWriter.getUUIDMode()
        SettingsReaderWriter.getUserDefinedUUID()


        If SettingsReaderWriter.debugmode = True Then
            DebugM.Text = "Enabled"
        End If
        If SettingsReaderWriter.debugmode = False Then
            DebugM.Text = "Disabled"
        End If

        Memory.Text = SettingsReaderWriter.memory

        If SettingsReaderWriter.UUIDMode = True Then
            UUIDStatusBox.Text = "Enabled"
        End If
        If SettingsReaderWriter.UUIDMode = False Then
            UUIDStatusBox.Text = "Disabled"
        End If

        UserD_UUID.Text = SettingsReaderWriter.UserDefinedUUID

    End Sub

    Public Sub WriteLauncherOptions()
        If DebugM.Text = "Enabled" Then
            SettingsReaderWriter.debugmode = True
        End If
        If DebugM.Text = "Disabled" Then
            SettingsReaderWriter.debugmode = False
        End If

        If UUIDStatusBox.Text = "Enabled" Then
            SettingsReaderWriter.UUIDMode = True
        End If
        If UUIDStatusBox.Text = "Disabled" Then
            SettingsReaderWriter.UUIDMode = False
        End If

        SettingsReaderWriter.UserDefinedUUID = UserD_UUID.Text
        SettingsReaderWriter.memory = Memory.Text
        SettingsReaderWriter.setdebugmode()
        SettingsReaderWriter.setUUIDMode()
        SettingsReaderWriter.setmemory()
        SettingsReaderWriter.setUserDefinedUUID()
        SettingsReaderWriter.SaveSettings()

    End Sub

    Public Sub DisableMemoryFor32Bit()
        If Environment.Is64BitOperatingSystem = True Then
            'dont do anything here.

        ElseIf Environment.Is64BitOperatingSystem = False Then
            Memory.Items.Remove("1536M")
            Memory.Items.Remove("2048M")
            Memory.Items.Remove("3072M")
            Memory.Items.Remove("4096M")
            Memory.Items.Remove("6144M")
            Memory.Items.Remove("5120M")
            Memory.Items.Remove("7168M")
            Memory.Items.Remove("8192M")
        End If
    End Sub

    Private Sub OptionsWindow_Load(sender As Object, e As EventArgs) Handles Me.Load
        AdvItmToolTips.Text = "Disabled"
        HldItmToolTips.Text = "Disabled"
        FullBright.Text = "Disabled"
        UUIDStatusBox.Text = "Disabled"
        UserD_UUID.Text = ""
        '----------------------------default values end--------------------------

        ReadLauncherOptions()
        Try
            ReadMCOptions()

        Catch ex As Exception
            MsgBox("Error reading options.")
        End Try
        DisableMemoryFor32Bit()

    End Sub

    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click
        WriteLauncherOptions()
        WriteMCOptions()
        Me.Dispose()

    End Sub

    Private Sub ExitOptions_Click(sender As Object, e As EventArgs) Handles ExitOptions.Click
        Me.Dispose()

    End Sub

    Private Sub RebuildOptions_Click(sender As Object, e As EventArgs) Handles RebuildOptions.Click
        Try
            SettingsReaderWriter.ResetSettings()
            MsgBox("Launcher closing... Please restart.")
            MainMenu.Dispose()

        Catch ex As Exception
            MsgBox(Environment.StackTrace)
        End Try

    End Sub

    Private Sub ShowCredits_Click(sender As Object, e As EventArgs) Handles ShowCredits.Click
        Credit.Show()

    End Sub

    '----------------------------------GUI Stuff Starts Here---------------------------------


    Private Sub ShowCredits_MouseEnter(sender As Object, e As EventArgs) Handles ShowCredits.MouseEnter
        ShowCredits.BackgroundImage = My.Resources.CreditsHover

    End Sub

    Private Sub ShowCredits_MouseLeave(sender As Object, e As EventArgs) Handles ShowCredits.MouseLeave
        ShowCredits.BackgroundImage = My.Resources.Credits

    End Sub

    Private Sub Save_MouseEnter(sender As Object, e As EventArgs) Handles Save.MouseEnter
        Save.BackgroundImage = My.Resources.SaveOptionsHover

    End Sub

    Private Sub Save_MouseLeave(sender As Object, e As EventArgs) Handles Save.MouseLeave
        Save.BackgroundImage = My.Resources.SaveOptions

    End Sub

    Private Sub ExitOptions_MouseEnter(sender As Object, e As EventArgs) Handles ExitOptions.MouseEnter
        ExitOptions.BackgroundImage = My.Resources.ExitHover

    End Sub

    Private Sub ExitOptions_MouseLeave(sender As Object, e As EventArgs) Handles ExitOptions.MouseLeave
        ExitOptions.BackgroundImage = My.Resources.Exit_

    End Sub
    Private Sub RebuildOptions_MouseEnter(sender As Object, e As EventArgs) Handles RebuildOptions.MouseEnter
        RebuildOptions.BackgroundImage = My.Resources.rebuildhover

    End Sub

    Private Sub RebuildOptions_MouseLeave(sender As Object, e As EventArgs) Handles RebuildOptions.MouseLeave
        RebuildOptions.BackgroundImage = My.Resources.rebuild

    End Sub
End Class