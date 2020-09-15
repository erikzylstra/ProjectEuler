module BinarySearch

(*increasingFunction defined for all integers in the range [lower, upper]*)
let search (increasingFunction : int -> int) (upper : int) (lower : int) (targetValue : int) = 
    let half (range : int*int) =
        (fst range + snd range) / 2
    
    let rec findIn (range : int*int) = 
        let middle = half range
        match range with 
        | (lower, _) when increasingFunction lower = targetValue -> lower
        | (lower, upper) when lower = upper -> lower
        | (lower, upper) when increasingFunction middle < targetValue -> findIn (1 + middle, upper)
        | (lower, upper) -> findIn (lower, middle)
        

    findIn (lower, upper)