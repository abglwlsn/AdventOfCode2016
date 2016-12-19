using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    public class Key
    {
        public Key(string hash, int index)
        {
            Hash = hash;
            Index = index;
        }

        public string Hash { get; set; }
        public int Index { get; set; }
    }
}
