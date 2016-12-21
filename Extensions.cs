using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    public static class X
    {
        public static string[] ShiftPixels(this string[] pixelArray, int distance)
        {
            var row = new string[pixelArray.Length];
            //copies initial part of array, minus the indexes that will move off screen right, and inserts it at n index
            Array.Copy(pixelArray, 0, row, distance, pixelArray.Length - distance);
            //copies the indexes that move off screen right into the beginning of the new array
            Array.Copy(pixelArray, pixelArray.Length - distance, row, 0, distance);

            return row;
        }

        public static string GetHexadecimalHashCode(this string input, int index)
        {
            var hashInput = input + index;
            var sb = new StringBuilder();

            var md5 = MD5.Create();
            var data = md5.ComputeHash(Encoding.UTF8.GetBytes(hashInput));

            //var sb2 = new StringBuilder(data.Length * 2);

            //convert to hexadecimal
            foreach (var d in data)
                sb.Append(d.ToString("x2"));

            return sb.ToString();
        }

        public static bool HasValue(this string value)
        {
            return !string.IsNullOrEmpty(value) && value.Length >= 1;
        }

        public static string GetRepeatedCharacter(this string input, int sequenceLength)
        {
            return Regex.IsMatch(input, "([a-zA-Z0-9])\\1{" + (sequenceLength - 1) + "}") ? Regex.Match(input, "([a-zA-Z0-9])\\1{" + (sequenceLength - 1) + "}").Value[0].ToString() : null;
        }

        public static StringBuilder SwapByPosition(this StringBuilder code, string[] segments)
        {
            var x = Convert.ToInt32(segments[2]);
            var y = Convert.ToInt32(segments[5]);
            var Xvalue = code[x];
            var Yvalue = code[y];

            code[x] = Yvalue;
            code[y] = Xvalue;

            return code;
        }

        public static StringBuilder SwapByLetter(this StringBuilder code, string[] segments)
        {
            var firstLetter = segments[2][0];
            var secondLetter = segments[5][0];
            var newCode = code.ToString().Select(
                        x => x == firstLetter ? secondLetter : (x == secondLetter ? firstLetter : x)).ToArray();
            code.Clear();
            code.Append(newCode);

            return code;
        }

        public static StringBuilder RotateLeft(this StringBuilder code, int distance)
        {
            var newCode = new char[code.Length];
            var array = code.ToString().ToArray();
            Array.Copy(array, distance, newCode, 0, array.Length - distance);
            Array.Copy(array, 0, newCode, array.Length - distance, distance);
            code.Clear();
            code.Append(newCode);

            return code;
        }

        public static StringBuilder RotateRight(this StringBuilder code, int distance)
        {
            var newCode = new char[code.Length];
            var array = code.ToString().ToArray();
            Array.Copy(array, 0, newCode, distance, array.Length - distance);
            Array.Copy(array, array.Length - distance, newCode, 0, distance);
            code.Clear();
            code.Append(newCode);
            return code;
        }

        public static StringBuilder Reverse(this StringBuilder code, string[] segments)
        {
            var startIndex = Convert.ToInt32(segments[2]);
            var endIndex = Convert.ToInt32(segments[4]);
            var section = code.ToString().Substring(startIndex, (endIndex - startIndex + 1)).ToCharArray();
            var newSection = section.Reverse().ToArray();

            if (section.Length != newSection.Length)
                throw new InvalidOperationException();

            code.Replace(new string(section), new string(newSection), startIndex, (endIndex - startIndex + 1));
            return code;
        }
    }
}

