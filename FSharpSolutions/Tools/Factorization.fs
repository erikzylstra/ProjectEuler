module Factorization

open Microsoft.FSharp.Core.Operators

let divides n m = (n % m = 0)

//primes loaded beforehand for repeatability
let primeDivisors n primesToCheck = 
    let primes = primesToCheck |> Seq.takeWhile (fun p -> p <= n)
    primes |> Seq.filter (fun p -> divides n p)
    
let rec multiplicity n factor =
    match n % factor with
    | x when x <> 0 -> 0
    | _ -> 1 + multiplicity (n / factor) factor

let properDivisors n = 
    [1..(n/2)] |> List.filter (fun p -> divides n p)

let isPrimeFloat (n : float) (primes : seq<float>)= 
    if n < 2.0 then 
        false 
    else
        Seq.takeWhile (fun p -> p <= sqrt n) primes |> Seq.filter (fun p -> n % p = 0.0) |> Seq.isEmpty

let isPrime (primes : seq<int>) (n : int) = 
    isPrimeFloat (float n) (Seq.map float primes)
