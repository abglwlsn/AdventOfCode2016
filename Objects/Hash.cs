using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    public class Hash
    {
        public Hash(int index, string value, string character)
        {
            Index = index;
            Value = value;
            RepeatedCharacter = character;
        }

        public int Index { get; set; }
        public string Value { get; set; }
        public string RepeatedCharacter { get; set; }
    }
}
