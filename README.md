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
```
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
  ```
  
##Spielfeld
Das Spielfeld ist in einzelne Felder unterteilt und die Blöcke, die als Panels definiert sind, besetzen die Felder. Dies geschieht dadurch, dass der Wert des Feldes verändert wird. Die Randfelder erhalten den Wert -2. Selbst wenn ein Block versucht dieses Feld zu besetzen wird der Wert des Feldes von -2 auf -1 verändert und das Feld gilt weiterhin als leer. Ein normales Feld, welches besetzt werden darf
