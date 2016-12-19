using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    public class DayOne
    {
        public List<Point> _visitedPoints;
        private bool _hasVisited = false;

        public int GetDistanceToHeadquarters(string input)
        {
            var specialAgent = new Point() { X = 0, Y = 0, Orientation = 0 };
            var infiltrationSteps = Regex.Split(input, ", ");
            _visitedPoints = new List<Point> { new Point(specialAgent.X, specialAgent.Y) };

            for (var i = 0; i < infiltrationSteps.Length; i++)
            {
                var direction = infiltrationSteps[i][0].ToString();
                var distance = Convert.ToInt32(String.Join("", infiltrationSteps[i].Where(char.IsDigit)));

                specialAgent.ChangeOrientation(direction);
                Move(specialAgent, distance);

                if (_hasVisited)
                    return Math.Abs(specialAgent.X) + Math.Abs(specialAgent.Y);
            }

            return Math.Abs(specialAgent.X) + Math.Abs(specialAgent.Y);
        }


        public void Move(Point specialAgent, int distance)
        {
            for (var i = 0; i < distance; i++)
            {
                if (specialAgent.Orientation == 90)
                    specialAgent.X++;
                else if (specialAgent.Orientation == 270)
                    specialAgent.X--;
                else if (specialAgent.Orientation == 0)
                    specialAgent.Y++;
                else
                    specialAgent.Y--;

                _hasVisited = _visitedPoints.Any(p => p.X == specialAgent.X && p.Y == specialAgent.Y);
                if (_hasVisited)
                    break;

                _visitedPoints.Add(new Point(specialAgent.X, specialAgent.Y));
            }
        }
    }
}


