module Problem22

(*

Using names.txt (right click and 'Save Link/Target As...'), a 46K text file containing over five-thousand first names, begin by sorting it into alphabetical order. Then working out the alphabetical value for each name, multiply this value by its alphabetical position in the list to obtain a name score.

For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list. So, COLIN would obtain a score of 938 × 53 = 49714.

What is the total of all the name scores in the file?

Solution: 871198282
*)


open System.IO
open System.Reflection

let letterScore = function
    | c when c = '"' -> 0 //don't count these
    | c -> int(c) - 64 //A is 1, B is 2, etc.

let nameScore (s : string) (index : int) = 
    s.ToCharArray() |> Seq.map letterScore |> Seq.sum |> (fun i -> i * index)

let solution = 
    let assembly = Assembly.GetExecutingAssembly()
    let resourceName = assembly.GetManifestResourceNames() |> Array.find (fun str -> str.EndsWith("p022_names.txt"))
    use reader = new StreamReader(assembly.GetManifestResourceStream(resourceName))
    let content = reader.ReadToEnd()

    let names = content.Split(',') |> Seq.sort |> Seq.toList 
    names |> List.mapi (fun i name -> nameScore name (i + 1)) |> List.sum
    