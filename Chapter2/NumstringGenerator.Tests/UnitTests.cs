using System;
using Xunit;

namespace Chapter2.Tests
{
    public class UnitTest1
    {
        [Fact]
        void TestStringGenerator()
        {
            Assert.Equal("one", NumstringGenerator.Generate(1));
            Assert.Equal("two", NumstringGenerator.Generate(2));
            Assert.Equal("nine", NumstringGenerator.Generate(9));
            Assert.Equal("ten", NumstringGenerator.Generate(10));
            Assert.Equal("eleven", NumstringGenerator.Generate(11));
            Assert.Equal("nineteen", NumstringGenerator.Generate(19));
            Assert.Equal("twenty", NumstringGenerator.Generate(20));
            Assert.Equal("twenty one", NumstringGenerator.Generate(21));
            Assert.Equal("fifty six", NumstringGenerator.Generate(56));
            Assert.Equal("one hundred", NumstringGenerator.Generate(100));
            Assert.Equal("one hundred and one", NumstringGenerator.Generate(101));
            Assert.Equal("six hundred and fifty nine", NumstringGenerator.Generate(659));
            Assert.Equal("one thousand", NumstringGenerator.Generate(1000));
            Assert.Equal("one thousand and one", NumstringGenerator.Generate(1001));
            Assert.Equal("one thousand and fifty one", NumstringGenerator.Generate(1051));
            Assert.Equal("one thousand one hundred and fifty one", NumstringGenerator.Generate(1151));
            Assert.Equal("nine thousand five hundred and eighty four", NumstringGenerator.Generate(9584));
            Assert.Equal("ten thousand", NumstringGenerator.Generate(10000));
            Assert.Equal("one hundred thousand", NumstringGenerator.Generate(100000));
            Assert.Equal("nine hundred and ninety nine thousand nine hundred and ninety nine", NumstringGenerator.Generate(999999));
        }
    }
}
