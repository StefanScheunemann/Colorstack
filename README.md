<h1>Colorstack</h1>
<p>In diesem Projekt wird mithilfe von Visual Basic ein Spiel erstellt, dass dem bekannten Tetris ähnelt.</p>
  
<h2>Inhaltserzeichnis</h2>
<ul>
<li>1. Colorstack</li>
<li>2. Visual Basic</li>
<li>3. Variablen</li>
<li>4. Das Spielfeld</li>
<li>5. Steuerung</li>
<li>6. Erstellen von Blöcken</li>
<li>7. Fallen von Blöcken</li>
<li>8. Löschen von Blöcken</li>
<li>9. Highscore</li>
<li>10. Stundenprotokoll</li>
</ul>
  
<h2>1. Colorstack</h2>
<p>In dem Spiel Colorstack ist es das Ziel, drei gleichfarbige Blöcke neben- oder übereinander zu platzieren. Die Steuerung erfolgt durch "A" und "D" um den aktiven Block nach links und rechts zu verschieben, mit "S" kann der Block sofort in die unterste mögliche Reihe verschoben werden. Mit "Leertaste" kann das Spiel pausiert werden.<br>
Sobald drei gleichfarbige Blöcke neben- oder übereinander liegen werden diese entfernt und der Spieler erhält einen Punkt. Die Blockgeschwindigkeit steigt jedesmal wenn Blöcke entfernt werden und sobald kein Block mehr erstellt werden kann, weil das Spielfeld voll nach oben hin gefüllt ist, ist das Spiel vorbei.</p>


<h2>2. Visual Basic</h2>
<p>ual Basic ist eine von Microsoft angebotene Programmiersprache, die in Visual Studio verwendet werden kann. Diese ähnelt C# in vielen Aspekten, statt nur reinem Code kann zusätzlich aber auch eine visuelle Darstellung des späteren Programms erstellt werden. Durch die von Visual Studio bereitgestellte Toolbox können Funktionen hinzugefügt werden, wie Buttons, Panels und Timer. Diese Funktionen werden direkt in den Code übernommen und es kann mit diesen normal weitergearbeitet werden, wie in C#.</p>
  
<h2>3. Variablen</h2>
Die global verwendeten Variablen werden am Anfang deklariert.  
Die globalen Variablen sind:
<code>
    Dim record As Integer = 0
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
</code>

<h2>4. Spielfeld</h2>
<p>Das Spielfeld ist in einzelne Felder unterteilt und die Blöcke, die als Panels definiert sind, besetzen die Felder. Dies geschieht dadurch, dass der Wert des Feldes verändert wird. Die Randfelder erhalten den Wert -2. Selbst wenn ein Block versucht dieses Feld zu besetzen wird der Wert des Feldes von -2 auf -1 verändert und das Feld gilt weiterhin als leer. Ein normales Feld, welches besetzt werden darf, besitzt normalerweise einen Wert von -1, wenn dieses nun besetzt wird verändert sich der Wert auf 0. Ein Feld mit dem Wert 0 wird nicht weiter besetzt und wird im späteren Verlauf überprüft, ob drei gleiche Blöcke nebeneinander liegen.<br>
Im Code wird das Spielfeld als Arraylist behandelt, wodurch das Eintragen dieser Werte ermöglicht wird.</p>


