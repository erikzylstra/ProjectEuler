module Problem15

(*
Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner.
How many such routes are there through a 20×20 grid?
Solution: 137846528820
*)

//The answer is the number of ways to order 20 "rights" and 20 "downs," which is (2n)!/((n!)^2) for n = 20

let factorial n = [1I..n] |> List.reduce (*)

let square (n : bigint) = n * n

let solution = 
    let n = 20I
    factorial(2I * n) / square(factorial n)