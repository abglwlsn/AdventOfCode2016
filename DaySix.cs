using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    public class DaySix
    {
        public string GetMessageToSanta(string input)
        {           
            var message = new StringBuilder();
            var lines = input.Split(new string[] { "\r", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var columns = PopulateColumns(lines);
            foreach (var column in columns)
            {
                var letterCounts = new List<LetterCounter>();

                foreach (var character in column)
                {
                    var counter = letterCounts?.FirstOrDefault(l => l.Letter == character);
                    if (counter == null)
                    {
                        counter = new LetterCounter(character);
                        letterCounts.Add(counter);
                    }

                    counter.Occurences++;
                }

                //var mostFrequent = FindMostFrequentLetter(letterCounts);
                var leastFrequent = FindLeastFrequentLetter(letterCounts, lines.Count());

                message.Append(leastFrequent);
            }

            return message.ToString();
        }

        private List<List<char>> PopulateColumns(string[] lines)
        {
            var columns = CreateColumns(lines[0]);

            foreach (var line in lines)
            {
                var letters = line.Trim().ToCharArray();
                for (var i = 0; i < letters.Length; i++)
                    columns[i].Add(letters[i]);
            }

            return columns;
        }

        private List<List<char>> CreateColumns(string firstLine)
        {
            var columns = new List<List<char>>();
            var characters = firstLine.Trim().ToCharArray();

            foreach (var c in characters)
                columns.Add(new List<char>());

            return columns;
        }

        private string FindMostFrequentLetter(List<LetterCounter> letterCounts)
        {
            var frequency = 0;
            var mostFrequentLetter = string.Empty;

            foreach(var letter in letterCounts)
            {
                if (letter.Occurences > frequency)
                {
                    frequency = letter.Occurences;
                    mostFrequentLetter = letter.Letter.ToString();
                }
            }
            return mostFrequentLetter;
        }

        private string FindLeastFrequentLetter(List<LetterCounter> letterCounts, int frequency)
        {
            var leastFrequentLetter = string.Empty;

            foreach (var letter in letterCounts)
            {
                if (letter.Occurences < frequency)
                {
                    frequency = letter.Occurences;
                    leastFrequentLetter = letter.Letter.ToString();
                }
            }
            return leastFrequentLetter;
        }
    }

    public class LetterCounter
    {
        public LetterCounter(char letter)
        {
            Letter = letter;
            Occurences = 0;
        }

        public char Letter { get; set; }
        public int Occurences { get; set; }
    }
}
