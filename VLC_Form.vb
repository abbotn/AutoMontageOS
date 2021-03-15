Imports System.ComponentModel
Imports LibVLCSharp.Shared

Public Class VLC_Form

    Dim libVLC As LibVLC

    Public Function PlayVideo(Filename As String) As String

        PlayVideo = ""

        Try
            VideoView1.MediaPlayer.Media = New Media(libVLC, Filename.ToString, FromType.FromPath)
            VideoView1.MediaPlayer.Play()
        Catch ex As Exception
            PlayVideo = ex.Message
        End Try

    End Function

    Public Property IsPaused As Boolean
        Set(value As Boolean)
            If value Then
                VideoView1.MediaPlayer.Pause()
            Else
                VideoView1.MediaPlayer.Play()
            End If
        End Set
        Get
            Return If(VideoView1.MediaPlayer.State = VLCState.Paused, True, False)
        End Get
    End Property


    Public Sub StopVideo()

        VideoView1.MediaPlayer.Stop()

    End Sub

    Public ReadOnly Property IsPlaying() As Boolean
        Get
            Return VideoView1.MediaPlayer.IsPlaying
        End Get
    End Property

    Private Sub VLC_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Core.Initialize()

        libVLC = New LibVLC
        VideoView1.MediaPlayer = New MediaPlayer(libVLC)

        Try
            Me.Width = My.Settings.VLC_FormWidth
            Me.Height = My.Settings.VLC_FormHeight
        Catch ex As Exception

        End Try

    End Sub

    Private Sub VLC_Form_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            MainForm.TB_VWidth.Text = VideoView1.Width.ToString
            MainForm.TB_VHeight.Text = VideoView1.Height.ToString
        Catch ex As Exception

        End Try
    End Sub

    Private Sub VLC_Form_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            If Not MainForm.TB_VWidth.Focused And Not MainForm.TB_VHeight.Focused Then
                MainForm.TB_VWidth.Text = VideoView1.Width.ToString
                MainForm.TB_VHeight.Text = VideoView1.Height.ToString
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub VLC_Form_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        Try
            My.Settings.VLC_FormWidth = Me.Width.ToString
            My.Settings.VLC_FormHeight = Me.Height.ToString
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

        ' Can use space to pause/resume
        If e.KeyChar = Chr(32) Then
            MainForm.B_Pause.PerformClick()
        End If

    End Sub


End Class