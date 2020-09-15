module Problem10
(*
The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
Find the sum of all the primes below two million.
Solution: 142913828922
*)

let solution = 
    let twoMillion = 2000000
    NumericSequences.primes twoMillion |> Seq.map (fun p -> int64 p) |> Seq.reduce (+)