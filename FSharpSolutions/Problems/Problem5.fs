module Problem5
(*
2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
Solution: 232792560
*)

let solution = 

    let nums = [2..20]

    let rec sieveMultiples (l : list<int>) = 
        match l with
        | [] -> []
        | x::xs -> x::(sieveMultiples (List.map (fun y -> if y % x = 0 then y / x else y) xs))

    sieveMultiples nums |> List.reduce (*)