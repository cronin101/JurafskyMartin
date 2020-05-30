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
            Assert.Equal("one hundred dollars", Solutions.StringGenerator(100));
            Assert.Equal("one hundred and one dollars", Solutions.StringGenerator(101));
            Assert.Equal("six hundred and fifty nine dollars", Solutions.StringGenerator(659));
            Assert.Equal("one thousand dollars", Solutions.StringGenerator(1000));
            Assert.Equal("one thousand and one dollars", Solutions.StringGenerator(1001));
            Assert.Equal("one thousand and fifty one dollars", Solutions.StringGenerator(1051));
            Assert.Equal("one thousand one hundred and fifty one dollars", Solutions.StringGenerator(1151));
            Assert.Equal("nine thousand five hundred and eighty four dollars", Solutions.StringGenerator(9584));
            Assert.Equal("ten thousand dollars", Solutions.StringGenerator(10000));
            Assert.Equal("one hundred thousand dollars", Solutions.StringGenerator(100000));
            Assert.Equal("nine hundred and ninety nine thousand nine hundred and ninety nine dollars", Solutions.StringGenerator(999999));
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
                Enumerable.Range(1, 100000).Select(n => Solutions.StringGenerator(n)).ToList(),
                new string[0]
            );
        }
    }
}
