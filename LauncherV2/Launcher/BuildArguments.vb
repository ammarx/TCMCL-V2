Imports System.IO
Imports Newtonsoft.Json
Imports System.Text.RegularExpressions

Module BuildArguments
    Dim libraries As String = ""
    Dim minecraftArgumentsFinal As String = ""
    Dim mainClassFinal As String = ""
    Dim assetsFinal As String = ""

    Dim minecraftArguments As String = ""
    Dim xmlvalue As String
    Dim jsonvalue As String

    
    Public Sub FinalArgumentBuilder()
        LoadJsonArguments()

        Dim objReader As New System.IO.StreamReader(MainMenu.arguments_txt)

        libraries = objReader.ReadLine()
        libraries = libraries.Replace(Chr(34), "")

        minecraftArgumentsFinal = ("java" + vbNewLine + "-XX:HeapDumpPath=MojangTricksIntelDriversForPerformance_javaw.exe_minecraft.exe.heapdump" + vbNewLine + "-Xmx" + SettingsReaderWriter.memory + vbNewLine + "-Djava.library.path=" + MainMenu.versionsfolder + "/" + SettingsReaderWriter.versionnumber + "/" + SettingsReaderWriter.versionnumber + "_TagCraftMC" + vbNewLine + "-cp" + vbNewLine + libraries + MainMenu.versionsfolder + "/" + SettingsReaderWriter.versionnumber + "/" + SettingsReaderWriter.versionnumber + ".jar" + vbNewLine + mainClassFinal + vbNewLine + minecraftArgumentsFinal)
        minecraftArgumentsFinal = minecraftArgumentsFinal.Replace("${auth_player_name}", SettingsReaderWriter.username)
        minecraftArgumentsFinal = minecraftArgumentsFinal.Replace("${version_name}", SettingsReaderWriter.versionnumber)
        minecraftArgumentsFinal = minecraftArgumentsFinal.Replace("${game_directory}", MainMenu.dot_minecraft)

        If assetsFinal = "" Then
            minecraftArgumentsFinal = minecraftArgumentsFinal.Replace("${assets_root}", MainMenu.assetsDirLegacy)
            minecraftArgumentsFinal = minecraftArgumentsFinal.Replace("${game_assets}", MainMenu.assetsDirLegacy)

        Else
            minecraftArgumentsFinal = minecraftArgumentsFinal.Replace("${assets_root}", MainMenu.assetsDir)
            minecraftArgumentsFinal = minecraftArgumentsFinal.Replace("${assets_index_name}", assetsFinal)

        End If

        minecraftArgumentsFinal = minecraftArgumentsFinal.Replace("${auth_uuid}", SettingsReaderWriter.UUID)
        minecraftArgumentsFinal = minecraftArgumentsFinal.Replace("${auth_access_token}", SettingsReaderWriter.AccessToken)
        minecraftArgumentsFinal = minecraftArgumentsFinal.Replace("${user_properties}", "{}")
        minecraftArgumentsFinal = minecraftArgumentsFinal.Replace("${user_type}", "{}")


        ' MsgBox(minecraftArgumentsFinal)
        ' MsgBox(assetsFinal)
    End Sub

    Public Sub WriteArgumentToText()
        Dim path As String = MainMenu.arguments_launch_txt

            Dim createText As String = minecraftArgumentsFinal
            File.WriteAllText(path, createText)

    End Sub

    Public Sub LoadJsonArguments()

        Dim reader As New StreamReader(MainMenu.versionsfolder + "/" + SettingsReaderWriter.versionnumber + "/" + SettingsReaderWriter.versionnumber + ".json")
        jsonvalue = reader.ReadToEnd()

        reader.Close()

        Dim node As XNode = JsonConvert.DeserializeXNode(jsonvalue, "Root")

        xmlvalue = node.ToString()
        ' TextBox1.Text = xmlvalue


        mcArguments()
        mainClass()
        assets()

        minecraftArguments = LTrim(minecraftArguments)
        minecraftArguments = RTrim(minecraftArguments)

        mainClassFinal = LTrim(mainClassFinal)
        mainClassFinal = RTrim(mainClassFinal)

        assetsFinal = LTrim(assetsFinal)
        assetsFinal = RTrim(assetsFinal)

        Dim s As String

        Dim arr As String() = SplitWords(minecraftArguments)

        For Each s In arr
            minecraftArgumentsFinal = minecraftArgumentsFinal + s + vbNewLine

        Next
        Console.ReadLine()
    End Sub



    Private Function SplitWords(ByVal s As String) As String()
        '
        ' Call Regex.Split function from the imported namespace.
        ' Return the result array.
        '
        Return Regex.Split(s, " ")

    End Function

    Public Sub mcArguments()
        Dim aLine As String
        Dim strReader As New StringReader(xmlvalue)
        While True
            aLine = strReader.ReadLine()
            If aLine Is Nothing Then

                Exit While
            Else
                If aLine.Contains("<minecraftArguments>") Then
                    aLine = aLine.Replace("<minecraftArguments>", "")
                    aLine = aLine.Replace("</minecraftArguments>", "")
                    'aLine = aLine.Replace(" ", "")

                    minecraftArguments = aLine
                    ' Exit While
                End If
            End If
        End While
    End Sub

    Public Sub mainClass()
        Dim aLine As String
        Dim strReader As New StringReader(xmlvalue)
        While True
            aLine = strReader.ReadLine()
            If aLine Is Nothing Then

                Exit While
            Else
                If aLine.Contains("<mainClass>") Then
                    aLine = aLine.Replace("<mainClass>", "")
                    aLine = aLine.Replace("</mainClass>", "")
                    'aLine = aLine.Replace(" ", "")

                    mainClassFinal = aLine
                    ' Exit While
                End If
            End If
        End While
    End Sub


    Public Sub assets()
        Dim aLine As String
        Dim strReader As New StringReader(xmlvalue)
        While True
            aLine = strReader.ReadLine()
            If aLine Is Nothing Then

                Exit While
            Else
                If aLine.Contains("<assets>") Then
                    aLine = aLine.Replace("<assets>", "")
                    aLine = aLine.Replace("</assets>", "")
                    'aLine = aLine.Replace(" ", "")

                    assetsFinal = aLine
                    ' Exit While
                End If
            End If
        End While
    End Sub
End Module
