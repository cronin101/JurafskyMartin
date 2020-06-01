using System.Text.RegularExpressions;

namespace Chapter2.PartThree
{
    public class Solutions
    {


        public static Regex One()
        {
            var singleCentPattern = $"({SharedRegex.OnePattern} cent)";
            var centsPattern = $"({singleCentPattern}|{SharedRegex.BelowHundredExcludingOnePattern} cents)\\b";
            var singleDollarPattern = $"({SharedRegex.OnePattern} dollar)";
            var dollarsPattern = $"({singleDollarPattern}|{SharedRegex.BelowMillionExcludingOnePattern} dollars)\\b";
            var combinedPattern = $"^(({dollarsPattern}( and {centsPattern})?)|{centsPattern})$";
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
