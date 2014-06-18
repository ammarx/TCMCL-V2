Imports System.Net
Imports System.Text
Imports System.IO
Imports Newtonsoft.Json

Public Class UUIDLoader
    Public Shared Sub GetUUIDFromServer()

        Dim request As WebRequest = WebRequest.Create(MainMenu.MojangUUID_API_URL)

        request.Method = "POST"

        Dim postData As String = "[""" + SettingsReaderWriter.username + """]"
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
        request.ContentType = "application/json"
        request.ContentLength = byteArray.Length
        request.Timeout = 2500
        Dim dataStream As Stream = request.GetRequestStream()
        dataStream.Write(byteArray, 0, byteArray.Length)
        dataStream.Close()
        Dim response As WebResponse = request.GetResponse()

        dataStream = response.GetResponseStream()
        Dim reader As New StreamReader(dataStream)
        MainMenu.responseFromServer_For_UUID = reader.ReadToEnd()

        reader.Close()
        dataStream.Close()
        response.Close()

    End Sub

    Public Shared Sub Convert_responseFromServer_For_UUID_To_XML()
        MainMenu.responseFromServer_For_UUID = MainMenu.responseFromServer_For_UUID.Replace("[", "")
        MainMenu.responseFromServer_For_UUID = MainMenu.responseFromServer_For_UUID.Replace("]", "")

        Dim node As XNode = JsonConvert.DeserializeXNode(MainMenu.responseFromServer_For_UUID, "Root")

        MainMenu.XML_UUID = node.ToString()

    End Sub

    Public Shared Sub Get_UUID_From_XML()
        Dim aLine As String
        Dim strReader As New StringReader(MainMenu.XML_UUID)

        While True
            aLine = strReader.ReadLine()
            If aLine Is Nothing Then

                Exit While
            Else
                If aLine.Contains("<id>") Then
                    aLine = aLine.Replace("<id>", "")
                    aLine = aLine.Replace("</id>", "")
                    aLine = aLine.Replace(" ", "")
                    SettingsReaderWriter.UUID = aLine

                    Exit While
                End If
            End If
        End While

    End Sub
End Class
