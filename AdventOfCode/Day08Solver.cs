using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Day08Solver : ISolver
    {
        public int Day => 8;

        public string Title => "I Heard You Like Registers";

        public void SolvePart1()
        {
            Console.WriteLine(GetMaxValues().maxValueAtEnd);
        }

        public void SolvePart2()
        {
            Console.WriteLine(GetMaxValues().maxValueAtAnyPoint);
        }

        private static (int maxValueAtEnd, int maxValueAtAnyPoint) GetMaxValues()
        {
            string[] inputArray =
                Properties.Resources.Day08.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            List<(string, bool, int, string, Func<Dictionary<string, int>, string, bool>)> list =
                inputArray.Select(ParseString).ToList();

            Dictionary<string, int> dictionary = list.Select(x => x.Item1).Distinct().ToDictionary(x => x, x => 0);

            var maxValue = 0;
            foreach ((string name, bool increase, int value, string compareTo, Func<Dictionary<string, int>, string, bool> expression) item in list)
            {
                if (item.expression(dictionary, item.compareTo))
                {
                    if (item.increase)
                    {
                        dictionary[item.name] += item.value;
                    }
                    else
                    {
                        dictionary[item.name] -= item.value;
                    }
                }

                int newMax = dictionary.Max(x => x.Value);
                if (newMax > maxValue)
                {
                    maxValue = newMax;
                }
            }

            return (dictionary.Max(x => x.Value), maxValue);
        }

        public static Func<Dictionary<string, int>, string, bool> ParseExpression(string stringOperator, int value)
        {
            switch (stringOperator)
            {
                case "<":
                    return (dict, key) => dict[key] < value;
                case ">":
                    return (dict, key) => dict[key] > value;
                case "<=":
                    return (dict, key) => dict[key] <= value;
                case ">=":
                    return (dict, key) => dict[key] >= value;
                case "==":
                    return (dict, key) => dict[key] == value;
                case "!=":
                    return (dict, key) => dict[key] != value;
                default:
                    throw new ArgumentException("Cannot parse expression");
            }
        }

        private static (string name, bool increase, int value, string compareTo, Func<Dictionary<string, int>, string, bool> expression) ParseString(string input)
        {
            string[] split = input.Split(null).Where(x => !string.IsNullOrEmpty(x)).ToArray();
            string compareTo = split[4];
            int expressionValue = int.Parse(split[6]);
            int value = int.Parse(split[2]);

            return string.Compare(split[1], "inc", true) == 0 
                ? (split[0], true, value, compareTo, ParseExpression(split[5], expressionValue)) 
                : (split[0], false, value, compareTo, ParseExpression(split[5], expressionValue));
        }
    }
}
