using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Block_Chain
{
    class Blockchain
    {
        private List<Block> chain;
        private List<Validator> validators; 

        public Blockchain()
        {
            chain = new List<Block>
        {
            CreateGenesisBlock()
        };

            validators = new List<Validator>
        {
            new Validator { Name = "Validator A", Stake = 500 },
            new Validator { Name = "Validator B", Stake = 300 },
            new Validator { Name = "Validator C", Stake = 200 }
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

        public void AddBlock(string transactionData)
        {
            // Select a block proposer based on stakes
            string blockProposer = SelectBlockProposer(validators);

            // Create a new block with the selected proposer
            Block newBlock = new Block(chain.Count, GetLatestBlock().Hash, DateTimeOffset.UtcNow.ToUnixTimeSeconds(), transactionData);

            // Mine the block
            newBlock.MineBlock(4); // Adjust difficulty as needed

            // Add the block to the chain
            chain.Add(newBlock);

            Console.WriteLine($"Block {newBlock.Index} mined by {blockProposer} - Hash: {newBlock.Hash}");
        }

        public IEnumerable<Block> GetChain()
        {
            return chain;
        }

        private string SelectBlockProposer(List<Validator> validators)
        {
            // Simplified selection based on stakes
            Random random = new Random();
            int totalStake = validators.Sum(v => v.Stake);
            int randomValue = random.Next(0, totalStake);

            foreach (var validator in validators)
            {
                if (randomValue < validator.Stake)
                {
                    return validator.Name;
                }
                randomValue -= validator.Stake;
            }

            // Default return (should not be reached)
            return validators[0].Name;
        }
    }

}
