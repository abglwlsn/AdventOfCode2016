using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    class DaySeven
    {
        private List<string> _stringsInsideBrackets = new List<string>();
        private List<string> _stringsOutsideBrackets = new List<string>();

        public int GetSupportedIPs(string input)
        {      
            var IPs = input.Split(new string[] { "\r", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            //var addressesSupportingTLS = 0;
            var addressesSupportingSSL = 0;

            foreach (var ipAddress in IPs)
            {
                OrganizeByBracketContainment(ipAddress);

                //if (SupportsTLS(ipAddress))
                //    addressesSupportingTLS++;

                if (SupportsSSL(ipAddress))
                    addressesSupportingSSL++;

                _stringsInsideBrackets.Clear();
                _stringsOutsideBrackets.Clear();
            }

            //return addressesSupportingTLS;
            return addressesSupportingSSL;
        }

        private void OrganizeByBracketContainment(string ip)
        {
            var segments = ip.Split(new string[] { "[", "]" }, StringSplitOptions.RemoveEmptyEntries);
            for (var i = 0; i < segments.Length; i++)
            {
                if (i % 2 == 0)
                    _stringsOutsideBrackets.Add(segments[i].Trim());
                else
                    _stringsInsideBrackets.Add(segments[i].Trim());
            }
        }

        #region PartOne
        private bool SupportsTLS(string ipAddress)
        {
            foreach (var segment in _stringsInsideBrackets)
                if (ContainsABBASequence(segment.ToCharArray()))
                    return false;

            var outsideSegmentsWithABBA = 0;
            foreach (var segment in _stringsOutsideBrackets)
                if (ContainsABBASequence(segment.ToCharArray()))
                    outsideSegmentsWithABBA++;

            if (outsideSegmentsWithABBA > 0)
                return true;
            else return false;
        }

        private bool ContainsABBASequence(char[] segment)
        {
            if (segment.Length < 4)
                return false;

            var current = segment[1].ToString();
            for (var i = 2; i < segment.Length - 1; i++)
            {
                var next = segment[i].ToString();
                var preceding = segment[i - 2].ToString();
                var afterNext = segment[i + 1].ToString();

                if (current == next && preceding == afterNext && current != preceding)
                    return true;

                preceding = current;
                current = next;
                next = afterNext;
            }

            return false;
        }
        #endregion

        private bool SupportsSSL(string ipAddress)
        {
            var ABAsequences = GetSequences(_stringsOutsideBrackets);
            var BABsequences = GetSequences(_stringsInsideBrackets);

            if (!ABAsequences.Any())
                return false;

            foreach (var ABAseq in ABAsequences)
            {
                var Acharacters = ABAseq.ToCharArray();
                foreach (var BABseq in BABsequences)
                {
                    var Bcharacters = BABseq.ToCharArray();
                    if (Acharacters[1] == Bcharacters[0] && Acharacters[0] == Bcharacters[1])
                        return true;
                }
            }

            return false;    
        }

        private List<string> GetSequences(List<string> segmentList)
        {
            var sequences = new List<string>();

            foreach (var segment in segmentList)
            {
                if (segment.Length < 3)
                    continue;

                for (var i = 1; i < segment.Length - 1; i++)
                {
                    var current = segment[i].ToString();
                    var next = segment[i + 1].ToString();
                    var preceding = segment[i - 1].ToString();

                    if (preceding == next && preceding != current)
                        sequences.Add(preceding + current + next);
                }
            }

            return sequences;
        }      
    }
}
