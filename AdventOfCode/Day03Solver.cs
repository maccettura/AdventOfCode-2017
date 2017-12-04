using System;

namespace AdventOfCode
{
    public class Day03Solver : ISolver
    {
        public int Day => 3;

        public string Title => "Spiral Memory";

        public void SolvePart1()
        {
            Console.WriteLine(Part1(368078));
        }

        public void SolvePart2()
        {
            throw new NotImplementedException();
        }

        private static int Part1(int input)
        {
            var squareRoot = 3;
            var gridLevelCounter = 1;
            while (squareRoot * squareRoot < input)
            {
                squareRoot += 2;
                gridLevelCounter++;
            }

            Tuple<int, int> coordinate = GetCoordinate(squareRoot, gridLevelCounter, input);
            return coordinate != null ? GetManhattanDistanceFromCenter(coordinate.Item1, coordinate.Item2) : 0;
        }

        private static int Part2(int input)
        {
            throw new NotImplementedException();
        }

        private static int GetManhattanDistanceFromCenter(int x, int y)
        {
            return Math.Abs(0 - x) + Math.Abs(0 - y);
        }

        private static Tuple<int, int> GetCoordinate(int squareRoot, int gridLevel, int valueToFind)
        {
            int x = gridLevel;
            int y = gridLevel * -1 + 1;
            int cornerTurn = gridLevel * 8 / 4;

            int currentNum = squareRoot * squareRoot - gridLevel * 8 + 1;
            for (var sideIndex = 0; sideIndex < 5; sideIndex++)
            {
                for (var s = 0; s < cornerTurn; s++)
                {
                    if (currentNum == valueToFind)
                    {
                        return new Tuple<int, int>(x, y);
                    }

                    if (sideIndex == 0)
                    {
                        y += 1;
                    }
                    else if (sideIndex == 1)
                    {
                        x -= 1;
                    }
                    else if (sideIndex == 2)
                    {
                        y -= 1;
                    }
                    else if (sideIndex == 3)
                    {
                        x += 1;
                    }
                    currentNum++;
                }
            }
            return null;
        }
    }
}
