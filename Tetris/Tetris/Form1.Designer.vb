<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.panUnten = New System.Windows.Forms.Panel()
        Me.timT = New System.Windows.Forms.Timer(Me.components)
        Me.panRechts = New System.Windows.Forms.Panel()
        Me.panLinks = New System.Windows.Forms.Panel()
        Me.cmdPause = New System.Windows.Forms.Button()
        Me.cmdRechts = New System.Windows.Forms.Button()
        Me.cmdUnten = New System.Windows.Forms.Button()
        Me.cmdLinks = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'panUnten
        '
        Me.panUnten.BackColor = System.Drawing.Color.Black
        Me.panUnten.Location = New System.Drawing.Point(20, 340)
        Me.panUnten.Name = "panUnten"
        Me.panUnten.Size = New System.Drawing.Size(160, 1)
        Me.panUnten.TabIndex = 26
        '
        'timT
        '
        Me.timT.Enabled = True
        Me.timT.Interval = 500
        '
        'panRechts
        '
        Me.panRechts.BackColor = System.Drawing.Color.Black
        Me.panRechts.Location = New System.Drawing.Point(180, 80)
        Me.panRechts.Name = "panRechts"
        Me.panRechts.Size = New System.Drawing.Size(1, 260)
        Me.panRechts.TabIndex = 25
        '
        'panLinks
        '
        Me.panLinks.BackColor = System.Drawing.Color.Black
        Me.panLinks.Location = New System.Drawing.Point(20, 80)
        Me.panLinks.Name = "panLinks"
        Me.panLinks.Size = New System.Drawing.Size(1, 260)
        Me.panLinks.TabIndex = 24
        '
        'cmdPause
        '
        Me.cmdPause.Location = New System.Drawing.Point(70, 350)
        Me.cmdPause.Name = "cmdPause"
        Me.cmdPause.Size = New System.Drawing.Size(70, 28)
        Me.cmdPause.TabIndex = 23
        Me.cmdPause.Text = "Pause"
        Me.cmdPause.UseVisualStyleBackColor = True
        '
        'cmdRechts
        '
        Me.cmdRechts.Location = New System.Drawing.Point(96, 15)
        Me.cmdRechts.Name = "cmdRechts"
        Me.cmdRechts.Size = New System.Drawing.Size(40, 28)
        Me.cmdRechts.TabIndex = 22
        Me.cmdRechts.Text = "Re"
        Me.cmdRechts.UseVisualStyleBackColor = True
        '
        'cmdUnten
        '
        Me.cmdUnten.Location = New System.Drawing.Point(56, 50)
        Me.cmdUnten.Name = "cmdUnten"
        Me.cmdUnten.Size = New System.Drawing.Size(40, 28)
        Me.cmdUnten.TabIndex = 21
        Me.cmdUnten.Text = "Dr"
        Me.cmdUnten.UseVisualStyleBackColor = True
        '
        'cmdLinks
        '
        Me.cmdLinks.Location = New System.Drawing.Point(16, 15)
        Me.cmdLinks.Name = "cmdLinks"
        Me.cmdLinks.Size = New System.Drawing.Size(40, 28)
        Me.cmdLinks.TabIndex = 20
        Me.cmdLinks.Text = "Li"
        Me.cmdLinks.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(209, 401)
        Me.Controls.Add(Me.panUnten)
        Me.Controls.Add(Me.panRechts)
        Me.Controls.Add(Me.panLinks)
        Me.Controls.Add(Me.cmdPause)
        Me.Controls.Add(Me.cmdRechts)
        Me.Controls.Add(Me.cmdUnten)
        Me.Controls.Add(Me.cmdLinks)
        Me.Name = "Form1"
        Me.Text = "Tetris"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panUnten As System.Windows.Forms.Panel
    Friend WithEvents timT As System.Windows.Forms.Timer
    Friend WithEvents panRechts As System.Windows.Forms.Panel
    Friend WithEvents panLinks As System.Windows.Forms.Panel
    Friend WithEvents cmdPause As System.Windows.Forms.Button
    Friend WithEvents cmdRechts As System.Windows.Forms.Button
    Friend WithEvents cmdUnten As System.Windows.Forms.Button
    Friend WithEvents cmdLinks As System.Windows.Forms.Button

End Class
