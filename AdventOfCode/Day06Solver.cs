using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    ///<Summary>
    ///<see href="https://adventofcode.com/2017/day/6">A Maze of Twisty Trampolines, All Alike</see>
    ///</Summary>
    public class Day06Solver : ISolver
    {
        public int Day => 6;

        public string Title => "Memory Reallocation";

        private static int[] Parse(string input) => input.Split(null).Select(int.Parse).ToArray();

        public void SolvePart1()
        {
            Tuple<ICollection<string>, int[]> returnVal = BankProcessor(Parse(Properties.Resources.Day6), new HashSet<string>());
            Console.WriteLine(returnVal.Item1.Count);
        }

        public void SolvePart2()
        {
            Tuple<ICollection<string>, int[]> returnVal = BankProcessor(Parse(Properties.Resources.Day6), new HashSet<string>());

            Console.WriteLine(returnVal.Item1.Count - returnVal.Item1.ToList().IndexOf(GetHashString(returnVal.Item2)));
        }

        private static Tuple<ICollection<string>, int[]> BankProcessor(int[] banks, ICollection<string> seenCollection)
        {
            while (true)
            {
                string hashString = GetHashString(banks);
                if (seenCollection.Contains(hashString))
                {
                    break;
                }
                seenCollection.Add(GetHashString(banks));
                banks = RedistributeBlocks(banks);
            }
            return new Tuple<ICollection<string>, int[]>(seenCollection, banks);
        }

        private static int[] RedistributeBlocks(int[] banks)
        {
            int max = banks.Max();
            int index = Array.FindIndex(banks, i => i == max);

            banks[index++] = 0;

            while (max > 0)
            {
                if (index >= banks.Length)
                {
                    index = 0;
                }

                banks[index++]++;
                max--;
            }
            return banks;
        }

        private static string GetHashString(IEnumerable<int> intArray)
        {
            return string.Join(",", intArray.Select(x => x.ToString()));
        }
    }
}
