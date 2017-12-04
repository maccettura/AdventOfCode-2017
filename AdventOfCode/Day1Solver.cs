using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Day1Solver : ISolver
    {
        public void Solve()
        {
            int[] inputArray = ConvertStringToIntArray(Properties.Resources.Day1);

            Console.WriteLine(Part1(inputArray));
            Console.WriteLine(Part2(inputArray));
        }

        private static int[] ConvertStringToIntArray(string input)
        {
            return input.Select(x => (int)char.GetNumericValue(x)).ToArray();
        }

        private static int Part1(IReadOnlyList<int> inputArray)
        {
            var sum = 0;
            for (var i = 0; i < inputArray.Count - 1; i++)
            {
                if (inputArray[i] == inputArray[i + 1])
                {
                    sum += inputArray[i];
                }
            }
            if (inputArray[0] == inputArray[inputArray.Count - 1])
            {
                sum += inputArray[0];
            }
            return sum;
        }

        private static int Part2(IReadOnlyList<int> inputArray)
        {
            var sum = 0;
            int halfLength = inputArray.Count / 2;
            for (var i = 0; i < halfLength; i++)
            {
                if (inputArray[i] == inputArray[i + halfLength])
                {
                    sum += inputArray[i] * 2;
                }
            }
            return sum;
        }
    }
}
