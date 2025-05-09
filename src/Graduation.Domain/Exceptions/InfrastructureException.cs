namespace Graduation.Domain.Exceptions;

[Serializable]
public class InfrastructureException : Exception
{
    private const string DefaultErrorMessage = "A server error has occurred. Please try again later.";
    
    /// <summary>
    /// Optional description code for this exception.
    /// </summary>
    public string Code { get; protected set; } = string.Empty;

    /// <summary>
    /// Initializes a new instance of the class
    /// </summary>
    public InfrastructureException() : base(DefaultErrorMessage)
    {
    }

    /// <summary>
    /// Initializes a new instance of the
    /// class with a specified error code.
    /// </summary>
    /// <param name="code">Optional description code for this exception.</param>
    public InfrastructureException(int code) : base(DefaultErrorMessage)
    {
        this.Code = code.ToString();
    }

    /// <inheritdoc/>
    public InfrastructureException(string message) : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the
    /// class with a specified error message and code.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="code">Optional description code for this exception.</param>
    public InfrastructureException(string message, int code) : base(message)
    {
        this.Code = code.ToString();
    }

    /// <summary>
    /// Initializes a new instance of the
    /// class with a specified error message and code.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="code">Optional description code for this exception.</param>
    public InfrastructureException(string message, string code) : base(message)
    {
        this.Code = code;
    }

    /// <inheritdoc/>
    public InfrastructureException(string message, Exception innerException) :
        base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the
    /// class with a specified error message, code and exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a
    /// null reference if no inner exception is specified.</param>
    /// <param name="code">Optional description code for this exception.</param>
    public InfrastructureException(string message, Exception innerException, int code) :
        base(message, innerException)
    {
        this.Code = code.ToString();
    }

    /// <summary>
    /// Initializes a new instance of the
    /// class with a specified error message, code and exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a
    /// null reference if no inner exception is specified.</param>
    /// <param name="code">Optional description code for this exception.</param>
    public InfrastructureException(string message, Exception innerException, string code) :
        base(message, innerException)
    {
        this.Code = code;
    }
}
