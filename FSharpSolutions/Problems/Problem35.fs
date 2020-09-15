module Problem35

(*
The number, 197, is called a circular prime because all rotations of the digits: 197, 971, and 719, are themselves prime.

There are thirteen such primes below 100: 2, 3, 5, 7, 11, 13, 17, 31, 37, 71, 73, 79, and 97.

How many circular primes are there below one million?
*)

open NumericSequences
open Factorization
open Digits
open System.Collections.Generic

let rotations digs = //hacky way to get the rotations by concatenating two copies of the digits and extracting some specific slices.
    let doubleDigs = digs@digs
    digs
    |> List.mapi (fun i _ -> doubleDigs.[i..i+digs.Length - 1] |> Seq.rev)
    |> List.map compress

let isPoisonDigit dig = //if a prime contains any of these digits it can never be circular... unless it is two or 5.
    if Seq.tryFind (fun pd -> pd = dig) [0; 2; 4; 5; 6; 8] = None then false
    else true
  
let hasPoisonDigits digits = 
    if Seq.tryFind (fun dig -> isPoisonDigit dig) digits = None then false
    else true

let isCircular prime ps =
    let digs = prime |> digits |> Array.toList
    if prime > 10 && hasPoisonDigits digs then false //see above comment for the reason behind prime > 10.
    else rotations digs |> List.forall (isPrime ps)

let solution = 
    let max = 1000000 //one million
    let ps = primes max

    ps |> Seq.filter (fun p -> isCircular p ps) |> Seq.length
