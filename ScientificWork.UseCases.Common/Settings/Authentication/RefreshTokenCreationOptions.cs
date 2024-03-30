namespace ScientificWork.UseCases.Common.Settings.Authentication;

public class RefreshTokenCreationOptions
{
    public TimeSpan TokenLifespan { get; set; } = AuthenticationConstants.RefreshTokenRememberMeExpire;

    public string? SessionId { get; set; }
}
