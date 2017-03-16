<h1>Tetris-Projekt</h1>
<p>In diesem Projekt wird mithilfe von Visual Basic ein Spiel erstellt, dass dem bekannten Tetris ähnelt.</p>
  
<h2>Inhaltserzeichnis</h2>
<ul>
<li>1. Visual Basic</li>
<li>2. Variablen</li>
<li>3. Das Spielfeld</li>
<li>4. Steuerung</li>
<li>5. Erstellen von Blöcken</li>
<li>6. Fallen von Blöcken</li>
<li>7. Löschen von Blöcken</li>
<li>8. Timer und Schwierigkeitsgrad</li>
<li>9. Musik</li>
<li>10. Highscore</li>
<li>11. Stundenprotokoll</li>
</ul>
  
<h2>1. Visual Basic</h2>
Visual Basic ist eine von Microsoft angebotene Programmiersprache, die in Visual Studio verwendet werden kann. Diese ähnelt C# in vielen Aspekten, statt nur reinem Code kann zusätzlich aber auch eine visuelle Darstellung des späteren Programms erstellt werden. Durch die von Visual Studio bereitgestellte Toolbox können Funktionen hinzugefügt werden, wie Buttons, Panels und Timer. Diese Funktionen werden direkt in den Code übernommen und es kann mit diesen normal weiterarbeiten, wie in C#.  
  
<h2>2. Variablen</h2>
Die global verwendeten Variablen werden am Anfang definiert.  
Die globalen Variablen sind:
<code>
    Dim PX As Integer ' Das aktuelle Panel, welches sich bewegt, erhält einen Index um später wieder aufgerufen zu werden. Dies geschieht beim prüfen, ob drei gleiche Farben in Neben- oder Übereinander sich befinden und für das darausfolgende Löschen des Panels.
    Dim F(14, 9) As Integer ' Das gesamte Spielfeld, dabei ist 14 die Höhe und 9 die Breite. Effektiv belegt werden können nur die Felder 1 bis 13 vertikal und 0 bis 8 waagerecht. die äußeren werte stehen für die Begrenzung des Feldes.
    Dim PZ As Integer ' Die Zeile, in dem sich das aktive Panel befindet. PZ kann dabei dieGgrößen 1 bis 13 annehmen, da dies die Felder sind, welche belegt werden dürfen.
    Dim PS As Integer ' Die Spalte, in dem sich das aktive Panel befindet. PS kann dabei dieGgrößen 1 bis 8 annehmen, da dies die Felder sind, welche belegt werden dürfen.
    Dim Stufe As Integer ' Der Schwierigkeitsgrad steigt kontinuirlich an, Anfangs fallen die Blöcke alle 0,5 Sekunden um ein Feld.
    Dim PL As New ArrayList ' Wird zu Anfang geladen, das Spielfeld wird als ArrayList definiert und ist Anfangs leer.
    Dim FarbenFeld() As Color = {Color.Red, ' Die Blöcke erhalten eine zufällig ausgewählte Farbe, später wird überprüft, ob drei gleichfarbige Blöcke nebeneinander liegen. Es existieren acht mögliche Farben und acht Spalten im Spielfeld, die belegt werden können. Das Spiel ist also zu keinem Zeitpunkt unfair.
        Color.Yellow,
        Color.Green,
        Color.Blue,
        Color.Orange,
        Color.Magenta,
        Color.Black,
        Color.White}
    Const Leer = -1 ' Wenn ein Feld nicht besetzt ist, erhält es die Konstante Leer. Wenn ein Block in ein Feld bewegt wird verändert sich der Wert des Feldes.
    Const Rand = -2 ' Die Randfelder werden mit der Konstante Rand besetzt, in diese kann kein Block bewegt werden.
</code>

<h2>3. Spielfeld</h2>
<p>Das Spielfeld ist in einzelne Felder unterteilt und die Blöcke, die als Panels definiert sind, besetzen die Felder. Dies geschieht dadurch, dass der Wert des Feldes verändert wird. Die Randfelder erhalten den Wert -2. Selbst wenn ein Block versucht dieses Feld zu besetzen wird der Wert des Feldes von -2 auf -1 verändert und das Feld gilt weiterhin als leer. Ein normales Feld, welches besetzt werden darf, besitzt normalerweise einen Wert von -1, wenn dieses nun besetzt wird verändert sich der Wert auf 0. Ein Feld mit dem Wert 0 wird nicht weiter besetzt und wird im späteren Verlauf überprüft, ob drei gleiche Blöcke nebeneinander liegen.<br>
Im Code wird das Spielfeld als Arraylist behandelt, wodurch das Eintragen dieser Werte ermöglicht wird.</p>

