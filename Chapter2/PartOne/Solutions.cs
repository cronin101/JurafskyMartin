using System.Text.RegularExpressions;

namespace Chapter2.PartOne
{
    public class Solutions
    {
        // The set of all alphanumeric strings
        public static Regex One()
        {
            return new Regex("^[a-zA-Z]+$");
        }

        // The set of all lowercase alphanumeric strings, ending with "b"
        public static Regex Two()
        {
            return new Regex("^[a-z]*b$");
        }

        // The set of all strings with only words repeating twice
        public static Regex Three()
        {
            return new Regex(@"^(\w+) \1$");
        }

        // The set of all strings from {a, b} where each a is sandwiched between b
        public static Regex Four()
        {
            return new Regex("^(b(b|ab)*)?$");
        }

        // The set of all strings that begin with an integer and end with a word
        public static Regex Five()
        {
            return new Regex("^[1-9][0-9]*.*[a-zA-Z]+$");
        }

        // All strings that contain both "grotto" and "raven", but not as parts of other words e.g. "grottos"
        public static Regex Six()
        {
            return new Regex(
                @"^(.+\b)*((grotto(\b.+)*\braven)|(raven(\b.+)*\bgrotto))(\b.+)*$");
        }

        // Place the first word of an English sentence into a register
        public static Regex Seven()
        {
            return new Regex("^(\\w+).*$");
        }
    }
}
