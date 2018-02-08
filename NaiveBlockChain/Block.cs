using System;

namespace NaiveBlockChain
{
    public class Block
    {
        public int Index { get; }
        public string PreviousHash { get; }
        public DateTime TimeStamp { get; }
        public string Data { get; }
        public string Hash { get; }

        public Block(int index, string previousHash, DateTime timeStamp, string data, string hash)
        {
            Index = index;
            PreviousHash = previousHash;
            TimeStamp = timeStamp;
            Data = data;
            Hash = hash;
        }

        public override string ToString()
        {
            return $"{Index}{PreviousHash}{TimeStamp}{Data}{Hash}";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Block block))
            {
                return false;
            }

            return Index.ToString().Equals(block.ToString());
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public string CalculateHash()
        {
            return BlockHash.Calculate(Index, PreviousHash, TimeStamp, Data);
        }
    }
}
