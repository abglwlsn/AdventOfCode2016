using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    public class DayTwo
    {
        public int DetermineBathroomCode(string input)
        {
            var sb = new StringBuilder();
            var keys = PopulateKeys();
            var code = string.Empty;
            var location = new Key(5, 2, 2);
            var lines = Regex.Split(input,"\r");
            foreach (var line in lines)
            {
                var instructions = line.ToCharArray();
                for (var i = 0; i < instructions.Count(); i++)
                {
                    if (instructions[i] == Direction.Up)
                        location.Y++;
                    else if (instructions[i] == Direction.Down)
                        location.Y--;
                    else if (instructions[i] == Direction.Right)
                        location.X++;
                    else
                        location.X--;

                    if (location.Y > 3)
                        location.Y = 3;
                    if (location.Y < 1)
                        location.Y = 1;

                    if (location.X > 3)
                        location.X = 3;
                    if (location.X < 1)
                        location.X = 1;
                }

                var key = keys.FirstOrDefault(k => k.X == location.X && k.Y == location.Y);
                sb.Append(key.Number.ToString());
            }

            code = sb.ToString();
     
            return Convert.ToInt32(code);
        }

        private List<Key> PopulateKeys()
        {
            var keys = new List<Key>() { Key.One, Key.Two, Key.Three, Key.Four, Key.Five, Key.Six, Key.Seven, Key.Eight, Key.Nine };
            return keys;
        }

        internal static class Direction
        {
            public static char Up = 'U';
            public static char Down = 'D';
            public static char Left = 'L';
            public static char Right = 'R';
        }

        internal class Key
        {
            public static readonly Key One = new Key(1, 1, 3);
            public static readonly Key Two = new Key(2, 2, 3);
            public static readonly Key Three = new Key(3, 3, 3);
            public static readonly Key Four = new Key(4, 1, 2);
            public static readonly Key Five = new Key(5, 2, 2);
            public static readonly Key Six = new Key(6, 3, 2);
            public static readonly Key Seven = new Key(7, 1, 1);
            public static readonly Key Eight = new Key(8, 2, 1);
            public static readonly Key Nine = new Key(9, 3, 1);

            public Key(int number, int x, int y)
            {
                Number = number;
                X = x;
                Y = y;
            }

            public int X { get; set; }
            public int Y { get; set; }
            public int Number { get; set; }
        }
    }
}
