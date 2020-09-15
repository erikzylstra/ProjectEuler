module ExponentialSearch

(* 
increasingFunction defined for all natural numbers. The target value need 
not be an actual value of the function; the output in this case will be the
greatest input value whose output does not exceed target.
*)

let search (increasingFunction : int -> int) (target : int) (initialIndex : int) = 
    let double = (fun i -> i * 2)

    let rec findUpper i =
        let value = increasingFunction i
        if value > target then i else findUpper (double i)

    let upperBound = findUpper initialIndex
    BinarySearch.search increasingFunction upperBound (upperBound / 2) target 