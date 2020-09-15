module Problem42

open NumericSequences
open System.IO

(*
The nth term of the sequence of triangle numbers is given by, tn = ½n(n+1); so the first ten triangle numbers are:

1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...

By converting each letter in a word to a number corresponding to its alphabetical position and adding these values we form a word value. 
For example, the word value for SKY is 19 + 11 + 25 = 55 = t10. 
If the word value is a triangle number then we shall call the word a triangle word.

Using words.txt (right click and 'Save Link/Target As...'), a 16K text file containing nearly two-thousand common English words, 
how many are triangle words?
*)


//Solution steps:
//Get all words
//Find length of longest word, and therefore highest possible word score,
//Which will tell us the triangle numbers we need.
//Build function to generate arbitrarily long sequences of triangle numbers (in NumericSequences)
//Build a function to score the words. Filter by triangle number score, take max by score

let file = File.ReadAllLines("C:\\Users\\erikz\\source\\repos\\ProjectEuler\\ProjectEuler\\Misc\\p042_words.txt")
let words = file.[0].Split(',') //file is one line, words in quotes, separated by commas

//cf. Problem 22.
let letterScore = function
    | c when c = '"' -> 0 //don't count these
    | c -> int(c) - 64 //A is 1, B is 2, etc.

let wordScore (w : string) = 
    w.ToCharArray() |> Seq.map letterScore |> Seq.reduce (+)

let highestScore = 
    Seq.maxBy wordScore words |> wordScore

let triangles =
    let maxTri = Seq.find (fun tri -> tri > highestScore) triangleNumbers
    Seq.takeWhile (fun tri -> tri <= maxTri) triangleNumbers

let isTriangle score = 
    (Seq.tryFind (fun tri -> tri = score) triangles) <> None

let solution = 
    words |> Seq.filter (fun w -> isTriangle (wordScore w)) |> Seq.length