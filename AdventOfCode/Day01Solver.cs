using System;
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
            _inputArray = Properties.Resources.Day1.Select(x => (int) char.GetNumericValue(x)).ToArray();
        }

        public void SolvePart1()
        {
            var sum = 0;
            for (var i = 0; i < _inputArray.Length - 1; i++)
            {
                if (_inputArray[i] == _inputArray[i + 1])
                {
                    sum += _inputArray[i];
                }
            }
            if (_inputArray[0] == _inputArray[_inputArray.Length - 1])
            {
                sum += _inputArray[0];
            }

            Console.WriteLine(sum);
        }

        public void SolvePart2()
        {
            var sum = 0;
            int halfLength = _inputArray.Length / 2;
            for (var i = 0; i < halfLength; i++)
            {
                if (_inputArray[i] == _inputArray[i + halfLength])
                {
                    sum += _inputArray[i] * 2;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
