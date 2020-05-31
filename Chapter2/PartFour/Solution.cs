using System.Text.RegularExpressions;

namespace Chapter2.PartFour
{
    public class Solution
    {
        public static Regex One()
        {
            var oneSecondPattern = $"({SharedRegex.OnePattern} second)";
            var belowSixtyPluralSecondsPattern = $"({SharedRegex.BelowSixtyExcludingOnePattern} seconds)";
            var belowSixtySecondsPattern = $"(({oneSecondPattern}|{belowSixtyPluralSecondsPattern})\\b)";
            return new Regex(belowSixtySecondsPattern, RegexOptions.Compiled);
        }
    }
}
