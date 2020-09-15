module Problem47

open System.Collections.Generic

(*
The first two consecutive numbers to have two distinct prime factors are:

14 = 2 × 7
15 = 3 × 5

The first three consecutive numbers to have three distinct prime factors are:

644 = 2² × 7 × 23
645 = 3 × 5 × 43
646 = 2 × 17 × 19.

Find the first four consecutive integers to have four distinct prime factors each. What is the first of these numbers?
*)


(*****Solved, but runtime is about 2 min*****)

//letting this be mutable so we can calculate more if neccessary.
let mutable ps = NumericSequences.primes 1000 |> Seq.toList 

let factorize i primes = 
    Factorization.primeDivisors i primes 
    |> Seq.map (fun fac -> (fac, Factorization.multiplicity i fac))

let rec testConsecutive i = 
    if i >= ps.[ps.Length - 1] then 
        ps <- NumericSequences.primes (2 * i) |> Seq.toList

    let factors = 
        seq {i..i+3} |> Seq.collect (fun j -> factorize j ps)
        |> Seq.distinct |> Seq.toList

    match factors.Length with
    | 16 -> i //4 primes with 4 factors is 16 factors
    | _ -> testConsecutive (i + 1)

let solution = testConsecutive 1
//Solution: 134043