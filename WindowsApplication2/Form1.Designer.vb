<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.TimerStartUp = New System.Windows.Forms.Timer(Me.components)
        Me.TimerIncreaseOpacity = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TimerDecreaseOpacity = New System.Windows.Forms.Timer(Me.components)
        Me.TimerGrowHeight = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowSpotifyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompactModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HideToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TimerShrinkHeight = New System.Windows.Forms.Timer(Me.components)
        Me.TimerGetTrack = New System.Windows.Forms.Timer(Me.components)
        Me.lblTrack = New System.Windows.Forms.Label()
        Me.btnPrev = New System.Windows.Forms.PictureBox()
        Me.btnPlay = New System.Windows.Forms.PictureBox()
        Me.btnNext = New System.Windows.Forms.PictureBox()
        Me.btnExpand = New System.Windows.Forms.PictureBox()
        Me.TimerChangeWindowWidth = New System.Windows.Forms.Timer(Me.components)
        Me.TimerPositionWindow = New System.Windows.Forms.Timer(Me.components)
        Me.TimerHoverOff = New System.Windows.Forms.Timer(Me.components)
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TimerExit = New System.Windows.Forms.Timer(Me.components)
        Me.TimerHide = New System.Windows.Forms.Timer(Me.components)
        Me.TimerDragMe = New System.Windows.Forms.Timer(Me.components)
        Me.TimerPositionWindowY = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.btnPrev, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnPlay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnNext, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnExpand, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TimerStartUp
        '
        Me.TimerStartUp.Enabled = True
        Me.TimerStartUp.Interval = 1
        '
        'TimerIncreaseOpacity
        '
        Me.TimerIncreaseOpacity.Interval = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Lucida Sans", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(98, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = " "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TimerDecreaseOpacity
        '
        Me.TimerDecreaseOpacity.Interval = 1
        '
        'TimerGrowHeight
        '
        Me.TimerGrowHeight.Interval = 1
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowSpotifyToolStripMenuItem, Me.CompactModeToolStripMenuItem, Me.HideToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(158, 92)
        '
        'ShowSpotifyToolStripMenuItem
        '
        Me.ShowSpotifyToolStripMenuItem.Name = "ShowSpotifyToolStripMenuItem"
        Me.ShowSpotifyToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.ShowSpotifyToolStripMenuItem.Text = "Show Spotify"
        '
        'CompactModeToolStripMenuItem
        '
        Me.CompactModeToolStripMenuItem.Name = "CompactModeToolStripMenuItem"
        Me.CompactModeToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.CompactModeToolStripMenuItem.Text = "Compact Mode"
        '
        'HideToolStripMenuItem
        '
        Me.HideToolStripMenuItem.Name = "HideToolStripMenuItem"
        Me.HideToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.HideToolStripMenuItem.Text = "Hide"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'TimerShrinkHeight
        '
        Me.TimerShrinkHeight.Interval = 1
        '
        'TimerGetTrack
        '
        Me.TimerGetTrack.Enabled = True
        Me.TimerGetTrack.Interval = 250
        '
        'lblTrack
        '
        Me.lblTrack.AutoSize = True
        Me.lblTrack.BackColor = System.Drawing.Color.Transparent
        Me.lblTrack.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTrack.ForeColor = System.Drawing.Color.White
        Me.lblTrack.Location = New System.Drawing.Point(98, 4)
        Me.lblTrack.Name = "lblTrack"
        Me.lblTrack.Size = New System.Drawing.Size(11, 14)
        Me.lblTrack.TabIndex = 8
        Me.lblTrack.Text = " "
        '
        'btnPrev
        '
        Me.btnPrev.BackColor = System.Drawing.Color.Transparent
        Me.btnPrev.Image = CType(resources.GetObject("btnPrev.Image"), System.Drawing.Image)
        Me.btnPrev.Location = New System.Drawing.Point(4, 0)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(29, 38)
        Me.btnPrev.TabIndex = 9
        Me.btnPrev.TabStop = False
        '
        'btnPlay
        '
        Me.btnPlay.Image = Global.WindowsApplication1.My.Resources.Resources.play2
        Me.btnPlay.Location = New System.Drawing.Point(33, 0)
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(35, 38)
        Me.btnPlay.TabIndex = 10
        Me.btnPlay.TabStop = False
        '
        'btnNext
        '
        Me.btnNext.Image = CType(resources.GetObject("btnNext.Image"), System.Drawing.Image)
        Me.btnNext.Location = New System.Drawing.Point(68, 0)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(29, 38)
        Me.btnNext.TabIndex = 11
        Me.btnNext.TabStop = False
        '
        'btnExpand
        '
        Me.btnExpand.Image = Global.WindowsApplication1.My.Resources.Resources.exp1
        Me.btnExpand.Location = New System.Drawing.Point(132, 0)
        Me.btnExpand.Name = "btnExpand"
        Me.btnExpand.Size = New System.Drawing.Size(18, 38)
        Me.btnExpand.TabIndex = 12
        Me.btnExpand.TabStop = False
        '
        'TimerChangeWindowWidth
        '
        Me.TimerChangeWindowWidth.Interval = 1
        '
        'TimerPositionWindow
        '
        Me.TimerPositionWindow.Interval = 1
        '
        'TimerHoverOff
        '
        Me.TimerHoverOff.Enabled = True
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.Silver
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Location = New System.Drawing.Point(12, 43)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(119, 13)
        Me.TextBox1.TabIndex = 14
        Me.TextBox1.Text = "Search..."
        '
        'TimerExit
        '
        Me.TimerExit.Interval = 1
        '
        'TimerHide
        '
        Me.TimerHide.Interval = 1
        '
        'TimerDragMe
        '
        Me.TimerDragMe.Interval = 1
        '
        'TimerPositionWindowY
        '
        Me.TimerPositionWindowY.Interval = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(1, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 14)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Compact mode"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(1, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 14)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Hide"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(1, 130)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 14)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Exit"
        '
        'Form1
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(150, 360)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.btnExpand)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnPlay)
        Me.Controls.Add(Me.btnPrev)
        Me.Controls.Add(Me.lblTrack)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = New System.Drawing.Point(600, 0)
        Me.Name = "Form1"
        Me.Opacity = 0.0R
        Me.ShowInTaskbar = False
        Me.Text = "Form1"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.btnPrev, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnPlay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnNext, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnExpand, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TimerStartUp As System.Windows.Forms.Timer
    Friend WithEvents TimerIncreaseOpacity As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TimerDecreaseOpacity As System.Windows.Forms.Timer
    Friend WithEvents TimerGrowHeight As System.Windows.Forms.Timer
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TimerShrinkHeight As System.Windows.Forms.Timer
    Friend WithEvents TimerGetTrack As System.Windows.Forms.Timer
    Friend WithEvents lblTrack As System.Windows.Forms.Label
    Friend WithEvents btnPrev As System.Windows.Forms.PictureBox
    Friend WithEvents btnPlay As System.Windows.Forms.PictureBox
    Friend WithEvents btnNext As System.Windows.Forms.PictureBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents btnExpand As System.Windows.Forms.PictureBox
    Friend WithEvents TimerChangeWindowWidth As System.Windows.Forms.Timer
    Friend WithEvents TimerPositionWindow As System.Windows.Forms.Timer
    Friend WithEvents TimerHoverOff As System.Windows.Forms.Timer
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TimerExit As System.Windows.Forms.Timer
    Friend WithEvents TimerHide As System.Windows.Forms.Timer
    Friend WithEvents TimerDragMe As System.Windows.Forms.Timer
    Friend WithEvents TimerPositionWindowY As System.Windows.Forms.Timer
    Friend WithEvents HideToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowSpotifyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CompactModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label

End Class
