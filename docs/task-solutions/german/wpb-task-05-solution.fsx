(**
---
title: 05 Programming with Objects 
category: Musterlösungen(deutsch)
categoryindex: 1
index: 5
---
*)

(**
[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/csbiology/BIO-BTE-12-V-4/gh-pages?filepath={{fsdocs-source-basename}}.ipynb)&emsp;
[![Script]({{root}}img/badge-script.svg)]({{root}}{{fsdocs-source-basename}}.fsx)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

# Task05 - Programming with Objects 

## Veränderliche Werte

### Task 1.1:

Erstellen und Verändern von veränderlichen Werten

Tipp: 

- Benutzt das `mutable` keyword
- Zur Veränderung der Werte wird der `<-` Operator verwendet

### Subtask 1.1.1

Erstelle einen veränderlichen Integer mit dem Wert 1 und bindet ihn an den Namen x


*)

let mutable x = 1

(**
### Subtask 1.1.2

Verändere den Wert der an x gebunden ist indem ihr den Wert den x trägt mit 5 multipliziert 

*)

x <- (x * 5)

(**
### Subtask 1.1.3

Erstelle einen Record Type `Mensch` mit 

- dem unveränderlichen Feld `Name` vom Typ string
- und dem veränderlichen Feld `Alter` vom Typ int

*)

type Mensch =
    {
        Name : string
        mutable Alter : int
    }

(**
### Subtask 1.1.4

Erstelle die Funktion `geburtstagFeiern` die als Parameter einen Wert des Typen `Mensch` erhält und das Alter des Menschen um eins erhöht

*)

let geburtstagFeiern (m : Mensch) =
    m.Alter <- m.Alter + 1

(**
### Subtask 1.1.5

Erstelle einen Menschen, binde ihn an einen Namen und lass diesen erstellten Menschen mit der Funktion `geburtstagFeiern` altern.

*)

let mensch1 = { Name = "Max"; Alter = 22 }

geburtstagFeiern mensch1

(**
### Task 1.2 (Bonusaufgabe) Veränderliche Werte in Funktionen

Erstelle eine eigene Version der `Array.max` Funktion. Diese Funktion soll ein Array von ints erhalten und den größten der ints zurückgeben.
Signatur: `int [] -> int`

Dabei soll der aktuell größte int ein `veränderlicher Wert` sein und es soll eine `for-Schleife` verwendet werden.

*)

let arrayMax (array : int[]) = 
    let mutable maxValue = array.[0] 
    for i in array do
        if i > maxValue then
            maxValue <- i
    maxValue

let arrayMax2 (array : int[]) = 
    let mutable maxValue = array.[0] 
    for i = 1 to array.Length - 1 do
        if array.[i] > maxValue then
            maxValue <- array.[i]
    maxValue

let array1 = [|4; 23; 6; 4; 7|]

arrayMax array1
arrayMax2 array1

(**
## Vererbung

### Task 2.1 Erstellen von Klassen und Objekten

### Subtask 2.1.1

Im folgenden wird die Klasse `Fahrzeug` erstellt. Versuche nachzuvollziehen, was passiert und kommentiere jede Zeile kurz

Keywortfundgrube: Methode, Feld, Konstruktor, Parameter, alternativ, binden


*)

// Kommentar: Es wird eine Klasse namens `Fahrzeug` erstellt, deren Hauptkonstruktor einen Parameter namens `hersteller` vom Typ string erhält
type Fahrzeug (hersteller:string) =
    // Kommentar: Ein Feld namens `Hersteller` wird definiert, an das der Wert des parameters `hersteller` gebunden wird
    member self.Hersteller = hersteller
    // Kommentar: Es wird eine parameterlose Methode namens `Fahren` definiert, welche über die Selbstreferenz das Feld `Hersteller` verwendet
    member self.Fahren() = printfn "%s macht brumm brumm" self.Hersteller
    // Kommentar: Ein parameterloser alternativer Konstruktor wird erstellt.
    new() = Fahrzeug("VW")

