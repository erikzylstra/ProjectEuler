module Problem40

(*
An irrational decimal fraction is created by concatenating the positive integers:

0.123456789101112131415161718192021...

It can be seen that the 12th digit of the fractional part is 1.

If d_n represents the nth digit of the fractional part, find the value of the following expression.

d_1 × d_10 × d_100 × d_1000 × d_10000 × d_100000 × d_1000000
*)
//Solution: 210


open Digits

//acc keeps track of how many digits we used. Every integer is split into digits and the digits are assigned their number of places after the decimal using acc.
let digitMap = 
    Seq.unfold (fun (n, acc) -> Some((digits n) |> Seq.mapi (fun i dig -> (dig, acc + i)), (n + 1, acc + n.ToString().Length))) (1, 1)

let nthDigit n =
    digitMap |> Seq.find (fun digs -> (Seq.tryFind (fun (_, place) -> place = n) digs) <> None) 
    |> Seq.find (fun (_, place) -> place = n) |> fst

let solution = 
    (nthDigit 1) * (nthDigit 10) * (nthDigit 100) * (nthDigit 1000) * (nthDigit 10000) * (nthDigit 100000) * (nthDigit 1000000)