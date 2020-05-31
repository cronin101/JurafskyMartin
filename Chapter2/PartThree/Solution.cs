using System.Text.RegularExpressions;

namespace Chapter2.PartThree
{
    public class Solutions
    {


        public static Regex One()
        {
            var singleDollarPattern = $"({SharedRegex.OnePattern} dollar)";
            var combinedPattern = $"({singleDollarPattern}|{SharedRegex.BelowMillionExcludingOnePattern} dollars)$";
            return new Regex(combinedPattern, RegexOptions.Compiled);
        }

        public static string DollarGenerator(int input)
        {
            if (input == 1)
            {
                return "one dollar";
            }

            return $"{NumstringGenerator.Generate(input)} dollars";
        }
    }
}
