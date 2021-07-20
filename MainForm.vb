Imports System.ComponentModel
'Imports LibVLCSharp.Shared
Imports System.IO
Imports System.Security.Cryptography

Public Class MainForm

    Dim RMC_DS As New AMOS_DataSet
    Dim RNG As New RNGCryptoServiceProvider
    Dim Playlist_dt As New AMOS_DataSet.VideoClipDataTable
    Dim VLC_Play_Thrd As Threading.Thread
    Public The_VLC_Form As VLC_Form = New VLC_Form

    ' From VLC Source: \vlc-3.0.12\include\vlc_interface.h
    '#define EXTENSIONS_VIDEO_CSV "3g2", "3gp", "3gp2", "3gpp", "amv", "asf", "avi", "bik", "crf", "divx", "drc", "dv", "dvr-ms" \
    '                             "evo", "f4v", "flv", "gvi", "gxf", "iso", \
    '                             "m1v", "m2v", "m2t", "m2ts", "m4v", "mkv", "mov",\
    '                             "mp2", "mp2v", "mp4", "mp4v", "mpe", "mpeg", "mpeg1", \
    '                             "mpeg2", "mpeg4", "mpg", "mpv2", "mts", "mtv", "mxf", "mxg", "nsv", "nuv", \
    '                             "ogg", "ogm", "ogv", "ogx", "ps", \
    '                             "rec", "rm", "rmvb", "rpl", "thp", "tod", "ts", "tts", "txd", "vob", "vro", \
    '                             "webm", "wm", "wmv", "wtv", "xesc"

    Dim FI As FileInfo
    Dim EXTENSIONS_VIDEO_CSV As String = String.Join(",",
                                                         {".3g2", ".3gp", ".3gp2", ".3gpp", ".amv", ".asf", ".avi", ".bik", ".crf", ".divx", ".drc", ".dv", ".dvr-ms",
                                                         ".evo", ".f4v", ".flv", ".gvi", ".gxf", ".iso",
                                                         ".m1v", ".m2v", ".m2t", ".m2ts", ".m4v", ".mkv", ".mov",
                                                         ".mp2", ".mp2v", ".mp4", ".mp4v", ".mpe", ".mpeg", ".mpeg1",
                                                         ".mpeg2", ".mpeg4", ".mpg", ".mpv2", ".mts", ".mtv", ".mxf", ".mxg", ".nsv", ".nuv",
                                                         ".ogg", ".ogm", ".ogv", ".ogx", ".ps",
                                                         ".rec", ".rm", ".rmvb", ".rpl", ".thp", ".tod", ".ts", ".tts", ".txd", ".vob", ".vro",
                                                         ".webm", ".wm", ".wmv", ".wtv", ".xesc"})

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim s As String = Application.ExecutablePath

        The_VLC_Form.Show()

    End Sub

    Private Sub MainForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Try

            For Each c As Control In Me.Controls
                SaveRestore_Controls(c, False)
            Next

            If Not String.IsNullOrEmpty(TB_VideoClips.Text) Then
                FolderBrowserDialog1.SelectedPath = TB_VideoClips.Text
                LoadClipsFolder()
                GB_ViewerConfig.Enabled = True
                GB_Playlist.Enabled = True
            Else
                StatusLabel1.Text = "Please select a clips folder."
            End If

            Me.Location = My.Settings.MainForm_Location

        Catch ex As Exception
            StatusLabel1.Text = ex.Message
        End Try

    End Sub

    Private Function SaveRestore_Controls(c As Control, SaveIt As Boolean) As Boolean

        If c.Controls.Count > 0 Then
            For Each c1 As Control In c.Controls
                SaveRestore_Controls(c1, SaveIt)
            Next
        Else
            If c.GetType = GetType(TextBox) AndAlso
                (c.Name.StartsWith("TB") And
                (c.Name <> "TB_VWidth" And c.Name <> "TB_VHeight")) Then
                Try
                    If SaveIt Then
                        My.Settings.Item(c.Name) = c.Text
                    Else
                        c.Text = My.Settings.Item(c.Name)
                    End If

                Catch ex As Exception
                    StatusLabel1.Text &= ex.Message & vbCrLf
                End Try
            End If

            If c.GetType = GetType(CheckBox) Then
                Try
                    If SaveIt Then
                        My.Settings.Item(c.Name) = DirectCast(c, CheckBox).Checked
                    Else
                        DirectCast(c, CheckBox).Checked = My.Settings.Item(c.Name)
                    End If

                Catch ex As Exception
                    StatusLabel1.Text &= ex.Message & vbCrLf
                End Try
            End If
        End If

        Return True

    End Function

    Private Sub MainForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        Dim sErrors As String = ""

        Try
            If Not VLC_Play_Thrd Is Nothing Then
                VLC_Play_Thrd.Abort()
                VLC_Play_Thrd = Nothing
            End If
        Catch ex As Exception

        End Try

        Try
            If The_VLC_Form.IsPlaying Then
                The_VLC_Form.StopVideo()
            End If
        Catch ex As Exception
            sErrors &= ex.Message & vbCrLf
        End Try

        Try
            The_VLC_Form.Close()
        Catch ex As Exception
            sErrors &= ex.Message & vbCrLf
        End Try

        Try
            For Each c As Control In Me.Controls
                If Not SaveRestore_Controls(c, True) Then
                    Exit For
                End If
            Next

            If Me.Location.X >= 0 And Me.Location.Y >= 0 Then
                My.Settings.MainForm_Location = Me.Location
            End If

        Catch ex As Exception
            sErrors &= ex.Message & vbCrLf
        End Try

        Try

            My.Settings.RCM_DS_XML = RMC_DS.GetXml()

        Catch ex As Exception
            sErrors &= ex.Message & vbCrLf
        End Try

        If Not String.IsNullOrEmpty(sErrors) Then
            MsgBox(sErrors)
        End If

    End Sub

    Private Sub B_FBD1_Click(sender As Object, e As EventArgs) Handles B_FBD1.Click

        Try
            StatusLabel1.Text = ""

            FolderBrowserDialog1.ShowDialog()

            If Not String.IsNullOrEmpty(FolderBrowserDialog1.SelectedPath) Then

                TB_VideoClips.Text = FolderBrowserDialog1.SelectedPath
                LoadClipsFolder()

                OpenFileDialog1.InitialDirectory = FolderBrowserDialog1.SelectedPath
                OpenFileDialog2.InitialDirectory = FolderBrowserDialog1.SelectedPath

                GB_ViewerConfig.Enabled = True
                GB_Playlist.Enabled = True

            End If

        Catch ex As Exception
            StatusLabel1.Text = ex.Message
        End Try

    End Sub

    Private Sub B_Intro_Click(sender As Object, e As EventArgs) Handles B_Intro.Click

        Try
            StatusLabel1.Text = ""

            With OpenFileDialog1
                .InitialDirectory = FolderBrowserDialog1.SelectedPath
                .Filter = ""
                .ShowDialog()
            End With

            If Not String.IsNullOrEmpty(OpenFileDialog1.FileName) Then
                TB_IntroClip.Text = OpenFileDialog1.FileName
            End If

        Catch ex As Exception
            StatusLabel1.Text = ex.Message
        End Try

    End Sub

    Private Sub B_Always_Click(sender As Object, e As EventArgs) Handles B_Always.Click

        Try
            StatusLabel1.Text = ""

            With OpenFileDialog2
                .InitialDirectory = FolderBrowserDialog1.SelectedPath
                .Filter = ""
                .ShowDialog()
            End With

            If OpenFileDialog2.FileNames.Length > 0 Then
                TB_AlwaysPlay.Text = String.Join(vbCrLf, OpenFileDialog2.FileNames)
            End If

        Catch ex As Exception
            StatusLabel1.Text = ex.Message
        End Try

    End Sub


    Private Sub TB_VideoClips_LostFocus(sender As Object, e As EventArgs) Handles TB_VideoClips.LostFocus

        Try
            StatusLabel1.Text = ""

            'If TB_VideoClips.Focused Then

            If Not String.IsNullOrEmpty(TB_VideoClips.Text) Then

                Do Until Not TB_VideoClips.Text.EndsWith("\")
                    TB_VideoClips.Text = TB_VideoClips.Text.Substring(0, TB_VideoClips.Text.Length - 1)
                Loop

                TB_VideoClips.Text = TB_VideoClips.Text.Trim

                FolderBrowserDialog1.SelectedPath = TB_VideoClips.Text
                LoadClipsFolder()

                GB_ViewerConfig.Enabled = True
                GB_Playlist.Enabled = True

            Else
                StatusLabel1.Text = "Clips cannot be blank, please select a clips Folder."
            End If

            'End If

        Catch ex As Exception
            StatusLabel1.Text = ex.Message
        End Try

    End Sub
    Private Sub LoadClipsFolder()

        Dim VC_row As AMOS_DataSet.VideoClipRow

        If Not String.IsNullOrEmpty(My.Settings.RCM_DS_XML) Then
            RMC_DS.ReadXml(New StringReader(My.Settings.RCM_DS_XML))
            RMC_DS.VideoClip.Clear()
        End If


        StatusLabel1.Text = "Loading clips folder"

        For Each sFile As String In My.Computer.FileSystem.GetFiles(FolderBrowserDialog1.SelectedPath)

            FI = New FileInfo(sFile)

            If EXTENSIONS_VIDEO_CSV.Contains(FI.Extension.ToLower) Then

                VC_row = RMC_DS.VideoClip.FindByFileName(FI.Name)

                If VC_row Is Nothing Then
                    RMC_DS.VideoClip.LoadDataRow({FI.Name, FI.LastWriteTime, Nothing, Nothing}, False)
                Else
                    ' If a clip is modified/trimmed with the same name, update the row and zero the counters.
                    If FI.LastWriteTime <> VC_row.ModifiedDate Then
                        VC_row.ModifiedDate = FI.LastWriteTime
                        VC_row.LastPlayed = "1/1/1970"
                        VC_row.PlayCount = 0
                    End If
                End If

            End If
        Next

        For Each VC_row In RMC_DS.VideoClip.ToArray

            If Not File.Exists(FolderBrowserDialog1.SelectedPath & "\" & VC_row.FileName) Then
                VC_row.Delete()
            End If
        Next

        RMC_DS.AcceptChanges()
        My.Settings.RCM_DS_XML = RMC_DS.GetXml

        StatusLabel1.Text = "Loaded clips folder: " & RMC_DS.VideoClip.Count & " clips found."

    End Sub

    Private Sub TB_VSize_TextChanged(sender As Object, e As EventArgs) Handles TB_VWidth.TextChanged, TB_VHeight.TextChanged

        Try
            StatusLabel1.Text = ""

            If TB_VWidth.Focused Or TB_VHeight.Focused Then

                Dim iWidth As Integer = CInt(TB_VWidth.Text)
                Dim iHeight As Integer = CInt(TB_VHeight.Text)

                If iWidth > 0 Then
                    The_VLC_Form.Width = iWidth + (The_VLC_Form.Width - The_VLC_Form.VideoView1.Width)
                End If

                If iHeight > 0 Then
                    The_VLC_Form.Height = iHeight + (The_VLC_Form.Height - The_VLC_Form.VideoView1.Height)
                End If

            End If

        Catch ex As Exception
            StatusLabel1.Text = ex.Message
        End Try

    End Sub

    Private Sub TB_VSize_LostFocus(sender As Object, e As EventArgs) Handles TB_VWidth.LostFocus, TB_VHeight.LostFocus

        Try
            StatusLabel1.Text = ""

            TB_VWidth.Text = The_VLC_Form.VideoView1.Width
            TB_VHeight.Text = The_VLC_Form.VideoView1.Height

        Catch ex As Exception
            StatusLabel1.Text = ex.Message
        End Try

    End Sub

    Private Sub TB_ViewerTitle_TextChanged(sender As Object, e As EventArgs) Handles TB_ViewerTitle.TextChanged

        Dim TB As TextBox = sender

        Try
            StatusLabel1.Text = ""

            If String.IsNullOrEmpty(TB.Text) Then
                TB.Text = "VLC Viewer"
                StatusLabel1.Text = "Title can never be blank!"
            End If

            The_VLC_Form.Text = TB.Text

        Catch ex As Exception
            StatusLabel1.Text = ex.Message
        End Try
    End Sub

    Private Sub B_GenList_Click(sender As Object, e As EventArgs) Handles B_GenList.Click

        Dim Temp_dt As New AMOS_DataSet.VideoClipDataTable
        Dim VC_row As AMOS_DataSet.VideoClipRow

        Dim iTotal As Integer
        Dim iNew As Integer
        Dim iOld As Integer
        Dim iPop As Integer
        Dim iUnPop As Integer

        Dim NewOldDate As Date
        Dim iTemp As Integer
        Dim iDGV_Selected As Integer = -1

        Try
            StatusLabel1.Text = ""

            If Not String.IsNullOrEmpty(TB_NumClips.Text) Then
                iTotal = CInt(TB_NumClips.Text)
            Else
                iTotal = Integer.MaxValue
            End If

            If CB_EasyPeazy.Checked Then

                FillTemp(iTotal, Temp_dt)

            Else

                iNew = CInt(If(String.IsNullOrEmpty(TB_PercNew.Text), "0", TB_PercNew.Text) / 100 * iTotal)
                iOld = CInt(If(String.IsNullOrEmpty(TB_PercOld.Text), "0", TB_PercOld.Text) / 100 * iTotal)

                NewOldDate = Now.AddDays(-CInt(TB_AgeNew.Text)) ' Subtract days from Now()

                ' Either fill with iNew rows or however many rows are in NewOld_dt, which ever comes first.

                '+++ Get "New"
                RMC_DS.VideoClip.DefaultView.RowFilter = "ModifiedDate > '" & NewOldDate.Date & "'" &
                    If(CB_Dupes.Checked, " AND LastPlayed < '" & Now.Date & "'", "")
                FillTemp(iNew, Temp_dt)
                '---

                '+++ Popular
                RMC_DS.VideoClip.DefaultView.RowFilter = "UpVotes > DownVotes" &
                    If(CB_Dupes.Checked, " AND LastPlayed < '" & Now.Date & "'", "")
                FillTemp(iPop, Temp_dt)
                '---

                '+++ Reverse the date, "OLD".
                RMC_DS.VideoClip.DefaultView.RowFilter = "ModifiedDate <= '" & NewOldDate.Date & "'" &
                    If(CB_Dupes.Checked, " AND LastPlayed < '" & Now.Date & "'", "")
                FillTemp(iOld, Temp_dt)
                '---

                '+++ UnPopular
                RMC_DS.VideoClip.DefaultView.RowFilter = "UpVotes <= DownVotes" &
                    If(CB_Dupes.Checked, " AND LastPlayed < '" & Now.Date & "'", "")
                FillTemp(iUnPop, Temp_dt)

            End If
            '---


            ' Build the Playlist.
            Playlist_dt = New AMOS_DataSet.VideoClipDataTable

            '+++ Add the intro first
            If Not String.IsNullOrEmpty(TB_IntroClip.Text) Then

                FI = New FileInfo(TB_IntroClip.Text)

                If EXTENSIONS_VIDEO_CSV.Contains(FI.Extension.ToLower) Then
                    Playlist_dt.LoadDataRow({FI.Name, FI.LastWriteTime}, False)
                Else
                    StatusLabel1.Text = FI.Name & "(" & FI.Extension & ") is not supported by VLC."
                    Exit Sub
                End If
            End If
            '---

            '+++ Add the "always play" to the Temp list.
            For Each sFile As String In TB_AlwaysPlay.Text.Replace(vbLf, "").Split(vbCr)

                If Not String.IsNullOrEmpty(sFile) Then

                    FI = New FileInfo(sFile)

                    If EXTENSIONS_VIDEO_CSV.Contains(FI.Extension.ToLower) Then

                        If Temp_dt.FindByFileName(FI.Name) Is Nothing Then
                            Temp_dt.LoadDataRow({FI.Name, FI.LastWriteTime}, False)
                        End If
                    Else
                        StatusLabel1.Text = FI.Name & "(" & FI.Extension & ") is not supported by VLC."
                        Exit Sub
                    End If
                End If
            Next
            '---

            '+++ Randomize the temp list  into the Playlist.
            Do Until Temp_dt.Count = 0

                ' Get Random record number
                iTemp = GetRng(0, Temp_dt.Count - 1)
                VC_row = Temp_dt.Rows(iTemp)

                If Playlist_dt.FindByFileName(VC_row.FileName) Is Nothing Then
                    Playlist_dt.LoadDataRow({VC_row.FileName, VC_row.ModifiedDate, VC_row.LastPlayed, VC_row.PlayCount}, False)
                End If

                Temp_dt.Rows(iTemp).Delete()

            Loop
            '---

            With DGV_Playlist

                ' If there's a previous list that was perhaps even playing, remember the selected clip "Now Playing."
                If .SelectedRows.Count > 0 Then
                    iDGV_Selected = .SelectedRows(0).Index
                End If

                .DataSource = Playlist_dt
                .AutoResizeColumns()
                .Update()

                If .Columns(0).Width > 200 Then
                    .Columns(0).Width = 200
                End If

                ' If there's a previous list that was perhaps even playing, set the selected clip "Now Playing." (It will be wrong, but it will be the correct number.)
                If iDGV_Selected > -1 And iDGV_Selected <= .Rows.Count - 1 Then
                    .ClearSelection()
                    .Rows(iDGV_Selected).Selected = True
                    If Not .Rows(iDGV_Selected).Displayed Then
                        .FirstDisplayedScrollingRowIndex = .Rows(iDGV_Selected).Index
                    End If
                End If

            End With

        Catch ex As Exception
            StatusLabel1.Text = ex.Message
        End Try

    End Sub

    Private Sub FillTemp(iCount As Integer, ByRef Temp_dt As AMOS_DataSet.VideoClipDataTable)

        Dim PreTemp_dt As New AMOS_DataSet.VideoClipDataTable
        Dim VC_row As AMOS_DataSet.VideoClipRow
        Dim iTemp As Integer

        If iCount = 0 Then Exit Sub

        For Each rowView As DataRowView In RMC_DS.VideoClip.DefaultView
            VC_row = rowView.Row
            PreTemp_dt.LoadDataRow({VC_row.FileName, VC_row.ModifiedDate, VC_row.LastPlayed, VC_row.PlayCount}, False)
        Next

        Do Until PreTemp_dt.Count = 0

            If iCount = 0 Then Exit Do

            iTemp = GetRng(0, PreTemp_dt.Count - 1)
            VC_row = PreTemp_dt.Rows(iTemp)

            If Temp_dt.FindByFileName(VC_row.FileName) Is Nothing Then
                Temp_dt.LoadDataRow({VC_row.FileName, VC_row.ModifiedDate, VC_row.LastPlayed, VC_row.PlayCount}, False)
                iCount -= 1
            End If

            PreTemp_dt.Rows(iTemp).Delete()

        Loop

    End Sub

    Private Sub TB_NumClips_TextChanged(sender As Object, e As EventArgs) Handles TB_NumClips.TextChanged,
            TB_PercNew.TextChanged, TB_PercOld.TextChanged,
            TB_AgeNew.TextChanged

        Dim TB As TextBox = sender
        Dim sText As String

        TB.Text = TB.Text.Replace("%", "").Trim
        sText = TB.Text

        If Not String.IsNullOrEmpty(sText) Then
            If Not IsNumeric(sText) Then
                StatusLabel1.Text = TB.Name & " is not numeric."
                TB.Focus()
            Else
                TB.Text = sText
                StatusLabel1.Text = ""
            End If
        Else
            ' Num Clips can be empty for MAX.
            If TB.Name <> TB_NumClips.Name Then
                StatusLabel1.Text = TB.Name & " is not numeric."
                TB.Focus()
            End If
        End If

    End Sub
    Private Function GetRng(LO As Integer, HI As Integer) As Integer

        Dim Data(3) As Byte
        Dim dRNG As Double
        Dim iResult As Integer

        RNG.GetBytes(Data)
        dRNG = BitConverter.ToUInt32(Data, 0) / (UInteger.MaxValue + 1.0)

        iResult = (dRNG * (HI - LO)) + LO
        Return iResult

    End Function

    Private Sub B_PlayList_Click(sender As Object, e As EventArgs) Handles B_PlayList.Click

        Dim B As Button = sender

        Try
            StatusLabel1.Text = ""

            If B.Text = "Play" Then

                ' Play button will gen a list if no list exists.
                If Playlist_dt.Count = 0 Then
                    B_GenList.PerformClick()
                End If

                If Playlist_dt.Count = 0 Then
                    StatusLabel1.Text = "What?! No list?!"
                    Exit Sub
                End If

                VLC_Play_Thrd = New Threading.Thread(Sub()

                                                         Dim sError As String
                                                         Dim sFileName As String

                                                         Try

                                                             For Each clip As DataGridViewRow In DGV_Playlist.Rows
                                                                 Try

                                                                     Invoke(Sub()
                                                                                DGV_Playlist.ClearSelection()
                                                                                clip.Selected = True
                                                                                If Not clip.Displayed Then
                                                                                    DGV_Playlist.FirstDisplayedScrollingRowIndex = clip.Index
                                                                                End If
                                                                            End Sub)


                                                                     Try

                                                                         ' The DGV is not bound to the main DB Table.
                                                                         ' We have to update it manually.
                                                                         clip.Cells("LastPlayed").Value = Now.Date
                                                                         clip.Cells("PlayCount").Value += 1

                                                                         sFileName = clip.Cells("FileName").Value

                                                                         '+++ Play clip
                                                                         sError = The_VLC_Form.PlayVideo(FolderBrowserDialog1.SelectedPath & "\" & sFileName)


                                                                         If sError <> "" Then
                                                                             Invoke(Sub()
                                                                                        StatusLabel1.Text = sError.Replace(vbCr, " ").Replace(vbLf, "")
                                                                                    End Sub)
                                                                             Continue For
                                                                         End If
                                                                         '---

                                                                         Do Until The_VLC_Form.IsPlaying
                                                                             Threading.Thread.Sleep(10)
                                                                         Loop

                                                                         Do Until Not The_VLC_Form.IsPlaying And Not The_VLC_Form.IsPaused
                                                                             Threading.Thread.Sleep(10)
                                                                         Loop

                                                                         '+++
                                                                         ' Update main DB Table
                                                                         With RMC_DS.VideoClip.FindByFileName(sFileName)
                                                                             .LastPlayed = Now.Date
                                                                             .PlayCount += 1
                                                                         End With
                                                                         '---

                                                                     Catch ex As Exception

                                                                     End Try


                                                                     The_VLC_Form.StopVideo()
                                                                     Threading.Thread.Sleep(300)

                                                                 Catch ex As Exception
                                                                     Invoke(Sub()
                                                                                StatusLabel1.Text = ex.Message
                                                                            End Sub)
                                                                 End Try
                                                             Next


                                                         Catch ex As Exception
                                                             Try
                                                                 If Not VLC_Play_Thrd Is Nothing Then
                                                                     Invoke(Sub()
                                                                                The_VLC_Form.StopVideo()
                                                                                StatusLabel1.Text = ex.Message
                                                                            End Sub)
                                                                 End If
                                                             Catch ex1 As Exception

                                                             End Try
                                                         End Try

                                                         Try
                                                             If Not VLC_Play_Thrd Is Nothing Then
                                                                 Invoke(Sub()
                                                                            B.Text = "Play"
                                                                        End Sub)
                                                             End If
                                                         Catch ex As Exception

                                                         End Try

                                                     End Sub)

                VLC_Play_Thrd.Start()
                B.Text = "Stop"
            Else

                ' Stop
                Try
                    VLC_Play_Thrd.Abort()
                Catch ex As Exception

                End Try

                The_VLC_Form.StopVideo()
                B.Text = "Play"
                B_Pause.Text = "Pause"

                ' Write DB
                My.Settings.RCM_DS_XML = RMC_DS.GetXml

            End If

        Catch ex As Exception
            StatusLabel1.Text = ex.Message
        End Try

    End Sub

    Private Sub B_Pause_Click(sender As Object, e As EventArgs) Handles B_Pause.Click

        Dim B As Button = sender

        Try
            StatusLabel1.Text = ""

            If B.Text = "Pause" Then
                If The_VLC_Form.IsPlaying Then
                    The_VLC_Form.IsPaused = True
                    B.Text = "Resume"
                End If
            Else
                The_VLC_Form.IsPaused = False
                B.Text = "Pause"
            End If

        Catch ex As Exception
            StatusLabel1.Text = ex.Message
        End Try

    End Sub

    Private Sub MainForm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

        ' Can use space to pause/resume
        If e.KeyChar = Chr(32) Then
            B_Pause.PerformClick()
        End If

    End Sub

    Private Sub TB_IAClip_TextChanged(sender As Object, e As EventArgs) Handles TB_IntroClip.TextChanged, TB_AlwaysPlay.TextChanged

        Dim TB As TextBox = sender

        StatusLabel1.Text = ""

        If Not String.IsNullOrEmpty(TB.Text) Then

            For Each sFile As String In TB.Text.Replace(vbLf, "").Split(vbCr)

                If Not File.Exists(sFile) Then
                    StatusLabel1.Text = "Video clip not found"
                End If

            Next
        End If

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CB_EasyPeazy.CheckedChanged

        Dim CB As CheckBox = sender

        'TB_NumClips.Enabled = Not CB.Checked
        TB_PercNew.Enabled = Not CB.Checked
        TB_PercOld.Enabled = Not CB.Checked
        TB_AgeNew.Enabled = Not CB.Checked

        'Label2.Enabled = Not CB.Checked
        Label3.Enabled = Not CB.Checked
        Label4.Enabled = Not CB.Checked
        Label6.Enabled = Not CB.Checked

    End Sub

    Private Sub CB_Lock_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Lock.CheckedChanged

        Dim CB As CheckBox = sender

        TB_ViewerTitle.Enabled = Not CB.Checked
        TB_VWidth.Enabled = Not CB.Checked
        TB_VHeight.Enabled = Not CB.Checked

    End Sub

End Class
