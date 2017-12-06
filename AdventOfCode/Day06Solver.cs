using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Day06Solver : ISolver
    {
        public int Day => 6;

        public string Title => "Memory Reallocation";

        public void SolvePart1()
        {           
            int[] banks = Properties.Resources.Day6.Split(null).Select(int.Parse).ToArray();
            var set = new HashSet<string>();

            while (true)
            {
                string hashString = GetHashString(banks);
                if (set.Contains(hashString))
                {
                    break;                    
                }
                set.Add(hashString);
                banks = RedistributeBlocks(banks);
            }
            Console.WriteLine(set.Count);
        }

        public void SolvePart2()
        {
            int[] banks = Properties.Resources.Day6.Split(null).Select(int.Parse).ToArray();
            var list = new List<string>();

            while (true)
            {
                string hashString = GetHashString(banks);
                if (list.Contains(hashString))
                {
                    break;
                }
                list.Add(GetHashString(banks));
                banks = RedistributeBlocks(banks);
            }

            Console.WriteLine(list.Count - list.IndexOf(GetHashString(banks)));
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
