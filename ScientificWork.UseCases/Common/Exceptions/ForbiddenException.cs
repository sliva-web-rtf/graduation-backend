namespace ScientificWork.UseCases.Common.Exceptions;

[Serializable]
public class ForbiddenException : DomainException
{
    private const string DefaultErrorMessage = "Action is forbidden.";

    /// <summary>
    /// Initializes a new instance of the
    /// class with a default error message.
    /// </summary>
    public ForbiddenException() : base(DefaultErrorMessage)
    {
    }

    /// <summary>
    /// Initializes a new instance of the
    /// class with a specified error code.
    /// </summary>
    public ForbiddenException(int code) : base(DefaultErrorMessage, code)
    {
    }

    /// <inheritdoc/>
    public ForbiddenException(string message) : base(message)
    {
    }

    /// <inheritdoc/>
    public ForbiddenException(string message, int code) : base(message, code)
    {
    }

    /// <inheritdoc/>
    public ForbiddenException(string message, string code) : base(message, code)
    {
    }

    /// <inheritdoc/>
    public ForbiddenException(string message, Exception innerException) :
        base(message, innerException)
    {
    }

    /// <inheritdoc/>
    public ForbiddenException(string message, Exception innerException, int code) :
        base(message, innerException, code)
    {
    }

    /// <inheritdoc/>
    public ForbiddenException(string message, Exception innerException, string code) :
        base(message, innerException, code)
    {
    }
}