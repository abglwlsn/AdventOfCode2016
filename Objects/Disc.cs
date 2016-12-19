using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
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
