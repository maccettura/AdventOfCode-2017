using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var wrappers = new List<SolverWrapper>()
            {
                new SolverWrapper(new Day1Solver()),
                new SolverWrapper(new Day2Solver()),
            };


            foreach (SolverWrapper wrapper in wrappers)
            {
                wrapper.Solve();
            }

            Console.ReadLine();
        }
    }
}
