using System;
using System.IO;
using System.Linq;
using static System.Console;

namespace AOC_day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = File.ReadAllLines("text.txt").Select(o => int.Parse(o));


            ReadKey();
        }
    }
}
