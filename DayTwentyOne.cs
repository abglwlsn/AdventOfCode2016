using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    public class DayTwentyOne
    {
        public string DeScramblePassword(string input)
        {
            var code = new StringBuilder("fbgdceah");
            var rules = input.Split(new[] { "\r\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);

            for (var i = rules.Length - 1; i > -1; i--)
            {
                var segments = rules[i].Trim().Split(' ');
                var action = segments[0];

                if (action == "swap")
                {
                    if (segments[1] == "position")
                        code = code.SwapByPosition(segments);

                    if (segments[1] == "letter")
                        code = code.SwapByLetter(segments);
                }
                else if (action == "rotate")
                {
                    if (segments[1] == "based")
                    {
                        var index = code.ToString().IndexOf(segments[6]);
                        switch (index)
                        {
                            case 0:
                                code = code.RotateRight(7);
                                break;
                            case 1:
                                code = code.RotateRight(7);
                                break;
                            case 2:
                                code = code.RotateRight(2);
                                break;
                            case 3:
                                code = code.RotateRight(6);
                                break;
                            case 4:
                                code = code.RotateRight(1);
                                break;
                            case 5:
                                code = code.RotateRight(5);
                                break;
                            case 6:
                                break;
                            case 7:
                                code = code.RotateRight(4);
                                break;
                            default:
                                break;
                        }
                        continue;
                    }

                    var distance = Convert.ToInt32(segments[2]);
                    if (segments[1] == "left")
                        code = code.RotateRight(distance);
                    else
                        code = code.RotateLeft(distance);
                }
                else if (action == "reverse")
                    code = code.Reverse(segments);

                else if (action == "move")
                {
                    var letterIndex = Convert.ToInt32(segments[2]);
                    var insertIndex = Convert.ToInt32(segments[5]);
                    var letter = code[insertIndex];
                    code.Remove(insertIndex, 1);
                    code.Insert(letterIndex, letter);
                }
                else throw new InvalidOperationException();
            }

            return code.ToString();
        }

        //part one
        public string GetPassword(string input)
        {
            var code = new StringBuilder("abcdefgh");
            var rules = input.Split(new[] { "\r\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var rule in rules)
            {
                var segments = rule.Trim().Split(' ');
                var action = segments[0];

                if (action == "swap")
                {
                    if (segments[1] == "position")
                        code = code.SwapByPosition(segments);

                    if (segments[1] == "letter")
                        code = code.SwapByLetter(segments);
                }
                else if (action == "rotate")
                {
                    if (segments[1] == "based")
                    {
                        var index = code.ToString().IndexOf(segments[6]);
                        code = code.RotateRight(1);
                        code = code.RotateRight(index);
                        if (index > 3)
                            code = code.RotateRight(1);
                        continue;
                    }

                    var distance = Convert.ToInt32(segments[2]);
                    if (segments[1] == "left")
                        code = code.RotateLeft(distance);
                    else
                        code = code.RotateRight(distance);
                }
                else if (action == "reverse")
                    code = code.Reverse(segments);

                else if (action == "move")
                {
                    var letterIndex = Convert.ToInt32(segments[2]);
                    var insertIndex = Convert.ToInt32(segments[5]);
                    var letter = code[letterIndex];
                    code.Remove(letterIndex, 1);
                    code.Insert(insertIndex, letter);
                }
                else throw new InvalidOperationException();
            }

            return code.ToString();
        }
    }
}