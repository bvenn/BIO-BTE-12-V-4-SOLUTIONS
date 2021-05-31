(**
// can't yet format YamlFrontmatter (["title: 01 Hello F#"; "category: Model solution(english)"; "categoryindex: 2"; "index: 1"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

[![Binder](/BIO-BTE-12-V-4-SOLUTIONS/img/badge-binder.svg)](https://mybinder.org/v2/gh/csbiology/BIO-BTE-12-V-4/gh-pages?filepath=task-solutions/english/wpb-task-01-solution.ipynb)&emsp;
[![Script](/BIO-BTE-12-V-4-SOLUTIONS/img/badge-script.svg)](/BIO-BTE-12-V-4-SOLUTIONS/task-solutions/english/wpb-task-01-solution.fsx)&emsp;
[![Notebook](/BIO-BTE-12-V-4-SOLUTIONS/img/badge-notebook.svg)](/BIO-BTE-12-V-4-SOLUTIONS/task-solutions/english/wpb-task-01-solution.ipynb)
# Task01 - Hello F#


-------------------------------
Let's start with the basics:
- **In a .fsx script:** 
    Highlight the '10' and press Alt+Enter, which will open a console and give the output 'val it: int = 10'.
    (If the code to execute has only one line, you can just click into the line and press Alt+Enter without highlighting.)
- **In a notebook:**
    There is a 'play' button in the left upper corner of the field below. Press it to execute the respective code block, 
    which in this case will simply give '10' as output. 
    **Note that you always have to end codeblocks in notebooks with the value you want to put out**

*)
10
(**
Working in this interactive way has the advantage that you can always directly test your code and look at the output.
Try it with the line below and appreciate that the result of the calculation is 30.

*)
10 + 20
(**
Everything after a `//` or inside of `(* ... *)` is treated as a comment and will not get executed as code.
You can use `(* ... *)` to comment parts of a single line. 
The standard keybinding for commenting a selection is (Strg + K -> Strg + C)

*)
10 (*+ 40 *) + 30
(**
If you not quite get a task right, please submit partial solutions or trails of thought as comments to get partial points!
## Das 'let'-Binding
## Task 1
### Task 1.1
Bind the value 10 to the name 'x'. Bind the value 20 to the name 'kaesebrot'.

*)
let x = 10

let kaesebrot = 20
(**
### Task 1.2
Bind the result of the Addition of 'x' and 10 to the name 'y'.

*)
let y = x + 10
(**
### Task 1.3
Bind any first name as string to 'vorname'.

*)
let vorname = "Vorname"
(**
### Task 1.4
Calculate the remainder of 432858049/41 and bind the result to 'modulo'

*)
let modulo = 432858049%41
(**
### Task 1.5
Binde the sum of both sums (x + 10) and (y + 20) to the Name 'sumXY'. 
Die Zwischenergebnisse sollten nicht im globalen Sichtbarkeitsbereich (Scope) liegen.

*)
let summeXY =
    let summeX = x + 10
    let summeY = y + 20
    summeX + summeY

// shorter version without intermediate results:
let summeXY' = x + 10 + y + 20
(**
## Die "printfn" - Funktion
### Task 2
_Tipp: https://docs.microsoft.com/de-de/dotnet/fsharp/language-reference/plaintext-formatting_
### Task 2.1:  
Use the printfn function to print "Hello F#" to the console.

*)
printfn "Hallo F#"
(**
### Task 2.2:  
Use the printfn function to print the value of 'vorname' to the console.

*)
printfn "%s" vorname
(**
### Task 2.3:  
Use the printfn function to print the value of 'y' to the console.

*)
printfn "%i" y
(**
## Primitive Datentypen und Funktionen
### Task 3
### Task 3.1
Bind an arbitrary integer value to the name intI.

*)
let intI = 1
(**
### Task 3.2
Bind an arbitrary float value to the name floatI.

*)
let floatI = 2.
(**
### Task 3.3
Convert one of intI or floatI to the data type of the other and sum both up.

*)
intI + int floatI

// or:
float intI + floatI
(**
### Task 3.4
Calculate the integer division of '27' und '13'. Then perform the same operation but on '27' and '13' as float values.

*)
27 / 13

float 27 / float 13
(**
### Task 3.5:
Concatenate an arbitrary string value with an arbitrary char (character)

*)
"myStrin" + string 'g'
(**
### Task 3.6:
Declare a function named 'mulitplyBy2' that doubles a single input float.

*)
let multiplyBy2 (x:float) = 2.0 * x
(**
### Task 3.7:  
Declare a function named 'calculateCylinderVolume' that takes radius and length of a cylinder as inputs and 
returns the cylinders volume AND additionally prints the message "The volume of the cylinder is XXX" (where XXX is the volume)
Why can it make sense to print values inside a function before returning a value?

*)
// Possible answer: The printf function allows visualization of intermediate results.
let calculateCylinderVolume radius length =
    let volume = System.Math.PI * radius * radius * length
    printfn "The volume of the cylinder is: %f" volume
    // The returned value is the same as the value bound to "volume"
    volume
(**
### Task 3.8:  
Declare a function that takes an integer as input, converts it, and applies the previously defined 'multiplyBy2' function on it.

*)
let multiplyBy2Two x = multiplyBy2 (float x)
(**
### Task 3.9:  
Declare a function that takes the feollowing inputs:
- two floats
- a comparison operator (<, >, = )
- a boolean
The function should then compare the result of applying the operator to the two 
float inputs with the boolean input and return the result.
(_2 Points_)

*)
let compare (x:float) (y:float) (op: float  -> float -> bool) (boolWert:bool) = 
    let tmp = op x y 
    tmp = boolWert