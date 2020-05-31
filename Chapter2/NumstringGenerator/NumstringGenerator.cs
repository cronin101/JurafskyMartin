using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter2
{
    public class NumstringGenerator
    {
        public static string Generate(int input)
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
                        parts.Add($"{Generate(hundreds)} hundred{(parts.Any() ? " and" : string.Empty)}");
                        remaining -= hundreds * 100;
                    }
                    else if (hundreds < 10000)
                    {

                        var thousands = (int)Math.Floor((double)hundreds / 10);
                        var leftOver = input - (thousands * 1000);
                        var thousandsString = $"{Generate(thousands)} thousand";

                        if (leftOver == 0)
                        {
                            return thousandsString;
                        }
                        else if (leftOver < 100)
                        {
                            return $"{thousandsString} and {Generate(leftOver)}";
                        }
                        else
                        {
                            return $"{thousandsString} {Generate(leftOver)}";
                        }
                    }
                }
            }

            return string.Join(" ", Enumerable.Reverse(parts));
        }
    }
}
