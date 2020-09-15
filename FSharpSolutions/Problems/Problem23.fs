module Problem23

(*

A perfect number is a number for which the sum of its proper divisors is exactly equal to the number. 
For example, the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.

A number n is called deficient if the sum of its proper divisors is less than n and it is called abundant if this sum exceeds n.

As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number that can be written as the sum of two abundant numbers is 24. 
By mathematical analysis, it can be shown that all integers greater than 28123 can be written as the sum of two abundant numbers. 
However, this upper limit cannot be reduced any further by analysis 
even though it is known that the greatest number that cannot be expressed as the sum of two abundant numbers is less than this limit.

Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.

*)

//find abundant numbers < 28124
//take all pairwise sums of these numbers
//remove these sums from { a : a is an integer < 28124 }
//sum leftover numbers

let isAbundant (n : int) = 
    let d = List.sum (Factorization.properDivisors n)
    d > n

//let allSums intList = 
//    intList |> List.mapi (fun i x -> intList.GetSlice(Some i, None) |> List.map (fun n -> n + x))
//    |> List.concat |> List.distinct

let rec allSums acc intList = 
    match intList with
    | [] -> acc |> List.distinct
    | x::xs -> allSums (intList |> List.fold (fun acc i -> (i + x)::acc) acc) xs

let solution = 
    let abundantSums = [1..28124] |> List.filter isAbundant |> allSums []
    (Set.ofList [1..28124]) - (Set.ofList abundantSums) |> Set.toList |> List.sum