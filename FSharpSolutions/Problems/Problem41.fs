module Problem41
open NumericSequences
open Factorization
open Digits

(*We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once. 
For example, 2143 is a 4-digit pandigital and is also prime.

What is the largest n-digit pandigital prime that exists?*)
//Solution: 7652413



//Solution steps:
//Generate primes < sqrt(1 billion) = 31622 for trial division
//Generate all n-pandigital numbers (9! = 362880 so this is feasible); this will neccessitate a way to generate permutations of sets.
//check for primality using trial division. (Factorization module)

let ps = primes 31622 //see solution steps

//places n at every possible location in list.
let distribute n (list : list<int>) = (List.replicate (list.Length + 1) list)
                                      |> List.mapi (fun i l -> l |> List.splitAt i)
                                      |> List.map (fun (first, second) -> first@[n]@second)

let rec permutations (list : list<int>) =
    match list with
    | _ when list.Length = 2 -> [list; list |> List.rev]
    | x::xs -> xs |> permutations |> List.collect (fun perm -> distribute x perm)
    | _ -> []

let solution = 
    [1..9] 
    |> List.map (fun i -> [1..i])
    |> Seq.collect permutations
    |> Seq.map compress 
    |> Seq.filter (isPrime ps) 
    |> Seq.max
