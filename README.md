<h1>Colorstack</h1>
<p>In diesem Projekt wird mithilfe von Visual Basic ein Programm erstellt, dass auf jedem Windows PC verwendet werden kann.</p>
  
<h2>Inhaltserzeichnis</h2>
<ul>
<li><a href="#Col">1. Colorstack</a></li>
<li><a href="#Vis">2. Visual Basic</a></li>
<li><a href="#Var">3. Variablen</a></li>
<li><a href="#Spi">4. Das Spielfeld</a></li>
<li><a href="#Ste">5. Steuerung</a></li>
<li><a href="#Ers">6. Erstellen von Blöcken</a></li>
<li><a href="#Fal">7. Fallen von Blöcken</a></li>
<li><a href="#Lös">8. Löschen von Blöcken</a></li>
<li><a href="#Hig">9. Highscore</a></li>
<li><a href="#Stu">10. Stundenprotokoll</a></li>
<li><a hreg="Que">11. Quellen</a></li>
</ul>
  
<h2><a id="Col">1. Colorstack</a></h2>
<p>In dem Spiel Colorstack ist es das Ziel, drei gleichfarbige Blöcke neben- oder übereinander zu platzieren. Die Steuerung erfolgt durch "A" und "D" um den aktiven Block nach links und rechts zu verschieben, mit "S" kann der Block sofort in die unterste mögliche Reihe verschoben werden. Mit "Leertaste" wird das Spiel pausiert.<br>
Sobald drei gleichfarbige Blöcke neben- oder übereinander liegen werden diese entfernt und der Spieler erhält einen Punkt. Die Blockgeschwindigkeit steigt jedesmal, wenn Blöcke entfernt werden.<br>
Sobald kein Block mehr erstellt werden kann, weil das Spielfeld nach oben hin gefüllt ist, ist das Spiel vorbei.</p>

<p>Im Ordner "Colorstack Installation" befindet sich eine Setup.exe, durch diese kann das Programm installiert werden.<br>
Aktuell funktioniert der Installer nicht, das Programm gibt einen Fehler bei der Installation aus.<br>
Das Problem ist bekannt doch habe Ich es noch nicht geschafft, es zu lösen.</p>


<h2><a id="Vis">2. Visual Basic</a></h2>
<p>Visual Basic ist eine von Microsoft angebotene Programmiersprache, die in Visual Studio verwendet werden kann. Diese ähnelt C# in vielen Aspekten, statt nur reinem Code kann aber auch eine visuelle Darstellung des späteren Programms erstellt werden. Durch die von Visual Studio bereitgestellte Toolbox können Funktionen hinzugefügt werden, wie Buttons, Panels und Timer. Diese Funktionen werden direkt in den Code übernommen und es kann mit diesen normal weitergearbeitet werden, wie in C#.</p>
  
<h2><a id="Var">3. Variablen</a></h2>
<p>Die global verwendeten Variablen werden am Anfang deklariert.<br>
Aus den Kommentaren geht hervor, wofür die Variablen verwendet werden.<br>
"record" und "Playername" sind nicht beschriftet, diese werden für den Highscore verwendet um den Namen des Spielers zu speichern und für die erreichte Punktzahl.</p>

<p><img src="images/Variablen.PNG" alt="Variablen" style="width:635px;height:307px;border:0;"></p>

<h2><a id="Spi">4. Spielfeld</a></h2>
<p>Das Spielfeld ist in einzelne Felder unterteilt und die Blöcke, die als Panels definiert sind, besetzen die Felder.<br>
Dies geschieht dadurch, dass der Wert des Feldes verändert wird..<br>
Ein normales Feld, welches besetzt werden darf, besitzt im leeren Zustand einen Wert von -1, wenn dieses nun besetzt wird verändert sich der Wert auf 0. Ein Feld mit dem Wert 0 wird nicht weiter besetzt und wird im späteren Verlauf darauf überprüft, ob drei gleiche Blöcke nebeneinander liegen.<br>
Die Randfelder haben einen Wert von -2 definiert. Selbst wenn ein Block versucht dieses Feld zu besetzen wird der Wert des Feldes von -2 auf -1 verändert und das Feld gilt weiterhin als leer. Die Spielfeldbegrenzung findet also nicht durch die für den Spieler sichtbaren Panels statt<br>
Im Code wird das Spielfeld als Arraylist behandelt, wodurch das Eintragen dieser Werte ermöglicht wird. Die Arraylist ist eine von Visual Basic zur Verfügung gestellte Tabelle für Werte, die nich direkt einsehbar ist.</p>


