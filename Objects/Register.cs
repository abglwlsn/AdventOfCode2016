using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    public class Register
    {
        public Register(string name)
        {
            Name = name;
            Value = 0;
        }
        public string Name { get; set; }
        public int Value { get; set; }
        public bool IsZero()
        {
            return Value == 0;
        }

        public void CopyValue(string[] segments, Register copiedRegister)
        {
            int value;
            Value = int.TryParse(segments[1], out value) ? value : copiedRegister.Value;
        }

        public void Increment()
        {
            Value++;
        }

        public void Decrement()
        {
            Value--;
        }
    }
}
