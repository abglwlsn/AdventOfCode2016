using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    public class Party
    {
        public Elf CurrentPlayer { get; set; }
        public Elf Target { get; set; }

        public void GetThisPartyStarted(int numberofElves)
        {
            var firstElf = new Elf(1, 1, null, null);
            var elf = firstElf;

            for (var i = 2; i < numberofElves + 1; i++)
            {
                var nextElf = new Elf(i, 1, null, elf);
                elf.Next = nextElf;
                elf = nextElf;
            }

            elf.Next = firstElf;
            firstElf.Previous = elf;
            Target = firstElf.Next;
            CurrentPlayer = firstElf;
        }

        public void Next()
        {
            CurrentPlayer.Next = Target.Next;
            Target.Next.Previous = CurrentPlayer;
            CurrentPlayer = CurrentPlayer.Next;
            Target = Target.Next.Next;
        }
    }

    public class PartyAcross
    {
        public Elf CurrentPlayer { get; set; }
        public Elf Target { get; set; }
        public int Participants { get; set; }

        public void GetThisPartyStarted(int numberofElves)
        {
            var firstElf = new Elf(1, 1, null, null);
            var elf = firstElf;
            var targetIndex = GetTargetId(numberofElves, firstElf.Id);

            for (var i = 2; i < numberofElves + 1; i++)
            {
                var nextElf = new Elf(i, 1, null, elf);
                elf.Next = nextElf;
                elf = nextElf;

                if (targetIndex == i)
                    Target = elf;
            }

            Participants = numberofElves;
            elf.Next = firstElf;
            firstElf.Previous = elf;
            CurrentPlayer = firstElf;
        }

        public void Next()
        {
            Target.Previous.Next = Target.Next;
            Target.Next.Previous = Target.Previous;

            if (Participants % 2 == 1)
                Target = Target.Next.Next;
            else Target = Target.Next;

            CurrentPlayer = CurrentPlayer.Next;
            Participants--;
        }

        public int GetTargetId(int numberOfElves, int currentPosition)
        {
            var half = numberOfElves / 2;
            var index = half + currentPosition;
            if (index > numberOfElves)
                return half;
            return index;
        }
    }
}
