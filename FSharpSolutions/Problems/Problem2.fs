﻿module Problem2

//
//Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1 and 2, the first 10 terms will be:
//1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
//By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.
//Solution: 4613732
//

let solution = 
    
    //second solution:
    let fourMillion = 4 * 1000000

    NumericSequences.fibs 
    |> Seq.takeWhile (fun f -> f <= fourMillion) 
    |> Seq.filter (fun f -> f % 2 = 0)
    |> Seq.reduce (+)

    
    //first solution:

    //let maxVal = 4 * 1000000  //four million

    //let rec filterEven numbers evens = 
    //    match numbers with
    //    | [] -> evens
    //    | head::tail when head % 2 = 0 -> filterEven tail (head::evens)
    //    | _::tail -> filterEven tail evens

    //let numbers = Fibs |> Seq.takeWhile (fun i -> (int i) <= maxVal) |> Seq.toList |> List.map int
    //filterEven numbers [] |> List.fold (+) 0