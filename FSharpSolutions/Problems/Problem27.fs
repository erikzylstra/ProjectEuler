module Problem27

(*
Euler discovered the remarkable quadratic formula:

n^2+n+41

It turns out that the formula will produce 40 primes for the consecutive integer values 0≤n≤39. 
However, when n=40,402+40+41=40(40+1)+41 is divisible by 41, and certainly when n=41,412+41+41 is clearly divisible by 41.

The incredible formula n^2−79n+1601 was discovered, which produces 80 primes for the consecutive values 0≤n≤79. 
The product of the coefficients, −79 and 1601, is −126479.

Considering quadratics of the form:

    n^2+an+b, where |a|<1000 and |b|≤1000

where |n| is the modulus/absolute value of n e.g. |11|=11 and |−4|=4

Find the product of the coefficients, aand b, for the quadratic expression that produces 
the maximum number of primes for consecutive values of n, starting with n=0.
*)

//iterate over each possible formula (one million in number) and:
//iterate through the values of each function starting from 0 until we reach a composite number
//assign a count score based on the number of primes
//find the quadratic with highest score 
//take product of the coefficients

//Solution: -59231

//still kinda slow, 44s

open Factorization
open NumericSequences
let solution = 

    let primes = primes 100000000 |> Seq.map float

    let quad (a:float) (b: float) (n: float) = (n*n) + (a*n) + b

    let quadScore a b = List.unfold (fun n -> if isPrimeFloat (quad a b n) primes then Some(n, n + 1.0) else None) 0.0 |> List.length

    (List.allPairs [-999..2..999] [-999..2..999]) //go by two to avoid even numbers; they fail when n = 2
    |> List.map (fun (a, b) -> (a, b, quadScore (float a) (float b)))   
    |> List.maxBy (fun (_, _, score) -> score)
    |> (fun (a, b, score) -> (a, b, score, a * b))