<h2>5. Steuerung</h2>
<p>Die Steuerung geschieht durch vier Buttons. Das verschieben der Blöcke wird durch jeweils einen Button für left und right gesteuert. Um den aktiven Block fallen zu lassen wird der Button "down" verwendet. Wenn das Spiel pausiert werden soll kann der "pause" Button genutzt werden, durch diesen wird der Timer angehalten und der aktive Block bewegt sich nicht weiter.  
Durch Visual Basic kann man zuerst die visuelle Oberfläche des Programms erstellen, dabei wird die gegebene Toolbox verwendet. Die Buttons können im Code aufgerufen werden, die Position und Größe der Fläche werden im Code zusätzlich defieniert.</p>
<code>
    Private Sub cmdLeft_Click(sender As Object, e As EventArgs) Handles cmdLeft.Click
        If F(PZ, PS - 1) = Leer Then ' Es wird überprüft, ob das Feld links neben dem Block leer ist
            PL(PX).Left = PL(PX).Left - 20 ' Der Block wird um 20 Pixel verschoben
            PS = PS - 1 ' Die neue Position wird in der Arraylist eingetragen
        End If
    End Sub

    Private Sub cmdRight_Click(sender As Object, e As EventArgs) Handles cmdRight.Click
        If F(PZ, PS + 1) = Leer Then ' Es wird überprüft, ob das Feld rechts neben dem Block leer ist
            PL(PX).Left = PL(PX).Left + 20 ' Der Block wird um 20 Pixel verschoben
            PS = PS + 1 ' Die neue Position wird in der Arraylsit eingetragen
        End If
    End Sub

    Private Sub cmdDown_Click(sender As Object, e As EventArgs) Handles cmdDown.Click
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
  
<h2>6. Erstellen von Blöcken</h2>
<p>Die Blöcke werden als Panels behandelt, jedes Panel besitzt eine Größe von 20x20 Pixeln. Beim verschieben der Blöcke wird immer eine Positionsveränderung von 20 Pixeln verwendet, somit existieren acht feste Spalten, in denen sich Blöcke befinden können. Beim erstellen ist die Größe fest definiert, die Farbe wird zufällig ausgewählt. Aus einer Liste von acht möglichen Farben wird eine ausgewählt für den neuen Block. Das Spiel ist also zu keinem Zeitpunkt unfair, es gibt nicht mehr mögliche Farben als Spalten. Das Panel wird nun der Arraylist hinzugefügt und somit vermerkt, um es später wieder löschen zu können.</p>

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
  
<h2>7. Fallen von Blöcken</h2>
<p>Der aktive Block fällt um den definierten Betrag von 20 Pixeln wenn der Timer einen Tick durchlaufen hat. Zu Beginn dauert dies 0,5 Sekunden. Immer wenn Blöcke entfernt werden und das level um eins erhöht wird steigt der Schwierigkeitsgrad, dies wird durch eine Verringerung der Tick-Länge verursacht. Die Funktion dafür ist</p>
<code>
            level = level + 1 ' Tempo erhöhen
            timer.Interval = 5000 / (level + 9)
            Counter.Text = Val(Counter.Text) + 1 ' Jede entladene Reihe einen Punkt wert
</code>

<p>Die vorherige Stufe wird um eins erhöht und das Intervall von 0,5 Sekunden durch die neue Stufe + 9 geteilt. Dadurch werden die Zeitintevalle pro Tick kontinuirlich kürzer und es wird schwieriger, die Blöcke richtig zu platzieren. Theoretisch können die Intervalle extrem kurz werden, ab einem bestimmten Punkt wird es aber schwierig, die Kontrolle zu behalten und das Spiel endet.</p>

<h2>8. Löschen von Blöcken</h2>
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

<h2>9. Highscore</h2>
<p>Der Highscore wird in einer txt-Datei gespeichert und kann jedes mal aufgerufen werden, wenn das Spiel gestartet wird. Es wird immer nur der höchste Highscore gespeichert, die txt-Datei kann im Programmordner gefunden werden.<br>
Es werden zwei Funktionen benutzt, um in der Datei schreiben zu können und um die Datei auslesen zu können.</p>

