using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    public class DayFive
    {
        public string DetermineDoorPassword()
        {
            var input = "abbhdwsy";
            var index = 0;
            var code = new string[8];

            while (!Array.TrueForAll(code, X.HasValue))
            {
                var hash = input.GetHexadecimalHashCode(index);
                if (hash.Substring(0, 5) == "00000")
                {
                    var position = (int)Char.GetNumericValue(hash[5]);
                    var codeValue = hash[6].ToString();

                    var containsValidPosition = (position > -1 && position < 8);
                    if (containsValidPosition && code[position] == null)
                        code[position] = codeValue;
                }

                index++;
            }

            return string.Join("", code);
        }
    }
}
