using System.Collections.Generic;

namespace AdventOfCode2016
{
    public class DayFifteen
    {
        public int DetermineWhenToPressTheButton()
        {
            var pressButton = false;
            var startTime = 0;
            var sculpture = new SculptureState();

            while (pressButton == false)
            {
                sculpture.InitializeDiscs(startTime);

                var collisions = 0;
                foreach (var disc in sculpture.Discs)
                {
                    sculpture.TimePasses();
                    if (disc.CurrentPosition != 0)
                        collisions++;
                }

                if (collisions == 0)
                    pressButton = true;
                startTime++;
            }

            return startTime - 1;
        }
    }
}
