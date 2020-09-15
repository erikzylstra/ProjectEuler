module Problem49

(*
The arithmetic sequence, 1487, 4817, 8147, in which each of the terms increases by 3330, is unusual in two ways: 
(i) each of the three terms are prime, and, 
(ii) each of the 4-digit numbers are permutations of one another.

There are no arithmetic sequences made up of three 1-, 2-, or 3-digit primes, exhibiting this property, 
but there is one other 4-digit increasing sequence.

What 12-digit number do you form by concatenating the three terms in this sequence?
*)

(***
Calculate 4 digit primes.
Group these primes according to their digits.
Filter for the groups with common difference. Discard the example solution.
Sort and concatenate.
***)

let ps = NumericSequences.primes 10000 |> Seq.toList

let digitMultiplicity (i : int) (ds : seq<int>) = //counts the number of times i appears in the seq ds
    Seq.fold (fun acc d -> if d = i then acc + 1 else acc) 0 ds

let key p = //generates a set of the digits of p including the number of times that digit appears.
    let digs = Digits.digits p
    Array.map (fun dig -> (dig, digitMultiplicity dig digs)) digs |> Set.ofArray

let hasEqualElements (l : list<int>) = 
    List.forall (fun i -> i = l.Head) l.Tail

let isArithmetic (sequence : list<int>) = 
    if sequence.Length < 3 then false
    else //for simplicity assume list sorting handled elsewhere
        List.mapi (fun i element -> element - sequence.[i]) sequence.Tail |> hasEqualElements

let sameDigitsPrimes = List.groupBy key ps

let solution = (*isArithmetic [1487; 4817; 8147]*)
    List.filter (fun (_, sdps) -> List.sort sdps |> isArithmetic) sameDigitsPrimes