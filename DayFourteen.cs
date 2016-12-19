using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2016
{
    public class DayFourteen
    {
        private int index = -1;
        //private List<string> Keys = new List<string>();  part one
        private List<Key> Keys = new List<Key>();
        private HashCollection Triples = new HashCollection();


        public int DetermineIndexof64thKeyPartTwo()
        {
            var salt = "cuanljph";
            while (Keys.Count() < 64)
            {
                index++;
                var input = salt + index;
                var triple = string.Empty;
                var quintuple = string.Empty;
                var active = input;

                //get stretched hash
                var hashCount = 0;
                while (hashCount < 2017)
                {
                    var hash = active.GetHexadecimalHashCode(0);
                    active = hash;
                    hashCount++;
                }

                //populate hash in triples if exists
                triple = active.GetRepeatedCharacter(3);
                if (!string.IsNullOrEmpty(triple))
                    Triples.Add(new Hash(index, active, triple));

                //if quintuple exists, check triples for matching character and appropriate index
                quintuple = active.GetRepeatedCharacter(5);
                if (string.IsNullOrEmpty(quintuple)) continue;

                var keyHash = Triples.Hashes.FirstOrDefault(h => h.RepeatedCharacter == quintuple && h.Index > (index - 1001));
                if (keyHash != null)
                    Keys.Add(new Key(keyHash.Value, keyHash.Index));
            }
            var sortedKeys = Keys.OrderBy(k => k.Index);
            var lastIndex = sortedKeys.Last().Index;

            return lastIndex;
        }

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

        public int DetermineIndexOf64thKey()
        {
            var salt = "cuanljph";

            while (Keys.Count() < 64)
            {
                index++;

                var hash = salt.GetHexadecimalHashCode(index);
                var triple = hash.GetRepeatedCharacter(3);
                if (triple == null)
                    continue;

                var secondaryIndex = 0;
                while (secondaryIndex < 1001)
                {
                    secondaryIndex++;
                    var secondHash = salt.GetHexadecimalHashCode(index + secondaryIndex);
                    var quintuple = secondHash.GetRepeatedCharacter(5);
                    if (quintuple == null || quintuple != triple)
                        continue;

                    //Keys.Add(hash);
                }
                secondaryIndex = 0;
            }

            return index;
        }
    }
}
