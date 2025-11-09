using System.Text.RegularExpressions;

namespace DeadTree.Domain.Constants;

public static partial class RegexPatterns
{
    [GeneratedRegex(@"^[a-zA-Z0-9]+$")]
    public static partial Regex Alphanumeric();
    
    [GeneratedRegex(@"^[\w\.-]+@[\w\.-]+\.\w+$")]
    public static partial Regex Email();

    [GeneratedRegex(@"^https?://[\w\.-]+(\.[a-zA-Z]{2,})(/.*)?$")]
    public static partial Regex Url();
}