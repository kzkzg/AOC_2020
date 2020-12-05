using System;
using System.IO;
using System.Linq;

namespace AOC_day5
{
    class Program
    {
        static void Main(string[] args)
        {
            var seats = File.ReadAllLines(@"..\..\..\text.txt").Select(o => ConvertToInt(o.Substring(0, 7), 'F') * 8 + ConvertToInt(o.Substring(7), 'L')).OrderBy(o => o).ToList();

            Console.WriteLine(seats.Max());

            for (int i = seats.Min(); i <= seats.Max(); i++)
                if (!seats.Contains(i))
                    Console.WriteLine(i);

            Console.ReadKey();
        }
        static int ConvertToInt(string s, char lowerChar) => Convert.ToInt32(s.Select(o => o == lowerChar ? "0" : "1").Aggregate((x, y) => x + y), 2);
    }
}