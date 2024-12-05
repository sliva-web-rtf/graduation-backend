using ScientificWork.Infrastructure.Tools.Domain.Exceptions;

namespace ScientificWork.Infrastructure.DataAccess.Extensions;

public static class StringExtensions
{
    public static void ThrowIfNull(this string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new DomainException("Value was null");
        }
    }
}
