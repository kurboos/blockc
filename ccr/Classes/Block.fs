module Block

open System
open System.Text
open System.Security.Cryptography

type Block = 
    {
        Index: int
        Timestamp: DateTime
        Data: string list
        PreviousHash: string
        Nonce: int
        Hash: string
    }

// Calculate the hash of the block based on its contents.
let calculateHash index timestamp data previousHash nonce =
    let dataString = String.concat "" data

    let raw =
        $"{index}{timestamp}{dataString}{previousHash}{nonce}"

    use sha = SHA256.Create()

    raw
    |> Encoding.UTF8.GetBytes
    |> sha.ComputeHash
    |> Array.map (fun b -> b.ToString("x2"))
    |> String.concat ""

let create index data previousHash =
    let timestamp = DateTime.UtcNow
    let nonce = 0
    let hash = calculateHash index timestamp data previousHash nonce

    {
        Index = index
        Timestamp = timestamp
        Data = data
        PreviousHash = previousHash
        Nonce = nonce
        Hash = hash
    }



// Example usage:
//let genesis =
//    Block.create 0 ["Genesis Block"] "0"