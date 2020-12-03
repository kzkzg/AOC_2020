using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC_day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("text.txt").ToList();
            for (int j = 0; j < lines.Count(); j++)
            {
                var line = lines[j];
                for (int i = 0; i < j; i++)
                    lines[j] += line;
            }

            uint result = Gogogo(3, 1, lines);
            Console.WriteLine(result);
            result *= Gogogo(1, 1, lines);
            result *= Gogogo(5, 1, lines);
            result *= Gogogo(7, 1, lines);
            result *= Gogogo(1, 2, lines);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        private static uint Gogogo(int addX, int addY, List<string> lines)
        {
            uint counter = 0;

            int x = 0;
            for (int y = 0; y < lines.Count(); y += addY)
            {
                if (lines[y][x] == '#')
                    counter++;
                x += addX;
            }
            return counter;
        }
    }
}
