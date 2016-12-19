using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    public class LetterCounter
    {
        public LetterCounter(char letter)
        {
            Letter = letter;
            Occurences = 0;
        }

        public char Letter { get; set; }
        public int Occurences { get; set; }
    }
}
