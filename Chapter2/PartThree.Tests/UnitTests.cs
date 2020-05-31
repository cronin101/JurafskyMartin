using System;
using System.Linq;
using Xunit;

namespace Chapter2.PartThree.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestCanHandleBaseDollars()
        {
            TestUtils.PerformTestCasesOnRegex(
                Solutions.One(),
                new[] { "one dollar", "two dollars", "nine dollars", "ten dollars" },
                new[] { "one dollars", "two dollar", "nine dollar", "ten dollar" });
        }
        [Fact]
        public void TestCanHandleTeenDollars()
        {
            TestUtils.PerformTestCasesOnRegex(
                Solutions.One(),
                new[] { "eleven dollars", "fifteen dollars" },
                new[] { "eleven dollar", "fifteen dollar" });
        }

        [Fact]
        public void TestUsingStringGenerator()
        {
            TestUtils.PerformTestCasesOnRegex(
                Solutions.One(),
                Enumerable.Range(1, 100000).Select(n => Solutions.DollarGenerator(n)).ToList(),
                new string[0]
            );
        }
    }
}
