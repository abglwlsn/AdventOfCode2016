using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{

    public class Row
    {
        public Row(int columns)
        {
            Pixels = new string[columns];

            for (var i = 0; i < Pixels.Count(); i++)
                Pixels[i] = " ";
        }

        public string[] Pixels { get; set; }

        public int LitPixels()
        {
            var pixelsLit = 0;
            for (var i = 0; i < Pixels.Length; i++)
                if (Pixels[i] == "*")
                    pixelsLit++;

            return pixelsLit;
        }

        public Row RotateRow(int distance)
        {
            Pixels = Pixels.ShiftPixels(distance);
            return this;
        }
    }
}