<p>Die Funktion zum schreiben befindet sich im timer, sobald die "game over" Message Box angezeigt wird prüft das Programm, ob der aktuelle Punktestand höher ist als der bisherige Rekord. Falls der aktuelle Punktestand höher ist als der Rekord wird der Spieler aufgefordert, seinen Namen einzugeben, dieser wird im Highscore gespeichert.</p>
```
                If level > record Then ' Wenn mehr Punkte erzielt als bisheriger Rekord
                    record = level
                    Highscore.Text = "High Score: " & record
                    Playername = InputBox("Spielername", "Spielername eingeben")
                    BestPlayer.Text = "Bester Spieler: " & Playername
                    HighscoreList = FreeFile()
                    FileOpen(HighscoreList, "Highscore.txt", OpenMode.Output) ' Öffnen der Datei direkt im Programmordner
                    PrintLine(HighscoreList, Playername)
                    PrintLine(HighscoreList, level)
                    FileClose(HighscoreList)
```

<p>Wenn das Programm gestartet wird wird der aktuelle Highscore aus der txt-Datei geladen und im Spiel angezeigt. Dafür werden zwei Labels verwendet, Spielername und Highscore werden getrennt geladen. Die Funktion dafür befindet sich im FormLoader, es wird also direkt zu Anfang ausgeführt.</p>
```
        HighscoreList = FreeFile()
        FileOpen(HighscoreList, "Highscore.txt", OpenMode.Input) ' Definition, welche Datei geöffnet werden soll
        Playername = LineInput(HighscoreList)
        level = LineInput(HighscoreList)
        BestPlayer.Text = "Bester Spieler: " & Playername ' Die Label erhalten ihren Inhalt
        Highscore.Text = "Highscore: " & level
        FileClose(HighscoreList)
```


<h2>10.Stundenprotokoll</h2>
<h4>14.3.</h4>
<p>Das System für das Löschen der Blöcke hat noch Fehler erzeugt, wenn durch nachrücken von Blöcken ein weiteres mal Blöcke entfernt werden können ist dies bisher nicht geschehen. Den Großteil der Stunde habe ich mit diesem Bug verbracht, die Lösung war es, am Ende der AllCheck Funktion ein weiteres mal diese Funktion aufzurufen. Falls keine weiteren Blöcke gelöscht werden können wird die If-Abfrage sofort beendet und ein neuer Block wird generiert.</p>

<h4>16.3.</h4>
<p>Erste Stunde:<br> 
In Visual Basic kann man txt-Dateien erstellen, in diesen schreiben und sie auch auslesen. Ich habe mich in dieser Stunde damit beschäftigt, wie eine derartige Datei erstellt wird und man diese modifizieren kann. Dazu gibt es eine Anleitung von Microsoft, doese kann <a href="https://msdn.microsoft.com/de-de/library/6ka1wd3w(v=vs.110).aspx">hier</a> gefunden werden. Danach habe Ich eine erste txt-Datei erstellt, die Funktionen zum auslesen und schreiben in dieser der Datei habe ich aber erst später geschrieben.<br>
Zweite Stunde:<br>
In der zweiten Stunde habe ich an der Dokumentation gearbeitet und die Erklärung für das Löschen von Blöcken und die Erklärung für den Highscore, also die txt-Datei, begonnen. Diese Erklärung wurde auch zu einemn späteren Zeitpunkt beendet</p>

<h4>21.3.</h4>
<p>In dieser Stunde habe ich mich in die "KeyDown" Funktion eingelesen, diese wird <a href="https://msdn.microsoft.com/de-de/library/system.windows.forms.control.keydown(v=vs.110).aspx"> hier</a> erklärt. Es ist möglich, durch den "KeyChar" Befehl, direkte Tastatureingaben zu verwenden, wobei der KeyDown Befehl beim Anschlag der Taste den Befehl registriert. Wenn eine Tastenkombination verwendet werden soll muss eine eigene Funktion für diese geschrieben werden, in meinem Fall werden aber nur einfache Tastenanschläge benötigt.<br>
Es existiert auch der Befehl "KeyPress", dieser verwendet aber keine Sonderzeichen, wie die Pfeile, Enter und Leertaste.<br>
In meinem Fall war "KeyDown" besser geeignet, da die Leertaste zum pausieren des Spiels verwendet werden soll.<p>
