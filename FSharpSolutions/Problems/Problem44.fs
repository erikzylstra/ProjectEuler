﻿module Problem44

(*
Pentagonal numbers are generated by the formula, Pn=n(3n−1)/2. The first ten pentagonal numbers are:

1, 5, 12, 22, 35, 51, 70, 92, 117, 145, ...

It can be seen that P4 + P7 = 22 + 70 = 92 = P8. However, their difference, 70 − 22 = 48, is not pentagonal.

Find the pair of pentagonal numbers, Pj and Pk, for which their sum and difference are pentagonal and D = |Pk − Pj| is minimised; 
what is the value of D?
*)

//Since the numbers get increasingly farther apart, minimising D is equivalent to finding the first such pair
//Pk and Pj for which their sum and diff are pentagonal.
//The algrothm we will use is as follows:
    //iterate over the pentagonals
    //add all previous pentagonals to the current pentagonal
    //if such a number is pentagonal, then we have a pair whose difference is pentagonal.
    //filter these pairs for those which also sum to pentagonals
    //declare victory the first time we find such a pair

let pentagonals = 
    let gen n = (n*(3*n - 1))/2
    Seq.initInfinite gen
    //Seq.unfold (fun n -> Some(gen n, n+1)) 1

let sumPrevious pent = 
    Seq.takeWhile (fun p -> p <= pent) pentagonals |> Seq.map (fun p -> (p, p + pent))

//The generating function for the pentagonals is a quadratic,
//so if we throw away the negative solutions we can invert it.
//It is not exact enough to test for pentagonality but it can tell us which pentagonals to compare
//with a certain number.
let inversePentagonal (v : int) = 
    (1.0/6.0) + sqrt ((2.0/3.0)*(float v) + (1.0/36.0))

let isPentagonal p = 
    let inv = inversePentagonal p |> int
    [max 0 (inv-3)..inv+2] |> List.map (fun i -> Seq.item i pentagonals)
    |> List.tryFind (fun pent -> pent = p) 
    |> (fun opt -> opt <> None)

let checkP p = 
    sumPrevious p 
    |> Seq.filter (fun pair -> isPentagonal (snd pair))
    |> Seq.tryFind (fun (p1, p2) -> isPentagonal (p1 + p2))

let solution = 
    pentagonals |> Seq.map checkP |> Seq.find (fun (p : (int*int) option) -> p<>None && (fst p.Value) > 1)
    

