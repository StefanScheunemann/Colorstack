Public Class Form1
    Dim record As Integer = 0
    Dim Rekord As Integer = 0
    Dim Playername As String = ""
    Dim PX As Integer ' Index des aktiven Panels
    Dim F(14, 9) As Integer ' Spielfeld mit Rand
    Dim PZ As Integer ' Zeile des aktiven Panels
    Dim PS As Integer ' Spalte des aktiven Panels
    Dim level As Integer ' Schwierigkeitsgrad
    Dim PL As New ArrayList ' leeres Spielfeld
    Dim ColorField() As Color = {Color.Red, ' Verschiedene Farben der Blöcke
        Color.Yellow,
        Color.Green,
        Color.Blue,
        Color.Orange,
        Color.Magenta,
        Color.Black,
        Color.White}
    Const empty = -1 ' Feld leer
    Const edge = -2 ' Randfeld

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Z, S As Integer
        Dim HighscoreList As Integer

        Me.Size = New Size(300, 440) ' Größe und Ort
        Left.Size = New Size(40, 28)
        Left.Location = New Point(16, 15)
        Right.Size = New Size(40, 28)
        Right.Location = New Point(96, 15)
        Down.Size = New Size(40, 28)
        Down.Location = New Point(56, 50)
        PanLinks.Size = New Size(1, 260)
        PanLinks.Location = New Point(20, 80)
        PanRechts.Size = New Size(1, 260)
        PanRechts.Location = New Point(180, 80)
        PanUnten.Size = New Size(160, 1)
        PanUnten.Location = New Point(20, 340)
        Pause.Size = New Size(70, 28)
        Pause.Location = New Point(70, 350)
        Counter.Size = New Size(40, 28)
        Counter.Location = New Point(185, 350)
        Highscore.Size = New Size(80, 20)
        Highscore.Location = New Point(150, 15)
        BestPlayer.Size = New Size(80, 20)
        BestPlayer.Location = New Point(150, 50)

        HighscoreList = FreeFile()
        FileOpen(HighscoreList, "Highscore.txt", OpenMode.Input)
        Playername = LineInput(HighscoreList)
        level = LineInput(HighscoreList)
        BestPlayer.Text = "Bester Spieler: " & Playername
        Highscore.Text = "Highscore: " & level
        FileClose(HighscoreList)

        Randomize() ' Zufallsgenerator
        For Z = 1 To 13 ' Feld mit Panel besetzen
            F(Z, 0) = edge
            For S = 1 To 8
                F(Z, S) = empty
            Next S
            F(Z, 9) = edge
        Next Z

        For S = 0 To 9
            F(14, S) = edge
        Next S

        level = 1 ' Initialisierung
        nextPanel()

    End Sub

    Private Sub nextPanel()
        Dim Colour As Integer
        Dim p As New Panel

        PL.Add(p) ' Panel zur ArraryList hinzufügen

        p.Location = New Point(100, 80) ' Panel platzieren
        p.Size = New Point(20, 20)

        Colour = Math.Floor(Rnd() * 8) ' Zufällige Farbe des Panels
        p.BackColor = ColorField(Colour)

        Controls.Add(p) ' Panel zum Kontrollformular hinzufügen

        PX = PL.Count - 1 ' Index für späteres Entfernen ermitteln

        PZ = 1 ' Aktuelle Zeile und Spalte
        PS = 5
    End Sub

    Private Sub timer_Tick(sender As Object, e As EventArgs) Handles timer.Tick
        Dim HighscoreList As Integer

        If F(PZ + 1, PS) <> empty Then ' Falls keine Panels erstellt werden können
            If PZ = 1 Then ' Falls oberste Zeile erreicht
                timer.Enabled = False
                MessageBox.Show("Game Over")
                If level > record Then ' Wenn mehr Punkte erzielt als bisheriger Rekord
                    record = level
                    Highscore.Text = "High Score: " & record
                    Playername = InputBox("Spielername", "Spielername eingeben")
                    BestPlayer.Text = "Bester Spieler: " & Playername
                    HighscoreList = FreeFile()
                    FileOpen(HighscoreList, "Highscore.txt", OpenMode.Output)
                    PrintLine(HighscoreList, Playername)
                    PrintLine(HighscoreList, level)
                    FileClose(HighscoreList)
                End If
                Application.Restart()
            End If

            F(PZ, PS) = PX ' Panel Belegen
            allCheck()
            nextPanel()

        Else
            PL(PX).Top = PL(PX).Top + 20 ' Falls Felder frei
            PZ = PZ + 1
        End If
    End Sub

    Private Sub allCheck()
        Dim Z, S As Integer
        Dim Beside, Above As Boolean
        Beside = False
        Above = False

        For Z = 13 To 1 Step -1 ' Wenn drei gleiche Farben nebeneinander
            For S = 1 To 6
                Beside = checkBeside(Z, S)
                If Beside Then Exit For
            Next S
            If Beside Then Exit For
        Next Z

        For Z = 13 To 3 Step -1 ' Wenn drei gleiche Farben übereinander
            For S = 1 To 8
                Above = checkAbove(Z, S)
                If Above Then Exit For
            Next S
            If Above Then Exit For
        Next Z

        If Beside Or Above Then
            level = level + 1 ' Tempo erhöhen
            timer.Interval = 5000 / (level + 9)
            Counter.Text = Val(Counter.Text) + 1 ' Jede entladene Reihe einen Punkt wert

            allCheck() ' Prüfen, ob noch eine Reihe entfernt werden kann
        End If

    End Sub

    Private Function checkBeside(Z As Integer, S As Integer) As Boolean ' Prüfen, ob drei gleiche Farben nebeneiander
        Dim ZX, SX As Integer
        checkBeside = False

        If F(Z, S) <> empty And
                F(Z, S + 1) <> empty And
                F(Z, S + 2) <> empty Then

            If PL(F(Z, S)).BackColor = ' Wenn drei Farben gleich sind
                    PL(F(Z, S + 1)).BackColor And
                    PL(F(Z, S)).BackColor =
                    PL(F(Z, S + 2)).BackColor Then

                For SX = S To S + 2
                    Controls.Remove(PL(F(Z, SX))) ' Panel aus dem Formular löschen
                    F(Z, SX) = empty ' Feld zurückseten

                    ZX = Z - 1 ' Panel überhalb runterziehen
                    Do While F(ZX, SX) <> empty
                        PL(F(ZX, SX)).Top =
                            PL(F(ZX, SX)).Top + 20

                        F(ZX + 1, SX) = F(ZX, SX) ' Feld neu besetzen
                        F(ZX, SX) = empty
                        ZX = ZX - 1
                    Loop

                Next SX
                checkBeside = True
            End If
        End If
    End Function

    Private Function checkAbove(Z As Integer, S As Integer) As Boolean ' Prüfen, ob drei gleiche Farben übereinander
        Dim ZX As Integer
        checkAbove = False

        If F(Z, S) <> empty And F(Z - 1, S) <> empty And
                F(Z - 2, S) <> empty Then

            If PL(F(Z, S)).BackColor = ' Wenn drei Farben gleich sind
                    PL(F(Z - 1, S)).BackColor And
                    PL(F(Z, S)).BackColor =
                    PL(F(Z - 2, S)).BackColor Then

                For ZX = Z To Z - 2 Step -1 ' Panels entladen
                    Controls.Remove(PL(F(ZX, S))) ' Panel aus Formular löschen
                    F(ZX, S) = empty ' Feld zurücksetzen
                Next ZX
                checkAbove = True
            End If
        End If
    End Function

    Private Sub Left_Click(sender As Object, e As EventArgs) Handles Left.Click
        If F(PZ, PS - 1) = empty Then
            PL(PX).Left = PL(PX).Left - 20
            PS = PS - 1
        End If
    End Sub

    Private Sub Right_Click(sender As Object, e As EventArgs) Handles Right.Click
        If F(PZ, PS + 1) = empty Then
            PL(PX).Left = PL(PX).Left + 20
            PS = PS + 1
        End If
    End Sub

    Private Sub Down_Click(sender As Object, e As EventArgs) Handles Down.Click
        Do While F(PZ + 1, PS) = empty
            PL(PX).Top = PL(PX).Top + 20
            PZ = PZ + 1
        Loop
        F(PZ, PS) = PX ' Feld mit Panel belegen
        allCheck()
        nextPanel()
    End Sub

    Private Sub Pause_Click(sender As Object, e As EventArgs) Handles Pause.Click
        timer.Enabled = Not timer.Enabled
    End Sub
End Class