using System;
using System.Linq;
using Xunit;

namespace Chapter2.PartThree.Tests
{
    public class UnitTest1
    {
        [Fact]
        void TestStringGenerator()
        {
            Assert.Equal("one dollar", Solutions.StringGenerator(1));
            Assert.Equal("two dollars", Solutions.StringGenerator(2));
            Assert.Equal("nine dollars", Solutions.StringGenerator(9));
            Assert.Equal("ten dollars", Solutions.StringGenerator(10));
            Assert.Equal("eleven dollars", Solutions.StringGenerator(11));
            Assert.Equal("nineteen dollars", Solutions.StringGenerator(19));
            Assert.Equal("twenty dollars", Solutions.StringGenerator(20));
            Assert.Equal("twenty one dollars", Solutions.StringGenerator(21));
            Assert.Equal("fifty six dollars", Solutions.StringGenerator(56));
        }
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
                Enumerable.Range(1, 99).Select(n => Solutions.StringGenerator(n)).ToList(),
                new string[0]
            );
        }
    }
}
