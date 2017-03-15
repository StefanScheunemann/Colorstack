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
        Me.cmdLeft = New System.Windows.Forms.Button()
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.cmdRight = New System.Windows.Forms.Button()
        Me.cmdPause = New System.Windows.Forms.Button()
        Me.PanLinks = New System.Windows.Forms.Panel()
        Me.PanRechts = New System.Windows.Forms.Panel()
        Me.PanUnten = New System.Windows.Forms.Panel()
        Me.timer = New System.Windows.Forms.Timer(Me.components)
        Me.Counter = New System.Windows.Forms.Label()
        Me.Highscore = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdLeft
        '
        Me.cmdLeft.Location = New System.Drawing.Point(16, 15)
        Me.cmdLeft.Name = "cmdLeft"
        Me.cmdLeft.Size = New System.Drawing.Size(40, 28)
        Me.cmdLeft.TabIndex = 0
        Me.cmdLeft.Text = "Links"
        Me.cmdLeft.UseVisualStyleBackColor = True
        '
        'cmdDown
        '
        Me.cmdDown.Location = New System.Drawing.Point(65, 50)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(40, 28)
        Me.cmdDown.TabIndex = 1
        Me.cmdDown.Text = "Unten"
        Me.cmdDown.UseVisualStyleBackColor = True
        '
        'cmdRight
        '
        Me.cmdRight.Location = New System.Drawing.Point(96, 15)
        Me.cmdRight.Name = "cmdRight"
        Me.cmdRight.Size = New System.Drawing.Size(40, 28)
        Me.cmdRight.TabIndex = 2
        Me.cmdRight.Text = "Rechts"
        Me.cmdRight.UseVisualStyleBackColor = True
        '
        'cmdPause
        '
        Me.cmdPause.Location = New System.Drawing.Point(70, 350)
        Me.cmdPause.Name = "cmdPause"
        Me.cmdPause.Size = New System.Drawing.Size(70, 28)
        Me.cmdPause.TabIndex = 3
        Me.cmdPause.Text = "Pause"
        Me.cmdPause.UseVisualStyleBackColor = True
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
        Me.Counter.Location = New System.Drawing.Point(150, 50)
        Me.Counter.Name = "Counter"
        Me.Counter.Size = New System.Drawing.Size(18, 20)
        Me.Counter.TabIndex = 5
        Me.Counter.Text = "0"
        '
        'Highscore
        '
        Me.Highscore.AutoSize = True
        Me.Highscore.Location = New System.Drawing.Point(150, 15)
        Me.Highscore.Name = "Highscore"
        Me.Highscore.Size = New System.Drawing.Size(81, 20)
        Me.Highscore.TabIndex = 6
        Me.Highscore.Text = "Highscore"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(205, 394)
        Me.Controls.Add(Me.Highscore)
        Me.Controls.Add(Me.Counter)
        Me.Controls.Add(Me.PanRechts)
        Me.Controls.Add(Me.PanUnten)
        Me.Controls.Add(Me.PanLinks)
        Me.Controls.Add(Me.cmdPause)
        Me.Controls.Add(Me.cmdRight)
        Me.Controls.Add(Me.cmdDown)
        Me.Controls.Add(Me.cmdLeft)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdLeft As Button
    Friend WithEvents cmdDown As Button
    Friend WithEvents cmdRight As Button
    Friend WithEvents cmdPause As Button
    Friend WithEvents PanLinks As Panel
    Friend WithEvents PanRechts As Panel
    Friend WithEvents PanUnten As Panel
    Friend WithEvents timer As Timer
    Friend WithEvents Counter As Label
    Friend WithEvents Highscore As Label
End Class
