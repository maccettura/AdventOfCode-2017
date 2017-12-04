using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Day2Solver : ISolver
    {
        public void Solve()
        {
            string result = Properties.Resources.Day2;

            Console.WriteLine(CalculateCheckSumPart1(result));
            Console.WriteLine(CalculateCheckSumPart2(result));
        }

        private static int CalculateCheckSumPart1(string input)
        {
            var sum = 0;
            foreach (string row in input.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
            {
                string[] columns = row.Split(null);

                int maxlen = columns.Max(x => x.Length);
                columns = columns.OrderBy(x => x.PadLeft(maxlen, '0')).ToArray();

                var min = 0;
                var max = 0;
                if (int.TryParse(columns[0], out min) && int.TryParse(columns[columns.Length - 1], out max))
                {
                    sum += max - min;
                }
            }
            return sum;
        }

        private static int CalculateCheckSumPart2(string input)
        {
            var sum = 0;
            foreach (string row in input.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
            {
                int[] columns = row.Split(null).Select(int.Parse).OrderByDescending(x => x).ToArray();

                IEnumerable<Tuple<int, int>> result2 = GetPermutations(columns);

                foreach (Tuple<int, int> r in result2)
                {
                    if (r.Item1 % r.Item2 == 0)
                    {
                        sum += r.Item1 / r.Item2;
                        break;
                    }
                }
            }
            return sum;
        }


        private static IEnumerable<Tuple<int, int>> GetPermutations(int[] items)
        {
            for (var o = 0; o < items.Length; o++)
            {
                for (int i = o + 1; i < items.Length; i++)
                {
                    yield return new Tuple<int, int>(items[o], items[i]);
                }
            }
        }
    }
}
