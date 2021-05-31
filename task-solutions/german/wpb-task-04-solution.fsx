(**
[![Binder](/BIO-BTE-12-V-4-SOLUTIONS/img/badge-binder.svg)](https://mybinder.org/v2/gh/csbiology/BIO-BTE-12-V-4/gh-pages?filepath=task-solutions/german/wpb-task-04-solution.ipynb)&emsp;
[![Script](/BIO-BTE-12-V-4-SOLUTIONS/img/badge-script.svg)](/BIO-BTE-12-V-4-SOLUTIONS/task-solutions/german/wpb-task-04-solution.fsx)&emsp;
[![Notebook](/BIO-BTE-12-V-4-SOLUTIONS/img/badge-notebook.svg)](/BIO-BTE-12-V-4-SOLUTIONS/task-solutions/german/wpb-task-04-solution.ipynb)


# Task04 - Programming with functions

## Funktionen höherer Ordnung

### Task 1.1:

Schreibe folgende Funktion mit Hilfe des Pipe-Operators `|>` und den angegebenen Funktionen.

Tipp: 

  - Der Pipeoperator setzt den Parameter links vom Operator ans Ende der rechten Seite: 

  - `a |> add b` ist gleichbedeutend mit `add b a`


*)
let mathNotation x y = ((2. + 3. * (x + 1.))**2.) * y


let add (a:float) b = a + b
let square (x :float) = x * x
let multiply (a:float) b = a * b


let pipeNotation x y =
    x
    |> add 1.
    |> multiply 3.
    |> add 2.
    |> square
    |> multiply y

// Test ob beide notationen das gleiche Ergebnis erzeugen
pipeNotation 1. 7. = mathNotation 1. 7.
(**
### Task 1.2

Deklariere eine beliebige Funktion mit der Signatur `int -> int -> int`. Achte darauf, dass alle Parameter im Funktionskörper verwendet werden.

Ist dies eine Funktion erster Ordnung oder eine Funktion höherer Ordnung?



*)
let subtract a b = a - b
//  Funktion 1. Ordnung 
(**
### Task 1.3

Deklariere eine beliebige Funktion mit der Signatur `int -> int -> (int -> int -> int) -> float`. Achte darauf, dass alle Parameter verwendet werden.

Ist dies eine Funktion erster Ordnung oder eine Funktion höherer Ordnung?

*)
let testFunction a b (f:int -> int -> int) =
    f a b
    |> float

// Funktion höherer Ordnung
(**
### Task 1.4

Rufe die in `1.3` erstellte Funktion auf. Nutze als Parameter zwei beliebige Werte sowie die Funktion aus `1.2`.


*)
testFunction 2 4 subtract
(**
## Programmieren mit Funktionen

### Task 2.1.1

Unten siehst du einen record type mit dem Namen `Cat`. 
Erstelle zwei beliebige Werte des Typs `Cat` und binde sie an beliebige Namen.
Schaut euch `Übung 02` an, falls es hier Schwierigkeiten geben sollte.



*)
type Cat = {
    Name    : string
    Weight  : float
    Color   : string
    Age     : int}

let createCat n w c a = {Name=n;Weight=w;Color=c;Age=a}

let paul = createCat "Paulchen" 4.2 "black" 6
let lisa = createCat "Lischen" 3.3 "red" 2
(**
### Task 2.1.2

Deklariere eine Funktion mit dem Namen `getWeight`, die als Parameter eine `Cat` erhält und deren Gewicht zurück gibt. 


*)
let getWeight cat = cat.Weight
(**
### Task 2.1.3

Du kannst keine mathematischen Standard-Operatoren auf record typen anwenden. 
Deklariere eine Funktion mit dem Namen `applyToWeight`, die zwei Parameter vom Typ `Cat` (c1 und c2) und einen Parameter vom Typ `(float -> float -> float)` (f) erhält. 
Im Funktionskörper soll die Funktion f auf die Gewichte der beiden Katzen c1 und c2 angewendet werden.

Tipp: Definiere die Typen der Parameter. 



*)
let applyToWeight (c1:Cat) c2 (f:float -> float -> float) =
    f c1.Weight c2.Weight
(**
### Task 2.1.4

Wende die Funktion `applyToWeight` mit den zuvor erstellten `Cats` und der Funktion `averageOfTwo` an.  



*)
let averageOfTwo (a:float) b =
    (a + b) / 2.

applyToWeight paul lisa averageOfTwo
(**
### Task 2.2 (optional)

Diese Aufgabe muss nicht gelöst werden! Sie dient dazu eine `Cat list` zu erstellen, die an späterer Stelle benötigt wird.
Wenn du willst, kannst du kommentieren was in den angegebenen Zeilen geschieht (Extrapunkt)



*)
// Dies ist ein Zufallsgenerator. 
// Mit randomNumberGenerator.NextDouble() kann nun ein zufälliger float zwischen 0. und 1. erstellt werden.
// Mit randomNumberGenerator.Next(x) kann nun ein zufälliger int zwischen 0 und x-1 erstellt werden.
let randomNumberGenerator = System.Random()

// Nachfolgend ist eine Funktion dargestellt, die einen Wert vom Typ Cat erstellt.
let createRandomCat (i :int) = 
    // Kommentar: An 'name' wird ein string gebunden, der aus dem Zusammenschluss aus "Cat " und dem Parameter i (integer) besteht, der zu einem string umgewandelt wird.
    let name   = "Cat " + string i 
    // Kommentar: An 'age' wird ein integer gebunden, der eine zufaellige Zahl zwischen 0 und 15 ist.
    let age    = randomNumberGenerator.Next(16)
    // Kommentar: An 'weight' wird ein float gebunden, der aus einer Berechnung (3+5x) mit einem zufaelligen Wert zwischen 0. und 1. ensteht.
    let weight = 3. + 5. * randomNumberGenerator.NextDouble()
    let color  = 
        let colors = ["white";"red";"black";"grey";"mixed"]
        // Kommentar: Das 'colors' Array ist 5 Elemente lang. Der Index der zu waehlenden Farbe wird durch modulo 5 bestimmt.
        // Wenn i > 4, dann liegt der Teilungs-Rest zwischen 0 und 4. Damit ist fuer jeden integer eine Farbe definiert.
        colors.[i%5]
    // Kommentar: Hier wird ein Wert des Typs Cat mithilfe der zuvor erstellten Wertebindung erstellt (instantiiert).
    {
    Name    = name
    Weight  = weight
    Color   = color   
    Age     = age
    }

// Kommentar: Hier wird eine Cat-Liste erstellt, die 60 random cats enthaelt
let catList = [for i=1 to 60 do yield createRandomCat i]
(**
### Task 2.3

Erstelle eine float List mit den Werten von 0. bis 100. und binde sie an den Namen `nList`.



*)
let nList = [1. .. 100.]
(**
### Task 2.4

Mit map-Funktionen kann man eine Funktion, die auf einzelnen Elementen angewendet werden kann auf alle Elemente einer Liste anwenden.
Parameter der `map`-Funktion:

  1. `doSomethingWithX`:  Funktion, die auf jedes Listenelement angewendet werden soll

  2. `list`:              Liste der Elemente, auf die `doSomeThingWithX` angewendet werden soll

Die `List.map` Funktion wird dann folgendermaßen angewendet:

  - `List.map (fun listElement -> doSomethingWithX listElement) list`

Wende auf jedes Element von `nList` die Funktion `square` (Task 1.1) an. Binde das Ergebnis an den Namen `nListSquared`.


*)
let nListSquared = List.map (fun x -> square x) nList
(**
### Task 2.5

Extrahiere alle Gewichte aus 'catList' und binde sie an den Namen `catWeights`.



*)
let catWeights = catList |> List.map (fun x -> x.Weight)
(**
### Task 2.6

Berechne die Summe der Werte aus `nList`. 

Tipp: Durchsuche das `List`-Modul nach einer passenden Funktion.


*)
List.sum nList
(**
### Task 2.7

Filtere alle Listenelemente, die durch 15 teilbar sind.

Tipp1: Nutze `List.filter` und die angegebene Funktion.

*)
let isDivisibleWithoutRemainder denumerator numerator = 
     numerator % denumerator = 0.

List.filter (isDivisibleWithoutRemainder 15.) nList
(**
### Task 2.8

Berechne die Summe der Quadrate der einzelnen Werte aus nList.
Versuche dieses in einem Schritt mit `List.fold` zu erreichen.

*)
List.fold (fun acc x -> acc + square x) 0. nList
(**
### Task 2.9

Berechne das Durchschnittsgewicht der Katzen aus `catList`. 

Tipp: Die Aufgabe kann entweder durch die Nutzung von Funktionen aus dem `List`-Modul gelöst werden, oder man löst sie durch eine einzige fold Funktion (für Experten).

*)
List.average catWeights

List.fold (fun acc x -> acc + (x / float catWeights.Length)) 0. catWeights