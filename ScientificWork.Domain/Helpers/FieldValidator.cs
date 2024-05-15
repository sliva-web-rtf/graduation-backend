namespace ScientificWork.Domain.Helpers;

public static class FieldValidator
{
    public static bool ValidateNotNull(params string?[] values)
    {
        return !values.Any(v => string.IsNullOrEmpty(v));
    }
}
