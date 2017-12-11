using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    public class Day11Solver : ISolver
    {
        public int Day => 11;

        public string Title => "Hex Ed";

        public void SolvePart1()
        {
            Console.WriteLine(GetSteps().minSteps);
        }

        public void SolvePart2()
        {
            Console.WriteLine(GetSteps().maxSteps);
        }

        private static (int maxSteps, int minSteps) GetSteps()
        {
            var counts = new Dictionary<string, int>();

            var maxSteps = 0;
            foreach (string s in Properties.Resources.Day11.Split(','))
            {
                if (counts.ContainsKey(s))
                {
                    counts[s]++;
                }
                else
                {
                    counts.Add(s, 0);
                }

                int distance = Calculate(counts);

                if (distance > maxSteps)
                {
                    maxSteps = distance;
                }                
            }

            return (maxSteps, Calculate(counts));
        }

        private static int Calculate(IReadOnlyDictionary<string, int> counts)
        {
            try
            {
                int x = Math.Abs(counts["se"] + counts["ne"] - (counts["sw"] + counts["nw"]));
                int y = Math.Abs(counts["n"] + counts["nw"] - (counts["s"] + counts["se"]));
                int z = Math.Abs(counts["s"] + counts["sw"] - (counts["n"] + counts["ne"]));
                return (x + y + z) / 2;
            }
            catch
            {
                return 0;
            }
        }
    }
}
