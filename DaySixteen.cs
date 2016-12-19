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
    }
}
