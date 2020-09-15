module Problem31

(*In the United Kingdom the currency is made up of pound (£) and pence (p). There are eight coins in general circulation:

1p, 2p, 5p, 10p, 20p, 50p, £1 (100p), and £2 (200p).
It is possible to make £2 in the following way:

1×£1 + 1×50p + 2×20p + 1×5p + 1×2p + 3×1p
How many different ways can £2 be made using any number of coins?*)

//Solution: 73682
//Not exactly functional but by far the most straightforward and readable and is also quick.
let solution = 
    let mutable count = 0
    for onePound in 0..2 do
        for fifty in 0..(200 - 100*onePound)/50 do
            for twenty in 0..(200 - 100*onePound - 50*fifty)/20 do
                for ten in 0..(200 - 100*onePound - 50*fifty - 20*twenty)/10 do
                    for five in 0..(200 - 100*onePound - 50*fifty - 20*twenty - 10*ten)/5 do
                        for two in 0..(200 - 100*onePound - 50*fifty - 20*twenty - 10*ten - 5*five)/2 do
                            for one in 0..(200 - 100*onePound - 50*fifty - 20*twenty - 10*ten - 5*five - 2*two) do
                                if one + 2*two + 5*five + 10*ten + 20*twenty + 50*fifty + 100*onePound = 200 then
                                    count <- count + 1
    count + 1 //+1 for two pound coin.