using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Block_Chain
{
    class Block
    {
        public int Index { get; }
        public string PreviousHash { get; set; }
        public long Timestamp { get; }
        public string Data { get; }
        public int Nonce { get; private set; }
        public string Hash { get; private set; }

        public Block(int index, string previousHash, long timestamp, string data)
        {
            Index = index;
            PreviousHash = previousHash;
            Timestamp = timestamp;
            Data = data;
            Nonce = 0;
            Hash = CalculateHash();
        }

        public string CalculateHash()
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                string input = Index + PreviousHash + Timestamp + Data + Nonce;
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        public void MineBlock(int difficulty)
        {
            string target = new string('0', difficulty);
            while (Hash.Substring(0, difficulty) != target)
            {
                Nonce++;
                Hash = CalculateHash();
            }
        }
    }

}