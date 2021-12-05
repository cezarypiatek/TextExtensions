using System.Diagnostics.CodeAnalysis;

namespace TextExtensions;

public static class TrimExtensions
{
    [return: NotNullIfNotNull("input")]
    public static string? TrimStart(this string? input, string? toRemove)
    {
        if (input == null)
        {
            return null;
        }

        if (toRemove == null)
        {
            return input;
        }

        return input.StartsWith(toRemove) ? input.Substring(toRemove.Length) : input;
    }

    [return: NotNullIfNotNull("input")]
    public static string? TrimEnd(this string? input, string? toRemove)
    {
        if (input == null)
        {
            return null;
        }

        if (toRemove == null)
        {
            return input;
        }

        return input.EndsWith(toRemove) ? input.Substring(0, input.Length - toRemove.Length) : input;
    }
}
