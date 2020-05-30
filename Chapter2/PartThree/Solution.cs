using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Chapter2.PartThree
{
    public class Solutions
    {
        private const string SingleDigitsPattern = @"one";
        private const string PluralDigitsPattern = @"(two|three|four|five|six|seven|eight|nine|ten)";
        private const string TeenPattern = @"(eleven|twelve|thirteen|fourteen|fifteen|sixteen|seventeen|eighteen|nineteen)";
        private const string TensPattern = @"(twenty|thirty|forty|fifty|sixty|seventy|eighty|ninety)";

        public static Regex One()
        {
            var allDigitsPattern = $"({SingleDigitsPattern}|{PluralDigitsPattern})";
            var singleDollarPattern = $"({SingleDigitsPattern} dollar)";
            var simplePattern = $"({PluralDigitsPattern}|{TeenPattern})";
            var tensAndDigitsPattern = $"({TensPattern}( {SingleDigitsPattern})?)";
            var lessThanHundredExcludingOnePattern = $"({simplePattern}|{tensAndDigitsPattern})";
            var lessThanHundredIncludingOnePattern = $"({simplePattern}|{tensAndDigitsPattern}|{SingleDigitsPattern})";
            var lessThanThousandPattern = $"(({allDigitsPattern} hundred( and {lessThanHundredIncludingOnePattern})?)|{lessThanHundredExcludingOnePattern})";
            var lessThanMillionPattern = $"((({lessThanThousandPattern}|{SingleDigitsPattern}) thousand(( and {lessThanHundredIncludingOnePattern})|( {lessThanThousandPattern}))?)|{lessThanThousandPattern})";

            var combinedPattern = $"({singleDollarPattern}|{lessThanMillionPattern} dollars)$";
            return new Regex(combinedPattern);
        }

        public static string StringGenerator(int input)
        {
            if (input == 1)
            {
                return "one dollar";
            }

            return $"{StringGeneratorInternal(input)} dollars";
        }

        private static string StringGeneratorInternal(int input)
        {
            var remaining = input;
            var parts = new List<string>();
            // Build up string by adding parts from RTL in increasing magnitude
            while (remaining > 0)
            {
                var asString = remaining.ToString();
                var lastTwoDigits = asString.Substring(asString.Length >= 2 ? asString.Length - 2 : 0).PadLeft(2, '0');
                if (lastTwoDigits != "00")
                {
                    var (amount, asText) = lastTwoDigits[0] switch
                    {

                        '1' => lastTwoDigits[1] switch
                        {
                            '9' => (19, "nineteen"),
                            '8' => (18, "eighteen"),
                            '7' => (17, "seventeen"),
                            '6' => (16, "sixteen"),
                            '5' => (15, "fifteen"),
                            '4' => (14, "fourteen"),
                            '3' => (13, "thirteen"),
                            '2' => (12, "twelve"),
                            '1' => (11, "eleven"),
                            _ => (10, "ten")
                        },
                        _ => lastTwoDigits[1] switch
                        {
                            '9' => (9, "nine"),
                            '8' => (8, "eight"),
                            '7' => (7, "seven"),
                            '6' => (6, "six"),
                            '5' => (5, "five"),
                            '4' => (4, "four"),
                            '3' => (3, "three"),
                            '2' => (2, "two"),
                            '1' => (1, "one"),
                            _ => lastTwoDigits[0] switch
                            {
                                '9' => (90, "ninety"),
                                '8' => (80, "eighty"),
                                '7' => (70, "seventy"),
                                '6' => (60, "sixty"),
                                '5' => (50, "fifty"),
                                '4' => (40, "forty"),
                                '3' => (30, "thirty"),
                                '2' => (20, "twenty"),
                            }
                        },
                    };
                    parts.Add(asText);
                    remaining -= amount;
                }
                else
                {
                    var hundreds = input / 100;
                    if (hundreds > 0 && hundreds < 10)
                    {
                        parts.Add($"{StringGeneratorInternal(hundreds)} hundred{(parts.Any() ? " and" : string.Empty)}");
                        remaining -= hundreds * 100;
                    }
                    else if (hundreds < 10000)
                    {

                        var thousands = (int)Math.Floor((double)hundreds / 10);
                        var leftOver = input - (thousands * 1000);
                        var thousandsString = $"{StringGeneratorInternal(thousands)} thousand";

                        if (leftOver == 0)
                        {
                            return thousandsString;
                        }
                        else if (leftOver < 100)
                        {
                            return $"{thousandsString} and {StringGeneratorInternal(leftOver)}";
                        }
                        else
                        {
                            return $"{thousandsString} {StringGeneratorInternal(leftOver)}";
                        }
                    }
                }
            }

            return string.Join(" ", Enumerable.Reverse(parts));
        }
    }
}
