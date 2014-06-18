Imports System.IO
Imports System.Net

Public Class ResourcesDownloader

    Public Shared UrlStatus As Boolean = False

    Public Shared Sub ReadJsonForURL()
        Dim reader As New StreamReader(MainMenu.versionsfolder + "/" + SettingsReaderWriter.versionnumber + "/" + SettingsReaderWriter.versionnumber + ".json")

        Dim a As String

        Do
            a = reader.ReadLine

            Try
                If a.Contains("url") Then
                    UrlStatus = True
                    Exit Sub
                Else
                    ' do nothing!
                End If

            Catch ex As Exception

            End Try

        Loop Until a Is Nothing

        reader.Close()

    End Sub

End Class