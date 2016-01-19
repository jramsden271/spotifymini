' Spotify API V0.01 beta - a very quick First draft
' © august 3 2009 by Steffest
' This code is free to use in any way you want and comes with NO WARRANTIES
' tested with Spotify 0.3.18
' Usage:
' 
' Dim Spotify As New Spotify()
' 
' Spotify.PlayPause()
' Spotify.PlayPrev()
' Spotify.PlayNext()
' Spotify.Mute()
' Spotify.VolumeUp()
' Spotify.VolumeDown()
' Spotify.Nowplaying() (Gets the name of the current playing track)
' Spotify.Search("Artist",False) (Searches for "Artist")
' Spotify.Search("Artist",True) (Searches for "Artist" and starts playing the results)



Public Class spotify

#Region " win32 "
    Private Declare Auto Function FindWindow Lib "user32" (ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    Private Declare Auto Function SendMessage Lib "user32" (ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    Private Declare Auto Function SetForegroundWindow Lib "user32" (ByVal hWnd As IntPtr) As Boolean
    Private Declare Auto Function keybd_event Lib "user32" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Integer, ByVal dwExtraInfo As Integer) As Boolean
    Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)
    Private Declare Auto Function GetWindowText Lib "user32" (ByVal hwnd As IntPtr, ByVal lpString As String, ByVal cch As IntPtr) As IntPtr
    Private Declare Auto Function SetWindowText Lib "user32" (ByVal hwnd As IntPtr, ByVal lpString As String) As Boolean
    Private Declare Auto Function EnumChildWindows Lib "user32" (ByVal hWndParent As Long, ByVal lpEnumFunc As Long, ByVal lParam As Long) As Long
#End Region

#Region " constants "
    Private Const WM_KEYDOWN = &H100
    Private Const WM_KEYUP = &H101
    Private Const WM_MOUSEACTIVATE = &H21
    Private Const KEYEVENTF_EXTENDEDKEY As Integer = &H1S
    Private Const KEYEVENTF_KEYUP As Integer = &H2S
