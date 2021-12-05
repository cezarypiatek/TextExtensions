using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextExtensions
{
    public static class CaseExtensions
    {
        private static readonly Regex WordSplitPattern = new(@"[^a-zA-Z0-9]", RegexOptions.Compiled);

        [return: NotNullIfNotNull("input")]
        public static string? ToPascalCase(this string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            var parts = WordSplitPattern.Split(input);
            if (parts.Length == 1)
            {
                return parts[0].FirstLetterUp();
            }
            return parts.Aggregate("", (left, right) => left + FirstLetterUp(right.Trim().ToLowerInvariant()));
        }

        [return: NotNullIfNotNull("input")]
        public static string? ToCamelCase(this string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            return input!.ToPascalCase().FirstLetterDown();
        }

        [return: NotNullIfNotNull("input")]
        public static string? ToSnakeCase(this string? input) => ToSeparatorCase(input, "_");

        [return: NotNullIfNotNull("input")]
        public static string? ToKebabCase(this string? input) => ToSeparatorCase(input, "-");

        private static readonly Regex InWorkBreakPattern = new("(?<!(^|[A-Z]))(?=[A-Z])|(?<!^)(?=[A-Z][a-z])", RegexOptions.Compiled);

        private static string? ToSeparatorCase(string? input, string separator)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            var parts = WordSplitPattern.Split(input).Select(word => InWorkBreakPattern.Split(word)).SelectMany(x => x).Where(x=> !string.IsNullOrWhiteSpace(x));
            return string.Join(separator, parts.Select(x => x.Trim().ToLowerInvariant()));
        }

        private static string FirstLetterDown(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            return char.ToLowerInvariant(input[0]) + input.Substring(1);
        }

        private static string FirstLetterUp(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            return char.ToUpperInvariant(input[0]) + input.Substring(1);
        }
    }
}
