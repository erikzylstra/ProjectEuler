module Problem24

(*
A permutation is an ordered arrangement of objects. For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4.
If all of the permutations are listed numerically or alphabetically, we call it lexicographic order. 
The lexicographic permutations of 0, 1 and 2 are:

012   021   102   120   201   210

What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?
*)

let intPow i n = List.replicate n i |> List.fold (*) 1
let bigAdd (a : bigint) (b : bigint) = bigint.Add (a, b)

//returns a list of ls with x inserted at every possible position
let distribute x (ls : list<int>) =
    List.replicate (ls.Length + 1) ls |> List.mapi (fun i l -> l |> List.splitAt(i)) |> List.map (fun h -> fst h @ (x :: snd h))

//distribute 2 []


let permutations ls =
    let folder head state = 
        List.collect (distribute head) state
    List.foldBack folder ls [[]]

//collapses a list of digits into a number
let collapse (ls : list<int>) =
    List.rev ls |> List.map bigint 
    |> List.mapi (fun i x -> bigint.Multiply(x, bigint.Pow(10I, i)))
    |> List.fold bigAdd 0I
    //|> List.mapi (fun i x -> x * (intPow 10 i)) |> List.map bigint |> List.fold bigAdd 0I

let perms = [0; 1; 2; 3; 4; 5; 6; 7; 8; 9] |> permutations |> List.map collapse |> List.sort
let solution = perms.[999999]