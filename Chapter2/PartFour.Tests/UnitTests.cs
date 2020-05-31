using Xunit;
using System.Linq;

namespace Chapter2.PartFour.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            TestUtils.PerformTestCasesOnRegex(
                Solution.One(),
                Enumerable.Range(2, 58).Select(s => $"{NumstringGenerator.Generate(s)} seconds").Append("one second").ToList(),
                new[] { "one seconds", "three second" });
        }
    }
}
