module Problem13

open System.IO
open System.Reflection

(*
Work out the first ten digits of the sum of the following one-hundred 50-digit numbers. (contained in text file)
Solution: 5537376230
*)

let ReadAllLines (stream : StreamReader) = 
    [ while (not stream.EndOfStream) do yield stream.ReadLine() ]

let solution = 
    let assembly = Assembly.GetExecutingAssembly()
    let resourceName = assembly.GetManifestResourceNames() |> Array.find (fun str -> str.EndsWith("p013_numbers.txt"))
    use reader = new StreamReader(assembly.GetManifestResourceStream(resourceName))
    let nums = ReadAllLines(reader)

    let sum = nums |> List.map (fun s -> bigint.Parse(s)) |> List.reduce (+) //use of the BigInteger class avoids the size limitations of Int32, Int64 etc.
    sum.ToString().Substring(0, 10)