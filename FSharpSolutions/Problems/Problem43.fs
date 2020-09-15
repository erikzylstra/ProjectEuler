module Problem43
open NumericSequences
open Combinatorics

(*
The number, 1406357289, is a 0 to 9 pandigital number because it is made up of each of the digits 0 to 9 in some order, 
but it also has a rather interesting sub-string divisibility property.

Let d1 be the 1st digit, d2 be the 2nd digit, and so on. In this way, we note the following:

    d2d3d4=406 is divisible by 2
    d3d4d5=063 is divisible by 3
    d4d5d6=635 is divisible by 5
    d5d6d7=357 is divisible by 7
    d6d7d8=572 is divisible by 11
    d7d8d9=728 is divisible by 13
    d8d9d10=289 is divisible by 17

Find the sum of all 0 to 9 pandigital numbers with this property.
*)
//Solution: 16695334890. Takes 12s, since there are ~3.6 million pandigitals



//Solution Steps:
//We have a way to generate permutations, so we can generate all 0-9 pandigitals
//Build function that checks pandigitals for the division prop
//Filter pandigitals using above function, sum results

let pans = permutations [0..9]
let ps = primes 17

let section i (list : list<int>) = 
    list.[i..i+2] |> List.map (fun i -> i.ToString()) |> List.reduce (+) |> int

let hasDivisionProp (list : list<int>) = 
    Seq.mapi (fun i prime -> (prime, i)) ps
    |> Seq.forall (fun (prime, idx) -> (section (idx+1) list)%prime = 0)

let bigAdd n m = bigint.Add(n, m)

//takes the digits of a number and combines them into the underlying bigint.
let Compress (digits : list<int>) = 
    digits |> List.mapi (fun i digit -> bigint.Multiply(bigint digit, bigint.Pow(10I, digits.Length - i - 1)))
    |> List.fold bigAdd 0I

let solution = 
    pans |> Seq.filter hasDivisionProp |> Seq.map Compress |> Seq.fold bigAdd 0I

