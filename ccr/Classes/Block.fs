module Block

// ============================================
// Imports
// ============================================

open System
open System.Text
open System.Security.Cryptography


// ============================================
// Block Data Structure
// ============================================
// Represents a single block in the blockchain.
// Blocks are immutable records containing
// metadata, stored data, and cryptographic links
// to the previous block.

type Block = 
    {
        // Position of the block in the chain
        Index: int

        // Time when the block was created (UTC)
        Timestamp: DateTime

        // Stored payload (transactions, messages, etc.)
        Data: string list

        // Hash of the previous block (chain linking)
        PreviousHash: string

        // Nonce used for mining / proof-of-work
        Nonce: int

        // SHA256 hash of this block's contents
        Hash: string
    }


// ============================================
// Hash Calculation
// ============================================
// Computes the SHA256 hash for a block based on
// all of its relevant fields. Any change in the
// block contents will produce a completely
// different hash.

let calculateHash index timestamp data previousHash nonce =

    // Combine all data entries into one string
    let dataString = String.concat "" data

    // Construct the raw string that will be hashed
    // The order matters because it defines the hash
    let raw =
        $"{index}{timestamp}{dataString}{previousHash}{nonce}"

    // Create SHA256 hashing object
    use sha = SHA256.Create()

    // Convert string -> bytes -> SHA256 -> hex string
    raw
    |> Encoding.UTF8.GetBytes
    |> sha.ComputeHash
    |> Array.map (fun b -> b.ToString("x2"))
    |> String.concat ""


// ============================================
// Block Creation
// ============================================
// Creates a new block instance. The hash is
// automatically calculated from the block
// contents.

let create index data previousHash =

    // Timestamp when the block is generated
    let timestamp = DateTime.UtcNow

    // Initial nonce (used later for mining)
    let nonce = 0

    // Compute the block's cryptographic hash
    let hash = calculateHash index timestamp data previousHash nonce

    // Return the completed block record
    {
        Index = index
        Timestamp = timestamp
        Data = data
        PreviousHash = previousHash
        Nonce = nonce
        Hash = hash
    }


// ============================================
// Example Usage
// ============================================
// Creating the first block in the blockchain.
// This is commonly called the "Genesis Block".

// let genesis =
//     Block.create 0 ["Genesis Block"] "0"