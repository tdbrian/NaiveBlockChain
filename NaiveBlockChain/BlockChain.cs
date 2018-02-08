using System;
using System.Collections.Generic;

namespace NaiveBlockChain
{
    public class BlockChain
    {
        private readonly List<Block> _chain = new List<Block>();
        private const string GENISIS_HAHS = "816534932c2b7154836da6afc367695e6337db8a921823784c14378abed4f7d7";

        public BlockChain()
        {
            AddGenesisBlock();
        }

        private void AddGenesisBlock()
        {
            var block = CreateGenesisBlock();
            _chain.Add(block);
        }

        private static Block CreateGenesisBlock()
        {
            return new Block(0, "0", DateTime.Now, "my genesis block!", GENISIS_HAHS);
        }

        public List<Block> GetChain()
        {
            return _chain;
        }

        public List<Block> AddToChain(Block block)
        {
            _chain.Add(block);
            return _chain;
        }

        public Block GetLatestBlock()
        {
            return _chain[_chain.Count - 1];
        }

        public Block GenerateNextBlock(string blockData)
        {
            var previousBlock = GetLatestBlock();
            var nextIndex = previousBlock.Index + 1;
            var nextTimestamp = DateTime.Now;
            var nextHash = BlockHash.Calculate(nextIndex, previousBlock.Hash, nextTimestamp, blockData);
            return new Block(nextIndex, previousBlock.Hash, nextTimestamp, blockData, nextHash);
        }

        public bool IsValid()
        {
            // Validates genesis hash
            var genesisBlock = CreateGenesisBlock();
            if (!_chain[0].Equals(genesisBlock))
            {
                return false;
            }

            // Start a rebuild of the chain for validation
            var tempBlocks = new List<Block>{ genesisBlock };

            // Validates each block in order
            for (var i = 1; i < _chain.Count; i++)
            {
                if (IsValidNewBlock(_chain[i], tempBlocks[i - 1]))
                {
                    tempBlocks.Add(_chain[i]);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsValidNewBlock(Block newBlock, Block previousBlock)
        {
            // Validates index
            if (previousBlock.Index + 1 != newBlock.Index)
            {
                return false;
            }

            // Validates previous hash
            if (previousBlock.Hash != newBlock.PreviousHash)
            {
                return false;
            }

            // Validates hash
            return newBlock.CalculateHash() == newBlock.Hash;
        }
    }
}
