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

        public class SculptureState
        {
            public SculptureState()
            {
                PressButton = false;
            }

            public List<Disc> Discs { get; set; }
            public int Time { get; set; }
            public bool PressButton { get; set; }

            public void TimePasses()
            {
                Time++;
                foreach (var disc in Discs)
                {
                    disc.CurrentPosition++;
                }
            }

            public void InitializeDiscs(int startTime)
            {
                Time = startTime;

                var discs = new List<Disc>
                {
                    new Disc(1, 17, (startTime + 1) % 17),
                    new Disc(2, 7, (startTime + 0) % 7),
                    new Disc(3, 19, (startTime + 2) % 19),
                    new Disc(4, 5, (startTime + 0) % 5),
                    new Disc(5, 3, (startTime + 0) % 3),
                    new Disc(6, 13, (startTime + 5) % 13),
                    new Disc(7, 11, (startTime + 0) % 11)
                };

                Discs = discs;
            }
        }

        public class Disc
        {
            public Disc(int id, int numberOfPositions, int startingPosition)
            {
                Id = id;
                NumberOfPositions = numberOfPositions;
                StartingPosition = startingPosition;
                CurrentPosition = startingPosition;
            }

            private int _currentPosition;
            public int Id { get; set; }
            public int NumberOfPositions { get; set; }
            public int StartingPosition { get; set; }
            public int CurrentPosition
            {
                get
                {
                    return _currentPosition;
                }
                set
                {
                    _currentPosition = value == NumberOfPositions ? 0 : value;
                }
            }
        }
    }
}
