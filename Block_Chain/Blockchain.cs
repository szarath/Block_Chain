using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Block_Chain
{
    class Blockchain
    {
        private List<Block> chain;

        public Blockchain()
        {
            chain = new List<Block>
        {
            CreateGenesisBlock()
        };
        }

        private Block CreateGenesisBlock()
        {
            return new Block(0, "0", DateTimeOffset.UtcNow.ToUnixTimeSeconds(), "Genesis Block");
        }

        public Block GetLatestBlock()
        {
            return chain[^1];
        }

        public void AddBlock(Block newBlock)
        {
            newBlock.PreviousHash = GetLatestBlock().Hash;
            newBlock.MineBlock(4); // Adjust difficulty as needed
            chain.Add(newBlock);
        }

        public IEnumerable<Block> GetChain()
        {
            return chain;
        }
    }
}