(**
### Subtask 2.1.2

Instanziiere 2 Objekte des Typs `Fahrzeug`. Verwende einmal den den Haupt- und einmal den alternativen Konstruktor

*)

let car1 = new Fahrzeug("Ford")

let car2 = new Fahrzeug()

(**
### Task 2.2 Vererbung

### Subtask 2.2.1

Hier ist ein Beispiel für die Vererbung eines Typen, namentlich der Typ `Motorrad` der vom Typ `Fahrzeug` erbt. 

Erstelle analog einen Typen `Auto`, der auch vom Typ `Fahrzeug` erben soll. Dieser Typ soll aber zusätzlich das Feld `AnzahlTueren` enthalten. 
Wähle hierzu einen passenden primitiven Typen und passe auch den Konstruktor an, sodass diese Anzahl der Türen auch beim Instanziieren gesetzt werden kann.

*)

type Motorrad (hersteller:string) =

    inherit Fahrzeug(hersteller)

    new() = Motorrad("Kawasaki")

type Auto (hersteller : string, anzahlTueren : int) =

    inherit Fahrzeug(hersteller)

    member self.AnzahlTueren = anzahlTueren

    new() = Auto("Mercedes",4)

(**
### Subtask 2.2.2

Erstelle eine Funktion, welche einen Parameter des Typs `Fahrzeug` enthält und die Methode `Fahren` dieses Fahrzeuges ausführt.

*)

