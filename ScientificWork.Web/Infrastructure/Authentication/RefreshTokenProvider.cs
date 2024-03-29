using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ScientificWork.Domain.Users;
using ScientificWork.Infrastructure.Common.Encoding;
using ScientificWork.Infrastructure.DataAccess;
using ScientificWork.UseCases.Users.AuthenticateUser;

namespace ScientificWork.Web.Infrastructure.Authentication;

/// <inheritdoc />
public class RefreshTokenProvider<TUser> : DataProtectorTokenProvider<TUser> where TUser : class
{
    private readonly AppDbContext dbContext;
    private readonly IHttpContextAccessor contextAccessor;

    /// <inheritdoc />
    public RefreshTokenProvider(
        IDataProtectionProvider dataProtectionProvider,
        IOptions<RefreshTokenProviderOptions> options,
        ILogger<DataProtectorTokenProvider<TUser>> logger,
        AppDbContext dbContext, IHttpContextAccessor contextAccessor)
        : base(dataProtectionProvider, options, logger)
    {
        this.dbContext = dbContext;
        this.contextAccessor = contextAccessor;
    }

    /// <inheritdoc />
    public override async Task<string> GenerateAsync(string? purpose, UserManager<TUser> manager, TUser user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        var userAgent = contextAccessor.HttpContext!.Request.Headers.UserAgent.FirstOrDefault() ?? "";

        var ms = new MemoryStream();
        var userId = await manager.GetUserIdAsync(user);
        await using var writer = ms.CreateWriter();

        writer.Write(DateTimeOffset.UtcNow);
        writer.Write(userId);
        writer.Write(purpose ?? "");
        var parsedUserId = Guid.Parse(userId);
        var stamp = NewSecurityToken();
        var token = await dbContext.UserSecurityTokens
            .FirstOrDefaultAsync(t => t.Description == userAgent && t.UserId == parsedUserId);
        if (token is null)
        {
            var newToken = UserToken.Create(parsedUserId, stamp, userAgent);
            await dbContext.UserSecurityTokens.AddAsync(newToken);
        }
        else
        {
            token.SetToken(stamp);
        }

        await dbContext.SaveChangesAsync();

        writer.Write(stamp);

        var protectedBytes = Protector.Protect(ms.ToArray());
        return Convert.ToBase64String(protectedBytes);
    }

    /// <inheritdoc />
    public override async Task<bool> ValidateAsync(string purpose, string token, UserManager<TUser> manager, TUser user)
    {
        try
        {
            var unprotectedData = Protector.Unprotect(Convert.FromBase64String(token));
            var ms = new MemoryStream(unprotectedData);
            using var reader = ms.CreateReader();

            var creationTime = reader.ReadDateTimeOffset();
            var expirationTime = creationTime + Options.TokenLifespan;
            if (expirationTime < DateTimeOffset.UtcNow)
            {
                return false;
            }

            var userId = reader.ReadString();
            var actualUserId = await manager.GetUserIdAsync(user);
            if (userId != actualUserId)
            {
                return false;
            }

            var purp = reader.ReadString();
            if (!string.Equals(purp, purpose))
            {
                return false;
            }

            var stamp = reader.ReadString();
            if (reader.PeekChar() != -1)
            {
                return false;
            }

            var dbToken = await dbContext.UserSecurityTokens.FirstOrDefaultAsync(t => t.Token == stamp);

            var isEqualsSecurityStamp = dbToken is not null;

            return isEqualsSecurityStamp;
        }
        catch
        {
            // ignored
        }

        return false;
    }

    private static string NewSecurityToken()
    {
        var bytes = new byte[20];
        RandomNumberGenerator.Fill(bytes);
        return Base32.ToBase32(bytes);
    }
}

/// <inheritdoc />
public class RefreshTokenProviderOptions : DataProtectionTokenProviderOptions
{
    /// <inheritdoc />
    public RefreshTokenProviderOptions()
    {
        Name = AuthenticationConstants.AppLoginProvider;
        TokenLifespan = AuthenticationConstants.RefreshTokenExpire;
    }
}

internal static class StreamExtensions
{
    private static readonly Encoding DefaultEncoding = new UTF8Encoding(false, true);

    public static BinaryReader CreateReader(this Stream stream)
    {
        return new BinaryReader(stream, DefaultEncoding, true);
    }

    public static BinaryWriter CreateWriter(this Stream stream)
    {
        return new BinaryWriter(stream, DefaultEncoding, true);
    }

    public static DateTimeOffset ReadDateTimeOffset(this BinaryReader reader)
    {
        return new DateTimeOffset(reader.ReadInt64(), TimeSpan.Zero);
    }

    public static void Write(this BinaryWriter writer, DateTimeOffset value)
    {
        writer.Write(value.UtcTicks);
    }
}
