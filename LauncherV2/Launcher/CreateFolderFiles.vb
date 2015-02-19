Imports System.IO

Public Class CreateFolderFiles

    Public Shared Sub CreateTCMC_Folder()
        Dim di As DirectoryInfo = New DirectoryInfo(MainMenu.TCMC_FILES)
        Try
            If di.Exists Then
                'MsgBox("That path exists already.")
                Exit Sub
            Else
                di.Create()
                'MsgBox("The directory was created successfully.")
                Exit Sub
            End If

        Catch e As Exception
            MsgBox("The process failed: {0}", e.ToString())
        End Try
    End Sub

    Public Shared Sub CreateTCMC_Folder_Arguments()
        Dim di As DirectoryInfo = New DirectoryInfo(MainMenu.TCMC_FILES + "Arguments/")
        Try
            If di.Exists Then
                'MsgBox("That path exists already.")
                Exit Sub
            Else
                di.Create()
                'MsgBox("The directory was created successfully.")
                Exit Sub
            End If

        Catch e As Exception
            MsgBox("The process failed: {0}", e.ToString())
        End Try
    End Sub

    Public Shared Sub CreateTCMC_Folder_Arguments_logs()
        Dim di As DirectoryInfo = New DirectoryInfo(MainMenu.TCMC_FILES + "Arguments/logs/")
        Try
            If di.Exists Then
                'MsgBox("That path exists already.")
                Exit Sub
            Else
                di.Create()
                'MsgBox("The directory was created successfully.")
                Exit Sub
            End If

        Catch e As Exception
            MsgBox("The process failed: {0}", e.ToString())
        End Try
    End Sub

    Public Shared Sub CreateTCMC_Folder_Settings()
        Dim di As DirectoryInfo = New DirectoryInfo(MainMenu.TCMC_FILES + "Settings/")
        Try
            If di.Exists Then
                'MsgBox("That path exists already.")
                Exit Sub
            Else
                di.Create()
                'MsgBox("The directory was created successfully.")
                Exit Sub
            End If

        Catch e As Exception
            MsgBox("The process failed: {0}", e.ToString())
        End Try
    End Sub

    Public Shared Sub CreateTCMC_Folder_Settings_versions()
        Dim di As DirectoryInfo = New DirectoryInfo(MainMenu.TCMC_FILES + "Settings/versions/")
        Try
            If di.Exists Then
                'MsgBox("That path exists already.")
                Exit Sub
            Else
                di.Create()
                'MsgBox("The directory was created successfully.")
                Exit Sub
            End If

        Catch e As Exception
            MsgBox("The process failed: {0}", e.ToString())
        End Try
    End Sub

    Public Shared Sub CreateTCMC_File_Arguments()
        Dim file As System.IO.FileStream
        file = System.IO.File.Create(MainMenu.TCMC_FILES + "Arguments/Arguments.txt")

    End Sub

    Public Shared Sub CreateTCMC_File_Arguments_launch()
        Dim file As System.IO.FileStream
        file = System.IO.File.Create(MainMenu.TCMC_FILES + "Arguments/Arguments_launch.txt")

    End Sub

    Public Shared Sub CreateTCMC_File_Pre_Arguments()
        Dim file As System.IO.FileStream
        file = System.IO.File.Create(MainMenu.TCMC_FILES + "Arguments/Pre-Arguments.txt")

    End Sub

End Class
