using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC_day4
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines(@"..\..\..\text.txt").ToList();
            var passpords = new List<string>() {"" };
            string sss = passpords.Last();

            foreach(var line in lines)
            {
                if (line.Count() > 1)
                    passpords[passpords.Count-1] = passpords.Last() + line+" ";
                else
                    passpords.Add("");
            }
            var dane = new List<string> { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"};

            int counter = 0;
            foreach(var pass in passpords)
            {
                bool valid = true;
                var fields = pass.Split(" ").Select(o=> o.Split(":")[0]);
                foreach(var d in dane)
                {
                    if(!fields.Contains(d))
                    {
                        valid = false;
                        break;
                    }
                }
                if (valid)
                    counter++;
            }
        }
    }
}
