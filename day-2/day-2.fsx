open System.IO

let readLines filePath = File.ReadLines(filePath)

let split (a: char) (s: string) = s.Split(a)
let input = readLines "./input.txt"

let getInstructions input = input |> Seq.map (split ' ') 



//Part 1

let getSimpleDirection (instructions: seq<string []>) =
    instructions
    |> Seq.groupBy (fun x -> x.[0])
    |> Seq.map (fun (key, values) ->
        (key,
         values
         |> Seq.map (fun x -> (x.[1] |> int64))
         |> Seq.sum))
    |> dict

let challenge1 = getInstructions >> getSimpleDirection

let directions = challenge1 input

let answer =
    directions.Item("forward")
    * (directions.Item("down") - directions.Item("up"))

printfn "Solution part 1: %d" answer

//Part 2

let directionFromAim (horizontal: int64, depth: int64, aim: int64) (dir: string, amount: int64) =
    match dir with
    | "forward" -> (horizontal + amount, depth + (amount * aim), aim)
    | "up" -> (horizontal, depth, aim - amount)
    | "down" -> (horizontal, depth, aim + amount)
    | _ -> (horizontal, depth, depth)

let parseInstructions (instructions: seq<string []>) =
    instructions
    |> Seq.map (fun x -> (x.[0], x.[1] |> int64))

let getParsedInstructions: seq<string> -> seq<string * int64> = getInstructions >> parseInstructions

let challenge2: seq<string> -> int64 * int64 * int64 =
    getParsedInstructions
    >> Seq.fold directionFromAim (0, 0, 0)

let (horizontal, depth, _) = challenge2 input

let answer2 = horizontal * depth

printfn "Solution part 2: %d" answer2
