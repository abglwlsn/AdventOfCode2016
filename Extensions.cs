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
    }
}

