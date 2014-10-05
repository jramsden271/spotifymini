Public Class Form1

    Dim MySpotify As New spotify 'for api
    Dim SearchBox As New SearchBox
    Public Form1WindowState As Integer '0 for small, 1 for large, 2 for increasing, 3 for decreasing
    Public OpacityState As Integer '0 for low/idle, 1 for full, 2 for increasing, 3 for falling
    Public ShrinkHeight As Integer 'height of window in idle state
    Public GrowHeight As Integer 'height of window in full state
    Public MinWindowWidth As Integer 'min width of app window
    Public ScreenHeight As Integer 'system screen height
    Public LowOpacity As Single 'inactive opacity level
    Public HighOpacity As Single 'active opacity level
    Public LeftPosition As Integer 'gap between left of window and left of screen
    Public BottomGap As Integer 'gap between bottom of window and bottom of screen
    Dim Artist As String
    Dim TrackName As String
    Dim WelcomeMessage(2) As String 'startup message
    Dim DesiredWindowWidth As Integer 'width the window is to expand to
    Dim HoverWindowWidth As Integer 'width of window upon hovering
    Dim MaxWindowWidth As Integer 'max auto width of window
    Dim MouseHovering As Boolean 'true if mouse is hovering over title
    Dim DesiredLeftPosition As Integer 'desired left position of window
    Public PositionCode As Integer '0 for left, 50 for centre, 100 for right etc
    Public RightGap As Integer 'size of right taskbar
    Public ScreenWidth As Integer 'system screen width
    Dim FormToMouseX As Integer 'used for form drag (distance between mouse and left of form)
    Dim FormToMouseY As Integer
    Dim DoNotReposition As Boolean 'do not reposition the form after dragging
    Dim StartY As Integer 'variables used in Y dragging
    Dim MouseY As Integer
    Dim MouseX As Integer
    Dim StartForm1WindowState As Integer
    Dim MouseButtonDown As Boolean 'true if mouse button is being held down
    Dim DoNotPerformClick As Boolean'used when a button has been held to drag the form, rather than for the button's actual purpose
    Public CompactMode = True
    Dim WindowWidthLockTimer As Integer
    Dim WindowWidthLockTimerThreshold As Integer
    Public Hide0Exit1 As Integer 'used for exit procedure
    Dim HoverMsg(2) As String 'message on hovering
    Dim HoverLockEnterTimer As Integer
    Dim HoverLockLeaveTimer As Integer
    Dim HoverLockThreshold As Integer
    Dim JustClickedOpenSpotify As Boolean 'true if the user has just requested that spotify is opened
    Dim StartPositionCode As Integer 'used to aid flicks in dragging

    Dim tempval As Integer
    Dim tempstring As String

    Private Sub Form1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        If DoNotPerformClick = True Then Exit Sub
        JustClickedOpenSpotify = True

        If MouseHovering = True Then
            MySpotify.ShowSpotify()
            Call ShrinkMe()

        End If


    End Sub




    'form startup
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



        ScreenHeight = Screen.PrimaryScreen.Bounds.Height
        ScreenWidth = Screen.PrimaryScreen.Bounds.Width
        GrowHeight = 200
        MinWindowWidth = 0
        MaxWindowWidth = 0.5 * ScreenWidth
        ShrinkHeight = 38
        LowOpacity = 0.5
        HighOpacity = 1
        Form1WindowState = 0
        LeftPosition = 67
        RightGap = 0
        BottomGap = 0
        PositionCode = 50
        CompactMode = False
        WindowWidthLockTimerThreshold = 3
        WindowWidthLockTimer = WindowWidthLockTimerThreshold
        HoverLockEnterTimer = 0
        HoverLockThreshold = 3
        JustClickedOpenSpotify = False


        Me.Height = ShrinkHeight
        Width = MinWindowWidth
        btnExpand.Left = Width - btnExpand.Width
        Me.Left = LeftPosition
        Me.Top = ScreenHeight - BottomGap - ShrinkHeight

        DesiredWindowWidth = MinWindowWidth
        TimerChangeWindowWidth.Enabled = True


        WelcomeMessage(1) = "Welcome"
        WelcomeMessage(2) = "Please play a track from Spotify"
        HoverMsg(1) = "Open Spotify"
        HoverMsg(2) = "Click here to open Spotify"

        If MySpotify.IsSpotifyRunning = False Then MySpotify.ShowSpotify()
        



    End Sub
    Private Sub TimerStartUp_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerStartUp.Tick

        '"if" fixes bug of flickering at left of screen on startup if position<>1
        If PositionCode = 0 Or Me.Left > LeftPosition + 100 Then Me.Opacity = Me.Opacity + (HighOpacity - Me.Opacity) * 0.01 + 0.02

        If Me.Opacity > 0.995 * HighOpacity Then
            Me.Opacity = HighOpacity
            TimerStartUp.Enabled = False
        End If

    End Sub

    'opacity 
    Private Sub TimerIncreaseOpacity_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerIncreaseOpacity.Tick

        If OpacityState = 2 Then

            If Me.Opacity > 0.99 * HighOpacity Then
                If Me.Opacity <> HighOpacity Then Me.Opacity = HighOpacity
                TimerIncreaseOpacity.Enabled = False
                OpacityState = 1
            Else
                Me.Opacity += (HighOpacity - Me.Opacity) * 0.1
            End If

        Else

            TimerIncreaseOpacity.Enabled = False

        End If

    End Sub
    Private Sub TimerDecreaseOpacity_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerDecreaseOpacity.Tick

        If OpacityState = 3 Then

            If Me.Opacity < 1.01 * LowOpacity Then
                Me.Opacity = LowOpacity
                TimerDecreaseOpacity.Enabled = False
                OpacityState = 0
            Else
                Me.Opacity += (LowOpacity - Me.Opacity) * 0.1
            End If

        Else

            TimerDecreaseOpacity.Enabled = False

        End If

    End Sub

    'grow/shrink 
    Private Sub TimerGrowHeight_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerGrowHeight.Tick

        If Form1WindowState = 2 Then
            If Me.Height = GrowHeight Then
                TimerGrowHeight.Enabled = False
                Form1WindowState = 1
            Else
                Me.Top += -0.15 * (Me.Top - ScreenHeight + GrowHeight + BottomGap) - 1
                Me.Height = ScreenHeight - Me.Top - BottomGap
            End If
        End If

    End Sub
    Private Sub TimerShrinkHeight_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerShrinkHeight.Tick

        If Form1WindowState = 3 Then
            If Me.Height = ShrinkHeight Then
                TimerShrinkHeight.Enabled = False
                Form1WindowState = 0
            Else
                Me.Top += -0.1 * (Me.Top - ScreenHeight + ShrinkHeight + BottomGap) + 1
                Me.Height = ScreenHeight - Me.Top - BottomGap
            End If
        End If

    End Sub
    Public Sub ShrinkMe()

        Form1WindowState = 3
        btnExpand.Image = My.Resources.exp1
        TimerShrinkHeight.Enabled = True

    End Sub
    Public Sub GrowMe()

        Form1WindowState = 2
        btnExpand.Image = My.Resources.exp2
        TimerGrowHeight.Enabled = True

    End Sub
    Private Sub Form1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick

        If Form1WindowState = 0 Or Form1WindowState = 3 Then : GrowMe()
        Else : ShrinkMe()
        End If

    End Sub

    'live updates
    Private Sub TimerGetTrack_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerGetTrack.Tick

        'window stickiness
        If WindowWidthLockTimer < WindowWidthLockTimerThreshold Then
            If MousePosition.X > Me.Left And MousePosition.X < Me.Left + Me.Width And MousePosition.Y > Me.Top And MousePosition.Y < Me.Top + Me.Height Then
                WindowWidthLockTimer = 0
            Else
                WindowWidthLockTimer += 1
            End If
        End If

        tempstring = MySpotify.Nowplaying

        'find location of hyphen
        If MySpotify.Paused = False Then
            For Me.tempval = 0 To Len(tempstring) - 1
                If tempstring.Substring(tempval, 1) = "–" Then Exit For
            Next
        End If

        'detect artist and track name, and assign to labels
        'if hovering
        If MousePosition.X > Me.Left + lblTrack.Left And MousePosition.X < Me.Left + lblTrack.Left + Math.Max(lblTrack.Width, Label1.Width) And MousePosition.Y > Me.Top + lblTrack.Top And MousePosition.Y < Me.Top + ShrinkHeight Then
            MouseHovering = True
            If HoverLockEnterTimer <> HoverLockThreshold Then HoverLockEnterTimer += 1
        Else
            MouseHovering = False
            HoverLockEnterTimer = 0
            JustClickedOpenSpotify = False
        End If

        If JustClickedOpenSpotify = False And CompactMode = False And MySpotify.IsSpotifyRunning <> 0 And MouseHovering = True And DoNotPerformClick = False And HoverLockEnterTimer = HoverLockThreshold Then
            WindowWidthLockTimer = 0
            Label1.Text = HoverMsg(2)
            lblTrack.Text = HoverMsg(1)
            'ifplaying
        ElseIf MySpotify.Paused = False And CompactMode = False Then
            Artist = tempstring.Substring(0, tempval - 1)
            TrackName = tempstring.Substring(tempval + 2, Len(tempstring) - tempval - 2)
            If Label1.Text IsNot Artist Then Label1.Text = Artist
            If lblTrack.Text IsNot TrackName Then lblTrack.Text = TrackName
            'compact mode
        ElseIf CompactMode = True Then
            lblTrack.Text = ""
            Label1.Text = ""
            'normal startup
        ElseIf Artist Is Nothing And lblTrack.Text IsNot WelcomeMessage(1) Then
            lblTrack.Text = WelcomeMessage(1)
            Label1.Text = WelcomeMessage(2)
            'normal paused
        ElseIf MySpotify.Paused = True And MySpotify.IsSpotifyRunning > 0 Then
            If Artist IsNot WelcomeMessage(2) Then
                If Label1.Text IsNot Artist & " (Paused)" Then Label1.Text = Artist & " (Paused)"
            Else : Label1.Text = WelcomeMessage(2)
            End If
            lblTrack.Text = TrackName
            'main program is closed while toolbar still open
        ElseIf MySpotify.IsSpotifyRunning = 0 Then
            Label1.Text = "Attempting to re-open Spotify"
            lblTrack.Text = "Oops!"
            TrackName = WelcomeMessage(1)
            Artist = WelcomeMessage(2)
            MySpotify.ShowSpotify()
        End If





        MySpotify.RefreshConnection()

        'get desired window width
        HoverWindowWidth = Math.Max(lblTrack.Width, Label1.Width)
        HoverWindowWidth += 10 + btnExpand.Width + btnNext.Width + btnPlay.Width + btnPrev.Width

        'dimension window

        If HoverWindowWidth < MinWindowWidth Then
            DesiredWindowWidth = MinWindowWidth
        ElseIf HoverWindowWidth > MaxWindowWidth Then
            DesiredWindowWidth = MaxWindowWidth
        Else
            DesiredWindowWidth = HoverWindowWidth
        End If

        If Width <> DesiredWindowWidth Then TimerChangeWindowWidth.Enabled = True

        If Me.WindowState = FormWindowState.Normal And Me.ShowInTaskbar = True Then ShowInTaskbar = False

        'updates play/pause button
        If MouseButtonDown = False Then
            If MySpotify.Paused = True Then
                If btnPlay.Image IsNot My.Resources.play2 Then btnPlay.Image = My.Resources.play2
            ElseIf MySpotify.Paused = False Then
                If btnPlay.Image IsNot My.Resources.play1 Then btnPlay.Image = My.Resources.play1
            End If
        End If

    End Sub

    'labels/buttons
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        If DoNotPerformClick = True Then Exit Sub
        MySpotify.ShowSpotify()
        Call ShrinkMe()
        JustClickedOpenSpotify = True
    End Sub


    Private Sub btnPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlay.Click
        MySpotify.PlayPause()
        If MySpotify.Paused = True Then btnPlay.Image = My.Resources.play1
        If MySpotify.Paused = False Then btnPlay.Image = My.Resources.play2
    End Sub
    Private Sub btnPlay_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPlay.DoubleClick
        Call btnPlay_Click(Me, System.EventArgs.Empty)
    End Sub
    Private Sub btnPlay_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnPlay.MouseDown
        If MySpotify.Paused = True Then btnPlay.Image = My.Resources.play4
        If MySpotify.Paused = False Then btnPlay.Image = My.Resources.play3
        MouseButtonDown = True
    End Sub
    Private Sub btnExpand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpand.Click

        If Form1WindowState = 0 Then Call GrowMe()
        If Form1WindowState = 1 Then Call ShrinkMe()

    End Sub
    Private Sub lblTrack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTrack.Click
        If DoNotPerformClick = True Then Exit Sub
        MySpotify.ShowSpotify()
        Call ShrinkMe()
        JustClickedOpenSpotify = True
    End Sub
    Private Sub btnNext_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnNext.MouseDown
        MySpotify.PlayNext()
        WindowWidthLockTimer = 0
    End Sub
    Private Sub btnPrev_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnPrev.MouseDown
        MySpotify.PlayPrev()
        WindowWidthLockTimer = 0
    End Sub
    Private Sub btnPlay_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnPlay.MouseUp
        MouseButtonDown = False
        WindowWidthLockTimer = 0
    End Sub

    'mouse hover behaviour
    Private Sub btnExpand_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExpand.MouseEnter

        If Form1WindowState = 0 Or Form1WindowState = 3 Then
            btnExpand.Image = My.Resources.exp3
        Else
            btnExpand.Image = My.Resources.exp4
        End If

    End Sub
    Private Sub btnExpand_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExpand.MouseLeave



        If Form1WindowState = 0 Or Form1WindowState = 3 Then
            btnExpand.Image = My.Resources.exp1
        Else
            btnExpand.Image = My.Resources.exp2
        End If

    End Sub


    'form dragging
    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown

        FormToMouseX = Form1.MousePosition.X - Me.Left
        FormToMouseY = Form1.MousePosition.Y - Me.Top
        TimerDragMe.Enabled = True
        DoNotReposition = False
        StartY = Form1.MousePosition.Y
        StartForm1WindowState = Form1WindowState

    End Sub
    Private Sub TimerDragMe_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerDragMe.Tick

        If lblTrack.Text = HoverMsg(1) Then Exit Sub

        Dim tempval As Integer

        TimerPositionWindow.Enabled = True

        'vertical positioning
        MouseY = Form1.MousePosition.Y
        MouseX = Form1.MousePosition.X

        If StartForm1WindowState = 0 Then
            If MouseY < StartY - 30 And (Form1WindowState = 0 Or Form1WindowState = 3) Then
                GrowMe()
                DoNotPerformClick = True
            ElseIf MouseY > StartY - 1 And (Form1WindowState = 1 Or Form1WindowState = 2) Then
                ShrinkMe()
                DoNotPerformClick = True
            End If
        ElseIf StartForm1WindowState = 1 Then
            If MouseY < StartY And (Form1WindowState = 0 Or Form1WindowState = 3) Then
                GrowMe()
                DoNotPerformClick = True
            ElseIf MouseY > StartY + 10 And (Form1WindowState = 1 Or Form1WindowState = 2) Then
                ShrinkMe()
                DoNotPerformClick = True
            End If
        End If

        'horizontal positioning



        If MouseX < 0.4 * ScreenWidth Then : tempval = 0
        ElseIf MouseX > 0.7 * ScreenWidth Then : tempval = 100
        Else : tempval = 50
        End If

        If tempval <> PositionCode Then
            DoNotPerformClick = tempval
        End If


        PositionCode = tempval

    End Sub
    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp

        TimerDragMe.Enabled = False
        DoNotPerformClick = False

    End Sub

    'misc
    Private Sub Form1_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel

        If TimerPositionWindow.Enabled = False And MousePosition.X > Left And MousePosition.X < (Left + Width) And MousePosition.Y > Top And MousePosition.Y < (Top + Height) Then

            If e.Delta > 0 Then
                PositionCode += 50
            Else
                PositionCode -= 50
            End If

            If PositionCode = 150 Then
                PositionCode = 0
            ElseIf PositionCode = -50 Then
                PositionCode = 100
            End If

            TimerPositionWindow.Enabled = True

        End If

    End Sub
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        hide0exit1 = 1
        TimerStartUp.Enabled = False
        TimerExit.Enabled = True
        Call ShrinkMe()


    End Sub

    'window width
    Private Sub TimerChangeWindowWidth_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerChangeWindowWidth.Tick

        'resize window
        If Width <> DesiredWindowWidth Then

            If Width < DesiredWindowWidth Then
                tempval = 1
            Else
                tempval = -1
            End If

            Width += 0.1 * (DesiredWindowWidth - Width) + tempval
            btnExpand.Left = Width - btnExpand.Width

            'resize during right position
            If WindowWidthLockTimer = WindowWidthLockTimerThreshold Then Left = XPosition(PositionCode)


            TextBox1.Width = Width - 2 * TextBox1.Left

        ElseIf Left <> XPosition(PositionCode) And WindowWidthLockTimer = WindowWidthLockTimerThreshold Then
            TimerPositionWindow.Enabled = True
        ElseIf WindowWidthLockTimer = WindowWidthLockTimerThreshold Then
            TimerChangeWindowWidth.Enabled = False
        End If



    End Sub

    'window position
    Private Sub TimerPositionWindow_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerPositionWindow.Tick
        'If WindowWidthLockTimer <> WindowWidthLockTimerThreshold Then Exit Sub
        tempval = XPosition(PositionCode) - Left

        If tempval > 0 Then
            Left += 0.2 * tempval + 1
        ElseIf tempval < 0 Then
            Left += 0.2 * tempval - 1
        Else
            TimerPositionWindow.Enabled = False
        End If

    End Sub

    'search box
    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress

        If Form1WindowState = 0 Then GrowMe()

        If Asc(e.KeyChar) = Keys.Enter Then
            If TextBox1.Text = "hide" Then : Hide0Exit1 = 0 : TimerExit.Enabled = True
            ElseIf TextBox1.Text = "end" Or TextBox1.Text = "exit" Then : TimerExit.Enabled = True
            Else
                MySpotify.Search(TextBox1.Text, False)
                MySpotify.ShowSpotify()
            End If
            SearchBox.HideTextbox()
        End If

        If Asc(e.KeyChar) = Keys.Escape Then
            Call ShrinkMe()
            Me.TextBox1.Text = "Search..."
        End If

    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    'end
    Private Sub TimerExit_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerExit.Tick
        EndProgram(Hide0Exit1)
    End Sub



    'duplicate actions
    Private Sub lblTrack_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblTrack.MouseDown
        Call Form1_MouseDown(lblTrack, AcceptButton)

    End Sub
    Private Sub lblTrack_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblTrack.MouseUp
        Call Form1_MouseUp(lblTrack, AcceptButton)
    End Sub
    Private Sub Label1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseDown
        Call Form1_MouseDown(Label1, AcceptButton)
    End Sub
    Private Sub Label1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseUp
        Call Form1_MouseUp(Label1, AcceptButton)
    End Sub

    Private Sub HideToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideToolStripMenuItem.Click
        Hide0Exit1 = 0
        TimerExit.Enabled = True

    End Sub

    Private Sub CompactModeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompactModeToolStripMenuItem.Click
        If CompactMode = True Then
            CompactMode = False
            CompactModeToolStripMenuItem.Text = "Compact Mode On"
        Else
            CompactMode = True
            CompactModeToolStripMenuItem.Text = "Compact Mode Off"
        End If
    End Sub

    Private Sub ShowSpotifyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowSpotifyToolStripMenuItem.Click
        MySpotify.ShowSpotify()
    End Sub

    
    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        If CompactMode = True Then
            CompactMode = False
        Else : CompactMode = True
        End If
        ShrinkMe()
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click


        Hide0Exit1 = 0
        TimerExit.Enabled = True

    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        Hide0Exit1 = 1
        TimerExit.Enabled = True
    End Sub
End Class


