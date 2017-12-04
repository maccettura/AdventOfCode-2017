using System;
using System.Collections.Generic;

namespace AdventOfCode.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var wrappers = new List<SolverWrapper>()
            {
                new SolverWrapper(new Day01Solver()),
                new SolverWrapper(new Day02Solver()),
                new SolverWrapper(new Day03Solver()),
                new SolverWrapper(new Day04Solver()),
                new SolverWrapper(new Day05Solver()),
                new SolverWrapper(new Day06Solver()),
                new SolverWrapper(new Day07Solver()),
                new SolverWrapper(new Day08Solver()),
                new SolverWrapper(new Day09Solver()),
                new SolverWrapper(new Day10Solver()),
                new SolverWrapper(new Day11Solver()),
                new SolverWrapper(new Day12Solver()),
                new SolverWrapper(new Day13Solver()),
                new SolverWrapper(new Day14Solver()),
                new SolverWrapper(new Day15Solver()),
                new SolverWrapper(new Day16Solver()),
                new SolverWrapper(new Day17Solver()),
                new SolverWrapper(new Day18Solver()),
                new SolverWrapper(new Day19Solver()),
                new SolverWrapper(new Day20Solver()),
                new SolverWrapper(new Day21Solver()),
                new SolverWrapper(new Day22Solver()),
                new SolverWrapper(new Day23Solver()),
                new SolverWrapper(new Day24Solver()),
                new SolverWrapper(new Day25Solver()),
            };


            foreach (SolverWrapper wrapper in wrappers)
            {
                wrapper.Solve();
            }

            Console.ReadLine();
        }
    }
}
