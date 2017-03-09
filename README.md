# Tetris-Projekt

In diesem Projekt wird mithilfe von Visual Basic ein Spiel erstellt, dass dem bekannten Tetris ähnelt.  
  
##Inhaltserzeichnis
1. Visual Basic
2. Variablen
3. Das Spielfeld
4. Steuerung
5. Erstellen von Blöcken
6. Fallen von Blöcken
7. Löschen von Blöcken
8. Timer und Schwierigkeitsgrad
9. Musik
10. Menü
  
  
##1. Visual Basic
Visual Basic ist eine von Microsoft angebotene Programmiersprache, die in Visual Studio verwendet werden kann. Diese ähnelt C# in vielen Aspekten, statt nur reinem Code kann zusätzlich aber auch eine visuelle Darstellung des späteren Programms erstellt werden. Durch die von Visual Studio bereitgestellte Toolbox können Funktionen hinzugefügt werden, wie Buttons, Panels und Timer. Diese Funktionen werden direkt in den Code übernommen und es kann mit diesen normal weiterarbeiten, wie in C#.  
  
##2. Variablen
Die global verwendeten Variablen werden am Anfang definiert.  
Die globalen Variablen sind:
  
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
  
##3. Spielfeld
Das Spielfeld ist in einzelne Felder unterteilt und die Blöcke, die als Panels definiert sind, besetzen die Felder. Dies geschieht dadurch, dass der Wert des Feldes verändert wird. Die Randfelder erhalten den Wert -2. Selbst wenn ein Block versucht dieses Feld zu besetzen wird der Wert des Feldes von -2 auf -1 verändert und das Feld gilt weiterhin als leer. Ein normales Feld, welches besetzt werden darf, besitzt normalerweise einen Wert von -1, wenn dieses nun besetzt wird verändert sich der Wert auf 0. Ein Feld mit dem Wert 0 wird nicht weiter besetzt und wird im späteren Verlauf überprüft, ob drei gleiche Blöcke nebeneinander liegen.  
Im Code wird das Spielfeld als Arraylist behandelt, wodurch das Eintragen dieser Werte ermöglicht wird.  
  
##4. Steuerung
Die Steuerung geschieht durch vier Buttons. Das verschieben der Blöcke wird durch jeweils einen Button für links und rechts, um den aktiven Block fallen zu lassen wird der Button "unten" verwendet. Wenn das Spiel pausiert werden soll kann der Pause Button genutzt werden, durch diesen wird der Timer angehalten und der aktive Block bewegt sich nicht weiter.  
Durch Visual Basic kann man zuerst die visuelle Oberfläche des Programms erstellen, dabei wird die gegebene Toolbox verwendet. Die Buttons können im Code aufgerufen werden, die Position und Größe der Fläche müssen dadurch im Code nicht definiert werden, nur die Funktion, was passiert, sobald der Button getriggered wird.  
```

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
```
