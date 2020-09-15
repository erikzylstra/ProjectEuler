module Problem1
//
//If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
//Find the sum of all the multiples of 3 or 5 below 1000.
//Solution: 233168
//

let isMultiple n = 
    if (n % 3 = 0) || (n % 5 = 0) then true
    else false

let solution =  
    [1..999] |> List.where (fun i -> isMultiple i) |> List.reduce (+)
