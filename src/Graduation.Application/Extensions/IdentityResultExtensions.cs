using Graduation.Domain.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace Graduation.Application.Extensions;

public static class IdentityResultExtensions
{
    public static void ThrowOnError(this IdentityResult? result)
    {
        if (result is not null && !result.Succeeded)
        {
            var errors = result.Errors
                .Select(e => $"{e.Code}: {e.Description}");
            
            var message = string.Join(Environment.NewLine, errors);
            
            throw new DomainException(message);
        }
    }
}