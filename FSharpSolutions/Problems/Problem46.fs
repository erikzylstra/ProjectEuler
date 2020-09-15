module Problem46

open System

(*It was proposed by Christian Goldbach that every odd composite number can be written as the sum of a prime and twice a square.

9 = 7 + 2×1^2
15 = 7 + 2×2^2
21 = 3 + 2×3^2
25 = 7 + 2×3^2
27 = 19 + 2×2^2
33 = 31 + 2×1^2

It turns out that the conjecture was false.

What is the smallest odd composite that cannot be written as the sum of a prime and twice a square?*)

let odds = Seq.initInfinite (fun n -> 2.0*(float n) + 1.0)

let squares = function //gets all square numbers <= to max.
    | max when max < 1.0 -> Seq.empty
    | max -> Seq.map (fun i -> i * i) {1.0..(sqrt max)}

let checkOdd odd primes = //check whether the odd number has the Goldbach property above. Primes should pass trivially.
    let sqrs = squares ((odd-1.0)/2.0)
    let prms = Seq.takeWhile (fun p -> p <= odd) primes
    if Seq.last prms = odd then true else
        Seq.allPairs prms sqrs |> Seq.map (fun (p, s) -> p + 2.0*s)
        |> Seq.contains odd

let checkRange odds primes = 
    Seq.tryFind (fun odd -> not (checkOdd odd primes)) odds

//let solution = 
//    let primes = NumericSequences.primes 10000 |> Seq.tail |> Seq.map (fun i -> float i) //don't consider 2; a 2 in the "Goldbach decomposition" results in an even number.
    //checkRange primes primes
    //search ranges get larger by powers of two 
    //let searchRangeLimits = [1.0..Math.Log2(Double.MaxValue)] |> List.map (fun exp -> 2.0**exp)
    //List.tryFind checkRange [1.0..searchRangeLimits] (primes )