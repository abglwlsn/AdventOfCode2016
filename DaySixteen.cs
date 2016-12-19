using System.Linq;
using System.Text;

namespace AdventOfCode2016
{
    public class DaySixteen
    {
        public string DetermineChecksum()
        {
            var input = "11101000110010100";
            var diskLength = 35651584;
            var deceiver = new Deceiver(input, diskLength);

            while (deceiver.DragonCurve.Length < diskLength)
            {
                deceiver.SetDragonCurve();
                deceiver.InitialState = deceiver.DragonCurve;
            }

            var curve = deceiver.DragonCurve;
            while (deceiver.CheckSum.Length % 2 == 0)
            {
                deceiver.SetCheckSum(curve);
                curve = deceiver.CheckSum;
            }

            return deceiver.CheckSum;
        }

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
}
