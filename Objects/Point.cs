using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    public class Point
    {
        public Point() { }
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Orientation { get; set; }

        public void ChangeOrientation(string turnDirection)
        {
            if (turnDirection == "L")
                Orientation = ((Orientation - 90) % 360);
            if (turnDirection == "R")
                Orientation = ((Orientation + 90) % 360);
            if (Orientation == -90)
                Orientation = 270;
        }
    }
}
