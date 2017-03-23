Public Class Form1
    Dim record As Integer = 0
    Dim Playername As String = ""
    Dim ActPan As Integer ' Index des aktiven Panels
    Dim Field(14, 9) As Integer ' Spielfeld mit Rand
    Dim PanRow As Integer ' Zeile des aktiven Panels
    Dim PanCol As Integer ' Spalte des aktiven Panels
    Dim level As Integer ' Schwierigkeitsgrad
    Dim PanEmp As New ArrayList ' leeres Spielfeld
    Dim ColorField() As Color = {Color.Red, ' Verschiedene Farben der Blöcke
        Color.Yellow,
        Color.Green,
        Color.Blue,
        Color.Orange,
        Color.Magenta,
        Color.Black,
        Color.Cyan}
    Const empty = -1 ' Feld leer
    Const edge = -2 ' Randfeld

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Row, Col As Integer
        Dim HighscoreList As Integer

        Me.Size = New Size(220, 440) ' Größe und Ort
        PanLinks.Size = New Size(1, 260)
        PanLinks.Location = New Point(20, 80)
        PanRechts.Size = New Size(1, 260)
        PanRechts.Location = New Point(180, 80)
        PanUnten.Size = New Size(160, 1)
        PanUnten.Location = New Point(20, 340)
        Counter.Size = New Size(40, 28)
        Counter.Location = New Point(90, 350)
        Highscore.Size = New Size(80, 20)
        Highscore.Location = New Point(30, 50)
        BestPlayer.Size = New Size(80, 20)
        BestPlayer.Location = New Point(30, 30)


        HighscoreList = FreeFile()
        FileOpen(HighscoreList, "Highscore.txt", OpenMode.Input)
        Playername = LineInput(HighscoreList)
        record = LineInput(HighscoreList)
        BestPlayer.Text = "Bester Spieler: " & Playername
        Highscore.Text = "Highscore: " & record
        FileClose(HighscoreList)

        Randomize() ' Zufallsgenerator
        For Row = 1 To 13 ' Feld mit Panel besetzen
            Field(Row, 0) = edge
            For Col = 1 To 8
                Field(Row, Col) = empty
            Next Col
            Field(Row, 9) = edge
        Next Row

        For Col = 0 To 9
            Field(14, Col) = edge
        Next Col

        level = 1 ' Initialisierung
        nextPanel()

        Me.KeyPreview = True ' Tastatur Eingabe erlauben

    End Sub

    Private Sub nextPanel()
        Dim Color As Integer
        Dim Pan As New Panel

        PanEmp.Add(Pan) ' Panel zur ArraryList hinzufügen

        Pan.Location = New Point(100, 80) ' Panel platzieren
        Pan.Size = New Point(20, 20)

        Color = Math.Floor(Rnd() * 8) ' Zufällige Farbe des Panels
        Pan.BackColor = ColorField(Color)

        Controls.Add(Pan) ' Panel zum Kontrollformular hinzufügen

        ActPan = PanEmp.Count - 1 ' Index für späteres Entfernen ermitteln

        PanRow = 1 ' Aktuelle Zeile und Spalte
        PanCol = 5
    End Sub

    Private Sub allCheck()
        Dim Row, Col As Integer
        Dim Beside, Above As Boolean
        Beside = False
        Above = False

        For Row = 13 To 1 Step -1 ' Wenn drei gleiche Farben nebeneinander
            For Col = 1 To 6
                Beside = checkBeside(Row, Col)
                If Beside Then Exit For
            Next Col
            If Beside Then Exit For
        Next Row

        For Row = 13 To 3 Step -1 ' Wenn drei gleiche Farben übereinander
            For Col = 1 To 8
                Above = checkAbove(Row, Col)
                If Above Then Exit For
            Next Col
            If Above Then Exit For
        Next Row

        If Beside Or Above Then
            level = level + 1 ' Tempo erhöhen
            timer.Interval = 5000 / (level + 9)
            Counter.Text = Val(Counter.Text) + 1 ' Jede entladene Reihe einen Punkt wert

            allCheck() ' Prüfen, ob noch eine Reihe entfernt werden kann
        End If

    End Sub

    Private Function checkBeside(R As Integer, C As Integer) As Boolean ' Prüfen, ob drei gleiche Farben nebeneiander
        Dim RowX, ColX As Integer
        checkBeside = False

        If Field(R, C) <> empty And
                Field(R, C + 1) <> empty And
                Field(R, C + 2) <> empty Then

            If PanEmp(Field(R, C)).BackColor = ' Wenn drei Farben gleich sind
                    PanEmp(Field(R, C + 1)).BackColor And
                    PanEmp(Field(R, C)).BackColor =
                    PanEmp(Field(R, C + 2)).BackColor Then

                For ColX = C To C + 2
                    Controls.Remove(PanEmp(Field(C, ColX))) ' Panel aus dem Formular löschen
                    Field(R, ColX) = empty ' Feld zurückseten

                    RowX = R - 1 ' Panel überhalb runterziehen
                    Do While Field(RowX, ColX) <> empty
                        PanEmp(Field(RowX, ColX)).Top =
                            PanEmp(Field(RowX, ColX)).Top + 20

                        Field(RowX + 1, ColX) = Field(RowX, ColX) ' Feld neu besetzen
                        Field(RowX, ColX) = empty
                        RowX = RowX - 1
                    Loop

                Next ColX
                checkBeside = True
            End If
        End If
    End Function

    Private Function checkAbove(R As Integer, C As Integer) As Boolean ' Prüfen, ob drei gleiche Farben übereinander
        Dim ColX As Integer
        checkAbove = False

        If Field(R, C) <> empty And Field(R - 1, C) <> empty And
                Field(R - 2, C) <> empty Then

            If PanEmp(Field(R, C)).BackColor = ' Wenn drei Farben gleich sind
                    PanEmp(Field(R - 1, C)).BackColor And
                    PanEmp(Field(R, C)).BackColor =
                    PanEmp(Field(R - 2, C)).BackColor Then

                For ColX = R To R - 2 Step -1 ' Panels entladen
                    Controls.Remove(PanEmp(Field(ColX, C))) ' Panel aus Formular löschen
                    Field(ColX, C) = empty ' Feld zurücksetzen
                Next ColX
                checkAbove = True
            End If
        End If
    End Function

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.A Then
            If Field(PanRow, PanCol - 1) = empty Then
                PanEmp(ActPan).Left = PanEmp(ActPan).Left - 20
                PanCol = PanCol - 1
            End If
        End If
        If e.KeyCode = Keys.D Then
            If Field(PanRow, PanCol + 1) = empty Then
                PanEmp(ActPan).Left = PanEmp(ActPan).Left + 20
                PanCol = PanCol + 1
            End If
        End If
        If e.KeyCode = Keys.S Then
            Do While Field(PanRow + 1, PanCol) = empty
                PanEmp(ActPan).Top = PanEmp(ActPan).Top + 20
                PanRow = PanRow + 1
            Loop
            Field(PanRow, PanCol) = ActPan ' Feld mit Panel belegen
            allCheck()
            nextPanel()
        End If
        If e.KeyCode = Keys.Space Then
            timer.Enabled = Not timer.Enabled
        End If
    End Sub

    Private Sub timer_Tick(sender As Object, e As EventArgs) Handles timer.Tick
        Dim HighscoreList As Integer

        If Field(PanRow + 1, PanCol) <> empty Then ' Falls keine Panels erstellt werden können
            If PanRow = 1 Then ' Falls oberste Zeile erreicht
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
                    PrintLine(HighscoreList, level - 1)
                    FileClose(HighscoreList)
                End If
                Application.Restart()
            End If

            Field(PanRow, PanCol) = ActPan ' Panel Belegen
            allCheck()
            nextPanel()

        Else
            PanEmp(ActPan).Top = PanEmp(ActPan).Top + 20 ' Falls Felder frei
            PanRow = PanRow + 1
        End If
    End Sub
End Class