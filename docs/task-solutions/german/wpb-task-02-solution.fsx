(**
---
title: 02 Functions and Data types
category: Musterlösungen(deutsch)
categoryindex: 1
index: 2
---
*)

(**

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/csbiology/BIO-BTE-12-V-4/gh-pages?filepath={{fsdocs-source-basename}}.ipynb)&emsp;
[![Script]({{root}}img/badge-script.svg)]({{root}}{{fsdocs-source-basename}}.fsx)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

# Task02 - Functions and Data types

## Tuples

### Task 1.1:

Deklariere einen Tuple aus 2. und "Februar" und binde den Tuple an den Namen `tuple1`.
*)

let tuple1 = 2.,"Februar"

(**
### Task 1.2:

Deklariere einen Tuple aus 2., "Februar" und "Fruehling" und bindet ihn an den Namen `tuple2`.
*)

let tuple2 = 2.,"Februar","Fruehling"

(**
### Task 1.3:

Greife auf den zweiten Wert des Tuples aus 1.1 zu.
*)

snd tuple1

// oder

tuple1 |> fun (x,y) -> y

(**
### Task 1.4:

Bindet `tuple1` aus Task 1.1 an: `(output1,output2)`
Warum kann das sinnvoll sein?
Stichwort: Tuple Deconstruction.
*)

let output1,output2 = tuple1

output2

// Sinnvoll, weil man damit aus einem Tupel direkt das Element an einen Namen bindet statt an späterer Stelle immer wieder umständlich auf der jeweilige Element zugreifen zu müssen.

(**
## Record Types

### Task 2.1: 

Definiere einen Record Type mit dem Namen `Person`. Person soll die Felder `Name`(string) und `Alter`(int) haben.
Bei Record Types wird kein camel case, sondern pascal case verwendet (wie camel case nur ist der erste Buchstabe auch groß).
*)

type Person = {
    Name    : string
    Alter   : int
}

(**
### Task 2.2:

Erstellt einen Wert des Typs `Person` mit ausgedachten Feldwerten und bindet ihn an den Namen `meinePerson1`.
Greift auf das Feld `Alter` von `meinePerson1` zu.
*)

let meinePerson1 = {
    Name    = "Max Mustermann"
    Alter   = 37
}

meinePerson1.Alter

(**
### Task 2.3:

Deklariere eine Funktion die zwei Inputparameter erhaelt und als Rueckgabewert eine `Person` gibt.
Binde ein Ergebnis dieser Funktion an den Namen `meinePerson2`.
*)

let erzeugePerson name alter = {
    Name    = name
    Alter   = alter
}

let meinePerson2 = erzeugePerson "Eva Mustermann" 13

(**
### Task 2.4:

Definiere einen weiteren Record Type mit dem Namen `ErweitertePerson`. ErweitertePerson soll die gleichen Felder wie `Person`
haben, bekommt aber noch das zusaetzliche Feld `Hobby`. Da man alles zu seinem Hobby machen kann, soll
'Hobby' vom Typ generic type sein.
Tipp: Zwischen dem Namen des Record types und `=` muss der generic type durch `<'a>` angegeben werden
*)

type ErweitertePerson<'a> = {
    Name    : string
    Alter   : int
    Hobby   : 'a
}

(**
### Task 2.5

Erstellt einen Wert des Typs `ErweitertePerson`.
*)

let meinePerson3 = {
    Name    = "Otto Normalbürger"
    Alter   = 50
    Hobby   = "Fußball gucken"
}

(**
## Signatures

### Task 3.1

Deklariere eine beliebige Funktion mit der Signatur `int -> int`.
*)

let beliebigeFunktion x = x + 1

(**
### Task 3.2

Deklariere eine beliebige Funktion mit der Signatur `int -> (int -> int) -> float`.
*)

let beliebigeFunktion2 x (andereFunktion : int -> int) = andereFunktion x |> float

(**
### Task 3.3

Beschreibe den Rueckgabewert einer Funktion mit folgender Signatur `char -> (string -> char -> float)`.
*)

// Der Rückgabewert ist eine Funktion, die einen Parameter vom Typ 'string' und einen vom Typ 'char' nimmt und einen float zurückgibt.

(**
## Collection types

### Task 4.1

Erstelle eine int Liste mit den Zahlen 1 bis 100 und binde sie an einen Namen.
*)

let meineListe = [1 .. 100]

// oder

let meineListe' = List.init 100 (fun i -> i + 1)

(**
### Task 4.2

Binde das erste und das letzte Element der Liste an je einen Namen.
*)

let erstesElement = meineListe.[0]
let letztesElement = meineListe.[99] // erfordert, zu wissen, wie viele Elemente die Liste hat

// oder

let erstesElement' = List.item 0 meineListe
let letztesElement' = List.item 99 meineListe // erfordert, zu wissen, wie viele Elemente die Liste hat

// oder 

let erstesElement'' = List.head meineListe
let letztesElement'' = List.last meineListe

(**
### Task 4.3

Erstelle ein float Array mit den Zahlen von 1. bis 100. und binde es an einen Namen.
*)

let meinArray = [|1. .. 100.|]

// oder

let meinArray' = Array.init 100 (fun i -> i + 1 |> float)

(**
### Task 4.4

Binde das 15. Element des Arrays aus 4.3 an einen Namen.
*)

let fuenfzehntesElement = meinArray.[14]

// oder

let fuenfzehntesElement' = Array.item 14 meinArray

// oder

let fuenfzehntesElement'' = Array.get meinArray 14

(**
### Task 4.5

Erstelle eine Map, die alle Monate enthaelt. Verwende dafuer die Zahl des Monats (integer) als Key und den Namen (string) als Value.
*)

let alleMonate = Map [
    1, "Januar"
    2, "Februar"
    3, "Maerz"
    4, "April"
    5, "Mai"
    6, "Juni"
    7, "Juli"
    8, "August"
    9, "September"
    10, "Oktober"
    11, "November"
    12, "Dezember"
]

(**
### Task 4.6

Ueberpruefe anhand eines geeigneten Keys, ob der Monat Maerz in der Map vorhanden ist.
*)

alleMonate.[3] = "Maerz"

// oder

Map.containsKey 3 alleMonate // ob es sich beim Value an der Stelle des Keys 3 jedoch um Maerz oder etwas anderes handelt, wird nicht beantwortet

// oder

Map.exists (fun key value -> key = 3 && value = "Maerz") alleMonate

(**
### Task 4.7

Erstelle zwei Sets. Eins mit Zahlen von 1 bis 10 und eins mit Zahlen von 3 bis 7 und binde sie an je einen Namen.
*)

let set1bis10 = Set [1 .. 10]

let set3bis7 = Set [3 .. 7]

(**
### Task 4.8 

Vergleicht die zuvor erstellten Sets. Bildet die Schnittmenge (intersect) und die Vereinigungsmenge (union) aus beiden Sets und bindet sie an je einen Namen.
Tipp: Nutzt das Set Modul um durch 'reindotten' geeignete Funktionen zu erhalten.
*)

let meineSchnittmenge = Set.intersect set1bis10 set3bis7

let meineVereinigungsmenge = Set.union set1bis10 set3bis7