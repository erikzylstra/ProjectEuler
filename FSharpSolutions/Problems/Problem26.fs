module Problem26

(*
A unit fraction contains 1 in the numerator. The decimal representation of the unit fractions with denominators 2 to 10 are given:

    1/2	= 	0.5
    1/3	= 	0.(3)
    1/4	= 	0.25
    1/5	= 	0.2
    1/6	= 	0.1(6)
    1/7	= 	0.(142857)
    1/8	= 	0.125
    1/9	= 	0.(1)
    1/10	= 	0.1 

Where 0.1(6) means 0.166666..., and has a 1-digit recurring cycle. It can be seen that 1/7 has a 6-digit recurring cycle.

Find the value of d < 1000 for which 1/d contains the longest recurring cycle in its decimal fraction part.
*)

//Solution: 

open Factorization
open NumericSequences

//given the denominator d, finds the digit that is p places after the decimal of 1/d
let decimalPart (d : int) (p : int) = bigint.ModPow(bigint.Divide(bigint.Pow(10I, p), bigint d), 1I, 10I) |> int

let decimalTrail (d : int) (length : int) = List.unfold (fun i -> if i < length then Some((decimalPart d i), i + 1) else None) 1

//decimalTrail 995 20

//declare victory if the digits in our search range that are a cycle length apart are equal
let hasCycleWithLength cycleLength digits =
    let hasEqualDigits digList = digList |> List.forall (fun (_, digit) -> digit = snd (List.head digList))
    digits |> List.mapi (fun i digit -> (i, digit)) //small hack since I need the index in the groupBy
                 |> List.groupBy (fun (i, _) -> i % cycleLength) //group the digits that are spaced a cycle length apart
                 |> List.forall (fun (_, digits) -> hasEqualDigits digits) //if we found a cycle, the digits spaced the cycle length apart are equal.

let ps = primes 1000

//research shows the length of the cycle of a number n must divide phi(n) where phi is Euler's totient function.
//this puts a cap on the lengths of the cycles we have to look for
let totient n = 
    if isPrime ps n then n else
    let prod = (primeDivisors n (Seq.takeWhile (fun p -> p < n / 2) ps)) 
               |> Seq.map (fun p -> p - 1)
               |> Seq.reduce (*)
    prod / n 

let range = [995..999] //d < 1000
let maxLengths = dict([for n in range do (n, totient n)])

let searchDigits d digits = 
    digits |> List.splitAt (digits.Length - (10 * maxLengths.[d])) |> snd

//this actually gives the value 1 for d where 1/d terminates but we are only looking for large values.
let cycleLength d = 
    let digits = decimalTrail d (maxLengths.[d] * 100)
    List.unfold (fun i -> if i <= maxLengths.[d] && not (hasCycleWithLength i (searchDigits d digits)) then Some(i, i + 1) else None) 1
    |> List.length |> (fun l -> l + 1)

let solution =
    range |> List.maxBy (fun d -> cycleLength d)