<h2><a id="Ste">5. Steuerung</a></h2>
<p>Die Steuerung geschieht durch vier Tastaturbefehle.<br>
Die Blöcke können nach links und rechts mit "A" und "D" verschoben werden.<br>
Um den aktiven Block fallen zu lassen wird "S" verwendet.<br>
Wenn das Spiel pausiert werden soll wird die "Leertase" verwendet, durch diesen Befehl wird der Timer angehalten und der aktive Block bewegt sich nicht weiter.<br>
Für die Steuerung wird die "KeyDown" Funktion verwendet. Mit diesem Befehl wird beim Eindrücken der Taste ein Befehl ausgelöst. In der Funktion wird durch eine If-Abfrage überprüft, ob bestimmte Befehle von der Tastatur gegeben werden<br>
Um nicht vier "KeyDown" Funktionen zu erstellen, ist es möglich in einer Funktion durch mehrere If-Abfragen alle Keyboard Inputs direkt nacheinander zu behandeln.</p>

<p><img src="images/Steuerung.PNG" alt="Steuerung" style="width:694px;height:435px;border:0;"></p>
  
<h2><a id="Ers">6. Erstellen von Blöcken</a></h2>
<p>Die Blöcke werden als Panels behandelt, jedes Panel besitzt eine Größe von 20x20 Pixeln.<br>
Beim verschieben der Blöcke wird eine Positionsveränderung von 20 Pixeln verwendet, somit existieren acht feste Spalten, in denen sich Blöcke befinden können.<br>
Beim erstellen ist die Größe fest definiert, die Farbe wird zufällig ausgewählt. Aus einer Liste von acht möglichen Farben wird eine ausgewählt für den neuen Block.<br>
Das Spiel ist also zu keinem Zeitpunkt unfair, es gibt nicht mehr mögliche Farben als Spalten. Das Panel wird nun der Arraylist hinzugefügt und somit vermerkt, um es später wieder löschen zu können.<br>
Die Farbe ist als BackColor defniert, somit kann durch spätere Funktionen die Farbe ausgelesen werden.<br>
Jeder neue Block wird in der ersten Zeile in der fünften Spalte erzeugt, damit eine Kontinuität entsteht.</p>

<p><img src="images/Neuer Block.PNG" alt="Neuer Block" style="width:621px;height:325px;border:0;"></p>

  
<h2><a id="Fal">7. Fallen von Blöcken</a></h2>
<p>Der aktive Block fällt um den definierten Betrag von 20 Pixeln wenn der Timer einen Tick durchlaufen hat. Zu Beginn dauert dies 0,5 Sekunden.<br>
Immer wenn Blöcke entfernt werden und das level um eins erhöht wird steigt der Schwierigkeitsgrad, dies wird durch eine Verringerung der Tick-Länge verursacht.<br>
Dafür wird eine Variable verwendet, die beim Löschen der Blöcke um eins erhöt wird. Mit dieser Variable wird der Zeitintervall berrechnet.<br>
Die Formel für das Fallen der Blöcke ist 5000 Millisekunden / (level + 9)<br>
Zu Anfang ist das level = 1, wenn die Variable "level" steigt wird auch das Zeitintervall kürzer.<br>
In der Timer Funktion wird auch das Game Over Event behandelt, sobald ein Block die oberste Zeile berührt und nicht weiter fallen kann wird der Timer angehalten und eine "Game Over" Message Box erscheint.</p>

<p><img src="images/Timer3.PNG" alt="Timer3" style="width:635px;height:175px;border:0;"></p>


<h2><a id="Lös">8. Löschen von Blöcken</a></h2>
<p>Um die Blöcke zu löschen muss zuerst festgestellt werden, ob drei gleichfarbige Blöcke neben- oder übereinander angeordnet sind.<br> Dies wird in zwei Funktionen aufgeteilt, eine zum prüfen der nebeneinander liegenden Blöcke und eine für die Blöcke übereinander.<br>
Eine weitere Funktion ist "allCheck", diese ruft "checkBeside und checkAbove" auf.</p>

