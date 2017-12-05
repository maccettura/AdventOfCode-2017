using System;
using System.Linq;

namespace AdventOfCode
{
    public class Day05Solver : ISolver
    {
        public int Day => 5;

        public string Title => "A Maze of Twisty Trampolines, All Alike";

        public void SolvePart1()
        {
            int[] intArray = Properties.Resources.Day5.Split(new[] { Environment.NewLine }, StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();
            Console.WriteLine(MazeSolver(intArray, GetPart1Offset));
        }

        public void SolvePart2()
        {
            int[] intArray = Properties.Resources.Day5.Split(new[] { Environment.NewLine }, StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();
            Console.WriteLine(MazeSolver(intArray, GetPart2Offset));
        }

        private static int MazeSolver(int[] input, Func<int, int> getOffset)
        {
            var counter = 0;
            var currentIndex = 0;
            try
            {
                while (true)
                {
                    int value = input[currentIndex];
                    input[currentIndex] = getOffset(value);
                    currentIndex += value;
                    counter++;
                }
            }
            catch (IndexOutOfRangeException exception)
            {
                return counter;
            }
        }

        private static int GetPart1Offset(int value)
        {
            return value + 1;
        }

        private static int GetPart2Offset(int value)
        {
            return value >= 3 ? value - 1 : value + 1;
        }
    }
}
