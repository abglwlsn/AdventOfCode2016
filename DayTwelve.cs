using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2016
{
    public class DayTwelve
    {
        public int GetRegisterAValue()
        {
            var input = @"cpy 1 a
cpy 1 b
cpy 26 d
jnz c 2
jnz 1 5
cpy 7 c
inc d
dec c
jnz c -2
cpy a c
inc a
dec b
jnz b -2
cpy c b
dec d
jnz d -6
cpy 16 c
cpy 12 d
inc a
dec d
jnz d -2
dec c
jnz c -5";
            var registers = CreateRegisters(4);
            var c = registers.FirstOrDefault(r => r.Name == "C");
            c.Value = 1;
            var instructions = input.Split(new string[] { "\r\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
            for (var i = 0; i < instructions.Length; i++)
            {
                if (instructions[i] == string.Empty)
                    continue;
                var segments = instructions[i].Trim().Split(' ');
                var action = segments[0].Trim();
                if (action == "jnz")
                {
                    int value;
                    if (!int.TryParse(segments[1], out value))
                    {
                        var register = registers.FirstOrDefault(r => r.Name == segments[1].ToUpper());
                        if (register.Value == 0)
                            continue;
                        i += (Convert.ToInt32(segments[2]) - 1);
                    }
                    else
                    {
                        if (value == 0)
                            continue;
                        i += (Convert.ToInt32(segments[2]) - 1);
                    }

                    continue;
                }
                else if (action == "cpy")
                {
                    var register = registers.FirstOrDefault(r => r.Name == segments[2].ToUpper());
                    var copiedRegister = registers.FirstOrDefault(r => r.Name == segments[1].ToUpper());
                    register.CopyValue(segments, copiedRegister);
                }
                else if (action == "inc")
                {
                    var register = registers.FirstOrDefault(r => r.Name == segments[1].ToUpper());
                    register.Increment();
                }
                else if (action == "dec")
                {
                    var register = registers.FirstOrDefault(r => r.Name == segments[1].ToUpper());
                    register.Decrement();
                }
            }
            var registerA = registers.FirstOrDefault(r => r.Name == "A");
            return registerA.Value;
        }

        private List<Register> CreateRegisters(int numberOfRegisters)
        {
            var registers = new List<Register>();
            for (var i = 1; i < numberOfRegisters + 1; i++)
            {
                var character = (char)(i + 64);
                var register = new Register(character.ToString().ToUpper());
                registers.Add(register);
            }
            return registers;
        }
    }

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