<p>In der Funktion zum nebeneinander prüfen wird zuerst überprüft, ob drei Spalten nebeneinander leer sind. Wenn in den Spalten kein Inhalt ist können auch keine gleichfarbigen Panels vorliegen.<br>
Im nächsten Schritt wird davon ausgegangen, das in drei Spalten nebeneinader Blöcke liegen, aber die Farbe ist noch nicht überprüft. Das Prüfen der Farben geschieht durch den Vergleich der BackColor Einträge der Panels, wenn die Farben unterschiedlich sind beginnt der selbe Ablauf erneute für die nächste Spalte.<br>
Wenn die Farben gleich sind werden die überprüften Panels aus dem Formular gelöscht und der Arraylist Eintrag der Felder wieder auf "empty" gesetzt, also einen Wert von -1.<br>
Zusätzlich werden die Panels über den gelöschten Panels um 20 Pixel, also eine Spalte, nach unten verschoben.<br>
Danach geht die Funktion in eine Lop, wird also nochmal von vorne gestartet, um zu prüfen, ob durch die nachgerückten Panels wieder drei gleichfarbige nebeneinander liegen.<br>
Ist dies nicht der Fall wird die Funktion beendet.</p>

<p><img src="images/Überprüfen2.PNG" alt="Überprüfen2" style="width:922px;height:535px;border:0;"></p>

<p>Die Funktion zum übereinander prüfen ist genauso aufgebaut wie die Funktion zum nebeneinadner prüfen, nur die Funktion zum Nachrücken der Blöcke ist nicht in dieser.<br>
Da beide Funktionen parallel laufen ist es nicht nötig, auch in dieser Funktion das Nachrücken der Panels einzuabuen.</p>

<p><img src="images/Überprüfen3.PNG" alt="Überprüfen3" style="width:914px;height:340px;border:0;"></p>

<p>Diese beiden Funktionen werden in einer weiteren Funktion aufgerufen.<br>
Jede einzelne Zeile und Spalte wird durch die Funktionen "checkBeside" und "checkAbove" überprüft, sobald keine weiteren Panels zum löschen identifiziert werden, wird die Funktion beendet und ein neuer Block wird erzeugt.<br>
Sobald eine der Funktionen Panels aus der Arraylist entfernt wird der Wert der Variable "conuter" um eins erhöht, da so ein Punkt erzielt wird, der im Zähler im Spiel angezeigt wird.<br>
Für den Punktezähler wird ein Label verwenet, der Wert daraus wird am Ende für den Highscore verwendet.<br>
Um den Schwierigkeitsgrad kontinuierlich zu erhöhen wird nach jedem entfernen von Panels durch die Funktionen der Zeitintervall des Timers verkürzt. Sobald das level steigt wird das Tick Intervall der Blöcke neu berechnet.

<p><img src="images/Überprüfen1.PNG" alt="Überprüfen1" style="width:717px;height:518px;border:0;"></p>

<h2><a id="Hig">9. Highscore</a></h2>
<p>Der Highscore wird in einer txt-Datei gespeichert und wird jedes mal aufgerufen, wenn das Spiel gestartet wird.<br>
Es wird immer nur der höchste Highscore gespeichert, die txt-Datei kann im Programmordner gefunden werden.<br>
Es werden zwei Funktionen benutzt, um in der Datei schreiben zu können und um die Datei auslesen zu können.</p>

<p>Die Funktion zum schreiben befindet sich im timer, sobald die "game over" Message Box angezeigt wird prüft das Programm, ob der aktuelle Punktestand höher ist als der bisherige Rekord. Falls der aktuelle Punktestand höher ist als der Rekord wird der Spieler aufgefordert, seinen Namen einzugeben, dieser wird im Highscore gespeichert.<br>
Dabei wird vom Punktestand ein Punkt abgezogen, da von Beginn an der Spieler einen Punkt hat, um auf 0,5 Sekunden pro Tick für das Fallen der Blöcke zu kommen.<br>
Der Spielername und die Punktezahl werden in der txt-Datei in zwei getrennten Zeilen gespeichert, dadurch kann der Wert später einfacher ausgelesen werden.</p>

