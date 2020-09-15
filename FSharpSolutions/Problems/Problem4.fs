module Problem4

(*
A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
Find the largest palindrome made from the product of two 3-digit numbers.
Solution: 906609
*)

let palindrome i = 
    let s = i.ToString()
    match s.Length with
    | 6 -> s.[0] = s.[5] && s.[1] = s.[4] && s.[2] = s.[3]
    | 5 -> s.[0] = s.[4] && s.[1] = s.[3]

let products i = 
    let nums = [100..i]
    List.map (fun x -> i * x) nums

let GetMax l = 
    match l with
    | [] -> 0
    | _ -> List.max l

let solution =
    [100..999]
    |> List.map products
    |> List.map (List.filter palindrome)
    |> List.map GetMax 
    |> List.max