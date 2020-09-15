module Problem37

open Digits
open NumericSequences
open Factorization

(*
The number 3797 has an interesting property. Being prime itself, it is possible to continuously remove digits from left to right, 
and remain prime at each stage: 3797, 797, 97, and 7. Similarly we can work from right to left: 3797, 379, 37, and 3.

Find the sum of the only eleven primes that are both truncatable from left to right and right to left.

NOTE: 2, 3, 5, and 7 are not considered to be truncatable primes.
*)
//Solution: 748317

//Solution steps:
//build right/ left functions that generate the truncated numbers given an integer.
//use above function and filter to find the 11 primes.
//Sum them

//combines digits back into an integer
let CompressDigits (digits : list<int>) = 
    if digits.Length = 0 then 0 else
    digits |> List.map string |> List.fold (fun acc dig -> acc + dig) "" |> int

let leftTruncates n =
    Array.foldBack (fun dig acc -> (dig::acc.Head)::acc) (digits n) [[]] |> List.map CompressDigits |> List.rev |> List.tail

let rightTruncates n = 
    let digs = digits n |> Array.toList
    [1..digs.Length] |> List.map (fun i -> List.take i digs |> CompressDigits)

//by varying the below parameter we can find all 11 primes
let ps = primes 1000000 //one million

let arePrimes ls = List.forall (isPrime ps) ls

let hasPrimeTruncates n =
    arePrimes (leftTruncates n) && arePrimes (rightTruncates n)

let solution =  //an exception is thrown if we do not find 11 such primes in our search range
    ps |> Seq.filter (fun p -> p > 10 && hasPrimeTruncates p) |> Seq.take 11 |> Seq.reduce (+)