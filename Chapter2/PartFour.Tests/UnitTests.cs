using Xunit;
using System.Linq;

namespace Chapter2.PartFour.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestSecondsUsingNumstringGenerator()
        {
            TestUtils.PerformTestCasesOnRegex(
                Solution.One(),
                Enumerable.Range(2, 58).Select(s => $"{NumstringGenerator.Generate(s)} seconds").Append("one second").ToList(),
                new[] { "", "one seconds", "three second" });
        }

        [Fact]
        public void TestSeconds()
        {
            TestUtils.PerformTestCasesOnRegex(
                Solution.One(),
                new[] { "one second", "fifty nine seconds" },
                new[] { "", "one seconds", "fifty nine second" }
            );
        }

        [Fact]
        public void TestMinutes()
        {
            TestUtils.PerformTestCasesOnRegex(
                Solution.One(),
                new[] { "one minute", "fifty nine minutes" },
                new[] { "", "one minutes", "fifty nine minute" }
            );
        }

        [Fact]
        public void TestMinuteAndSeconds()
        {
            TestUtils.PerformTestCasesOnRegex(
                Solution.One(),
                new[] { "one minute and one second", "one minute and two seconds", "two minutes and one second", "two minutes and two seconds" },
                new[] { "one minutes and one seconds", "one minutes and two second", "two minute and one seconds", "two minute and two seconds" }
            );
        }

        [Fact]
        public void TestHours()
        {
            TestUtils.PerformTestCasesOnRegex(
                Solution.One(),
                new[] { "one hour", "five hours" },
                new[] { "", "one hours", "five hour" }
            );
        }

        [Fact]
        public void TestHoursWithMinutesAndSeconds()
        {
            TestUtils.PerformTestCasesOnRegex(
                Solution.One(),
                new[]
                {
                    "one hour and one second",
                    "one hour and two seconds",
                    "two hours and one second",
                    "two hours and two seconds",
                    "one hour and one minute",
                    "one hour and two minutes",
                    "two hours and one minute",
                    "two hours and two minutes",
                    "one hour, one minute and one second",
                    "one hour, one minute and two seconds",
                    "one hour, two minutes and one second",
                    "one hour, two minutes and two seconds",
                    "two hours, one minute and one second",
                    "two hours, two minutes and two seconds"
                },
                new[] {
                    "",
                    "one hours and one seconds",
                    "one hours and two second",
                    "two hour and one seconds",
                    "two hour and two second",
                    "one hours and one minutes",
                    "one hours and two minute",
                    "two hour and one minutes",
                    "two hour and two minute",
                    "one hours, one minutes and one seconds",
                    "one hours, one minutes and two second",
                    "one hours, two minute and one seconds",
                    "one hours, two minute and two second",
                    "two hour, one minutes and one seconds",
                    "two hour, two minute and two second"
                }
            );
        }
    }
}
