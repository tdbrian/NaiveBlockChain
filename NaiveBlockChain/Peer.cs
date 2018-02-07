using System;

namespace NaiveBlockChain
{
    public class Peer
    {
        public Uri Address { get; }

        public Peer(Uri address)
        {
            Address = address;
        }
    }
}