#End Region

    Private w As Integer

    Public Sub New()
        w = FindWindow("SpotifyMainWindow", vbNullString)
    End Sub

    Public Function RefreshConnection() As Boolean
        w = FindWindow("SpotifyMainWindow", vbNullString)
    End Function

    Public Function IsSpotifyRunning() As Integer
        Return w
    End Function

    Public Function PlayPause() As Boolean
        SetForegroundWindow(w)
        keybd_event(Keys.Space, &H1D, 0, 0)
        keybd_event(Keys.Space, &H1D, KEYEVENTF_KEYUP, 0)
    End Function

    Public Function PlayPrev() As Boolean
        ' for some reason the PostMessage(w, WM_KEYDOWN, Keys.MediaNextTrack, 0) doesn't work
        ' sending ctrl+ commands to a windows still is a PITA ...
        SetForegroundWindow(w)
        keybd_event(Keys.ControlKey, &H1D, 0, 0)
        keybd_event(Keys.Left, &H45S, KEYEVENTF_EXTENDEDKEY Or 0, 0)
        keybd_event(Keys.Left, &H45S, KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)
        Sleep(100) ' wait until spotify has trapped the control key before releasing it
        keybd_event(Keys.ControlKey, &H1D, KEYEVENTF_KEYUP, 0)
    End Function

    Public Function ShowNowPlaying() As Boolean
        SetForegroundWindow(w)

        keybd_event(Keys.ControlKey, &H1D, 0, 0)
        keybd_event(Keys.N, &H45S, 0, 0)
        keybd_event(Keys.N, &H45S, KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)
        Sleep(50)
        keybd_event(Keys.ControlKey, &H1D, KEYEVENTF_KEYUP, 0)

        keybd_event(Keys.Escape, &H45S, 0, 0)
        keybd_event(Keys.Escape, &H45S, KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)

        keybd_event(Keys.Up, &H45S, KEYEVENTF_EXTENDEDKEY Or 0, 0)
        keybd_event(Keys.Up, &H45S, KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)
        keybd_event(Keys.PageUp, &H45S, KEYEVENTF_EXTENDEDKEY Or 0, 0)
        keybd_event(Keys.PageUp, &H45S, KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)
        keybd_event(Keys.PageUp, &H45S, KEYEVENTF_EXTENDEDKEY Or 0, 0)
        keybd_event(Keys.PageUp, &H45S, KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)

        keybd_event(Keys.Down, &H45S, KEYEVENTF_EXTENDEDKEY Or 0, 0)
        keybd_event(Keys.Down, &H45S, KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)
        keybd_event(Keys.Down, &H45S, KEYEVENTF_EXTENDEDKEY Or 0, 0)
        keybd_event(Keys.Down, &H45S, KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)
        'Shell("C:/Program Files/Spotify/spotify.exe") FIXME - Spotify now saved in user folder
    End Function

    Public Function ShowSpotify() As Boolean
        'If IntPtr.Size = 4 Then : Shell("C:/Program Files/Spotify/spotify.exe") FIXME - Spotify now saved in user folder
        'ElseIf IntPtr.Size = 8 Then : Shell("C:/Program Files (x86)/Spotify/spotify.exe")FIXME - Spotify now saved in user folder
        'End If

        SetForegroundWindow(w)
        keybd_event(Keys.Enter, 0, 0, 0)

    End Function

    Public Function PlayNext() As Boolean
        SetForegroundWindow(w)
        keybd_event(Keys.ControlKey, &H1D, 0, 0)
        keybd_event(Keys.Right, &H45S, KEYEVENTF_EXTENDEDKEY Or 0, 0)
        keybd_event(Keys.Right, &H45S, KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)
        Sleep(100) ' wait until spotify has trapped the control key before releasing it
        keybd_event(Keys.ControlKey, &H1D, KEYEVENTF_KEYUP, 0)
    End Function

    Public Function VolumeUp() As Boolean
        SetForegroundWindow(w)
        keybd_event(Keys.ControlKey, &H1D, 0, 0)
        keybd_event(Keys.Up, &H45S, KEYEVENTF_EXTENDEDKEY Or 0, 0)
        keybd_event(Keys.Up, &H45S, KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)
        Sleep(100) ' wait until spotify has trapped the control key before releasing it
        keybd_event(Keys.ControlKey, &H1D, KEYEVENTF_KEYUP, 0)
    End Function

    Public Function Mute() As Boolean
        SetForegroundWindow(w)
        keybd_event(Keys.ControlKey, &H1D, 0, 0)
        keybd_event(Keys.ShiftKey, &H1D, 0, 0)
        keybd_event(Keys.Down, &H45S, KEYEVENTF_EXTENDEDKEY Or 0, 0)
        keybd_event(Keys.Down, &H45S, KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)
        Sleep(100) ' wait until spotify has trapped the control key before releasing it
        keybd_event(Keys.ShiftKey, &H1D, KEYEVENTF_KEYUP, 0)
        keybd_event(Keys.ControlKey, &H1D, KEYEVENTF_KEYUP, 0)
    End Function

    Public Function VolumeDown() As Boolean
        SetForegroundWindow(w)
        keybd_event(Keys.ControlKey, &H1D, 0, 0)
        keybd_event(Keys.Down, &H45S, KEYEVENTF_EXTENDEDKEY Or 0, 0)
        keybd_event(Keys.Down, &H45S, KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)
        Sleep(100) ' wait until spotify has trapped the control key before releasing it
        keybd_event(Keys.ControlKey, &H1D, KEYEVENTF_KEYUP, 0)
    End Function

    Public Function Nowplaying() As String
        Dim lpText As String
        lpText = New String(Chr(0), 200)
        Dim intLength As Integer = GetWindowText(w, lpText, lpText.Length)
        If (intLength <= 0) OrElse (intLength > lpText.Length) OrElse Not (lpText.IndexOf("Spotify") = -1) Then Return "Not Playing"
        Dim strTitle As String = lpText
        Return strTitle
    End Function

    Public Function Paused() As Boolean
        If Nowplaying() = "Not Playing" Or Nowplaying() = "" Then
            Return True
        Else : Return False
        End If
    End Function

    Public Function Search(ByVal s As String, ByVal AndPlay As Boolean) As Boolean
        SetForegroundWindow(w)
        keybd_event(Keys.ControlKey, &H1D, 0, 0)
        keybd_event(Keys.L, &H45S, KEYEVENTF_EXTENDEDKEY Or 0, 0)
        keybd_event(Keys.L, &H45S, KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)
        Sleep(100) ' wait until spotify has trapped the control key before releasing it
        keybd_event(Keys.ControlKey, &H1D, KEYEVENTF_KEYUP, 0)

        SendKeys.SendWait(s & Chr(13))

        If AndPlay Then
            ' this is a bit stupid but works in this version: press tab twice, then enter
            Sleep(100)
            SendKeys.SendWait(Chr(9) & Chr(9) & Chr(13))
        End If

    End Function

End Class
