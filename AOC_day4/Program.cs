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
            var passpords = new List<string>() { "" };
            string sss = passpords.Last();

            foreach (var line in lines)
            {
                if (line.Count() > 1)
                    passpords[passpords.Count - 1] = passpords.Last() + line + " ";
                else
                    passpords.Add("");
            }
            var dane = new List<string> { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };

            int counter = 0;
            foreach (var pass in passpords)
            {
                bool valid = true;
                var fields = pass.Split(" ").Select(o => o.Split(":")[0]);
                foreach (var d in dane)
                {
                    if (!fields.Contains(d))
                    {
                        valid = false;
                        break;
                    }
                }
                if (valid)
                    counter++;
            }
            Console.WriteLine(counter);
            var colors = new List<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

            counter = 0;
            foreach (var pass in passpords)
            {
                bool valid = true;
                var fields = pass.Split(" ").Select(o => o.Split(":")[0]);

                foreach (var d in dane)
                {
                    if (!fields.Contains(d))
                    {
                        valid = false;
                        break;
                    }
                }

                if (valid)
                {
                    foreach (var qq in pass.Split(" "))
                    {
                        var symbol = qq.Split(":")[0];
                        switch (symbol)
                        {
                            case "byr":
                                var val = int.Parse(qq.Split(":")[1]);
                                if (!(val >= 1920 && val <= 2002 && qq.Split(":")[1].Count() == 4))
                                    valid = false;
                                break;

                            case "iyr":
                                val = int.Parse(qq.Split(":")[1]);
                                if (!(val >= 2010 && val <= 2020 && qq.Split(":")[1].Count() == 4))
                                    valid = false;
                                break;

                            case "eyr":
                                val = int.Parse(qq.Split(":")[1]);
                                if (!(val >= 2020 && val <= 2030 && qq.Split(":")[1].Count() == 4))
                                    valid = false;
                                break;

                            case "hgt":
                                var ff = qq.Split(":")[1];
                                if (ff.EndsWith("cm"))
                                {
                                    var aa = int.Parse(ff.Split("c")[0]);
                                    if (!(aa >= 150 && aa <= 193))
                                        valid = false;
                                }
                                else if (ff.EndsWith("in"))
                                {
                                    var aa = int.Parse(ff.Split("i")[0]);
                                    if (!(aa >= 59 && aa <= 76))
                                        valid = false;
                                }
                                else
                                    valid = false;
                                break;

                            case "hcl":
                                ff = qq.Split(":")[1];
                                if (!(ff.StartsWith('#') && ff.Count() == 7))
                                    valid = false;
                                try
                                {
                                    var gg = System.Drawing.ColorTranslator.FromHtml(ff);
                                }
                                catch
                                {
                                    valid = false;
                                }
                                break;
                            case "ecl":
                                ff = qq.Split(":")[1];
                                if (!colors.Contains(ff))
                                    valid = false;
                                break;
                            case "pid":
                                ff = qq.Split(":")[1];
                                if (!(ff.Count() == 9 && int.TryParse(ff, out var jnf)))
                                    valid = false;
                                break;
                        }
                    }
                }

                if (valid)
                    counter++;
            }

            Console.WriteLine(counter);
            Console.ReadKey();
        }
    }
}
