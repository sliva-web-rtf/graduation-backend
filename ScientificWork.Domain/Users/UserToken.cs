using ScientificWork.Domain.Common;

namespace ScientificWork.Domain.Users;

public sealed class UserToken : Entity
{
    public User? User { get; }

    public Guid UserId { get; private set; }

    public string Token { get; private set; }

    public string Description { get; private set; }

    public DateTime IssuedAt { get; private set; }

    private UserToken(Guid userId, string token, string description, DateTime issuedAt)
    {
        UserId = userId;
        Token = token;
        Description = description;
        IssuedAt = issuedAt;
    }

    // ReSharper disable once UnusedMember.Local
    private UserToken()
    {
    }

    public static UserToken Create(Guid userId, string token, string description)
    {
        return new UserToken(userId, token, description, DateTime.UtcNow);
    }

    public void SetToken(string token)
    {
        Token = token;
        IssuedAt = DateTime.UtcNow;
    }

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Token;
    }
}
