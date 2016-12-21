using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    public class DayNineteen
    {
        public int DetermineWhoGetsTheGoods()
        {
            var numberOfElves = 3014603;
            var party = new PartyAcross();

            party.GetThisPartyStarted(numberOfElves);

            while (party.CurrentPlayer.Next != party.CurrentPlayer)
            {
                party.CurrentPlayer.TakePresents(party.Target);
                party.Next();
            }

            return party.CurrentPlayer.Id;
        }       
    }
}
