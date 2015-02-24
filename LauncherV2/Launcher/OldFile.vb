Imports System.IO

Public Class OldFile
    Public Shared Sub DeleteOnLoad()
      
        'Try
        'File.Delete(MainMenu.dot_minecraft + "Ionic.Zip.old.dll")
        'Catch ex As Exception
        'End Try
        Try
            File.Delete(MainMenu.dot_minecraft + "Launcher.old.exe")
        Catch ex As Exception

        End Try
        Try
            File.Delete(MainMenu.dot_minecraft + "launcher.old.exe")
        Catch ex As Exception

        End Try
        'Try
        'File.Delete(MainMenu.dot_minecraft + "Newtonsoft.Json.old.dll")
        'Catch ex As Exception
        'End Try
        Try
            File.Delete(MainMenu.dot_minecraft + "TagAPI.old.dll")
        Catch ex As Exception

        End Try
        Try
            File.Delete(MainMenu.dot_minecraft + "Arguments\Launch.old.exe")
        Catch ex As Exception

        End Try
        Try
            File.Delete(MainMenu.dot_minecraft + "ClientUpdate.zip")
        Catch ex As Exception

        End Try
        Try
            File.Delete(MainMenu.dot_minecraft + "MinecraftUpdate.zip")
        Catch ex As Exception

        End Try

    End Sub
End Class
