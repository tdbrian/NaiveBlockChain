using System.Collections.Generic;

namespace NaiveBlockChain
{
    public class Peers
    {
        public List<Peer> List { get; }

        public Peers(List<Peer> list)
        {
            List = list;
        }
    }
}
