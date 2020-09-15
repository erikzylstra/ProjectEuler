module NumericSequences
open System.Collections

let Fibs = Seq.unfold (fun (current, previous) -> Some(current, (current + previous, current))) (1I, 1I)

let fibs = Seq.unfold (fun (current, previous) -> Some(current, (current + previous, current))) (1, 1)

let primes max = //Sieve of Eratosthenes
    let array = new BitArray(max + 1, true)
    let last = sqrt(float max) |> int
    for p in 2..last+1 do 
        if array.Get(p) then List.iter (fun pm -> array.Set(pm, false)) [p*2..p..max]
    seq { for i in 2..max do if array.Get(i) then yield i }

let triangleNumbers = Seq.unfold (fun n -> Some((n*(n + 1))/2, n + 1)) 1