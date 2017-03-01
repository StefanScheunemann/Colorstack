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
        Me.cmdLinks = New System.Windows.Forms.Button()
        Me.cmdUnten = New System.Windows.Forms.Button()
        Me.cmdRechts = New System.Windows.Forms.Button()
        Me.cmdPause = New System.Windows.Forms.Button()
        Me.PanLinks = New System.Windows.Forms.Panel()
        Me.PanRechts = New System.Windows.Forms.Panel()
        Me.PanUnten = New System.Windows.Forms.Panel()
        Me.timer = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'cmdLinks
        '
        Me.cmdLinks.Location = New System.Drawing.Point(16, 15)
        Me.cmdLinks.Name = "cmdLinks"
        Me.cmdLinks.Size = New System.Drawing.Size(40, 28)
        Me.cmdLinks.TabIndex = 0
        Me.cmdLinks.Text = "Links"
        Me.cmdLinks.UseVisualStyleBackColor = True
        '
        'cmdUnten
        '
        Me.cmdUnten.Location = New System.Drawing.Point(65, 50)
        Me.cmdUnten.Name = "cmdUnten"
        Me.cmdUnten.Size = New System.Drawing.Size(40, 28)
        Me.cmdUnten.TabIndex = 1
        Me.cmdUnten.Text = "Unten"
        Me.cmdUnten.UseVisualStyleBackColor = True
        '
        'cmdRechts
        '
        Me.cmdRechts.Location = New System.Drawing.Point(96, 15)
        Me.cmdRechts.Name = "cmdRechts"
        Me.cmdRechts.Size = New System.Drawing.Size(40, 28)
        Me.cmdRechts.TabIndex = 2
        Me.cmdRechts.Text = "Rechts"
        Me.cmdRechts.UseVisualStyleBackColor = True
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
        Me.timer.Interval = 500
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(205, 394)
        Me.Controls.Add(Me.PanRechts)
        Me.Controls.Add(Me.PanUnten)
        Me.Controls.Add(Me.PanLinks)
        Me.Controls.Add(Me.cmdPause)
        Me.Controls.Add(Me.cmdRechts)
        Me.Controls.Add(Me.cmdUnten)
        Me.Controls.Add(Me.cmdLinks)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmdLinks As Button
    Friend WithEvents cmdUnten As Button
    Friend WithEvents cmdRechts As Button
    Friend WithEvents cmdPause As Button
    Friend WithEvents PanLinks As Panel
    Friend WithEvents PanRechts As Panel
    Friend WithEvents PanUnten As Panel
    Friend WithEvents timer As Timer
End Class
