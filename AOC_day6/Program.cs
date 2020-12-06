using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC_day6
{
    class Program
    {
        static void Main(string[] args)
        {
            var counter1 = 0;
            var counter2 = 0;
            var lines = File.ReadAllLines(@"..\..\..\text.txt");
            var groups = new List<List<string>> { new List<string> { lines.First() } };
            foreach (var line in lines.Skip(1))
                if (line == "")
                    groups.Add(new List<string>());
                else
                    groups.Last().Add(line);

            foreach (var group in groups)
            {
                var answers = string.Join("", group).Distinct();
                var answersCount = answers.Count();
                counter1 += answersCount;

                foreach (var answer in answers)
                    if (group.All(o => o.Contains(answer)))
                        counter2++;

            }
            Console.WriteLine($"{counter1}{Environment.NewLine}{counter2}");
            Console.ReadKey();
        }
    }
}