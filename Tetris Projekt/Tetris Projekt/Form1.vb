Public Class Form1
    Dim PX As Integer ' Index des aktiven Panels
    Dim F(14, 9) As Integer ' Spielfeld mit Rand
    Dim PZ As Integer ' Zeile des aktiven Panels
    Dim PS As Integer ' Spalte des aktiven Panels
    Dim Stufe As Integer ' Schwierigkeitsgrad
    Dim PL As New ArrayList ' leeres Spielfeld
    Dim FarbenFeld() As Color = {Color.Red, ' Verschiedene Farben der Blöcke
        Color.Yellow,
        Color.Green,
        Color.Blue,
        Color.Orange,
        Color.Magenta,
        Color.Black,
        Color.White}
    Const Leer = -1 ' Feld leer
    Const Rand = -2 ' Randfeld

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Z, S As Integer

        Me.Size = New Size(225, 440) ' Größe und Ort
        cmdLinks.Size = New Size(40, 28)
        cmdLinks.Location = New Point(16, 15)
        cmdRechts.Size = New Size(40, 28)
        cmdRechts.Location = New Point(96, 15)
        cmdUnten.Size = New Size(40, 28)
        cmdUnten.Location = New Point(56, 50)
        panLinks.Size = New Size(1, 260)
        panLinks.Location = New Point(20, 80)
        panRechts.Size = New Size(1, 260)
        panRechts.Location = New Point(180, 80)
        panUnten.Size = New Size(160, 1)
        panUnten.Location = New Point(20, 340)
        cmdPause.Size = New Size(70, 28)
        cmdPause.Location = New Point(70, 350)

        Randomize() ' Zufallsgenerator
        For Z = 1 To 13 ' Feld mit Panel besetzen
            F(Z, 0) = Rand
            For S = 1 To 8
                F(Z, S) = Leer
            Next S
            F(Z, 9) = Rand
        Next Z

        For S = 0 To 9
            F(14, S) = Rand
        Next S

        Stufe = 1 ' Initialisierung
        NächstesPanel()

    End Sub

    Private Sub NächstesPanel()
        Dim Farbe As Integer
        Dim p As New Panel

        PL.Add(p) ' Panel zur ArraryList hinzufügen

        p.Location = New Point(100, 80) ' Panel platzieren
        p.Size = New Point(20, 20)

        Farbe = Math.Floor(Rnd() * 8) ' Zufällige Farbe des Panels
        p.BackColor = FarbenFeld(Farbe)

        Controls.Add(p) ' Panel zum Kontrollformular hinzufügen

        PX = PL.Count - 1 ' Index für späteres Entfernen ermitteln

        PZ = 1 ' Aktuelle Zeile und Spalte
        PS = 5
    End Sub

    Private Sub timer_Tick(sender As Object, e As EventArgs) Handles timer.Tick
        If F(PZ + 1, PS) <> Leer Then ' Falls keine Panels erstellt werden können
            If PZ = 1 Then ' Falls oberste Zeile erreicht
                timer.Enabled = False
                MessageBox.Show("Game Over")
                Exit Sub
            End If

            F(PZ, PS) = PX ' Panel Belegen

        Else
            PL(PX).Top = PL(PX).Top + 20 ' Falls Felder frei
            PZ = PZ + 1
        End If
    End Sub

    Private Sub cmdLinks_Click(sender As Object, e As EventArgs) Handles cmdLinks.Click
        If F(PZ, PS - 1) = Leer Then
            PL(PX).Left = PL(PX).Left - 20
            PS = PS - 1
        End If
    End Sub

    Private Sub cmdRechts_Click(sender As Object, e As EventArgs) Handles cmdRechts.Click
        If F(PZ, PS + 1) = Leer Then
            PL(PX).Left = PL(PX).Left + 20
            PS = PS + 1
        End If
    End Sub

    Private Sub cmdUnten_Click(sender As Object, e As EventArgs) Handles cmdUnten.Click
        Do While F(PZ + 1, PS) = Leer
            PL(PX).Top = PL(PX).Top + 20
            PZ = PZ + 1
        Loop
        F(PZ, PS) = PX ' Feld mit Panel belegen
    End Sub

    Private Sub cmdPause_Click(sender As Object, e As EventArgs) Handles cmdPause.Click
        timer.Enabled = Not timer.Enabled
    End Sub

    Private Sub cmdLinks_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmdLinks.KeyPress

    End Sub
End Class
