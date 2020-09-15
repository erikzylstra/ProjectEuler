module Problem9

(*
There exists exactly one Pythagorean triplet for which a + b + c = 1000.
Find the product abc.
Solution: 31875000
*)

let solution = 

    let pythagorean = function
        | (a, b, c) -> a*a + b*b = c*c

    let product = function 
        | (a, b, c) -> a*b*c

    let allTriples = List.allPairs [1..500] [1..500] |> List.map (fun (a,b) -> a, b, 1000 - a - b)

    allTriples
    |> List.find pythagorean
    |> product