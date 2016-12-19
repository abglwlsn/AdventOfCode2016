using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    public class DayEight
    {
        public int DetermineNumberOfLitPixels(string input)
        {
            var screen = new Screen(50, 6);
            var instructions = input.Split(new string[] { "\r\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var instruction in instructions)
            {
                var details = instruction.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                if (details[0] == "rect")
                {
                    var dimensions = details[1].Split(new string[] { "x" }, StringSplitOptions.RemoveEmptyEntries);
                    screen.LightARectangle(dimensions);
                    continue;
                }

                int distance = Convert.ToInt32(details.Last());
                int moveIndex = Convert.ToInt32(details[2].Substring(2));

                if (details[1] == "row")
                    screen.RotateRow(distance, moveIndex);
                else if (details[1] == "column")
                    screen.RotateColumn(distance, moveIndex);         
            }

            //create screen visual in output
            for (var i = 0; i < screen.Rows.Count(); i++)
                System.Diagnostics.Debug.WriteLine(string.Join("", screen.Rows[i].Pixels));

            return screen.LitPixels();
        }
    }
}
