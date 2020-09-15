module Problem19

open System

(*How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?
Solution: 171*)

let years = [1901..2000]
let months = [1..12]

let SundaysOnFirstInYear year = 
    months |> List.map (fun month -> new DateTime(year, month, 1)) 
           |> List.where (fun date -> date.DayOfWeek = DayOfWeek.Sunday) 
           |> List.length

let solution = years |> List.fold (fun acc year -> acc + SundaysOnFirstInYear year) 0
