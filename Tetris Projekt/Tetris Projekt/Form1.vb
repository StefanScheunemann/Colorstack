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
            AllePrüfen()
            NächstesPanel()

        Else
            PL(PX).Top = PL(PX).Top + 20 ' Falls Felder frei
            PZ = PZ + 1
        End If
    End Sub

    Private Sub AllePrüfen()
        Dim Z, S As Integer
        Dim Neben, Über As Boolean
        Neben = False
        Über = False

        ' Drei gleiche Panel nebeneinander ?
        For Z = 13 To 1 Step -1
            For S = 1 To 6
                Neben = NebenPrüfen(Z, S)
                If Neben Then Exit For
            Next S
            If Neben Then Exit For
        Next Z

        ' Drei gleiche Panel übereinander ?
        For Z = 13 To 3 Step -1
            For S = 1 To 8
                Über = ÜberPrüfen(Z, S)
                If Über Then Exit For
            Next S
            If Über Then Exit For
        Next Z

        If Neben Or Über Then
            ' Schneller
            Stufe = Stufe + 1
            timer.Interval = 5000 / (Stufe + 9)

            ' Eventuell kann jetzt noch eine Reihe
            ' entfernt werden
            AllePrüfen()
        End If

    End Sub

    ' Falls 3 Felder nebeneinander besetzt
    Private Function NebenPrüfen(Z As Integer, S As Integer) As Boolean
        Dim ZX, SX As Integer
        NebenPrüfen = False

        If F(Z, S) <> Leer And
                F(Z, S + 1) <> Leer And
                F(Z, S + 2) <> Leer Then

            ' Falls drei Farben gleich
            If PL(F(Z, S)).BackColor =
                    PL(F(Z, S + 1)).BackColor And
                    PL(F(Z, S)).BackColor =
                    PL(F(Z, S + 2)).BackColor Then

                For SX = S To S + 2
                    ' PL aus dem Formular löschen
                    Controls.Remove(PL(F(Z, SX)))
                    ' Feld leeren
                    F(Z, SX) = Leer

                    ' Panels oberhalb des entladenen
                    ' Panels absenken
                    ZX = Z - 1
                    Do While F(ZX, SX) <> Leer
                        PL(F(ZX, SX)).Top =
                            PL(F(ZX, SX)).Top + 20

                        ' Feld neu besetzen
                        F(ZX + 1, SX) = F(ZX, SX)
                        F(ZX, SX) = Leer
                        ZX = ZX - 1
                    Loop

                Next SX
                NebenPrüfen = True
            End If
        End If
    End Function

    ' Falls drei Felder übereinander besetzt
    Private Function ÜberPrüfen(Z As Integer, S As Integer) As Boolean
        Dim ZX As Integer
        ÜberPrüfen = False

        If F(Z, S) <> Leer And F(Z - 1, S) <> Leer And
                F(Z - 2, S) <> Leer Then

            ' Falls drei Farben gleich
            If PL(F(Z, S)).BackColor =
                    PL(F(Z - 1, S)).BackColor And
                    PL(F(Z, S)).BackColor =
                    PL(F(Z - 2, S)).BackColor Then

                ' 3 Panels entladen
                For ZX = Z To Z - 2 Step -1
                    ' PL aus dem Formular löschen
                    Controls.Remove(PL(F(ZX, S)))
                    ' Feld leeren
                    F(ZX, S) = Leer
                Next ZX
                ÜberPrüfen = True
            End If
        End If
    End Function

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
        AllePrüfen()
        NächstesPanel()
    End Sub

    Private Sub cmdPause_Click(sender As Object, e As EventArgs) Handles cmdPause.Click
        timer.Enabled = Not timer.Enabled
    End Sub
End Class