<h2>4. Steuerung</h2>
<p>Die Steuerung geschieht durch vier Buttons. Das verschieben der Blöcke wird durch jeweils einen Button für links und rechts, um den aktiven Block fallen zu lassen wird der Button "unten" verwendet. Wenn das Spiel pausiert werden soll kann der Pause Button genutzt werden, durch diesen wird der Timer angehalten und der aktive Block bewegt sich nicht weiter.  
Durch Visual Basic kann man zuerst die visuelle Oberfläche des Programms erstellen, dabei wird die gegebene Toolbox verwendet. Die Buttons können im Code aufgerufen werden, die Position und Größe der Fläche müssen dadurch im Code nicht definiert werden, nur die Funktion, was passiert, sobald der Button getriggered wird.</p>
<code>
    Private Sub cmdLinks_Click(sender As Object, e As EventArgs) Handles cmdLinks.Click
        If F(PZ, PS - 1) = Leer Then ' Es wird überprüft, ob das Feld links neben dem Block leer ist
            PL(PX).Left = PL(PX).Left - 20 ' Der Block wird um 20 Pixel verschoben
            PS = PS - 1 ' Die neue Position wird in der Arraylist eingetragen
        End If
    End Sub

    Private Sub cmdRechts_Click(sender As Object, e As EventArgs) Handles cmdRechts.Click
        If F(PZ, PS + 1) = Leer Then ' Es wird überprüft, ob das Feld rechts neben dem Block leer ist
            PL(PX).Left = PL(PX).Left + 20 ' Der Block wird um 20 Pixel verschoben
            PS = PS + 1 ' Die neue Position wird in der Arraylsit eingetragen
        End If
    End Sub

    Private Sub cmdUnten_Click(sender As Object, e As EventArgs) Handles cmdUnten.Click
        Do While F(PZ + 1, PS) = Leer ' Es wird überprüft, ob das Feld unter dem Block leer ist
            PL(PX).Top = PL(PX).Top + 20 ' Der Block wird um 20 Pixel nach unten verschoben
            PZ = PZ + 1 ' Die neue Position wird in der Arraylist eingetragen
        Loop ' Dieser Vorgang wird wiederholt, bis der Block nicht weiter nach unten verschoben werden kann
        F(PZ, PS) = PX       ' Belegen und verändern des Wertes für das Feld in der Arraylist
        AllePrüfen() ' Es wird die Routine aufgerufen, die überprüft, ob drei gleiche Blöcke nebeneinader liegen
        NächstesPanel() ' Es wird die Routine aufgerufen, die einen neuen Block erzeugt
    End Sub

    Private Sub cmdPause_Click(sender As Object, e As EventArgs) Handles cmdPause.Click
        timT.Enabled = Not timT.Enabled ' Der Timer wird deaktiviert, um das Spiel zu pausieren
    End Sub
</code>
  
<h2>5. Erstellen von Blöcken</h2>
<p>Die Blöcke werden als Panels behandelt, jedes Panel besitzt eine Größe von 20x20 Pixeln. Beim verschieben der Blöcke wird immer eine Positionsveränderung von 20 Pixeln verwendet, somit existieren acht Spalten, in denen sich Blöcke befinden können. Beim erstellen ist die Größe fest definiert, die Farbe wird aber zufällig ausgewählt. Aus einer Liste von acht möglichen Farben wird eine ausgewählt für den neuen Block. Das Spiel ist also zu keinem Zeitpunkt unfair, es gibt nicht mehr mögliche Farben als Spalten. Das Panel wird nun der Arraylist hinzugefügt und somit vermerkt, um es später wieder löschen zu können.</p>

