using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    public class Elf
    {
        public Elf(int id, int numberOfPresents, Elf next, Elf previous)
        {
            Id = id;
            NumberOfPresents = numberOfPresents;
            Next = next;
            Previous = previous;
        }

        public int Id { get; set; }
        public int NumberOfPresents { get; set; }
        public Elf Next { get; set; }
        public Elf Previous { get; set; }

        public void TakePresents(Elf target)
        {
            NumberOfPresents += target.NumberOfPresents;
            target.NumberOfPresents = 0;
        }
    }
}
