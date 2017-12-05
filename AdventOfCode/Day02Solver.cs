using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    ///<Summary>
    ///<see href="https://adventofcode.com/2017/day/2">Corruption Checksum</see>
    ///</Summary>
    public class Day02Solver : ISolver
    {
        public int Day => 2;

        public string Title => "Corruption Checksum";

        private readonly string[] _inputArray;

        public Day02Solver()
        {
            _inputArray = Properties.Resources.Day2.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
        }

        public void SolvePart1()
        {
            var sum = 0;
            foreach (string row in _inputArray)
            {
                string[] columns = row.Split(null);

                //Instead of parsing each string into an int, I just pad and sort as a string
                int maxlen = columns.Max(x => x.Length);
                columns = columns.OrderBy(x => x.PadLeft(maxlen, '0')).ToArray();

                //Here we only have to parse the two we know are the min and max
                if (int.TryParse(columns[0], out int min) && int.TryParse(columns[columns.Length - 1], out int max))
                {
                    sum += max - min;
                }
            }
            Console.WriteLine(sum);
        }

        public void SolvePart2()
        {
            var sum = 0;
            foreach (string row in _inputArray)
            {
                int[] columns = row.Split(null).Select(int.Parse).ToArray();

                IEnumerable<(int, int)> result2 = GetPermutations(columns);

                foreach ((int highNum, int lowNum) in result2)
                {
                    if (highNum % lowNum == 0)
                    {
                        sum += highNum / lowNum;
                        break;
                    }
                }
            }
            Console.WriteLine(sum);
        }

        private static IEnumerable<(int, int)> GetPermutations(int[] items)
        {
            //According to the rules the two numbers have to divide evenly into one another and must be a whole number
            //Order from highest to lowest, then find all the possible combinations
            //Item1 will always be higher than Item2 in the resulting Tuple
            items = items.OrderByDescending(x => x).ToArray();
            for (var o = 0; o < items.Length; o++)
            {
                for (int i = o + 1; i < items.Length; i++)
                {
                    yield return (items[o], items[i]);
                }
            }
        }
    }
}
