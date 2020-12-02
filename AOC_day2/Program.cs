using System.IO;
using System.Linq;
using static System.Console;

namespace AOC_day2
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0, j = 0;
            var nums = File.ReadAllLines("text.txt");
            foreach (var line in nums)
            {
                var splited = line.Split();
                var numbers = splited[0].Split('-');
                var first = int.Parse(numbers[0]);
                var second = int.Parse(numbers[1]);
                var symbol = splited[1].Trim(':')[0];

                var qwe = splited[2].Count(o => o == symbol);
                if (qwe >= first && qwe <= second)
                    i++;

                if ((splited[2][first - 1] == symbol && splited[2][second - 1] != symbol) || (splited[2][first - 1] != symbol && splited[2][second - 1] == symbol))
                    j++;

            }

            WriteLine(i);
            WriteLine(j);
            ReadKey();
        }
    }
}
