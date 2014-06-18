Public Class SettingsReaderWriter
    Public Shared username As String
    Public Shared versionnumber As String
    Public Shared rememberaccount As Boolean
    Public Shared debugmode As Boolean
    Public Shared memorypass As Boolean
    Public Shared memory As String
    Public Shared tagoptions As Boolean
    Public Shared runtimecatch As Boolean
    Public Shared latestcrash As String
    Public Shared MojangUsername As String
    Public Shared MojangPassword As String
    Public Shared MojangName As String
    Public Shared UUID As String
    Public Shared AccessToken As String
    Public Shared UUIDMode As Boolean

    Public Shared Sub getusername()
        username = My.Settings.username

    End Sub

    Public Shared Sub setusername()
        My.Settings.username = username

    End Sub

    Public Shared Sub getversionnumber()
        versionnumber = My.Settings.versionnumber

    End Sub

    Public Shared Sub setversionnumber()
        My.Settings.versionnumber = versionnumber

    End Sub

    Public Shared Sub getrememberaccount()
        rememberaccount = My.Settings.rememberaccount

    End Sub

    Public Shared Sub setrememberaccount()
        My.Settings.rememberaccount = rememberaccount

    End Sub

    Public Shared Sub getdebugmode()
        debugmode = My.Settings.debugmode

    End Sub

    Public Shared Sub setdebugmode()
        My.Settings.debugmode = debugmode

    End Sub

    Public Shared Sub getmemorypass()
        memorypass = My.Settings.memorypass

    End Sub

    Public Shared Sub setmemorypass()
        My.Settings.memorypass = memorypass

    End Sub

    Public Shared Sub getmemory()
        memory = My.Settings.memory

    End Sub

    Public Shared Sub setmemory()
        My.Settings.memory = memory

    End Sub

    Public Shared Sub gettagoptions()
        tagoptions = My.Settings.tagoptions

    End Sub

    Public Shared Sub settagoptions()
        My.Settings.tagoptions = tagoptions

    End Sub

    Public Shared Sub getruntimecatch()
        runtimecatch = My.Settings.runtimecatch

    End Sub

    Public Shared Sub setruntimecatch()
        My.Settings.runtimecatch = runtimecatch

    End Sub

    Public Shared Sub getlatestcrash()
        latestcrash = My.Settings.latestcrash

    End Sub

    Public Shared Sub setlatestcrash()
        My.Settings.latestcrash = latestcrash

    End Sub

    Public Shared Sub getMojangUsername()
        MojangUsername = My.Settings.MojangUsername

    End Sub

    Public Shared Sub setMojangUsername()
        My.Settings.MojangUsername = MojangUsername

    End Sub

    Public Shared Sub getMojangPassword()
        MojangPassword = My.Settings.MojangPassword

    End Sub

    Public Shared Sub setMojangPassword()
        My.Settings.MojangPassword = MojangPassword

    End Sub

    Public Shared Sub getMojangName()
        MojangName = My.Settings.MojangName

    End Sub

    Public Shared Sub setMojangName()
        My.Settings.MojangName = MojangName

    End Sub

    Public Shared Sub getUUID()
        UUID = My.Settings.UUID

    End Sub

    Public Shared Sub setUUID()
        My.Settings.UUID = UUID

    End Sub

    Public Shared Sub getAccessToken()
        AccessToken = My.Settings.AccessToken

    End Sub

    Public Shared Sub setAccessToken()
        My.Settings.AccessToken = AccessToken

    End Sub

    Public Shared Sub getUUIDMode()
        UUIDMode = My.Settings.UUIDMode

    End Sub

    Public Shared Sub setUUIDMode()
        My.Settings.UUIDMode = UUIDMode

    End Sub

    Public Shared Sub SaveSettings()
        My.Settings.Save()
    End Sub

    Public Shared Sub ResetSettings()
        My.Settings.Reset()
    End Sub
End Class
