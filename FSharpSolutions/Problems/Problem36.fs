module Problem36

open System
open Digits

(*
The decimal number, 585 = 1001001001 (binary), is palindromic in both bases.

Find the sum of all numbers, less than one million, which are palindromic in base 10 and base 2.

(Please note that the palindromic number, in either base, may not include leading zeros.)
*)
//Solution: 872187



//Solution steps:
//function to check whether digit arrays are palindromes
//function for generating binary digits
//following the parenthetical, filter out evens since then the binary rep has a 0 at the end
//also numbers that start with even numbers due to the reflection of the digits.
//filter range of numbers for both palindrome types using above functions, sum results

let isPalindrome (digits : list<int>) = //works for any base
    if digits.Head % 2 = 0 then false //filter numbers with even first digit; see solution steps
    else if digits.Length = 1 then true //trivial; also would break next step
    else
        let halves = List.splitAt(digits.Length / 2) digits //split in half
        let backHalf = snd halves |> List.rev //reverse the second half so we start at the end
        List.mapi (fun i dig -> dig = backHalf.[i]) (fst halves) |> List.reduce (&&) //compare the halves sequentially

let binaryDigits (n : int) = 
    Convert.ToString(n, 2).ToCharArray() |> Array.map System.Globalization.CharUnicodeInfo.GetDigitValue |> Array.toList

let solution = 
    [1..2..1000000] //odds less than one million
    |> List.filter (fun n -> (isPalindrome (digits n |> Array.toList)) && isPalindrome (binaryDigits n))
    |> List.reduce (+)