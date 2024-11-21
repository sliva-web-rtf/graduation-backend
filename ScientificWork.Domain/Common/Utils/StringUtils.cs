namespace ScientificWork.Domain.Common.Utils;

public static class StringUtils
{
    /// <summary>Joins the objects ignore empty ones.</summary>
    /// <param name="separator">The string to use as a separator.</param>
    /// <param name="values">The values.</param>
    /// <returns>Concatenated string.</returns>
    public static string JoinIgnoreEmpty(string separator, params string[] values)
    {
        ArgumentNullException.ThrowIfNull(separator);
        ArgumentNullException.ThrowIfNull(values);
        return string.Join(separator, values.Where(x => !string.IsNullOrWhiteSpace(x)));
    }
}