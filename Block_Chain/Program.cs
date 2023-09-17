using Block_Chain;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;


class Program
{
    static void Main(string[] args)
    {
        Blockchain myCoin = new Blockchain();

        myCoin.AddBlock(new Block(1, myCoin.GetLatestBlock().Hash, DateTimeOffset.UtcNow.ToUnixTimeSeconds(), "Transaction Data 1"));
        myCoin.AddBlock(new Block(2, myCoin.GetLatestBlock().Hash, DateTimeOffset.UtcNow.ToUnixTimeSeconds(), "Transaction Data 2"));

        foreach (Block block in myCoin.GetChain())
        {
            Console.WriteLine($"Block {block.Index} - Hash: {block.Hash}");
        }
    }
}
