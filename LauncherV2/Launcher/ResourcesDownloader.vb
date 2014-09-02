Imports System.IO
Imports System.Net

Public Class ResourcesDownloader

    Public Shared UrlStatus As Boolean = False
    Dim url As String
    Dim namex As String
    Dim split1 As Array
    Dim split2 As Array
    Dim variable As Array
    Dim counter As Integer = 0
    Dim syn As String

    Dim splitx As String
    Dim splity As String
    Dim splitfinal As String

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

    Private Sub DownloadR_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim reader As StreamReader = My.Computer.FileSystem.OpenTextFileReader(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/.minecraft/versions/" + MainMenu.VersionSelector.Text + "/" + MainMenu.VersionSelector.Text + ".json") ' .json file comes here...

        Dim a As String

        Do
            a = reader.ReadLine
            'MsgBox(a)
            '
            ' Code here
            Try

                If a.Contains("name") Then
                    namex = a
                    namex = namex.Replace(Chr(34), "")
                    namex = namex.Replace(",", "")
                    namex = namex.Replace("name: ", "")
                End If
                If a.Contains("url") Then
                    url = a
                    url = url.Replace(Chr(34), "")
                    url = url.Replace(",", "")
                    url = url.Replace("url: ", "")
                    ' MsgBox(namex)
                    splitonce()
                End If


            Catch ex As Exception

            End Try
            '
        Loop Until a Is Nothing

        reader.Close()

        'download files here...
        BackgroundWorker1.RunWorkerAsync()

    End Sub


    Public Sub splitonce()
        ' Dim tstString As String = "net.minecraftforge:forge:1.7.2-10.12.0.982"
        syn = ""
        counter = 0
        Dim LineOfText As String
        Dim i As Integer
        Dim aryTextFile() As String

        '        LineOfText = "net.minecraftforge:forge:1.7.2-10.12.0.982"
        LineOfText = namex


        aryTextFile = LineOfText.Split(":")

        For i = 0 To UBound(aryTextFile)

            If counter = 1 Then
                aryTextFile(i) = aryTextFile(i) + "/"

                '  MsgBox(aryTextFile(i))
                syn = syn + aryTextFile(i)

            End If

            If counter = 0 Then
                counter = 1
                If aryTextFile(i).Contains(".") Then
                    aryTextFile(i) = aryTextFile(i).Replace(".", "/") + "/"
                    syn = syn + aryTextFile(i)
                    counter = 1
                End If

            End If


        Next i
        splitagain()
        'MsgBox(syn)

    End Sub

    Public Sub splitagain()
        splitfinal = ""
        Dim LineOfText As String
        Dim i As Integer
        Dim aryTextFile() As String

        LineOfText = syn

        aryTextFile = LineOfText.Split("/")

        For i = 0 To UBound(aryTextFile)

            If i = aryTextFile.Length - 2 Then
                ' MsgBox(aryTextFile(i))
                splitx = aryTextFile(i)
            End If

            If i = aryTextFile.Length - 3 Then
                '                MsgBox(aryTextFile(i))
                splity = aryTextFile(i)

            End If
        Next i
        splitfinal = syn + splity + "-" + splitx + ".jar"
        url = url.Replace(" ", "")
        url = url.Replace("	", "")
        splitfinal = splitfinal.Replace(" ", "")
        splitfinal = splitfinal.Replace("	", "")
        'MsgBox(url + splitfinal)
        TextBox1.Text = TextBox1.Text + url + splitfinal + vbNewLine

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        For Each path As String In TextBox1.Lines
            Try
                My.Computer.Network.DownloadFile(path, Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/.minecraft/libraries/" + splitfinal)
                'WC.DownloadFileAsync(Uri, Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/.minecraft/libraries/" + splitfinal)

            Catch ex As Exception

            End Try
        Next
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        'create file so that it does not download next time...
        File.Create(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/.minecraft/versions/" + MainMenu.VersionSelector.Text + "/DownloadR.AMMAR").Dispose()
        RunMineCraft()
    End Sub

End Class