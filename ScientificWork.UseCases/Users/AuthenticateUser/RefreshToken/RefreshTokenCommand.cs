using System.ComponentModel.DataAnnotations;
using MediatR;
using ScientificWork.Infrastructure.Abstractions.DTOs;

namespace ScientificWork.UseCases.Users.AuthenticateUser.RefreshToken;

/// <summary>
/// Refresh token command.
/// </summary>
public record RefreshTokenCommand : IRequest<TokenModel>
{
    /// <summary>
    /// User token.
    /// </summary>
    [Required]
    required public string RefreshToken { get; init; }
}
