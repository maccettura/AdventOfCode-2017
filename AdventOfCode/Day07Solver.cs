using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Day07Solver : ISolver
    {
        public int Day => 7;

        public string Title => "Recursive Circus";

        private static IEnumerable<string> Parse(string input) => input.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

        private string TopLevel = string.Empty;

        public void SolvePart1()
        {
            Dictionary<string, IEnumerable<string>> dictionary = Parse(Properties.Resources.Day07)
                .Where(x => x.Contains("->"))
                .Select(GetTupleFromString)
                .ToDictionary(x => x.Name, x => x.Children);

            foreach (KeyValuePair<string, IEnumerable<string>> entry in dictionary)
            {
                if (!dictionary.Values.Any(x => x.Contains(entry.Key.Trim())))
                {
                    TopLevel = entry.Key;
                    break;
                }
            }

            Console.WriteLine(TopLevel);
        }
        
        public void SolvePart2()
        {
            Dictionary<string, (string Name, int Weight, IEnumerable<string> Children)> dictionary = Parse(Properties.Resources.Day07)
                .Select(GetTupleFromString)
                .ToDictionary(x => x.Name, x => x);

            var sums = dictionary[TopLevel].Children
                .Select(x => GetSum(x, dictionary));

            int heaviestWeight = sums.OrderByDescending(x => x).First();

            Console.WriteLine(heaviestWeight);
        }

        private static int GetSum(string root, Dictionary<string, (string Name, int Weight, IEnumerable<string> Children)> dictionary)
        {
            int sum = dictionary[root].Weight;

            foreach (string s in dictionary[root].Children)
            {
                sum += GetSum(s, dictionary);
            }

            return sum;
        }

        private static (string Name, int Weight, IEnumerable<string> Children) GetTupleFromString(string input)
        {
            string[] array = input.Split(new [] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            (string, int, IEnumerable<string>) output = (RemoveWhitespace(array[0]), int.Parse(array[1]), Enumerable.Empty<string>());
            if (array.Length > 2)
            {
                output.Item3 = array[2].Replace("->", "").Trim().Split(',').Select(RemoveWhitespace);
            }
            return output;
        }

        public static string RemoveWhitespace(string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !char.IsWhiteSpace(c))
                .ToArray());
        }
    }
}
