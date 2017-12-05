using System;
using System.Collections.Generic;

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
            Console.WriteLine(Part2(368078));
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
            var values = new Dictionary<long, int>()
            {
                { HashCoordinate(0, 0), 1 }
            };

            int levelCounter = 1;
            int y = 0;
            int x = 1;


            int cornerTurn = levelCounter * 8 / 4;
            for (var sideIndex = 0; sideIndex < 4; sideIndex++)
            {
                for (var s = 0; s < cornerTurn; s++)
                {
                    int result = ExtractValues(GetCoordinatesForSum(x, y, GetDirectionArray(sideIndex)), values);

                    if (result > input)
                    {
                        return result;
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

                }
            }
            return 0;

            //while (!limitReached)
            //{
            //    spiralCount = levelCounter * 8 - 1;
            //    cornerIndex = spiralCount / 4;
            //    for (int s = 0; s < spiralCount; s++)
            //    {
            //        int value = 0;
            //        if (s < cornerIndex)
            //        {                        
            //            values.Add(HashCoordinate(x, y), ExtractValues(GetCoordinatesForSum(x, y, GetDirectionArray(0)), values));
            //            y += 1;
            //        }
            //        else if (s < cornerIndex * 2)
            //        {
            //            values.Add(HashCoordinate(x, y), ExtractValues(GetCoordinatesForSum(x, y, GetDirectionArray(1)), values));
            //            x -= 1;
            //        }
            //        else if (s < cornerIndex * 3)
            //        {
            //            values.Add(HashCoordinate(x, y), ExtractValues(GetCoordinatesForSum(x, y, GetDirectionArray(2)), values));
            //            y -= 1;
            //        }
            //        else
            //        {
            //            values.Add(HashCoordinate(x, y), ExtractValues(GetCoordinatesForSum(x, y, GetDirectionArray(3)), values));
            //            x += 1;
            //        }

            //    }
            //}



            //int gridSize = 3;
            //do
            //{
            //    values[values.Count - 1]
            //    values.Add();
            //} while ();
            //throw new NotImplementedException();
        }

        private static long HashCoordinate(int x, int y)
        {
            return ((long)x << 32) + y;
        }

        private enum Direction
        {
            N,
            NE,
            E,
            SE,
            S,
            SW,
            W,
            NW
        }

        private static IEnumerable<Direction> GetDirectionArray(int sideIndex)
        {
            if (sideIndex == 0)
            {
                //W NW SW S
                return new[] {Direction.W, Direction.NW, Direction.SW, Direction.S,};
            }
            if (sideIndex == 1)
            {
                //S E SW SE
                return new[] { Direction.S, Direction.E, Direction.SW, Direction.SE };
            }
            if (sideIndex == 2)
            {
                //E SE N NE
                return new[] { Direction.E, Direction.SE, Direction.N, Direction.NE };
            }
            if(sideIndex == 3)
            {
                //N NE W NW
                return new[] { Direction.N, Direction.NE, Direction.W, Direction.NW };
            }
            return null;
        }

        private static IEnumerable<Tuple<int, int>> GetCoordinatesForSum(int x, int y, IEnumerable<Direction> directions)
        {
            var output = new List<Tuple<int, int>>();
            foreach (var direction in directions)
            {
                if (direction == Direction.N)
                {
                    output.Add(new Tuple<int, int>(x, y + 1));
                }
                else if (direction == Direction.NE)
                {
                    output.Add(new Tuple<int, int>(x + 1, y + 1));
                }
                else if (direction == Direction.E)
                {
                    output.Add(new Tuple<int, int>(x + 1, y));
                }
                else if (direction == Direction.SE)
                {
                    output.Add(new Tuple<int, int>(x + 1, y - 1));
                }
                else if (direction == Direction.S)
                {
                    output.Add(new Tuple<int, int>(x, y - 1));
                }
                else if (direction == Direction.SW)
                {
                    output.Add(new Tuple<int, int>(x - 1, y - 1));
                }
                else if (direction == Direction.W)
                {
                    output.Add(new Tuple<int, int>(x - 1, y));
                }
                else if (direction == Direction.NW)
                {
                    output.Add(new Tuple<int, int>(x - 1, y + 1));
                }
            }
            return output;
        }

        private static int ExtractValues(IEnumerable<Tuple<int, int>> coordinates, Dictionary<long, int> values)
        {
            var sum = 0;
            long hash = 0;
            foreach (Tuple<int, int> coordinate in coordinates)
            {
                hash = HashCoordinate(coordinate.Item1, coordinate.Item2);
                if (values.ContainsKey(hash))
                {
                    sum += values[hash];
                }
            }
            return sum;
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
