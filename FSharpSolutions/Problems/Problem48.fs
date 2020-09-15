module Problem48
(*
The series, 1^1 + 2^2 + 3^3 + ... + 10^10 = 10405071317.
Find the last ten digits of the series, 1^1 + 2^2 + 3^3 + ... + 1000^1000.
*)

//Last ten digits = modulo 10^10
let modulus = bigint.Pow(10I, 10)

//Raises a bigint to its own power. Then uses the modulus to get the last ten digits.
let selfPow (b : bigint) = 
    bigint.ModPow(b, b, modulus)

//Adds two numbers then takes the modulus.
let modSum (a : bigint) (b : bigint) = 
    bigint.ModPow(bigint.Add(a, b), 1I, modulus)

let solution = 
    let tail = [2I..1000I] |> List.fold (fun acc i -> (modSum acc (selfPow i))) 1I |> string
    if tail.Length < 10 then "0" + tail else tail //need to account for zero as first digit
    //Solution: 9110846700