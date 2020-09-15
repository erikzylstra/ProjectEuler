module Combinatorics

//Permutations
//cf. Problem 41
//places n at every possible location in list.
let distribute n (list : list<int>) = (List.replicate (list.Length + 1) list)
                                      |> List.mapi (fun i l -> l |> List.splitAt i)
                                      |> List.map (fun (first, second) -> first@[n]@second)

let rec permutations (list : list<int>) =
    match list with
    | _ when list.Length = 2 -> seq { list; list |> List.rev }
    | x::xs -> xs |> permutations |> Seq.collect (fun perm -> (distribute x perm) |> List.toSeq)
    | _ -> Seq.empty