<p><img src="images/Highscore1.PNG" alt="Highscore1" style="width:707px;height:176px;border:0;"></p>

<p>Wenn das Programm gestartet wird, wird der aktuelle Highscore aus der txt-Datei geladen und im Spiel angezeigt.<br>
Dafür werden zwei Labels verwendet, Spielername und Highscore werden getrennt geladen.<br>
Die Funktion dafür befindet sich im Form1Loader, es wird also ausgeführt, wenn das Programm gestartet wird.<br>
Die Werte aus der txt-Datei werden geladen und in die vorhandenen Labels eingefügt.</p>

<p><img src="images/Highscore2.PNG" alt="Highscore2" style="width:552px;height:123px;border:0;"></p>

<h2><a id="Stu">10.Stundenprotokoll</a></h2>
<h4>21.2.2017</h4>
<p>Nach der html-Dokumentation folgt ein neues Projekt, in dieser Stunde habe Ich ein erstes Konzept für dieses erstellt. Mit Visual Basic sollte es möglich sein, ein Spiel nach dem Snake, Tetris oder Pong Prinzip zu schrieben, ohne den großen Aufwand, eine komplette neue Programmiersprache zu lernen.<br>
Eine einfache Kopie eines der gernannten Spiele ist nicht das Ziel dieses Projekts, doch eine Anlehnung an diese Klassiker wäre ein realisierbares Ziel.</p>

<h4>23.2.2017</h4>
<p>Für das neue Projekt verwende Ich das Raspberry Pi, darauf kann man mit der Programmiersprache Visual Basic arbeiten, welche leicht zu verstehen ist und schnell graphische Oberflächen erzeugen kann. Um Visual Basic auf dem Raspberry verwenden zu können muss Window 10 IOT verwendet werden.<br>
Windows 10 IOT ist eine von Windows angebotene Möglichkeit um Windows auf unter anderem dem Raspberry Pi Netzweksteuerung und Sensorensteuerung in Windows-Sprachen zu verwenden.</p>

<h4>1.3.2017</h4>
<p>Die Idee, dass Raspberry Pi zu verwenden ist prinzipiell umsetzbar, doch die Ausführung ist aufwendiger als erwartet und für die verbleibende Zeit zu knapp.<br>
Die Idee des Programms bleibt erhalten, doch die Umsetzung findet nur auf dem PC in einer normalen Programmierumgebung statt. Am Ende wird das Spiel ein Programm sein, welches Installiert werden kann und als Prozess besteht. Eine Umsetzung auf dem Raspberry Pi könnte in Zukunft noch folgen.<br>
Erste Formen und Oberflächen des neuen Programms erstellt</p>

<h4>2.3.2017</h4>
<p>Erster Code für das Programm erstellt und das Spielfeld definiert. Eine Breite von acht Feldern ist überschaubar und wird das Maß des Spielfeldes sein.<br>
Um das Spielfeld zu definieren wird eine Arraylist verwendet, <a href="https://msdn.microsoft.com/de-de/library/system.collections.arraylist(v=vs.110).aspx"> hier</a> wird die Verwendung dieser Funktion erklärt.<br>
Äußerlich für den Spieler existiert eine Begrenzung durch drei Panels in Form von Linien, im Code wird aber mit Pixel Zahlen für Blöcke und Spielfeld gearbeitet. Um das Spiel fair zu gestalten sollen acht verschiedenfarbige Blöcke integriert sein.</p>

<h4>8.3.2017</h4>
<p>In dieser Stunde weitergearbeitet am Code, die Blöcke können nun fallen durch einen Timer, bisher Stapeln die Blöcke sich aber noch unendlich, das Löschen von Blöcken ist noch nicht möglich. Auch ist der Schwierigkeitsgrad noch konstant, das Grundgerüst funktioniert aber wie angedacht.<br>
Weitere Definitionen von Varaiblen sind nötig, wie zum Beispiel eine Liste von Farben in einer Varbiablen erstellt werden kann wird <a href="https://msdn.microsoft.com/de-de/library/ke6sh835.aspx"> hier</a> erklärt.</p>

