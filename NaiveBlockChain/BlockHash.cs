using System;
using System.Security.Cryptography;

namespace NaiveBlockChain
{
    public static class BlockHash
    {
        public static string Calculate(int index, string previousHash, DateTime timestamp, string data)
        {
            var hash = SHA256.Create(index + previousHash + timestamp + data);
            return hash.ToString();
        }
    }
}
