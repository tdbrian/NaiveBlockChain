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
            var genisiBlock = new Block(0, "0", DateTime.Now, "my genesis block!", GENISIS_HAHS);
            _chain.Add(genisiBlock);
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
    }
}
