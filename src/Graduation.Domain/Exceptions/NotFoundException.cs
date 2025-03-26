namespace Graduation.Domain.Exceptions;

[Serializable]
public class NotFoundException : DomainException
{
    private const string DefaultErrorMessage = "The specified item not found.";

    /// <summary>
    /// Initializes a new instance of the
    /// class with a default error message.
    /// </summary>
    public NotFoundException() : base(DefaultErrorMessage)
    {
    }

    /// <summary>
    /// Initializes a new instance of the
    /// class with a specified error code.
    /// </summary>
    public NotFoundException(int code) : base(DefaultErrorMessage, code)
    {
    }

    /// <inheritdoc/>
    public NotFoundException(string message) : base(message)
    {
    }

    /// <inheritdoc/>
    public NotFoundException(string message, int code) : base(message, code)
    {
    }

    /// <inheritdoc/>
    public NotFoundException(string message, string code) : base(message, code)
    {
    }

    /// <inheritdoc/>
    public NotFoundException(string message, Exception innerException) :
        base(message, innerException)
    {
    }

    /// <inheritdoc/>
    public NotFoundException(string message, Exception innerException, int code) :
        base(message, innerException, code)
    {
    }

    /// <inheritdoc/>
    public NotFoundException(string message, Exception innerException, string code) :
        base(message, innerException, code)
    {
    }
}
