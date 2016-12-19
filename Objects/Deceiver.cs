using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{

    public class Deceiver
    {
        public Deceiver(string input, int diskLength)
        {
            InitialState = input;
            DiskLength = diskLength;
            DragonCurve = string.Empty;
            CheckSum = string.Empty;
        }

        private string _dragonCurve;

        public string InitialState { get; set; }
        public string WorkingState { get; set; }
        public string DragonCurve
        {
            get { return _dragonCurve; }
            set
            {
                _dragonCurve = value.Length > DiskLength ? new string(value.Take(DiskLength).ToArray()) : value;
            }
        }
        public int DiskLength { get; set; }
        public string CheckSum { get; set; }

        public void SetDragonCurve()
        {
            WorkingState = InitialState;
            ReverseWorkingState();
            InvertWorkingState();
            DragonCurve = InitialState + '0' + WorkingState.ToString();
        }

        private void ReverseWorkingState()
        {
            var characters = WorkingState.ToCharArray();
            var newState = new StringBuilder();
            for (var i = characters.Length - 1; i > -1; i--)
                newState.Append(characters[i]);
            WorkingState = newState.ToString();
        }

        private void InvertWorkingState()
        {
            var newState = new StringBuilder(WorkingState);
            for (var i = 0; i < WorkingState.Length; i++)
                newState[i] = WorkingState[i] == '0' ? '1' : '0';

            WorkingState = newState.ToString();
        }

        public void SetCheckSum(string input)
        {
            var checksum = new StringBuilder();
            for (var i = 0; i < input.Length; i += 2)
                checksum.Append(input[i] == input[i + 1] ? "1" : "0");

            CheckSum = checksum.ToString();
        }
    }
}