let fahren (fahrzeug : #Fahrzeug) =

    fahrzeug.Fahren()

(**
### Subtask 2.2.3

Erstelle ein `Auto` und binde en an einen Namen. Dann wende die oben definierte Funktion zum `Fahren` darauf an.

*)

let car3 = new Auto("Toyota", 3)

fahren car3

(**

### Task 2.3 (Bonusaufgabe) Veränderliche Werte in Objekten

Deklariere eine Klasse `Cabrio` die vom Typ `Fahrzeug` erbt. 

Diese Klasse soll ein Feld `DachOffen` vom Typ `bool` haben und zusätzlich Methoden, mit denen man das Dach öffnen und schließen kann

*)

// Lösung über Feld nur mit get (default), und Methoden die das Verhalten regeln (bevorzugt)
type Cabrio (hersteller:string, tueren:int) =

    inherit Auto(hersteller,tueren)

    let mutable dachOffen = false

    // Feld abrufbar aber nicht verwänderbar
    member this.DachOffen = dachOffen

    // Methoden, zur gezielten Zustandsänderung
    member self.Oeffnen() = 
        if dachOffen then printfn "Das Dach ist bereits offen!"
        else printfn "Das Dach ist jetzt offen."
        dachOffen <- true

    member self.Schliessen() = 
        if dachOffen then printfn "Das Dach ist jetzt zu!"
        else printfn "Das Dach ist schon zu!"
        dachOffen <- false        

    // Methoden, zum automatischen Zustandswechsel
    member this.DachBetaetigen() =
        if dachOffen = true then 
            dachOffen <- false
        else
            dachOffen <- true

// Zusätzliche Hilfsfunktionen
let dachSchliessen (c:Cabrio) = 
    c.Schliessen()

let dachOeffnen (c:Cabrio) = 
    c.Oeffnen()


let neuesCabrio = new Cabrio("Audi",4)

dachOeffnen neuesCabrio



// Lösung über Feld mit get/set, ohne Methoden
type Cabrio2 (hersteller:string, tueren:int) =

    inherit Auto(hersteller,tueren)

    let mutable dachOffen = false

    // Feld abrufbar und verwänderbar
    member this.DachOffen
        with get () = dachOffen
        and set (v) = dachOffen <- v

// In diesem Fall müssten die Funktionen die Logik selbst tragen
let dachOeffnen2 (c:Cabrio2) = 
    if c.DachOffen then printfn "Das Dach ist bereits offen!"
    else printfn "Das Dach ist jetzt offen."
    c.DachOffen <- true

let dachSchliessen2 (c:Cabrio2) = 
    if c.DachOffen then printfn "Das Dach ist jetzt zu!"
    else printfn "Das Dach ist schon zu!"
    c.DachOffen <- false       

let neuesCabrio2 = new Cabrio2("Audi",4)

dachOeffnen2 neuesCabrio2 


(**
## Polymorphismus

### Task 3.1

Wir wollen hier Personen implementieren, die ihren Namen sagen können. In Japan wird auch im alltäglichen Leben normalerweise der Familienname vor dem Eigennamen genannt. 
So ist Yoko Ono in Japan als Ono Yoko bekannt. Um diesen Unterschied programmatisch darzustellen, wurde der Code folgendermassen geschrieben:

Ordne die folgenden Begriffen den zugehörigen Codebausteinen zu: `Klassendeklaration`, `Objektinstanziierung`, `Interfacedeklaration`


*)
// Bezeichnung: Interfacedeklaration
type IPerson =
    abstract FamilienName   : string
    abstract EigenName      : string
    abstract NamenSagen     : unit -> string

// Bezeichnung: Klassendeklaration
type Japaner (fn, en) =
    let familienName = fn
    let eigenName = en
    interface IPerson with
        member self.FamilienName = familienName
        member self.EigenName = eigenName
        member self.NamenSagen () = familienName + " " + eigenName

// Bezeichnung: Klassendeklaration
type Deutscher (fn, en) =
    let familienName = fn
    let eigenName = en
    interface IPerson with
        member self.FamilienName = familienName
        member self.EigenName = eigenName
        member self.NamenSagen () = eigenName + " " + familienName

// Bezeichnung: Objektinstanziierung
let yokoOno = Japaner("Ono","Yoko")

// Bezeichnung: Objektinstanziierung
let angeloMerte = Deutscher("Merte","Angelo")
(**
### Task 3.2

Greife auf die Methode `NamenSagen` der beiden Personen zu. 
Tipp: Verwende den korrekten `casting Operator`

*)
// Variante1
let say = yokoOno :> IPerson
say.NamenSagen()

// Variante2
(angeloMerte :> IPerson).NamenSagen()

// Variante3
let namenSagen (p : #IPerson) =
    p.NamenSagen()

namenSagen yokoOno

(**
### Task 3.3

Erkläre kurz in eigenen Worten, warum in diesem Beispiel Polymorphismus verwendet wurde und nicht Vererbung.

*)

// In diesem Fall sollen alle Personen die gleiche Methode `NamenSagen` besitzen. Was genau in der Methode passiert soll aber je nach Nationalität unterschiedlich sein.
// Bei Vererbung würde das Verhalten der Methode einmal definiert werden und alle erbenden Personen würde den Namen auf die gleich Weise sagen.
// Polymorphismus erlaubt es, dass das konkrete Verhalten sich für die gleich benutzbare Methode zwischen den Leuten unterscheidet.

(**
### Task 3.4

Im fernen Land Dingeldongel wird wie auch in Deutschland erst der Eigenname und dann der Familienname genannt. Beide werden jedoch revertiert. (Angela Merkel -> alegnA lekreM)

Deklariere die Klasse `Dingeldongler`, die das Interface `IPerson` implementiert.

Tipp: Verwende die gegebene string-revertier Funktion


*)
let revert (s:string) = System.String(s.ToCharArray() |> Array.rev)

type Dingeldongler (fn, en) =
    let familienName = fn
    let eigenName = en 
    interface IPerson with
        member self.FamilienName = familienName
        member self.EigenName = eigenName
        member self.NamenSagen () = revert eigenName + " " + revert familienName

let amblimKamblim = Dingeldongler("Kamblim", "Amblim")
(amblimKamblim :> IPerson).NamenSagen()