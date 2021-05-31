(**
---
title: 01 Hello F#
category: Musterlösungen(deutsch)
categoryindex: 1
index: 1
---
*)

(**
[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/csbiology/BIO-BTE-12-V-4/gh-pages?filepath={{fsdocs-source-basename}}.ipynb)&emsp;
[![Script]({{root}}img/badge-script.svg)]({{root}}{{fsdocs-source-basename}}.fsx)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)


# Task01 - Hello F#
-------------------------------
Erst einmal die absoluten Basics:
- **In einem .fsx script:** 
    Markiert die '10', und drueckt Alt+Enter, dann sollte sich die interaktive Konsole oeffnen und euer 
    Output sollte 'val it: int = 10' sein.
    (Bei einzeiligem Code koennt ihr auch einfach die Zeile auswaehlen und Alt+Enter druecken ohne das alles markiert ist.)
- **In einem Notebook:**
    Links von dem Feld unten das die '10' beinhaltet befindet sich ein 'play' Knopf. 
    Dieser Knopf führt beim drücken den jeweiligen Code-block aus und gibt das Ergebnis (hier: 10) darunter aus.
    **Codeblöcke in notebooks müssen immer mit dem Wert enden, der ausgegben werden soll.**
*)

10

(**
Auf diese Weise koennt ihr Code den ihr geschrieben habt, direkt testen und euch den Output ansehen.
Versucht das mal mit der folgenden Zeile und ihr werdet sehen, dass das Ergebnis direkt ausgerechnet wird und 30 ist.
*)

10 + 20

(**
Alles was ihr hinter `//` oder innerhalb von `(* ... *)` schreibt ist ein Kommentar und wird nicht als Code ausgefuehrt.
Ihr koennt auch Teile einer Zeile mit `(* ... *)` auskommentieren. 
Die Standardtastenkombination zum auskommentieren ist (Strg + K -> Strg + C)
*)

10 (*+ 40 *) + 30

(**
Solltet ihr bei einer Uebung nicht auf die Loesung kommen, lasst auf jeden Fall euren Loesungsansatz stehen!
## Das 'let'-Binding
## Task 1
### Task 1.1
Binde den Wert 10 an den Namen 'x'. Binde den Wert 20 an den Namen 'kaesebrot'.
*)

let x = 10

let kaesebrot = 20

(**
### Task 1.2
Binde das Ergebnis der Addition von 'x' mit dem Wert 10 an 'y'.
*)

let y = x + 10

(**
### Task 1.3
Binde einen Vornamen als string an 'vorname'.
*)

let vorname = "Vorname"

(**
### Task 1.4
Berechne den Rest aus 432858049/41 und binde das Ergebnis an 'modulo'
*)

let modulo = 432858049%41

(**
### Task 1.5
Binde die Summe der jeweiligen Summen aus x + 10 und y + 20 an den Namen 'summeXY'. 
Die Zwischenergebnisse sollten nicht im globalen Sichtbarkeitsbereich (Scope) liegen.
*)

let summeXY =
    let summeX = x + 10
    let summeY = y + 20
    summeX + summeY

// oder kürzer und ohne zwischenErgebnis:
let summeXY' = x + 10 + y + 20

(**
## Die "printfn" - Funktion
### Task 2
_Tipp: https://docs.microsoft.com/de-de/dotnet/fsharp/language-reference/plaintext-formatting_
### Task 2.1:  
Benutze die printfn - Funktion um "Hallo F#" in die Konsole auszugeben.
*)

printfn "Hallo F#"

(**
### Task 2.2:  
Benutze die printfn - Funktion um den Wert von 'vorname' in die Konsole auszugeben.
*)

printfn "%s" vorname

(**
### Task 2.3:  
Benutzt printfn um 'y' in die Konsole auszugeben.
*)

printfn "%i" y

(**
## Primitive Datentypen und Funktionen
### Task 3
### Task 3.1
Binde einen beliebigen Wert vom Typ Integer an den Namen intI.
*)

let intI = 1

(**
### Task 3.2
Binde einen beliebigen Wert vom Typ Float an den Namen floatI.
*)

let floatI = 2.

(**
### Task 3.3
Wandelt entweder intI oder floatI in den Datentyp des anderen um und addiert beide.
*)

intI + int floatI

// oder:
float intI + floatI

(**
### Task 3.4
Berechne den Quotienten aus '27' und '13'. Dann berechne den Quotienten von beiden Integern als Float.
*)

27 / 13

float 27 / float 13

(**
### Task 3.5:
Konkateniere einen beliebigen Wert vom Typ String mit einem einzelnem Buchstaben (Typ Char)
*)

"myStrin" + string 'g'

(**
### Task 3.6:
Deklariere eine Funktion 'mulitplyBy2' die einen float verdoppelt. 
*)

let multiplyBy2 (x:float) = 2.0 * x

(**
### Task 3.7:  
Deklariere eine Funktion 'calculateCylinderVolume' die aus Radius und Laenge das Volumen eines Zylinders 
zurueckgibt UND zusaetzlich "Das Volumen des Zylinders ist: XX" in die Konsole printed. Wobei XX natuerlich 
das korrekte Volumen des Zylinders ist. (Der Output einer printfn Funktion ist Unit.)
Warum kann es Sinn machen, Ergebnisse zu printen? 
*)

// Mögliche Antwort: die print Funktion erlaubt es Zwischenergebnisse zu visualisieren.
let calculateCylinderVolume radius laenge =
    let volumen = System.Math.PI * radius * radius * laenge
    printfn "Das Volumen des Zylinders ist: %f" volumen
    // Der Rückgabewert ist gleich dem Wert der an Volumen gebunden wurde
    volumen

(**
### Task 3.8:  
Deklariere eine Funktion die einen Parameter vom Typ Integer als Input nimmt und die 'multiplyBy2' 
Funtkion darauf anwendet
*)

let multiplyBy2Two x = multiplyBy2 (float x)

(**
### Task 3.9:  
Deklariere eine Funktion die als Input zwei Parameter vom Typ Float, einen Vergleichsoperator z.B. 
(<, >, = ), und einen Parameter vom Typ Boolean akzeptiert. Das Ergebnis aus der Anwendung des angegebenen 
Operators auf die numerischen Parameter soll mit dem Parameter vom Typ Boolean auf Gleichheit ueberprueft werden.
(_2 Punkte_)
*)

let compare (x:float) (y:float) (op: float  -> float -> bool) (boolWert:bool) = 
    let tmp = op x y 
    tmp = boolWert