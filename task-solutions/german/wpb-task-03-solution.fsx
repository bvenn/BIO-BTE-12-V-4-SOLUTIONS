(**
// can't yet format YamlFrontmatter (["title: 03 Control flow"; "category: Musterlösungen(deutsch)"; "categoryindex: 1"; "index: 3"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

[![Binder](/BIO-BTE-12-V-4-SOLUTIONS/img/badge-binder.svg)](https://mybinder.org/v2/gh/csbiology/BIO-BTE-12-V-4/gh-pages?filepath=task-solutions/german/wpb-task-03-solution.ipynb)&emsp;
[![Script](/BIO-BTE-12-V-4-SOLUTIONS/img/badge-script.svg)](/BIO-BTE-12-V-4-SOLUTIONS/task-solutions/german/wpb-task-03-solution.fsx)&emsp;
[![Notebook](/BIO-BTE-12-V-4-SOLUTIONS/img/badge-notebook.svg)](/BIO-BTE-12-V-4-SOLUTIONS/task-solutions/german/wpb-task-03-solution.ipynb)

# Task03 - Control Flow


## If-then-else

### Task 1.1:

Deklariere eine Funktion, die einen Parameter `x` vom Typ float erhaelt. Ist der Wert von `x` groesser Null, so soll die Funktion den Wert zurueckgeben, falls nicht soll das 
Vorzeichen umgekehrt und denn der Wert zerueckgegeben werden.  
Tipp: Multiplikation


*)
let myFunc x = 
    if x > 0. then 
        x 
    else 
        x * -1.
(**
### Task 1.2:

Deklariere eine Funktion, die drei Zahlen als Parameter bekommt. Die groesste der drei Zahlen soll als Ergebnis ausgegeben werden.  
Tipp: `elif`!


*)
// mit elif und bool-Operatoren
let myFunc2 x y z =
    if x > y && x > z then
        x
    elif y > z then
        y
    else z

// ohne elif und bool-Operatoren
let myFunc2' x y z =
    if x > y then
        if x > z then
            x
        else
            z
    else
        if y > z then
            y
        else z
(**
### Task 1.3:

Deklariere eine Funktion, die eine Jahreszahl als Parameter bekommt. Wenn es sich um ein Schaltjahr handelt, soll das Ergebnis `true` sein, andernfalls `false`.  
Tipps:  
- Ist die Jahreszahl durch vier teilbar, aber nicht durch 100, ist es ein Schaltjahr. 2008 faellt unter diese Regel.  
- Ist die Jahreszahl durch 100 teilbar, aber nicht durch 400, ist es kein Schaltjahr. 2100 wird kein Schaltjahr sein.  
- Ist die Jahreszahl durch 400 teilbar, dann ist es immer ein Schaltjahr. Deshalb war das Jahr 2000 ein Schaltjahr.


*)
let istSchaltjahr jahreszahl =
    if jahreszahl % 4 = 0 && jahreszahl % 100 <> 0 then
        true
    elif jahreszahl % 100 = 0 && jahreszahl % 400 <> 0 then
        false
    elif jahreszahl % 400 = 0 then 
        true
    else false
(**
## Pattern matching

### Task 2.1:

Deklariere eine Funktion mit denselben Eigenschaften wie in Task 1.1 beschrieben. Verzichte auf if-then-else Expressions und verwende Pattern Matching.  
Tipp: Guarding Rules + Wildcard


*)
let myFunc3 x =
    match x with
    | a when a > 0. -> x
    | _             -> x * -1.
(**
### Task 2.2:

Gegeben ist die UnionCase Definition `Monat`:
```fsharp
type Monat =
    | Januar
    | Februar
    | Maerz
    | April
    | Mai
    | Juni
    | Juli
    | August
    | September
    | Oktober
    | November
    | Dezember
```

und die UnionCase Definition `Jahreszeit`:
```fsharp
type Jahreszeit =
    | Fruehling
    | Sommer
    | Herbst
    | Winter
```

Deklariere eine Funktion, die einen Parameter `m` vom Typ `Monat` besitzt. Verwende Pattern Matching, um jeden
Monat einer Jahreszeit zuzuordnen.


*)
type Monat =
    | Januar
    | Februar
    | Maerz
    | April
    | Mai
    | Juni
    | Juli
    | August
    | September
    | Oktober
    | November
    | Dezember
type Jahreszeit =
    | Fruehling
    | Sommer
    | Herbst
    | Winter


let monatZuJahreszeit m =
    match m with
    | Dezember  | Januar    | Februar   -> Winter
    | Maerz     | April     | Mai       -> Fruehling
    | Juni      | Juli      | August    -> Sommer
    | _                                 -> Herbst
(**
### Task 2.3:

Pattern matching ist sehr gut dazu geeignet Datenstrukturen zu zerlegen (eng. deconstruction). Deklariere eine
Funktion, die den Record type `Person` (bekannt aus Uebung 2) erhaelt und `true` zurueckgibt, falls der Nachname `Mueller` lautet.  
Tipp: https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/records#pattern-matching-with-records


*)
type Person = {
    Name    : string
    Alter   : int
}

let istNameMueller person =
    match person.Name with
    | "Mueller" -> true
    | _         -> false
(**
## Schleifen

### Task 3.1:

Deklariere eine Funktion, die einen Parameter `n` vom Typ `int` erhaelt.  
Die Funktion soll alle ganzen Zahlen von 1 bis n in der Konsole ausgeben (Tipp: `printfn`). Benutze dafuer eine `for`-Loop.


*)
let myFunc4 n =
    for i = 1 to n do
        printfn "%i" i
(**
### Task 3.2:

Deklariere eine Funktion, die einen Parameter `n` vom Typ `int` erhaelt.  
Die Funktion soll alle ganzen Zahlen von 1 bis n in einer Liste speichern.  
Tipps: Sequence Expressions, Comprehensions  
Extra Punkt: schreibe nur alle geraden Zahlen in eine Liste, Tipps: if-then-else, modulo.


*)
let myFunc5 n =
    [for i = 1 to n do i] // veraltet: [for i = 1 to n do yield i]

let myFunc5E n =
    [for i = 1 to n do 
        if i % 2 = 0 then i]
(**
### Task 3.3:

Deklariere eine Funktion, die einen Parameter `n` vom Typ `int` und einen Parameter `f` mit der Signatur `(int -> int)` erhaelt.  
Die Funktion soll `f` auf alle ganzen Zahlen von 1 bis n anwenden und in einer in einer Liste speichern.  
Tipps: Sequence Expressions, Comprehensions


*)
let myFunc6 n (f : int -> int) =
    [for i = 1 to n do f i]
(**
## Rekursion

### Task 4.1:

Modifiziere folgende Funktion (bekannt aus der Vorlesung) so, dass sie am Ende ausgibt wie viele Stufen bewaeltigt wurden.
```fsharp
let rec stufeSteigen nStufen position =
    if position = nStufen + 1 then
        printfn "Puh, geschafft"
    else
        printfn "Ich sollte mehr Sport machen"
        stufeSteigen nStufen (position + 1)
```


*)
let rec stufeSteigen nStufen aktPosition startPosition =
    if aktPosition = nStufen + 1 then
        printfn "Puh, geschafft. Das waren immerhin %i Stufen!" (nStufen - startPosition)
    else
        printfn "Ich sollte mehr Sport machen"
        stufeSteigen nStufen (aktPosition + 1) startPosition

let stufeSteigen' nStufen position =
    let rec loop positionLoop =
        if positionLoop = nStufen + 1 then
            printfn "Puh, geschafft. Das waren immerhin %i Stufen!" (nStufen - position)
        else
            printfn "Ich sollte mehr Sport machen"
            loop (positionLoop + 1)
    loop position
(**
### Task 4.2:

Modifiziere die folgende Funktion (bekannt aus der Vorlesung) so, dass sie -1 zurueckgibt, falls abzusehen ist, dass das Ergebnis groesser als 1000 wird.  
Tipp: Hier hilft die `print`-Funktion um Zwischenergebnisse zu visualisieren und die Funktion besser zu verstehen. Z. B.: `printfn "n:%i, acc':%i" n acc`.
```fsharp
let rec facultaet acc n  =
    if n = 1 then
        acc 
    else
        let acc' = n * acc
        facultaet acc' (n - 1)

facultaet 1 4
```


*)
let rec facultaet acc n  =
    if n = 1 then
        acc 
    elif acc * n > 1000 then
        -1
    else
        let acc' = n * acc
        facultaet acc' (n - 1)