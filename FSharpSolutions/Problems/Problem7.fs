module Problem7
(*
By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
What is the 10 001st prime number?
Solution: 104743
*)

//use the prime number theorem to estimate the size of the sieve we need to use
//experiment has shown that the ratio of number of primes to N/log(N) is always < 1.3,
//but we will double our estimate for simplicity/ to be safe

open System

let primeCounter n = float n / Math.Log(float n) |> int

let solution = 
    let findPrime index = 
        let estimate = ExponentialSearch.search primeCounter index 32 //arbitrary but low initial start for search
        let ps = NumericSequences.primes (estimate * 2) |> Seq.toList
        ps.[index]

    findPrime 10000
    



