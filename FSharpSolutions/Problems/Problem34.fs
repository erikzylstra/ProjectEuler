module Problem34

(*

145 is a curious number, as 1! + 4! + 5! = 1 + 24 + 120 = 145.

Find the sum of all numbers which are equal to the sum of the factorial of their digits.

Note: as 1! = 1 and 2! = 2 are not sums they are not included.

*)

//Calculations:
//9! = 362880
//8 * 9! = 2903040 which is only a seven digit number.
//so the factorial-sum of the digits of any eight digit number will not be high enough to represent that number.
//Therefore we need only consider numbers with less than eight digits, i.e. less than ten million.

//Solution: 40730

open Digits

let factorial n = 
    if n = 0 then 1
    else [1..n] |> List.reduce (*)

let facSum n = 
    n |> digits
    |> Array.map factorial
    |> Array.reduce (+)

let solution = 
    let max = 10000000
    seq { 3..max }
    |> Seq.filter (fun n -> n = facSum n)
    |> Seq.sum
