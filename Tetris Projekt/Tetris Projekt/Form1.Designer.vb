<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Left = New System.Windows.Forms.Button()
        Me.Down = New System.Windows.Forms.Button()
        Me.Right = New System.Windows.Forms.Button()
        Me.Pause = New System.Windows.Forms.Button()
        Me.PanLinks = New System.Windows.Forms.Panel()
        Me.PanRechts = New System.Windows.Forms.Panel()
        Me.PanUnten = New System.Windows.Forms.Panel()
        Me.timer = New System.Windows.Forms.Timer(Me.components)
        Me.Counter = New System.Windows.Forms.Label()
        Me.Highscore = New System.Windows.Forms.Label()
        Me.BestPlayer = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Left
        '
        Me.Left.Location = New System.Drawing.Point(16, 15)
        Me.Left.Name = "Left"
        Me.Left.Size = New System.Drawing.Size(40, 28)
        Me.Left.TabIndex = 0
        Me.Left.Text = "Links"
        Me.Left.UseVisualStyleBackColor = True
        '
        'Down
        '
        Me.Down.Location = New System.Drawing.Point(65, 50)
        Me.Down.Name = "Down"
        Me.Down.Size = New System.Drawing.Size(40, 28)
        Me.Down.TabIndex = 1
        Me.Down.Text = "Unten"
        Me.Down.UseVisualStyleBackColor = True
        '
        'Right
        '
        Me.Right.Location = New System.Drawing.Point(96, 15)
        Me.Right.Name = "Right"
        Me.Right.Size = New System.Drawing.Size(40, 28)
        Me.Right.TabIndex = 2
        Me.Right.Text = "Rechts"
        Me.Right.UseVisualStyleBackColor = True
        '
        'Pause
        '
        Me.Pause.Location = New System.Drawing.Point(70, 350)
        Me.Pause.Name = "Pause"
        Me.Pause.Size = New System.Drawing.Size(70, 28)
        Me.Pause.TabIndex = 3
        Me.Pause.Text = "Pause"
        Me.Pause.UseVisualStyleBackColor = True
        '
        'PanLinks
        '
        Me.PanLinks.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.PanLinks.Location = New System.Drawing.Point(20, 80)
        Me.PanLinks.Name = "PanLinks"
        Me.PanLinks.Size = New System.Drawing.Size(1, 260)
        Me.PanLinks.TabIndex = 4
        '
        'PanRechts
        '
        Me.PanRechts.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.PanRechts.Location = New System.Drawing.Point(180, 80)
        Me.PanRechts.Name = "PanRechts"
        Me.PanRechts.Size = New System.Drawing.Size(1, 260)
        Me.PanRechts.TabIndex = 0
        '
        'PanUnten
        '
        Me.PanUnten.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.PanUnten.Location = New System.Drawing.Point(20, 340)
        Me.PanUnten.Name = "PanUnten"
        Me.PanUnten.Size = New System.Drawing.Size(160, 1)
        Me.PanUnten.TabIndex = 0
        '
        'timer
        '
        Me.timer.Enabled = True
        Me.timer.Interval = 500
        '
        'Counter
        '
        Me.Counter.AutoSize = True
        Me.Counter.Location = New System.Drawing.Point(185, 350)
        Me.Counter.Name = "Counter"
        Me.Counter.Size = New System.Drawing.Size(18, 20)
        Me.Counter.TabIndex = 5
        Me.Counter.Text = "0"
        '
        'Highscore
        '
        Me.Highscore.AutoSize = True
        Me.Highscore.Location = New System.Drawing.Point(185, 19)
        Me.Highscore.Name = "Highscore"
        Me.Highscore.Size = New System.Drawing.Size(81, 20)
        Me.Highscore.TabIndex = 6
        Me.Highscore.Text = "Highscore"
        '
        'BestPlayer
        '
        Me.BestPlayer.AutoSize = True
        Me.BestPlayer.Location = New System.Drawing.Point(185, 50)
        Me.BestPlayer.Name = "BestPlayer"
        Me.BestPlayer.Size = New System.Drawing.Size(109, 20)
        Me.BestPlayer.TabIndex = 7
        Me.BestPlayer.Text = "Bester Spieler"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(278, 384)
        Me.Controls.Add(Me.BestPlayer)
        Me.Controls.Add(Me.Highscore)
        Me.Controls.Add(Me.Counter)
        Me.Controls.Add(Me.PanRechts)
        Me.Controls.Add(Me.PanUnten)
        Me.Controls.Add(Me.PanLinks)
        Me.Controls.Add(Me.Pause)
        Me.Controls.Add(Me.Right)
        Me.Controls.Add(Me.Down)
        Me.Controls.Add(Me.Left)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Left As Button
    Friend WithEvents Down As Button
    Friend WithEvents Right As Button
    Friend WithEvents Pause As Button
    Friend WithEvents PanLinks As Panel
    Friend WithEvents PanRechts As Panel
    Friend WithEvents PanUnten As Panel
    Friend WithEvents timer As Timer
    Friend WithEvents Counter As Label
    Friend WithEvents Highscore As Label
    Friend WithEvents BestPlayer As Label
End Class
