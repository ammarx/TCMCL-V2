<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OptionsWindow
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OptionsWindow))
        Me.FullBright = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Save = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ExitOptions = New System.Windows.Forms.Button()
        Me.OptionsToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.AdvItmToolTips = New System.Windows.Forms.ComboBox()
        Me.HldItmToolTips = New System.Windows.Forms.ComboBox()
        Me.DebugM = New System.Windows.Forms.ComboBox()
        Me.Memory = New System.Windows.Forms.ComboBox()
        Me.ShowCredits = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.UUIDStatusBox = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RebuildOptions = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'FullBright
        '
        Me.FullBright.AllowDrop = True
        Me.FullBright.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FullBright.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FullBright.FormattingEnabled = True
        Me.FullBright.Items.AddRange(New Object() {"Enabled", "Disabled"})
        Me.FullBright.Location = New System.Drawing.Point(308, 158)
        Me.FullBright.Name = "FullBright"
        Me.FullBright.Size = New System.Drawing.Size(94, 21)
        Me.FullBright.TabIndex = 0
        Me.OptionsToolTip.SetToolTip(Me.FullBright, "Allows you to enable Full bright.")
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Image = Global.Launcher.My.Resources.Resources.Fullbright
        Me.Label1.Location = New System.Drawing.Point(7, 162)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 17)
        Me.Label1.TabIndex = 1
        Me.OptionsToolTip.SetToolTip(Me.Label1, "Allows you to enable Full bright." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This options makes it easy to see in caves.")
        '
        'Save
        '
        Me.Save.BackColor = System.Drawing.Color.Transparent
        Me.Save.BackgroundImage = Global.Launcher.My.Resources.Resources.SaveOptions
        Me.Save.FlatAppearance.BorderSize = 0
        Me.Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Save.ForeColor = System.Drawing.Color.Transparent
        Me.Save.Location = New System.Drawing.Point(6, 415)
        Me.Save.Name = "Save"
        Me.Save.Size = New System.Drawing.Size(196, 40)
        Me.Save.TabIndex = 2
        Me.OptionsToolTip.SetToolTip(Me.Save, "Save any Options you have changed.")
        Me.Save.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Image = Global.Launcher.My.Resources.Resources.Memory
        Me.Label2.Location = New System.Drawing.Point(8, 189)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 17)
        Me.Label2.TabIndex = 4
        Me.OptionsToolTip.SetToolTip(Me.Label2, "Allows you to change how much memory you" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Allocate to Minecraft. Its good to incr" & _
        "ease this" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "if you're using mods such as Forge.")
        '
        'ExitOptions
        '
        Me.ExitOptions.BackColor = System.Drawing.Color.Transparent
        Me.ExitOptions.BackgroundImage = Global.Launcher.My.Resources.Resources.Exit_
        Me.ExitOptions.FlatAppearance.BorderSize = 0
        Me.ExitOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ExitOptions.ForeColor = System.Drawing.Color.Transparent
        Me.ExitOptions.Location = New System.Drawing.Point(212, 415)
        Me.ExitOptions.Name = "ExitOptions"
        Me.ExitOptions.Size = New System.Drawing.Size(196, 40)
        Me.ExitOptions.TabIndex = 10
        Me.OptionsToolTip.SetToolTip(Me.ExitOptions, "Exit the Options menu without saving any changes.")
        Me.ExitOptions.UseVisualStyleBackColor = False
        '
        'OptionsToolTip
        '
        Me.OptionsToolTip.BackColor = System.Drawing.Color.White
        Me.OptionsToolTip.ForeColor = System.Drawing.Color.Black
        '
        'AdvItmToolTips
        '
        Me.AdvItmToolTips.AllowDrop = True
        Me.AdvItmToolTips.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.AdvItmToolTips.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdvItmToolTips.FormattingEnabled = True
        Me.AdvItmToolTips.Items.AddRange(New Object() {"Enabled", "Disabled"})
        Me.AdvItmToolTips.Location = New System.Drawing.Point(308, 104)
        Me.AdvItmToolTips.Name = "AdvItmToolTips"
        Me.AdvItmToolTips.Size = New System.Drawing.Size(94, 21)
        Me.AdvItmToolTips.TabIndex = 16
        Me.OptionsToolTip.SetToolTip(Me.AdvItmToolTips, "Allows you to see all items ID's and damage values.")
        '
        'HldItmToolTips
        '
        Me.HldItmToolTips.AllowDrop = True
        Me.HldItmToolTips.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.HldItmToolTips.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HldItmToolTips.FormattingEnabled = True
        Me.HldItmToolTips.Items.AddRange(New Object() {"Enabled", "Disabled"})
        Me.HldItmToolTips.Location = New System.Drawing.Point(308, 131)
        Me.HldItmToolTips.Name = "HldItmToolTips"
        Me.HldItmToolTips.Size = New System.Drawing.Size(94, 21)
        Me.HldItmToolTips.TabIndex = 18
        Me.OptionsToolTip.SetToolTip(Me.HldItmToolTips, "Allows you to see held items ID's and damage values.")
        '
        'DebugM
        '
        Me.DebugM.AllowDrop = True
        Me.DebugM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DebugM.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DebugM.FormattingEnabled = True
        Me.DebugM.Items.AddRange(New Object() {"Enabled", "Disabled"})
        Me.DebugM.Location = New System.Drawing.Point(308, 239)
        Me.DebugM.Name = "DebugM"
        Me.DebugM.Size = New System.Drawing.Size(94, 21)
        Me.DebugM.TabIndex = 19
        Me.OptionsToolTip.SetToolTip(Me.DebugM, "Makes minecraft run in debug mode. This can help ")
        '
        'Memory
        '
        Me.Memory.AllowDrop = True
        Me.Memory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Memory.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Memory.FormattingEnabled = True
        Me.Memory.Items.AddRange(New Object() {"512M", "1024M", "1536M", "2048M", "3072M", "4096M", "6144M", "5120M", "7168M", "8192M"})
        Me.Memory.Location = New System.Drawing.Point(308, 185)
        Me.Memory.Name = "Memory"
        Me.Memory.Size = New System.Drawing.Size(94, 21)
        Me.Memory.TabIndex = 21
        Me.OptionsToolTip.SetToolTip(Me.Memory, "Allows you to change how much memory you")
        '
        'ShowCredits
        '
        Me.ShowCredits.BackgroundImage = Global.Launcher.My.Resources.Resources.Credits
        Me.ShowCredits.FlatAppearance.BorderSize = 0
        Me.ShowCredits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ShowCredits.Location = New System.Drawing.Point(109, 354)
        Me.ShowCredits.Name = "ShowCredits"
        Me.ShowCredits.Size = New System.Drawing.Size(196, 40)
        Me.ShowCredits.TabIndex = 13
        Me.OptionsToolTip.SetToolTip(Me.ShowCredits, "Brings up Credits and Thanks area.")
        Me.ShowCredits.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Image = Global.Launcher.My.Resources.Resources.Debug
        Me.Label5.Location = New System.Drawing.Point(2, 239)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 17)
        Me.Label5.TabIndex = 14
        Me.OptionsToolTip.SetToolTip(Me.Label5, "Makes minecraft run in debug mode. This can help " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "when looking for errors.")
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Image = Global.Launcher.My.Resources.Resources.AdvanceIT
        Me.Label4.Location = New System.Drawing.Point(2, 108)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(238, 17)
        Me.Label4.TabIndex = 15
        Me.OptionsToolTip.SetToolTip(Me.Label4, "Allows you to see all items ID's and damage values.")
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Image = Global.Launcher.My.Resources.Resources.HeldIT
        Me.Label6.Location = New System.Drawing.Point(2, 135)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(186, 17)
        Me.Label6.TabIndex = 17
        Me.OptionsToolTip.SetToolTip(Me.Label6, "Allows you to see held items ID's and damage values.")
        '
        'UUIDStatusBox
        '
        Me.UUIDStatusBox.AllowDrop = True
        Me.UUIDStatusBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.UUIDStatusBox.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UUIDStatusBox.FormattingEnabled = True
        Me.UUIDStatusBox.Items.AddRange(New Object() {"Enabled", "Disabled"})
        Me.UUIDStatusBox.Location = New System.Drawing.Point(308, 212)
        Me.UUIDStatusBox.Name = "UUIDStatusBox"
        Me.UUIDStatusBox.Size = New System.Drawing.Size(94, 21)
        Me.UUIDStatusBox.TabIndex = 24
        Me.OptionsToolTip.SetToolTip(Me.UUIDStatusBox, "Allows you to change how much memory you")
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Image = Global.Launcher.My.Resources.Resources.UUIDSkinMode
        Me.Label7.Location = New System.Drawing.Point(5, 212)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(147, 22)
        Me.Label7.TabIndex = 25
        Me.OptionsToolTip.SetToolTip(Me.Label7, "Should allow you to see your own skin." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Start up time will increase upto 5 second" & _
        "s.")
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Image = Global.Launcher.My.Resources.Resources.Options2
        Me.Label3.Location = New System.Drawing.Point(148, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 30)
        Me.Label3.TabIndex = 11
        '
        'RebuildOptions
        '
        Me.RebuildOptions.BackgroundImage = Global.Launcher.My.Resources.Resources.rebuild
        Me.RebuildOptions.FlatAppearance.BorderSize = 0
        Me.RebuildOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RebuildOptions.Location = New System.Drawing.Point(109, 311)
        Me.RebuildOptions.Name = "RebuildOptions"
        Me.RebuildOptions.Size = New System.Drawing.Size(196, 40)
        Me.RebuildOptions.TabIndex = 22
        Me.OptionsToolTip.SetToolTip(Me.RebuildOptions, "Allows you to rebuild broken Options")
        Me.RebuildOptions.UseVisualStyleBackColor = True
        '
        'OptionsWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BackgroundImage = Global.Launcher.My.Resources.Resources.OptionsArea
        Me.ClientSize = New System.Drawing.Size(414, 466)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.UUIDStatusBox)
        Me.Controls.Add(Me.RebuildOptions)
        Me.Controls.Add(Me.Memory)
        Me.Controls.Add(Me.DebugM)
        Me.Controls.Add(Me.HldItmToolTips)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.AdvItmToolTips)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ShowCredits)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.FullBright)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ExitOptions)
        Me.Controls.Add(Me.Save)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "OptionsWindow"
        Me.Text = "Minecraft Launcher Options"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FullBright As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Save As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ExitOptions As System.Windows.Forms.Button
    Friend WithEvents OptionsToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ShowCredits As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents AdvItmToolTips As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents HldItmToolTips As System.Windows.Forms.ComboBox
    Friend WithEvents DebugM As System.Windows.Forms.ComboBox
    Friend WithEvents Memory As System.Windows.Forms.ComboBox
    Friend WithEvents RebuildOptions As System.Windows.Forms.Button
    Friend WithEvents UUIDStatusBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
