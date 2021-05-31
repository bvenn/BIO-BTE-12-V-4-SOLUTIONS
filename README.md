# BIO-BTE-12-V-4
Notebooks, scripts and guides for the lecture Wissenschaftliche Programmierung für Biologen (BIO-BTE-12-V-4)

### Website lokal testen:

- dotnet tool restore
- dotnet fsdocs watch --eval

### Überführen der alten Übungen:

- VSCode hat mittlerweile keine probleme mehr mit umlaut encoding. Falls das doch bei euch der fall sein sollte, hier sind die relevanten settings:

![](./docs/img/VSCode-encoding.png)

- VS Community speichert allerdings nicht immer in UTF8 ab, das ist dann zu sehen, wenn die PR gestellt wird, oder das selbe file in VSCode geöffnet wird. Stellt also entweder sicher, dass das file in UTF8 (ohne BOM!) gespeichert wird, oder arbeitet einfach in VSCode.
- single line kommentare (`//`) ersetzen durch Kommentarblöcke im fsdocs format (`(** *)`)
- light markdown in den text blöcken verwenden
- `(******)` sind notwendig zwischen zwei Kommentarblöcken falls dazwischen ein Codeblock kommen soll.
- Englische versionen der übungen in `/docs/tasks/english`, deutsche in `/docs/tasks/german`
- Frontmatter muss am anfang der jeweiligen .fsx datei stehen: 

    ```fsharp
    (**
    ---
    title: Übung 01 // titel, der in der sidebar angezeigt wird
    category: Übungen(deutsch) // Kategorie, unter der der artikel in der sidebar eingeordnet wird
    categoryindex: 2 // index (für Reihenfolge) der Kategorie
    index: 2 // index (für Reihenfolge) des artikels innerhalb der kategorie 
    ---
    *)
    ```
- Binder links:
```
[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/csbiology/BIO-BTE-12-V-4/gh-pages?filepath={{fsdocs-source-basename}}.ipynb)&emsp;
[![Script]({{root}}img/badge-script.svg)]({{root}}{{fsdocs-source-basename}}.fsx)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)
```

### Hinzufügen der lecture slides/videos

Die lecture artikel haben alle dasselbe format, es kann also der von der vorherigen kopiert werden, und folgende sachen angepasst werden:

- Name und Index(!) der Vorlesung
- Links zu den vimeo videos (auf https://csb.bio.uni-kl.de/teaching/index.html#/lecture/sc1 -> rechtsklick auf das video of interest -> inspect -> iframe src attribut)
    ![image](https://user-images.githubusercontent.com/21338071/119108986-1097c100-ba21-11eb-9501-b24b35146d18.png)