<code>
Private Sub NächstesPanel()
        Dim Farbe As Integer ' Die Variable für die Farbe wird verwendet
        Dim p As New Panel ' Die Variable für Panel wird aufgerufen

        PL.Add(p) ' Ein Panel wird hinzugefügt, die Eigenschaften müssen noch definiert werden

        p.Location = New Point(100, 80) ' Das neue Panel wird platziert
        p.Size = New Size(20, 20) ' Die Größe ist auf 20x20 Pixel festgelegt

        Farbe = Math.Floor(Rnd() * 8) ' Die Farbe wird zufällig ausgewählt, durch die in den Variablen definierte Auswahl, alle acht Farben sollen verwendet werden
        p.BackColor = FarbenFeld(Farbe) ' Die ausgewählte Farbe wird auf das Panel angewendet

        Controls.Add(p) ' Das neue Panel wird zur Arraylist hinzugefügt

        PX = PL.Count - 1 ' Das Panel erhält einen Eintrag im Index, um später wieder entfernt zu werden

        PZ = 1 ' Zeile und Spalte des neuen Panels, es ligt direkt in der Mitte der ersten Zeile
        PS = 5
</code>

<p>Das Vermerken der Farbe ist wichtig, da durch diese später entschieden wird, ob das Panel aus dem Programm entladen wird.</p>
  
<h2>6. Fallen von Blöcken</h2>
<p>Der aktive Block fällt um den definierten Betrag von 20 Pixeln wenn der Timer einen Tick durchlaufen hat. Zu Beginn dauert dies 0,5 Sekunden. Nach jedem gsetzten Block erhöht sich aber der Schwierigkeitsgrad, dies wird durch eine Verringerung der Tick-Länge verursacht. Die Funktion dafür ist</p>
<code>
            Stufe = Stufe + 1
            timT.Interval = 5000 / (Stufe + 9)
</code>
<p>Die vorherige Stufe wird um eins erhöht und das Intervall von 0,5 Sekunden durch die neue Stufe + 9 geteilt. Dadurch werden die Zeitintevalle pro Tick kontinuirlich kürzer und es wird schwieriger, die Blöcke richtig zu platzieren. Theoretisch können die Intervalle extrem kurz werden, ab einem bestimmten Punkt ist es schwierig, die Kontrolle zu behalten und das Spiel endet.</p>