<h4>9.3.2017</h4>
<p>Aufgrund von technischen Problemen meines Laptops konnte Ich nicht am Code arbeiten, diese Stunde wurde verwendet um an der Dokumentation zu schreiben. Ein erstes Inhaltsverzeichnis wurde erstellt und Erklärungen zum bisherigen Code verfasst.<br>
Diese Erkärungen müssen aber zu einem späteren Zeitpunkt überarbeitet werden, wenn der restliche Code geschrieben ist.</p>


<h4>14.3.2017</h4>
<p>Das System für das Löschen der Blöcke erzeugt noch Fehler, wenn durch nachrücken von Blöcken ein weiteres mal Blöcke entfernt werden können ist dies bisher nicht geschehen. Den Großteil der Stunde habe ich mit diesem Bug verbracht, die Lösung war es, am Ende der "AllCheck" Funktion ein weiteres mal diese Funktion aufzurufen. Falls keine weiteren Blöcke gelöscht werden können wird die If-Abfrage sofort beendet und ein neuer Block wird generiert.</p>

<h4>16.3.2017</h4>
<p>In Visual Basic können txt-Dateien erstellt werden, in diesen kann geschreiben und auch gelesen werden. Ich habe mich in dieser Stunde damit beschäftigt, wie eine derartige Datei erstellt wird und modifiziert werden kann. Dazu gibt es eine Anleitung von Microsoft, diese kann <a href="https://msdn.microsoft.com/de-de/library/6ka1wd3w(v=vs.110).aspx">hier</a> gefunden werden. Danach habe Ich eine erste txt-Datei erstellt, die Funktionen zum auslesen und schreiben in dieser der Datei habe ich aber erst später geschrieben.<br>
Das System zum löschen der Blöcke funktioniert, es treten keine Fehler auf und der Schwierigkeitsgrad steigt kontinuirlich an. Die Steuerung ist noch problematisch, die Probleme davon konnten in dieser Stunde noch nicht behoben werden.</p>

<h4>21.3.2017</h4>
<p>In dieser Stunde habe ich mich in die "KeyDown" Funktion eingelesen, diese wird <a href="https://msdn.microsoft.com/de-de/library/system.windows.forms.control.keydown(v=vs.110).aspx"> hier</a> erklärt. Es ist möglich, durch den "KeyChar" Befehl, direkte Tastatureingaben zu verwenden, wobei der KeyDown Befehl beim Anschlag der Taste den Befehl registriert. Wenn eine Tastenkombination verwendet werden soll muss eine eigene Funktion für diese geschrieben werden, in meinem Fall werden aber nur einfache Tastenanschläge benötigt.<br>
Es existiert auch der Befehl "KeyPress", dieser verwendet aber keine Sonderzeichen, wie die Pfeile, Enter und Leertaste.<br>
In meinem Fall war "KeyDown" besser geeignet, da die Leertaste zum pausieren des Spiels verwendet werden soll.<p>

<h4>23.3.2017</h4>
<p>Letzte Stunde vor der Abgabe des Projekts, die verbleibende Zeit wurde zum schreiben an der Dokumentation verwendet. Das Programm ist fast fertig, nur Formatierungen und Positionen der Textblöcke zum Anzeigen des Highscores werden noch verändert. Die Dokumentation ist auch fast fertig, in dieser Stunde wurden die Verlinkungen innerhalb der Dokumentation erstellt.</p> 


<h2><a id="Que">11.Quellen</a></h2>
<ul>
<li><a href ="https://msdn.microsoft.com/de-de/library/system.collections.arraylist(v=vs.110).aspx">Arraylist Erklärung</a></li>
<li><a href ="https://msdn.microsoft.com/de-de/library/ke6sh835.aspx">Variablen Erkärung</a></li>
<li><a href ="https://msdn.microsoft.com/de-de/library/6ka1wd3w(v=vs.110).aspx">txt-File Erklärung</a></li>
<li><a href ="https://msdn.microsoft.com/de-de/library/system.windows.forms.control.keydown(v=vs.110).aspx">KeyDown Erkärung</a></li>
<li><a href="http://openbook.rheinwerk-verlag.de/einstieg_vb_2010/einstieg_vb_2010_kap_11_001.html">Tetris Tutorial für Visual Basic</a></li>
