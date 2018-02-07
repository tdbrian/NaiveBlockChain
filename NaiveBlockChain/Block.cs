using System;

namespace NaiveBlockChain
{
    public class Block
    {
        private readonly int _index;
        private readonly string _previousHash;
        private readonly DateTime _timeStamp;
        private readonly string _data;
        private readonly string _hash;

        public Block(int index, string previousHash, DateTime timeStamp, string data, string hash)
        {
            _index = index;
            _previousHash = previousHash;
            _timeStamp = timeStamp;
            _data = data;
            _hash = hash;
        }
    }
}
