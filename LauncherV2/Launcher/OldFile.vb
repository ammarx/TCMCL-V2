Imports System.IO

Public Class OldFile
    Public Shared Sub DeleteOnLoad()
        Try
            File.Delete("launcher.old.exe")
        Catch ex As Exception

        End Try
        Try
            File.Delete("TagAPI.old.dll")
        Catch ex As Exception

        End Try
        Try
            File.Delete("ClientUpdate.zip")
        Catch ex As Exception

        End Try
        Try
            File.Delete("MinecraftUpdate.zip")
        Catch ex As Exception

        End Try

    End Sub
End Class
