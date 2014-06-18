Module GameLoader

    Sub RunMineCraft()
        ' System.Diagnostics.Process.Start(Chr(34) + javapath + "\bin\javaw.exe" + Chr(34), "-jar " + MainMenu.Launch_jar)
        System.Diagnostics.Process.Start(MainMenu.Launch_exe)
        End

    End Sub
End Module