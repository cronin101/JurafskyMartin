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

            var oneMinutePattern = $"({SharedRegex.OnePattern} minute)";
            var belowSixtyPluralMinutesPattern = $"({SharedRegex.BelowSixtyExcludingOnePattern} minutes)";
            var belowSixtyMinutesPattern = $"(({oneMinutePattern}|{belowSixtyPluralMinutesPattern})\\b)";

            var belowSixtyMinutesWithMaybeSecondsPattern = $"({belowSixtyMinutesPattern}( and {belowSixtySecondsPattern})?)";

            var oneHoursPattern = $"({SharedRegex.OnePattern} hour)";
            var belowElevenPluralHoursPattern = $"({SharedRegex.PluralDigitsPattern} hours)";
            var belowElevenHoursPattern = $"(({oneHoursPattern}|{belowElevenPluralHoursPattern})\\b)";

            var hoursWithMaybeMinutesPattern = $"({belowElevenHoursPattern}( and {belowSixtyMinutesPattern})?)";
            var hoursWithMaybeSecondsPattern = $"({belowElevenHoursPattern}( and {belowSixtySecondsPattern})?)";
            var hoursWithMinutesAndSecondsPattern = $"({belowElevenHoursPattern}, {belowSixtyMinutesPattern} and {belowSixtySecondsPattern})";
            var hoursWithMaybeMinutesAndSeconds = $"({hoursWithMinutesAndSecondsPattern}|{hoursWithMaybeMinutesPattern}|{hoursWithMaybeSecondsPattern})";

            var combinedPattern = $"^({hoursWithMaybeMinutesAndSeconds}|{belowSixtyMinutesWithMaybeSecondsPattern}|{belowSixtySecondsPattern})$";
            return new Regex(combinedPattern, RegexOptions.Compiled);
        }
    }
}
