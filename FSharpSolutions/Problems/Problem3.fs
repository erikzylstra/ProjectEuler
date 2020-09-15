module Problem3

//
//The prime factors of 13195 are 5, 7, 13 and 29.
//What is the largest prime factor of the number 600851475143 ?
//

//finds the smallest divisor of a number (besides 1), guarenteed to be prime.
let smallestDivisor (l : int64) = 
    if l < 2L then l else
        let search = List.unfold (fun div -> if (l % div = 0L) then None else Some(div, div + 1L)) 2L
        search.Length + 2 |> int64  //the divisor is 2 + the number of divisors we checked.

let solution = 
    let num = 600851475143L
    let divisors = List.unfold (fun i -> let div = smallestDivisor i //find smallest divisor; divide by divisor, find next smallest divisor, etc.
                                         if div = 1L then None else Some(div, i/div)) num
    List.max divisors