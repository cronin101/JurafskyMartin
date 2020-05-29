using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Chapter2.PartTwo
{
    public class RegularExpressions
    {
        private static Random RandomSource = new Random();

        public static IList<Func<string, (string, bool)>> Transformations => new Func<string, (string, bool)>[] {
            (input) => (Regex.Replace(input, @"\bmy\b", "YOUR", RegexOptions.IgnoreCase), false),
            (input) => (Regex.Replace(input, @"\b(I'm|I am)\b", "YOU ARE"), false),
            (input) => {
                var hasMatch = Regex.Match(input, @"\ball\b", RegexOptions.IgnoreCase).Success;
                return hasMatch ? ("IN WHAT WAY?", true) : (input, false);
            },
            (input) => {
                var hasMatch = Regex.Match(input, @"\balways\b", RegexOptions.IgnoreCase).Success;
                return hasMatch ? ("CAN YOU THINK OF A SPECIFIC EXAMPLE?", true) : (input, false);
            },
            (input) => {
                var hasMatch = Regex.Match(input, @"\bnever\b", RegexOptions.IgnoreCase).Success;
                return hasMatch ? ("ARE YOU SURE?", true) : (input, false);
            },
            (input) => {
                var pattern = @"\bYOU ARE (depressed|sad)\b";
                var hasMatch = Regex.Match(input, pattern).Success;
                if (!hasMatch) {
                    return (input, false);
                }

                var response = new[] { "WHY DO YOU THINK THAT YOU ARE $1?", "I'M SORRY TO HEAR THAT YOU ARE $1" }[RandomSource.Next(2)];
                return (Regex.Replace(input, pattern, response), true);
            }
        };

        public static string RunTransformations(string input)
        {
            var (result, _) = Transformations.Aggregate(
                (input, false),
                (accumulator, transformation) =>
                    {
                        var (currentString, hasTerminated) = accumulator;
                        return hasTerminated ? accumulator : transformation(currentString);
                    });

            return result.ToUpperInvariant();
        }
    }
}
