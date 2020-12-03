using System.IO;
using System.Linq;
using static System.Console;

namespace AOC
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = File.ReadAllLines(@"..\..\..\text.txt").Select(o => int.Parse(o));
            WriteLine(One(nums.ToArray()));
            WriteLine(Two(nums.ToArray()));
            ReadKey();

        }

        private static int One(int[] nums)
        {
            for (int i = 0; i < nums.Count(); i++)
                for (int j = 1; j < nums.Count(); j++)
                    if (nums[i] + nums[j] == 2020)
                        return nums[i] * nums[j];
            return 0;
        }

        private static int Two(int[] nums)
        {
            for (int i = 0; i < nums.Count(); i++)
                for (int j = 1; j < nums.Count(); j++)
                    for (int k = 2; k < nums.Count(); k++)
                        if (nums[i] + nums[j] + nums[k] == 2020)
                            return nums[i] * nums[j] * nums[k];
            return 0;
        }
    }
}
