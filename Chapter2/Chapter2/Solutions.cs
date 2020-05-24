using System.Text.RegularExpressions;

namespace Chapter2
{
    public class Solutions
    {
        // The set of all alphanumeric strings
        public static Regex OnePointOne()
        {
            return new Regex("^[a-zA-Z]+$", RegexOptions.Compiled);
        }

        // The set of all lowercase alphanumeric strings, ending with "b"
        public static Regex OnePointTwo()
        {
            return new Regex("^[a-z]*b$", RegexOptions.Compiled);
        }

        // The set of all strings with only words repeating twice
        public static Regex OnePointThree()
        {
            return new Regex("^(\\w+) \\1$", RegexOptions.Compiled);
        }

        // The set of all strings from {a, b} where each a is sandwiched between b
        public static Regex OnePointFour()
        {
            return new Regex("^(b(b|ab)*)?$", RegexOptions.Compiled);
        }

        // The set of all strings that begin with an integer and end with a word
        public static Regex OnePointFive()
        {
            return new Regex("^[1-9][0-9]*.*[a-zA-Z]+$", RegexOptions.Compiled);
        }

        // All strings that contain both "grotto" and "raven", but not as parts of other words e.g. "grottos"
        public static Regex OnePointSix()
        {
            return new Regex(
                "^(.+\\b)*((grotto(\\b.+)*\\braven)|(raven(\\b.+)*\\bgrotto))(\\b.+)*$",
                RegexOptions.Compiled);
        }

        // Place the first word of an English sentence into a register
        public static Regex OnePointSeven()
        {
            return new Regex("^(\\w+).*$", RegexOptions.Compiled);
        }
    }
}
