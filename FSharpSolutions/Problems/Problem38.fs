module Problem38

(*Take the number 192 and multiply it by each of 1, 2, and 3:

192 × 1 = 192
192 × 2 = 384
192 × 3 = 576
By concatenating each product we get the 1 to 9 pandigital, 192384576. 
We will call 192384576 the concatenated product of 192 and (1,2,3)

The same can be achieved by starting with 9 and multiplying by 1, 2, 3, 4, and 5, 
giving the pandigital, 918273645, which is the concatenated product of 9 and (1,2,3,4,5).

What is the largest 1 to 9 pandigital 9-digit number that can be formed 
as the concatenated product of an integer with (1,2, ... , n) where n > 1?
*)
//Solution: 932718654


//Clearly the pandigital in question is over 900 million and under one billion:
//it is easy to construct numbers over 900 million and all 9 digit numbers are under one billion.
//So we are searching for a number whose first digit is 9 to use to create the pandigital.
//The smallest such is 9, whose n value is 5 since 9 x (1, 2, 3, 4, 5) = 918273645
//Any candidate number will be larger than 9 and have a smaller n value, so our n values are bounded by 5 from above.
//A number must have less than 5 digits to be considered; otherwise the second concatentation already gives a >= ten digit number
//So we need only consider numbers less than 10000

//Solution Steps:
//build function to generate m X (1, ..., n) concatenations, n up to 5
//this function will filter for 9 digit concatenations
//build function to check these for pandigitals, using sets to compare digits
//feed all numbers less than 10000 to these functions and sort the results

let nineDigitConcat (m :int) = 
    let concat = [1..5] |> List.map (fun i -> bigint.Multiply(bigint m, bigint i)) //product may be oustide int bounds
                 |> List.fold (fun (acc:string) prod -> if acc.Length + prod.ToString().Length <= 9 then acc + prod.ToString() else acc) ""
    if concat.Length = 9 then Some(int concat) else None

let firstDigitNine n =
    n.ToString().[0].Equals('9')

let solution =
    seq {1..10000}
    |> Seq.filter firstDigitNine
    |> Seq.map nineDigitConcat
    |> Seq.filter (fun num -> if num <> None then (Digits.isNPandigital 9 num.Value) else false)
    |> Seq.max |> Option.get

