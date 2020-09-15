module Problem16

(*
2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.
What is the sum of the digits of the number 2^1000?
*)

let solution = 

    let powerOfTwo = bigint.Pow(2I, 1000)

    int(Digits.Sum powerOfTwo)