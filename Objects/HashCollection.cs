using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    public class HashCollection
    {
        public HashCollection()
        {
            Hashes = new List<Hash>();
        }

        public List<Hash> Hashes { get; set; }

        public bool HasHashAtIndex(int index)
        {
            return Hashes.Any(h => h.Index == index);
        }
        public void Add(Hash hash)
        {
            Hashes.Add(hash);
        }
    }
}
