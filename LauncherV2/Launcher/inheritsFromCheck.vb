Imports System.IO
Imports System.Text.RegularExpressions
Imports Newtonsoft.Json

Module inheritsFromCheck
    Public Sub getINHstatus()
        Dim inh As String = ""
        Dim jsonvalue As String
        Dim xmlvalue As String

        Dim sr As System.IO.StreamReader = New System.IO.StreamReader(MainMenu.versionsfolder + "\" + SettingsReaderWriter.versionnumber + "\" + SettingsReaderWriter.versionnumber + ".json")
        'convert json to xml

        Dim reader As New StreamReader(MainMenu.versionsfolder + "\" + SettingsReaderWriter.versionnumber + "\" + SettingsReaderWriter.versionnumber + ".json")
        jsonvalue = reader.ReadToEnd()

        reader.Close()

        Dim node As XNode = JsonConvert.DeserializeXNode(jsonvalue, "Root")

        xmlvalue = node.ToString()

        Dim sourcecode As String = sr.ReadToEnd()
        sourcecode = xmlvalue
        Dim reg = New Regex("<inheritsFrom>(.*?)</inheritsFrom>")

        Dim s As String = ""
        Dim matches = reg.Matches(sourcecode)

        For Each mat As Match In matches
            s = mat.Value

            inh = s
            s = s.Replace("<inheritsFrom>", "")
            s = s.Replace("</inheritsFrom>", "")
            s = s.Trim

        Next mat

        If (s.Length < 1) Then
            'no inheritsFrom is here.. 
            MainMenu.inheritsFrom = False

        Else
            'inheritsfrom is here..
            MainMenu.inheritsFrom = True
            MainMenu.inheritsFrom_Value = s
            ' MsgBox(s)

        End If
        
    End Sub
End Module
