module Problem6
(*
The sum of the squares of the first ten natural numbers is 385
The square of the sum of the first ten natural numbers is 3025
Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025−385=2640.
Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
Solution: 25164150
*)

let solution = 
    let sumOfSquares max = 
        [1..max] |> List.map (fun i -> i*i) |> List.reduce (+)

    let squareOfSum max = 
        let sum = List.reduce (+) [1..max]
        sum * sum

    squareOfSum 100 - sumOfSquares 100