<h2>7. Löschen von Blöcken</h2>
<p>Um die Blöcke zu löschen muss zuerst festgestellt werden, ob drei gleichfarbige Blöcke neben- oder übereinander angeordnet sind. Dies wird in zwei Funktionen aufgeteilt, eine zum prüfen der nebeneinander liegenden Blöcke und eine für die Blöcke übereinander.<br>
Eine weitere Funktion ist "Alle Prüfen", diese ruft "neben- und überprüfen" auf.</p>
<p>Die Funktion zum nebeinander prüfen</p>
```
    Private Function checkBeside(Z As Integer, S As Integer) As Boolean ' Prüfen, ob drei gleiche Farben nebeneiander
        Dim ZX, SX As Integer
        checkBeside = False

        If F(Z, S) <> empty And
                F(Z, S + 1) <> empty And
                F(Z, S + 2) <> empty Then

            If PL(F(Z, S)).BackColor = ' Überprüfen, ob drei Panels nebeneinander die gleiche Farbe Farbvariable besitzen
                    PL(F(Z, S + 1)).BackColor And
                    PL(F(Z, S)).BackColor =
                    PL(F(Z, S + 2)).BackColor Then

                For SX = S To S + 2
                    Controls.Remove(PL(F(Z, SX))) ' Wenn drei Panels gleich sind werden diese aus der Arraylist gelöscht
                    F(Z, SX) = empty ' Feld zurückseten

                    ZX = Z - 1 ' Panels über den entfernten nachrücken lassen
                    Do While F(ZX, SX) <> empty
                        PL(F(ZX, SX)).Top =
                            PL(F(ZX, SX)).Top + 20 ' absenken um 20 Pixel, also eine Panel Größe, bis kein Platz verfügbar ist

                        F(ZX + 1, SX) = F(ZX, SX) ' Feld in Arraylist wieder in offenen Zustand setzen, Wert auf -1
                        F(ZX, SX) = empty
                        ZX = ZX - 1
                    Loop

                Next SX
                checkBeside = True ' Nach dem Prüfen nebeneinander wird geprüft, ob drei gleiche übereinander liegen
            End If
        End If
    End Function
```
<p>Diese beiden Funktionen werden in einer weiteren Funktion aufgerufen, die sobald keine weiteren Panels zum löschen identifiziert werden die Freigabe gibt um einen neues Panel zu erzeugen. Sobald eine der Funktionen Panels entfernt wird der Wert des Counters um eins erhöht, da so ein Punkt erzielt wird.<br>
Für den Punktezähler wir ein Label verwenet, der wert daraus wird am Ende gespeichert und für den Highscore verwendet.<br>
Um den Schwierigkeitsgrad kontinuirlich zu erhöhen wird nach jedem entfernen von Panels durch die Funktionen der Zeitintervall des Timers verkürzt. Durch das Verkürzen der Intervall wird die Fallgeschwindigkeit der Blöcke erhöht und es wird schwieriger, die Blöcke richtig zu platzieren.
<code>
    Private Sub allCheck()
        Dim Z, S As Integer
        Dim Beside, Above As Boolean
        Beside = False
        Above = False

        For Z = 13 To 1 Step -1 ' Definition, welche Felder geprüft werden sollen
            For S = 1 To 6
                Beside = checkBeside(Z, S)
                If Beside Then Exit For
            Next S
            If Beside Then Exit For
        Next Z

        For Z = 13 To 3 Step -1 ' Definition, welche Felder geprüft werden sollen
            For S = 1 To 8
                Above = checkAbove(Z, S)
                If Above Then Exit For
            Next S
            If Above Then Exit For
        Next Z

        If Beside Or Above Then
            level = level + 1 ' Tempo erhöhen
            timer.Interval = 5000 / (level + 9)
            Counter.Text = Val(Counter.Text) + 1 ' Jedes mal wenn drei Panels gelöscht werden wird der Punktezähler um einen erhöht. Dieser Wert wird später für den Highscore verwendet

            allCheck() ' Durch Nachrücken können weitere Panels gelöscht werden, falls drei gleiche nebeneinander liegen
        End If

    End Sub
    </code>

<h2>8. Timer</h2>
<p>Der Timer ist eine vorgefertigte Funktion von Visual Basic, die einfach aus der Toolbox übernommen werden kann. Der Timer befindet sich im Entwurfs Fenster, in dem die Funktionen von Visual Basic angeordet werden. Der Timer steht zuert auf 500 Millisekunden, und kann im Code bearbeitet werden.</p>
```
    Private Sub timer_Tick(sender As Object, e As EventArgs) Handles timer.Tick
        If F(PZ + 1, PS) <> empty Then ' Falls keine Panels erstellt werden können
            If PZ = 1 Then ' Wenn die oberste Zeile von einem Panel belegt wird und somit das Spiel beendet ist
                timer.Enabled = False ' Der Timer wird abgestellt, es können keine weiteren Blöcke generiert werden
                MessageBox.Show("Game Over")
                Exit Sub
            End If

            F(PZ, PS) = PX ' Falls das Spiel nicht beendet wird überprüft ob Panels entfernt werden können, sobald die funktion beendet ist wird die Funktion zum generieren eines neuen Panels aufgerufen
            allCheck()
            nextPanel()

        Else
            PL(PX).Top = PL(PX).Top + 20 ' Ein Block der nicht weiter fallen kann wird in der Arraylist vermerkt
            PZ = PZ + 1
        End If
    End Sub
```












<h2>11. Stundenprotokoll</h2>
<p>16.3. Erste Stunde:<br> 
Eingelesen in XML-Datein und wie diese erstellt, bearbeitet und ausgelesen werden können. Zu diesem Thema hat Microsoft eine Anleitung veröffentlicht, in der erklärt wird, wie mit XML-Dateien umgegegangen wird. Diese Anleitung kann <a href="https://msdn.microsoft.com/de-de/library/bb979298.aspx">hier</a> gefunden werden. Erste Anwendungen von XML-Dateien erstellt und eine XML-Datei  generiert, darin schreiben und auslesen ist aber noch nich möglich.<br>
Zweite Stunde:<br>
Weitergeschrieben an der Dokumentation, Erklärung für das Löschen von Blöcken beendet und 
