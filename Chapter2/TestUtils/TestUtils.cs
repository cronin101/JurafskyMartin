using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xunit;

namespace Chapter2
{
    public class TestUtils
    {
        public static void TestRegex(Regex regex, string input, bool shouldMatch)
        {
            if (shouldMatch)
            {
                Assert.True(regex.Match(input).Success, input);
            }
            else
            {
                Assert.False(regex.Match(input).Success, input);
            }
        }

        public static void PerformTestCasesOnRegex(Regex regex, IList<string> shouldMatch, IList<string> shouldntMatch)
        {
            foreach (var testCase in shouldMatch)
            {
                TestRegex(regex, testCase, true);
            }

            foreach (var testCase in shouldntMatch)
            {
                TestRegex(regex, testCase, false);
            }
        }
    }
}
