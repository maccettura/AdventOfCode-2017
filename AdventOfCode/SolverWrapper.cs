using System;

namespace AdventOfCode
{
    public class SolverWrapper
    {
        private readonly ISolver _solver;

        public SolverWrapper(ISolver solver)
        {
            _solver = solver;
        }

        public void Solve()
        {
            Console.WriteLine("Advent of Code Day {0} | {1} \n", _solver.Day, _solver.Title);
            Console.WriteLine("Part 1");
            _solver.SolvePart1();
            Console.WriteLine("Part 2");
            _solver.SolvePart2();
            Console.WriteLine();
        }
    }
}
