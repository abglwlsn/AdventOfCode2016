using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    public class Screen
    {
        public Screen(int numberOfColumns, int numberOfRows)
        {
            Rows = new Row[numberOfRows];
            for (var i = 0; i < Rows.Length; i++)
                Rows[i] = new Row(numberOfColumns);
        }

        public Row[] Rows { get; set; }

        public Screen LightARectangle(string[] dimensions)
        {
            var Xdistance = Convert.ToInt32(dimensions[0]);
            var Ydistance = Convert.ToInt32(dimensions[1]);

            for (var i = 0; i < Ydistance; i++)
                for (var j = 0; j < Xdistance; j++)
                    Rows[i].Pixels[j] = "*";

            return this;
        }

        public Screen RotateColumn(int distance, int columnNumber)
        {
            var originalPixels = new string[Rows.Count()];
            for (var i = 0; i < Rows.Count(); i++)
                originalPixels[i] = Rows[i].Pixels[columnNumber];

            var pixels = originalPixels.ShiftPixels(distance);
            for (var i = 0; i < Rows.Count(); i++)
                Rows[i].Pixels[columnNumber] = pixels[i];

            return this;
        }

        public Screen RotateRow(int distance, int rowNumber)
        {
            var row = Rows[rowNumber];
            row.RotateRow(distance);
            return this;
        }

        public int LitPixels()
        {
            var pixelsLit = 0;
            foreach (var row in Rows)
                pixelsLit += row.LitPixels();

            return pixelsLit;
        }
    }

}
