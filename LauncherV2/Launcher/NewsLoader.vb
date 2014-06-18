Imports System.Net

Public Class NewsLoader

    Public Shared UpdateNoNet As Boolean
    Public Shared UpdatesInfoResult As String

    Public Shared Function InternetConnection() As Boolean
        Dim req As System.Net.WebRequest = System.Net.WebRequest.Create(MainMenu.clientversions_URL + "?t=" + DateTime.Now.ToLocalTime())
        Dim resp As System.Net.WebResponse
        Try
            req.Timeout = 5000
            resp = req.GetResponse()
            resp.Close()
            req = Nothing
            Return True
        Catch ex As Exception
            req = Nothing
            Return False
        End Try

    End Function

    Public Shared Sub newsupdate()
        Dim client As WebClient = New WebClient()
        If InternetConnection() = False Then
            UpdateNoNet = True

        Else
            Try
                Dim URL As String = MainMenu.minecraftnews_URL + "?t=" + DateTime.Now.ToLocalTime()
                UpdatesInfoResult = client.DownloadString(URL).Replace("\red0\green0\blue0", "\red255\green255\blue255")

            Catch ex As Exception
                '
            End Try
        End If

    End Sub
End Class
