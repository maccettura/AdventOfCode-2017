using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Day04Solver : ISolver
    {
        public int Day => 4;

        public string Title => "High-Entropy Passphrases";

        public void SolvePart1()
        {
            Console.WriteLine(Part1(Properties.Resources.Day4));
        }

        public void SolvePart2()
        {
            Console.WriteLine(Part2(Properties.Resources.Day4));
        }

        private static int Part1(string input)
        {
            return input.Split(new[] {Environment.NewLine}, StringSplitOptions.None)
                .Select(s => s.Split(null))
                .Count(parts => parts.Length == parts.Distinct().Count());
        }

        private static int Part2(string input)
        {
            var validCount = 0;
            foreach (string inputSplit in input.Split(new[] {Environment.NewLine}, StringSplitOptions.None))
            {
                var set = new HashSet<string>();
                var isValid = true;
                foreach (string s in inputSplit.Split(null))
                {
                    char[] array = s.ToLower().ToCharArray();
                    Array.Sort(array);
                    var sorted = new string(array);

                    if (set.Contains(sorted))
                    {
                        isValid = false;
                        break;
                    }
                    set.Add(sorted);
                }
                if (isValid)
                {
                    validCount++;
                }                
            }
            return validCount;
        }
    }
}
