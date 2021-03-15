<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GB_Playlist = New System.Windows.Forms.GroupBox()
        Me.CB_Dupes = New System.Windows.Forms.CheckBox()
        Me.DGV_Playlist = New System.Windows.Forms.DataGridView()
        Me.B_Pause = New System.Windows.Forms.Button()
        Me.B_GenList = New System.Windows.Forms.Button()
        Me.B_PlayList = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.StatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GB_ViewerConfig = New System.Windows.Forms.GroupBox()
        Me.CB_Lock = New System.Windows.Forms.CheckBox()
        Me.CB_EasyPeazy = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TB_PercUnPop = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TB_VHeight = New System.Windows.Forms.TextBox()
        Me.TB_VWidth = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TB_ViewerTitle = New System.Windows.Forms.TextBox()
        Me.B_Always = New System.Windows.Forms.Button()
        Me.TB_AlwaysPlay = New System.Windows.Forms.TextBox()
        Me.B_Intro = New System.Windows.Forms.Button()
        Me.TB_IntroClip = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TB_AgeNew = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TB_PercPop = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TB_PercOld = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TB_PercNew = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TB_NumClips = New System.Windows.Forms.TextBox()
        Me.B_FBD1 = New System.Windows.Forms.Button()
        Me.TB_VideoClips = New System.Windows.Forms.TextBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.GB_Playlist.SuspendLayout()
        CType(Me.DGV_Playlist, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.GB_ViewerConfig.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GB_Playlist)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.StatusStrip1)
        Me.Panel1.Controls.Add(Me.GB_ViewerConfig)
        Me.Panel1.Controls.Add(Me.B_FBD1)
        Me.Panel1.Controls.Add(Me.TB_VideoClips)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(684, 761)
        Me.Panel1.TabIndex = 0
        '
        'GB_Playlist
        '
        Me.GB_Playlist.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GB_Playlist.Controls.Add(Me.CB_Dupes)
        Me.GB_Playlist.Controls.Add(Me.DGV_Playlist)
        Me.GB_Playlist.Controls.Add(Me.B_Pause)
        Me.GB_Playlist.Controls.Add(Me.B_GenList)
        Me.GB_Playlist.Controls.Add(Me.B_PlayList)
        Me.GB_Playlist.Enabled = False
        Me.GB_Playlist.Location = New System.Drawing.Point(10, 417)
        Me.GB_Playlist.Name = "GB_Playlist"
        Me.GB_Playlist.Size = New System.Drawing.Size(662, 317)
        Me.GB_Playlist.TabIndex = 8
        Me.GB_Playlist.TabStop = False
        Me.GB_Playlist.Text = "Playlist"
        '
        'CB_Dupes
        '
        Me.CB_Dupes.AutoSize = True
        Me.CB_Dupes.Location = New System.Drawing.Point(124, 23)
        Me.CB_Dupes.Name = "CB_Dupes"
        Me.CB_Dupes.Size = New System.Drawing.Size(142, 17)
        Me.CB_Dupes.TabIndex = 11
        Me.CB_Dupes.Text = "Prevent Daily Duplicates"
        Me.ToolTip1.SetToolTip(Me.CB_Dupes, "Prevent the same clip to be shown more than once on the same day.")
        Me.CB_Dupes.UseVisualStyleBackColor = True
        '
        'DGV_Playlist
        '
        Me.DGV_Playlist.AllowUserToAddRows = False
        Me.DGV_Playlist.AllowUserToResizeRows = False
        Me.DGV_Playlist.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV_Playlist.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DGV_Playlist.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.DGV_Playlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Playlist.Location = New System.Drawing.Point(6, 48)
        Me.DGV_Playlist.Name = "DGV_Playlist"
        Me.DGV_Playlist.ReadOnly = True
        Me.DGV_Playlist.Size = New System.Drawing.Size(650, 269)
        Me.DGV_Playlist.TabIndex = 0
        '
        'B_Pause
        '
        Me.B_Pause.Location = New System.Drawing.Point(581, 19)
        Me.B_Pause.Name = "B_Pause"
        Me.B_Pause.Size = New System.Drawing.Size(75, 23)
        Me.B_Pause.TabIndex = 10
        Me.B_Pause.Text = "Pause"
        Me.B_Pause.UseVisualStyleBackColor = True
        '
        'B_GenList
        '
        Me.B_GenList.Location = New System.Drawing.Point(6, 19)
        Me.B_GenList.Name = "B_GenList"
        Me.B_GenList.Size = New System.Drawing.Size(112, 23)
        Me.B_GenList.TabIndex = 7
        Me.B_GenList.Text = "Generate Playlist"
        Me.B_GenList.UseVisualStyleBackColor = True
        '
        'B_PlayList
        '
        Me.B_PlayList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_PlayList.Location = New System.Drawing.Point(488, 19)
        Me.B_PlayList.Name = "B_PlayList"
        Me.B_PlayList.Size = New System.Drawing.Size(75, 23)
        Me.B_PlayList.TabIndex = 9
        Me.B_PlayList.Text = "Play"
        Me.B_PlayList.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(56, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(177, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Folder Containing Video Clips."
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 739)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 12, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(684, 22)
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'StatusLabel1
        '
        Me.StatusLabel1.ForeColor = System.Drawing.Color.DarkRed
        Me.StatusLabel1.Name = "StatusLabel1"
        Me.StatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'GB_ViewerConfig
        '
        Me.GB_ViewerConfig.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GB_ViewerConfig.Controls.Add(Me.CB_Lock)
        Me.GB_ViewerConfig.Controls.Add(Me.CB_EasyPeazy)
        Me.GB_ViewerConfig.Controls.Add(Me.Label7)
        Me.GB_ViewerConfig.Controls.Add(Me.Label1)
        Me.GB_ViewerConfig.Controls.Add(Me.Label11)
        Me.GB_ViewerConfig.Controls.Add(Me.TB_PercUnPop)
        Me.GB_ViewerConfig.Controls.Add(Me.Label10)
        Me.GB_ViewerConfig.Controls.Add(Me.TB_VHeight)
        Me.GB_ViewerConfig.Controls.Add(Me.TB_VWidth)
        Me.GB_ViewerConfig.Controls.Add(Me.Label9)
        Me.GB_ViewerConfig.Controls.Add(Me.TB_ViewerTitle)
        Me.GB_ViewerConfig.Controls.Add(Me.B_Always)
        Me.GB_ViewerConfig.Controls.Add(Me.TB_AlwaysPlay)
        Me.GB_ViewerConfig.Controls.Add(Me.B_Intro)
        Me.GB_ViewerConfig.Controls.Add(Me.TB_IntroClip)
        Me.GB_ViewerConfig.Controls.Add(Me.Label6)
        Me.GB_ViewerConfig.Controls.Add(Me.TB_AgeNew)
        Me.GB_ViewerConfig.Controls.Add(Me.Label5)
        Me.GB_ViewerConfig.Controls.Add(Me.TB_PercPop)
        Me.GB_ViewerConfig.Controls.Add(Me.Label4)
        Me.GB_ViewerConfig.Controls.Add(Me.TB_PercOld)
        Me.GB_ViewerConfig.Controls.Add(Me.Label3)
        Me.GB_ViewerConfig.Controls.Add(Me.TB_PercNew)
        Me.GB_ViewerConfig.Controls.Add(Me.Label2)
        Me.GB_ViewerConfig.Controls.Add(Me.TB_NumClips)
        Me.GB_ViewerConfig.Enabled = False
        Me.GB_ViewerConfig.Location = New System.Drawing.Point(10, 73)
        Me.GB_ViewerConfig.Name = "GB_ViewerConfig"
        Me.GB_ViewerConfig.Size = New System.Drawing.Size(663, 338)
        Me.GB_ViewerConfig.TabIndex = 4
        Me.GB_ViewerConfig.TabStop = False
        Me.GB_ViewerConfig.Text = "Viewer Configuration"
        '
        'CB_Lock
        '
        Me.CB_Lock.AutoSize = True
        Me.CB_Lock.Location = New System.Drawing.Point(320, 40)
        Me.CB_Lock.Name = "CB_Lock"
        Me.CB_Lock.Size = New System.Drawing.Size(50, 17)
        Me.CB_Lock.TabIndex = 26
        Me.CB_Lock.Text = "Lock"
        Me.CB_Lock.UseVisualStyleBackColor = True
        '
        'CB_EasyPeazy
        '
        Me.CB_EasyPeazy.AutoSize = True
        Me.CB_EasyPeazy.Checked = True
        Me.CB_EasyPeazy.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CB_EasyPeazy.Location = New System.Drawing.Point(15, 79)
        Me.CB_EasyPeazy.Name = "CB_EasyPeazy"
        Me.CB_EasyPeazy.Size = New System.Drawing.Size(322, 17)
        Me.CB_EasyPeazy.TabIndex = 25
        Me.CB_EasyPeazy.Text = "I don't want to think. Just randomly choose from my clips folder."
        Me.CB_EasyPeazy.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(55, 190)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(387, 13)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Introduction clip that is alway played first, Tripoloski (Excluded from playlist " &
    "count)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(55, 243)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(340, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Clips that are always included - my faves. (Excluded from playlist count)"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(502, 130)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(125, 13)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Percent UnPopular Clips."
        '
        'TB_PercUnPop
        '
        Me.TB_PercUnPop.Location = New System.Drawing.Point(461, 127)
        Me.TB_PercUnPop.Name = "TB_PercUnPop"
        Me.TB_PercUnPop.Size = New System.Drawing.Size(36, 20)
        Me.TB_PercUnPop.TabIndex = 10
        Me.TB_PercUnPop.Text = "25"
        Me.TB_PercUnPop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(237, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 13)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Viewer size"
        '
        'TB_VHeight
        '
        Me.TB_VHeight.Location = New System.Drawing.Point(278, 38)
        Me.TB_VHeight.Name = "TB_VHeight"
        Me.TB_VHeight.Size = New System.Drawing.Size(36, 20)
        Me.TB_VHeight.TabIndex = 5
        Me.TB_VHeight.Text = "540"
        Me.TB_VHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TB_VWidth
        '
        Me.TB_VWidth.Location = New System.Drawing.Point(237, 38)
        Me.TB_VWidth.Name = "TB_VWidth"
        Me.TB_VWidth.Size = New System.Drawing.Size(36, 20)
        Me.TB_VWidth.TabIndex = 4
        Me.TB_VWidth.Text = "960"
        Me.TB_VWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(109, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Window Title for OBS"
        '
        'TB_ViewerTitle
        '
        Me.TB_ViewerTitle.Location = New System.Drawing.Point(15, 38)
        Me.TB_ViewerTitle.Name = "TB_ViewerTitle"
        Me.TB_ViewerTitle.Size = New System.Drawing.Size(216, 20)
        Me.TB_ViewerTitle.TabIndex = 3
        Me.TB_ViewerTitle.Text = "VLC Viewer"
        Me.ToolTip1.SetToolTip(Me.TB_ViewerTitle, "VLC Viewer Window Title for OBS.")
        '
        'B_Always
        '
        Me.B_Always.Image = CType(resources.GetObject("B_Always.Image"), System.Drawing.Image)
        Me.B_Always.Location = New System.Drawing.Point(10, 243)
        Me.B_Always.Name = "B_Always"
        Me.B_Always.Size = New System.Drawing.Size(41, 42)
        Me.B_Always.TabIndex = 14
        Me.B_Always.UseVisualStyleBackColor = True
        '
        'TB_AlwaysPlay
        '
        Me.TB_AlwaysPlay.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_AlwaysPlay.Location = New System.Drawing.Point(56, 259)
        Me.TB_AlwaysPlay.Multiline = True
        Me.TB_AlwaysPlay.Name = "TB_AlwaysPlay"
        Me.TB_AlwaysPlay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TB_AlwaysPlay.Size = New System.Drawing.Size(600, 72)
        Me.TB_AlwaysPlay.TabIndex = 13
        '
        'B_Intro
        '
        Me.B_Intro.Image = CType(resources.GetObject("B_Intro.Image"), System.Drawing.Image)
        Me.B_Intro.Location = New System.Drawing.Point(10, 190)
        Me.B_Intro.Name = "B_Intro"
        Me.B_Intro.Size = New System.Drawing.Size(41, 42)
        Me.B_Intro.TabIndex = 6
        Me.B_Intro.UseVisualStyleBackColor = True
        '
        'TB_IntroClip
        '
        Me.TB_IntroClip.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_IntroClip.Location = New System.Drawing.Point(55, 206)
        Me.TB_IntroClip.Name = "TB_IntroClip"
        Me.TB_IntroClip.Size = New System.Drawing.Size(601, 20)
        Me.TB_IntroClip.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(55, 155)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(143, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Age of ""NEW"" Clips in Days."
        '
        'TB_AgeNew
        '
        Me.TB_AgeNew.Location = New System.Drawing.Point(15, 152)
        Me.TB_AgeNew.Name = "TB_AgeNew"
        Me.TB_AgeNew.Size = New System.Drawing.Size(36, 20)
        Me.TB_AgeNew.TabIndex = 11
        Me.TB_AgeNew.Text = "90"
        Me.TB_AgeNew.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(202, 130)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(111, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Percent Popular Clips."
        '
        'TB_PercPop
        '
        Me.TB_PercPop.Location = New System.Drawing.Point(161, 127)
        Me.TB_PercPop.Name = "TB_PercPop"
        Me.TB_PercPop.Size = New System.Drawing.Size(36, 20)
        Me.TB_PercPop.TabIndex = 9
        Me.TB_PercPop.Text = "25"
        Me.TB_PercPop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(359, 130)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Percent OLD Clips."
        '
        'TB_PercOld
        '
        Me.TB_PercOld.Location = New System.Drawing.Point(318, 127)
        Me.TB_PercOld.Name = "TB_PercOld"
        Me.TB_PercOld.Size = New System.Drawing.Size(36, 20)
        Me.TB_PercOld.TabIndex = 8
        Me.TB_PercOld.Text = "25"
        Me.TB_PercOld.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(55, 130)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Percent NEW Clips."
        '
        'TB_PercNew
        '
        Me.TB_PercNew.Location = New System.Drawing.Point(15, 127)
        Me.TB_PercNew.Name = "TB_PercNew"
        Me.TB_PercNew.Size = New System.Drawing.Size(36, 20)
        Me.TB_PercNew.TabIndex = 9
        Me.TB_PercNew.Text = "25"
        Me.TB_PercNew.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(55, 105)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(213, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Maximum Number of Clips in Playlist."
        '
        'TB_NumClips
        '
        Me.TB_NumClips.Location = New System.Drawing.Point(15, 102)
        Me.TB_NumClips.Name = "TB_NumClips"
        Me.TB_NumClips.Size = New System.Drawing.Size(36, 20)
        Me.TB_NumClips.TabIndex = 8
        Me.TB_NumClips.Text = "100"
        Me.TB_NumClips.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'B_FBD1
        '
        Me.B_FBD1.Image = CType(resources.GetObject("B_FBD1.Image"), System.Drawing.Image)
        Me.B_FBD1.Location = New System.Drawing.Point(10, 16)
        Me.B_FBD1.Name = "B_FBD1"
        Me.B_FBD1.Size = New System.Drawing.Size(41, 42)
        Me.B_FBD1.TabIndex = 1
        Me.B_FBD1.UseVisualStyleBackColor = True
        '
        'TB_VideoClips
        '
        Me.TB_VideoClips.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_VideoClips.Location = New System.Drawing.Point(57, 32)
        Me.TB_VideoClips.Name = "TB_VideoClips"
        Me.TB_VideoClips.Size = New System.Drawing.Size(618, 20)
        Me.TB_VideoClips.TabIndex = 2
        '
        'OpenFileDialog2
        '
        Me.OpenFileDialog2.Multiselect = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 761)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.Name = "Form1"
        Me.Text = "Rate My Clips On Stream"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GB_Playlist.ResumeLayout(False)
        Me.GB_Playlist.PerformLayout()
        CType(Me.DGV_Playlist, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GB_ViewerConfig.ResumeLayout(False)
        Me.GB_ViewerConfig.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents B_FBD1 As Button
    Friend WithEvents TB_VideoClips As TextBox
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents GB_ViewerConfig As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TB_AgeNew As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TB_PercPop As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TB_PercOld As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TB_PercNew As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TB_NumClips As TextBox
    Friend WithEvents B_Intro As Button
    Friend WithEvents TB_IntroClip As TextBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents B_Always As Button
    Friend WithEvents TB_AlwaysPlay As TextBox
    Friend WithEvents OpenFileDialog2 As OpenFileDialog
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents StatusLabel1 As ToolStripStatusLabel
    Friend WithEvents Label9 As Label
    Friend WithEvents TB_ViewerTitle As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TB_VHeight As TextBox
    Friend WithEvents TB_VWidth As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TB_PercUnPop As TextBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Label1 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents GB_Playlist As GroupBox
    Friend WithEvents DGV_Playlist As DataGridView
    Friend WithEvents B_GenList As Button
    Friend WithEvents B_PlayList As Button
    Friend WithEvents B_Pause As Button
    Friend WithEvents CB_Dupes As CheckBox
    Friend WithEvents CB_EasyPeazy As CheckBox
    Friend WithEvents CB_Lock As CheckBox
End Class
