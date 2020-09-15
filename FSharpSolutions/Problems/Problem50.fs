module Problem50

(*
The prime 41, can be written as the sum of six consecutive primes:
41 = 2 + 3 + 5 + 7 + 11 + 13

This is the longest sum of consecutive primes that adds to a prime below one-hundred.

The longest sum of consecutive primes below one-thousand that adds to a prime, contains 21 terms, and is equal to 953.

Which prime, below one-million, can be written as the sum of the most consecutive primes?
*)

let oneMillion = 1000000

let ps = NumericSequences.primes oneMillion |> Seq.toList

let primeSum idx length = List.reduce (+) ps.[idx..idx+length-1]

let isPrime p =
    let closest = BinarySearch.search (fun i -> ps.[i]) (ps.Length-1) 0 p
    ps.[closest] = p

let rec longestConsecutive idx length acc = 
    match primeSum idx length with
    | s when s > oneMillion -> acc
    | s when isPrime s -> longestConsecutive idx (length + 1) length
    | _ -> longestConsecutive idx (length + 1) acc

let solution =
    let allLengths = [0..ps.Length-1] |> List.map (fun idx -> longestConsecutive idx 1 0)
    let longest = List.max allLengths
    let idxWithLongestLength = List.findIndex (fun l -> l = longest) allLengths
    primeSum idxWithLongestLength allLengths.[idxWithLongestLength]
