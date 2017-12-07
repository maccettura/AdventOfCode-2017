using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    ///<Summary>
    ///<see href="https://adventofcode.com/2017/day/4">High-Entropy Passphrases</see>
    ///</Summary>
    public class Day04Solver : ISolver
    {
        public int Day => 4;

        public string Title => "High-Entropy Passphrases";

        private readonly string[] _inputArray;

        public Day04Solver()
        {
            _inputArray = Properties.Resources.Day04.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
        }

        public void SolvePart1()
        {
            int count = _inputArray
                .Select(s => s.Split(null))
                .Count(parts => parts.Length == parts.Distinct().Count());
            Console.WriteLine(count);
        }

        public void SolvePart2()
        {
            var validCount = 0;
            foreach (string inputSplit in _inputArray)
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
            Console.WriteLine(validCount);
        }
    }
}
