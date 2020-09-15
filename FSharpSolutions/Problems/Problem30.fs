module Problem30

(*
Surprisingly there are only three numbers that can be written as the sum of fourth powers of their digits:

1634 = 14 + 64 + 34 + 44    <-- exponents
8208 = 84 + 24 + 04 + 84
9474 = 94 + 44 + 74 + 44
As 1 = 14 is not a sum it is not included.

The sum of these numbers is 1634 + 8208 + 9474 = 19316.

Find the sum of all the numbers that can be written as the sum of fifth powers of their digits.
*)

//Solution: 443839

//It is easy to check whether a number is the sum of the fifth powers of its digits.
//It is also trivial to sum them.
//The question remains which numbers to check.
//9^5 = 59049
//9^5 + 9^5 = 118098
//.........
//7 * (9^5) = 413343 which is only a six digit number, but is the max sum for a 7 digit number.
//Therefore we need only check numbers with less than 7 digits, i.e. less than one million.

let toTheFifth n = List.replicate 5 n |> List.reduce (*)

open Digits
let fifthPowerSumEqual (n : int) = 
    let digSum =
        (bigDigits (bigint n))
        |> Array.map (fun digit -> toTheFifth digit)
        |> Array.reduce (+)
    n = digSum

let solution = 
    [2..999999] 
    |> List.filter fifthPowerSumEqual 
    |> List.reduce (+)