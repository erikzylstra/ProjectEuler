module Digits

let bigDigits (n : bigint) = 
    n.ToString().ToCharArray() |> Array.map System.Globalization.CharUnicodeInfo.GetDigitValue

let digits (n : int) = 
    bigint n |> bigDigits

let compress (digits : seq<int>) =
    digits |> Seq.map string |> Seq.fold (fun acc dig -> dig + acc) "" |> int

let Sum (n : bigint) = 
    let digits = n.ToString().ToCharArray()
    digits |> Seq.map System.Char.GetNumericValue |> Seq.reduce (+) |> int

let Count (n : bigint) = 
    n.ToString().ToCharArray().Length

let isNPandigital N num = 
    set [1..N] = set (digits num)