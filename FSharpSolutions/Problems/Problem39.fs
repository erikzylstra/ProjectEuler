module Problem39

open System

(*
If p is the perimeter of a right angle triangle with integral length sides, {a,b,c}, there are exactly three solutions for p = 120.

{20,48,52}, {24,45,51}, {30,40,50}

For which value of p ≤ 1000, is the number of solutions maximised?
*)
//Solution: 840; there are 8 triples



//Solution steps:
//Find all pythagorean triples (a, b, c) where a + b < 1000 (weaker than a + b + c <= 1000)
//and a, b, c are integers.
//Group these triples by the perimeter
//Take the perimeter value with the largest group

let pythagTriples p = //this generates triples with all possible a and b values (plus a little extra); c is chosen to satisfy the Pythagorean theorem, but may not be an integer.
    [1..p-2] |> Seq.collect (fun a -> seq { for b in a..p-a-1 do (float a, float b) })
    |> Seq.map (fun (a, b) -> (a, b, sqrt(a*a + b*b)))

let isIntegerTriple (abc : Tuple<float, float, float>) = //also filter out triples with p vals too large
    (fun (a, b, c) -> a + b + c = floor(a + b + c) && (a + b + c <= 1000.0)) abc

let solution = 
    pythagTriples 1000 |> Seq.filter isIntegerTriple
    |> Seq.groupBy (fun (a, b, c) -> a + b + c)
    |> Seq.map (fun (p, triples) -> (p, triples |> Seq.length))
    |> Seq.maxBy (fun (p, numSolns) -> numSolns)
