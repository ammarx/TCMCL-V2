<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainMenu))
        Me.Launch = New System.Windows.Forms.Button()
        Me.Username = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Options = New System.Windows.Forms.Button()
        Me.ExitLauncher = New System.Windows.Forms.Button()
        Me.Help = New System.Windows.Forms.Button()
        Me.LauncherToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Website = New System.Windows.Forms.Button()
        Me.VersionSelector = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.MCUpdates = New System.Windows.Forms.Button()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RememberMe = New System.Windows.Forms.CheckBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CrashLabel = New System.Windows.Forms.Label()
        Me.BGWorker_Launch = New System.ComponentModel.BackgroundWorker()
        Me.BGWorker_News = New System.ComponentModel.BackgroundWorker()
        Me.TransparentRichTextBox2 = New Launcher.TransparentRichTextBox()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Launch
        '
        Me.Launch.BackColor = System.Drawing.Color.Transparent
        Me.Launch.BackgroundImage = Global.Launcher.My.Resources.Resources.Launch
        Me.Launch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Launch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Launch.Location = New System.Drawing.Point(294, 449)
        Me.Launch.Name = "Launch"
        Me.Launch.Size = New System.Drawing.Size(196, 40)
        Me.Launch.TabIndex = 0
        Me.LauncherToolTip.SetToolTip(Me.Launch, "Start Minecraft")
        Me.Launch.UseVisualStyleBackColor = False
        '
        'Username
        '
        Me.Username.BackColor = System.Drawing.Color.Black
        Me.Username.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Username.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Username.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Username.ForeColor = System.Drawing.Color.White
        Me.Username.Location = New System.Drawing.Point(304, 281)
        Me.Username.MaxLength = 16
        Me.Username.Name = "Username"
        Me.Username.Size = New System.Drawing.Size(176, 22)
        Me.Username.TabIndex = 1
        Me.LauncherToolTip.SetToolTip(Me.Username, "Choose a player name.")
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CutToolStripMenuItem, Me.CopyToolStripMenuItem, Me.PasteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ContextMenuStrip1.ShowImageMargin = False
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(78, 70)
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(77, 22)
        Me.CutToolStripMenuItem.Text = "Cut"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(77, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(77, 22)
        Me.PasteToolStripMenuItem.Text = "Paste"
        '
        'Options
        '
        Me.Options.BackColor = System.Drawing.Color.Transparent
        Me.Options.BackgroundImage = Global.Launcher.My.Resources.Resources.Options
        Me.Options.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Options.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Options.Location = New System.Drawing.Point(28, 265)
        Me.Options.Name = "Options"
        Me.Options.Size = New System.Drawing.Size(196, 40)
        Me.Options.TabIndex = 2
        Me.LauncherToolTip.SetToolTip(Me.Options, "Options for the following" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "In game tooltips." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Full Bright." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Memory Allocation." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "D" & _
        "ebug Mode.")
        Me.Options.UseVisualStyleBackColor = False
        '
        'ExitLauncher
        '
        Me.ExitLauncher.BackColor = System.Drawing.Color.Transparent
        Me.ExitLauncher.BackgroundImage = Global.Launcher.My.Resources.Resources.Exit_
        Me.ExitLauncher.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ExitLauncher.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ExitLauncher.Location = New System.Drawing.Point(28, 449)
        Me.ExitLauncher.Name = "ExitLauncher"
        Me.ExitLauncher.Size = New System.Drawing.Size(196, 40)
        Me.ExitLauncher.TabIndex = 4
        Me.LauncherToolTip.SetToolTip(Me.ExitLauncher, "Exit the launcher.")
        Me.ExitLauncher.UseVisualStyleBackColor = False
        '
        'Help
        '
        Me.Help.BackColor = System.Drawing.Color.Transparent
        Me.Help.BackgroundImage = Global.Launcher.My.Resources.Resources.HelpandInfo
        Me.Help.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Help.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Help.Location = New System.Drawing.Point(28, 357)
        Me.Help.Name = "Help"
        Me.Help.Size = New System.Drawing.Size(196, 40)
        Me.Help.TabIndex = 3
        Me.LauncherToolTip.SetToolTip(Me.Help, "Learn about the launcher." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Help about the launder.")
        Me.Help.UseVisualStyleBackColor = False
        '
        'LauncherToolTip
        '
        Me.LauncherToolTip.BackColor = System.Drawing.Color.White
        Me.LauncherToolTip.ForeColor = System.Drawing.Color.Black
        '
        'Website
        '
        Me.Website.BackColor = System.Drawing.Color.Transparent
        Me.Website.BackgroundImage = Global.Launcher.My.Resources.Resources.Visit
        Me.Website.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Website.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Website.Location = New System.Drawing.Point(28, 311)
        Me.Website.Name = "Website"
        Me.Website.Size = New System.Drawing.Size(196, 40)
        Me.Website.TabIndex = 14
        Me.LauncherToolTip.SetToolTip(Me.Website, "Visit our website.")
        Me.Website.UseVisualStyleBackColor = False
        '
        'VersionSelector
        '
        Me.VersionSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.VersionSelector.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VersionSelector.FormattingEnabled = True
        Me.VersionSelector.Location = New System.Drawing.Point(301, 342)
        Me.VersionSelector.Name = "VersionSelector"
        Me.VersionSelector.Size = New System.Drawing.Size(182, 21)
        Me.VersionSelector.TabIndex = 24
        Me.LauncherToolTip.SetToolTip(Me.VersionSelector, "Choose a version to run.")
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Image = Global.Launcher.My.Resources.Resources.RememberName
        Me.Label7.Location = New System.Drawing.Point(283, 375)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(207, 17)
        Me.Label7.TabIndex = 26
        Me.LauncherToolTip.SetToolTip(Me.Label7, "Remember your player name.")
        '
        'MCUpdates
        '
        Me.MCUpdates.BackColor = System.Drawing.Color.Transparent
        Me.MCUpdates.BackgroundImage = Global.Launcher.My.Resources.Resources.MinecraftUpdates
        Me.MCUpdates.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.MCUpdates.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.MCUpdates.Location = New System.Drawing.Point(28, 403)
        Me.MCUpdates.Name = "MCUpdates"
        Me.MCUpdates.Size = New System.Drawing.Size(196, 40)
        Me.MCUpdates.TabIndex = 29
        Me.LauncherToolTip.SetToolTip(Me.MCUpdates, "Update Minecraft." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Download and install major Minecraft" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "updates from our cloud s" & _
        "erver automatically." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "You're also able to install Minecraft Version" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "that come w" & _
        "ith pre-installed mods.")
        Me.MCUpdates.UseVisualStyleBackColor = False
        '
        'WebBrowser1
        '
        Me.WebBrowser1.IsWebBrowserContextMenuEnabled = False
        Me.WebBrowser1.Location = New System.Drawing.Point(759, 5)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.ScriptErrorsSuppressed = True
        Me.WebBrowser1.ScrollBarsEnabled = False
        Me.WebBrowser1.Size = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.TabIndex = 11
        Me.WebBrowser1.Url = New System.Uri("", System.UriKind.Relative)
        Me.WebBrowser1.Visible = False
        Me.WebBrowser1.WebBrowserShortcutsEnabled = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Launcher.My.Resources.Resources.TextBG2
        Me.PictureBox1.Location = New System.Drawing.Point(294, 272)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(196, 40)
        Me.PictureBox1.TabIndex = 15
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Launcher.My.Resources.Resources.TextBG2
        Me.PictureBox2.Location = New System.Drawing.Point(294, 332)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(196, 40)
        Me.PictureBox2.TabIndex = 16
        Me.PictureBox2.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Image = Global.Launcher.My.Resources.Resources.MinecraftPlayerName
        Me.Label1.Location = New System.Drawing.Point(273, 254)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(237, 17)
        Me.Label1.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Image = Global.Launcher.My.Resources.Resources.MinecraftVersion
        Me.Label2.Location = New System.Drawing.Point(273, 314)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(237, 17)
        Me.Label2.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Image = Global.Launcher.My.Resources.Resources.CopyrightMojang2014
        Me.Label3.Location = New System.Drawing.Point(140, 544)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(501, 17)
        Me.Label3.TabIndex = 19
        '
        'RememberMe
        '
        Me.RememberMe.AutoSize = True
        Me.RememberMe.BackColor = System.Drawing.Color.Transparent
        Me.RememberMe.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.RememberMe.ForeColor = System.Drawing.Color.White
        Me.RememberMe.Location = New System.Drawing.Point(294, 377)
        Me.RememberMe.Name = "RememberMe"
        Me.RememberMe.Size = New System.Drawing.Size(15, 14)
        Me.RememberMe.TabIndex = 20
        Me.RememberMe.UseVisualStyleBackColor = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = Global.Launcher.My.Resources.Resources.Logo
        Me.PictureBox3.Location = New System.Drawing.Point(28, 51)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(724, 136)
        Me.PictureBox3.TabIndex = 23
        Me.PictureBox3.TabStop = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Image = Global.Launcher.My.Resources.Resources.Version160
        Me.Label8.Location = New System.Drawing.Point(278, 527)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(237, 17)
        Me.Label8.TabIndex = 27
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Image = Global.Launcher.My.Resources.Resources.LoadingUUID
        Me.Label9.Location = New System.Drawing.Point(555, 493)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(196, 40)
        Me.Label9.TabIndex = 36
        Me.Label9.Visible = False
        '
        'CrashLabel
        '
        Me.CrashLabel.BackColor = System.Drawing.Color.Transparent
        Me.CrashLabel.Image = Global.Launcher.My.Resources.Resources.DetectedCrash2
        Me.CrashLabel.Location = New System.Drawing.Point(28, 190)
        Me.CrashLabel.Name = "CrashLabel"
        Me.CrashLabel.Size = New System.Drawing.Size(723, 43)
        Me.CrashLabel.TabIndex = 37
        Me.CrashLabel.Visible = False
        '
        'BGWorker_Launch
        '
        Me.BGWorker_Launch.WorkerReportsProgress = True
        Me.BGWorker_Launch.WorkerSupportsCancellation = True
        '
        'BGWorker_News
        '
        Me.BGWorker_News.WorkerReportsProgress = True
        Me.BGWorker_News.WorkerSupportsCancellation = True
        '
        'TransparentRichTextBox2
        '
        Me.TransparentRichTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TransparentRichTextBox2.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.TransparentRichTextBox2.ForeColor = System.Drawing.Color.White
        Me.TransparentRichTextBox2.Location = New System.Drawing.Point(559, 264)
        Me.TransparentRichTextBox2.Name = "TransparentRichTextBox2"
        Me.TransparentRichTextBox2.ReadOnly = True
        Me.TransparentRichTextBox2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.TransparentRichTextBox2.Size = New System.Drawing.Size(192, 226)
        Me.TransparentRichTextBox2.TabIndex = 33
        Me.TransparentRichTextBox2.Text = "Loading News, Please Wait..."
        '
        'MainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BackgroundImage = Global.Launcher.My.Resources.Resources.NewsBGV9
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.CrashLabel)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TransparentRichTextBox2)
        Me.Controls.Add(Me.MCUpdates)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.VersionSelector)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.RememberMe)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Website)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.Help)
        Me.Controls.Add(Me.ExitLauncher)
        Me.Controls.Add(Me.Options)
        Me.Controls.Add(Me.Username)
        Me.Controls.Add(Me.Launch)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label7)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MainMenu"
        Me.Text = "Minecraft Launcher"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Launch As System.Windows.Forms.Button
    Friend WithEvents Username As System.Windows.Forms.TextBox
    Friend WithEvents Options As System.Windows.Forms.Button
    Friend WithEvents ExitLauncher As System.Windows.Forms.Button
    Friend WithEvents Help As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LauncherToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents LauncherVersion As System.Windows.Forms.Label
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents Website As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents RememberMe As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents VersionSelector As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents MCUpdates As System.Windows.Forms.Button
    Friend WithEvents TransparentRichTextBox2 As Launcher.TransparentRichTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CrashLabel As System.Windows.Forms.Label
    Friend WithEvents BGWorker_Launch As System.ComponentModel.BackgroundWorker
    Friend WithEvents BGWorker_News As System.ComponentModel.BackgroundWorker

End Class
