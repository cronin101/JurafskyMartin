using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xunit;

namespace Chapter2.PartOne.Tests
{
    public class UnitTests
    {

        [Fact]
        public void TestOne()
        {
            TestUtils.PerformTestCasesOnRegex(
                Solutions.One(),
                shouldMatch: new[] { "Alphabeticstring" },
                shouldntMatch: new[] { "non-alphabetic string" });
        }

        [Fact]
        public void TestTwo()
        {
            TestUtils.PerformTestCasesOnRegex(
                Solutions.Two(),
                shouldMatch: new[]
                {
                    "lowercasestringendinginb",
                    "b"
                },
                shouldntMatch: new[]
                {
                    "lowercasestringwithouttheending"
                });
        }

        [Fact]
        public void TestThree()
        {
            TestUtils.PerformTestCasesOnRegex(
                Solutions.Three(),
                shouldMatch: new[]
                {
                    "Humbert Humbert",
                    "toot toot"
                },
                shouldntMatch: new[]
                {
                    "iced coffee",
                    "wow wow wow"
                });
        }

        [Fact]
        public void TestFour()
        {
            TestUtils.PerformTestCasesOnRegex(
                Solutions.Four(),
                shouldMatch: new[]
                {
                    "b",
                    "bab",
                    "bbabbab"
                },
                shouldntMatch: new[]
                {
                    "ba",
                    "a",
                    "bbabbaab"
                });
        }

        [Fact]
        public void TestFive()
        {
            TestUtils.PerformTestCasesOnRegex(
                Solutions.Five(),
                shouldMatch: new[]
                {
                    "6 balloons",
                    "552 is a number",
                    "13 year malt"
                },
                shouldntMatch: new[]
                {
                    "01 has a leading zero",
                    "1 is bigger than 2",
                    "the number is 8"
                });
        }

        [Fact]
        public void TestSix()
        {
            TestUtils.PerformTestCasesOnRegex(
                Solutions.Six(),
                shouldMatch: new[]
                {
                    "the raven is in the grotto",
                    "raven live within the grotto over there",
                    "the grotto contains a raven",
                    "This sentence could say grotto then raven, or raven then grotto. Either will pass"
                },
                shouldntMatch: new[]
                {
                    "ravens live in grottos",
                    "ravengrotto",
                    "raven",
                    "grotto"
                });
        }

        [Fact]
        public void TestSeven()
        {
            var regex = Solutions.Seven();
            Assert.Equal("Dave", regex.Match("Dave was angry").Groups[1].Value);
            Assert.Equal("Surprisingly", regex.Match("Surprisingly, punctuation is not a problem").Groups[1].Value);
        }
    }
}
