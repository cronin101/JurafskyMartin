namespace Chapter2
{
    public class SharedRegex
    {
        public const string OnePattern = @"one";
        public const string PluralDigitsPattern = @"(two|three|four|five|six|seven|eight|nine|ten)";
        public const string TeenPattern = @"(eleven|twelve|thirteen|fourteen|fifteen|sixteen|seventeen|eighteen|nineteen)";
        public const string TensBelowSixtyPattern = @"(twenty|thirty|forty|fifty)";
        public const string TensAboveFiftyPattern = @"(sixty|seventy|eighty|ninety)";
        public static readonly string TensPattern = $"({TensBelowSixtyPattern}|{TensAboveFiftyPattern})";
        public static readonly string AllDigitsPattern = $"({OnePattern}|{PluralDigitsPattern})";
        public static readonly string TensBelowSixtyWithDigitsPattern = $"({TensBelowSixtyPattern}( {AllDigitsPattern})?)";
        public static readonly string TensWithDigitsPattern = $"({TensPattern}( {AllDigitsPattern})?)";
        public static readonly string BelowTwentyExcludingOnePattern = $"({PluralDigitsPattern}|{TeenPattern})";
        public static readonly string BelowSixtyExcludingOnePattern = $"({BelowTwentyExcludingOnePattern}|{TensBelowSixtyWithDigitsPattern})";
        public static readonly string BelowHundredExcludingOnePattern = $"({BelowTwentyExcludingOnePattern}|{TensWithDigitsPattern})";
        public static readonly string BelowHundredPattern = $"({BelowHundredExcludingOnePattern}|{OnePattern})";
        public static readonly string BelowThousandExcludingOnePattern = $"(({AllDigitsPattern} hundred( and {BelowHundredPattern})?)|{BelowHundredExcludingOnePattern})";
        public static readonly string BelowThousandPattern = $"({BelowThousandExcludingOnePattern}|{OnePattern})";
        public static readonly string BelowMillionExcludingOnePattern = $"(({BelowThousandPattern} thousand(( and {BelowHundredPattern})|( {BelowThousandExcludingOnePattern}))?)|{BelowThousandExcludingOnePattern})";
        public static readonly string BelowMillionPattern = $"({BelowMillionExcludingOnePattern}|{OnePattern})";
    }
}
