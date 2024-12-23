namespace ScientificWork.Infrastructure.Tools.Domain.Exceptions;

[Serializable]
public class UnauthorizedException : DomainException
{
    private const string DefaultErrorMessage = "Unauthorized access.";

    /// <summary>
    /// Initializes a new instance of the
    /// class with a default error message.
    /// </summary>
    public UnauthorizedException() : base(DefaultErrorMessage)
    {
    }

    /// <summary>
    /// Initializes a new instance of the
    /// class with a specified error code.
    /// </summary>
    public UnauthorizedException(int code) : base(DefaultErrorMessage, code)
    {
    }

    /// <inheritdoc/>
    public UnauthorizedException(string message) : base(message)
    {
    }

    /// <inheritdoc/>
    public UnauthorizedException(string message, int code) : base(message, code)
    {
    }

    /// <inheritdoc/>
    public UnauthorizedException(string message, string code) : base(message, code)
    {
    }

    /// <inheritdoc/>
    public UnauthorizedException(string message, Exception innerException) :
        base(message, innerException)
    {
    }

    /// <inheritdoc/>
    public UnauthorizedException(string message, Exception innerException, int code) :
        base(message, innerException, code)
    {
    }

    /// <inheritdoc/>
    public UnauthorizedException(string message, Exception innerException, string code) :
        base(message, innerException, code)
    {
    }
}
