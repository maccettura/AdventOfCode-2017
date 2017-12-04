using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    ///<Summary>
    ///<see href="https://adventofcode.com/2017/day/1">Inverse Captcha</see>
    ///</Summary>
    public class Day01Solver : ISolver
    {
        public int Day => 1;

        public string Title => "Inverse Captcha";

        private readonly int[] _inputArray;

        public Day01Solver()
        {
            _inputArray = ConvertStringToIntArray(Properties.Resources.Day1);
        }

        public void SolvePart1()
        {
            Console.WriteLine(Part1(_inputArray));
        }

        public void SolvePart2()
        {
            Console.WriteLine(Part2(_inputArray));
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
