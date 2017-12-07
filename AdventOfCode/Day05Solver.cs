using System;
using System.Linq;

namespace AdventOfCode
{
    ///<Summary>
    ///<see href="https://adventofcode.com/2017/day/5">A Maze of Twisty Trampolines, All Alike</see>
    ///</Summary>
    public class Day05Solver : ISolver
    {
        public int Day => 5;

        public string Title => "A Maze of Twisty Trampolines, All Alike";

        private static int[] Parse(string input) => input.Split(new[] { Environment.NewLine }, StringSplitOptions.None)
                                        .Select(int.Parse)
                                        .ToArray();

        public void SolvePart1()
        {
            Console.WriteLine(MazeSolver(Parse(Properties.Resources.Day05), i => i + 1));
        }

        public void SolvePart2()
        {
            Console.WriteLine(MazeSolver(Parse(Properties.Resources.Day05), i => i + (i > 2 ? -1 : 1)));
        }

        private static int MazeSolver(int[] input, Func<int, int> getOffset)
        {
            var counter = 0;
            var currentIndex = 0;
            while (currentIndex >= 0 && currentIndex < input.Length)
            {
                int value = input[currentIndex];
                input[currentIndex] = getOffset(value);
                currentIndex += value;
                counter++;
            }
            return counter;
        }
    }
}
