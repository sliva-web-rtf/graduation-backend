namespace ScientificWork.UseCases.Common.Exceptions;

[Serializable]
public class ValidationException : DomainException
{
    /// <summary>
    /// Errors dictionary. Key is a member name, value is enumerable of error
    /// messages. Empty member name relates to a summary error message.
    /// For example:
    /// - Name: Field is required.
    /// - ConfirmPassword: Field is required, Should equal to Password field.
    /// </summary>
    public IDictionary<string, ICollection<string>> Errors { get; } = new Dictionary<string, ICollection<string>>();
    
    private const string DefaultErrorMessage = "Validation errors.";
    
    /// <inheritdoc />
    public override string Message => this.Errors.ContainsKey("") ? this.Errors[""].First() : base.Message;

    /// <summary>
    /// Initializes a new instance of the
    /// class with a default error message.
    /// </summary>
    public ValidationException() : base(DefaultErrorMessage)
    {
    }

    /// <summary>
    /// Initializes a new instance of the
    /// class with a specified error code.
    /// </summary>
    public ValidationException(int code) : base(DefaultErrorMessage, code)
    {
    }

    /// <inheritdoc/>
    public ValidationException(string message) : base(message)
    {
    }

    /// <inheritdoc/>
    public ValidationException(string message, int code) : base(message, code)
    {
    }

    /// <inheritdoc/>
    public ValidationException(string message, string code) : base(message, code)
    {
    }

    /// <inheritdoc/>
    public ValidationException(string message, Exception innerException) :
        base(message, innerException)
    {
    }

    /// <inheritdoc/>
    public ValidationException(string message, Exception innerException, int code) :
        base(message, innerException, code)
    {
    }

    /// <inheritdoc/>
    public ValidationException(string message, Exception innerException, string code) :
        base(message, innerException, code)
    {
    }
    
    /// <summary>
    /// Constructor with dictionary contains member field as key and error message as value.
    /// </summary>
    /// <param name="errors">Member error dictionary.</param>
    public ValidationException(IDictionary<string, string> errors) :
        base(DefaultErrorMessage)
    {
        if (errors == null)
        {
            throw new ArgumentNullException(nameof(errors));
        }

        foreach (var error in errors)
        {
            this.Errors[error.Key] = new[] { error.Value };
        }
    }
    
    /// <summary>
    /// Constructor with dictionary contains member field as key and error messages as value.
    /// </summary>
    /// <param name="errors">Member errors dictionary.</param>
    public ValidationException(IDictionary<string, ICollection<string>> errors) :
        base(DefaultErrorMessage)
    {
        if (errors == null)
        {
            throw new ArgumentNullException(nameof(errors));
        }

        this.Errors = errors;
    }
    
    /// <summary>
    /// Constructor with dictionary contains member field as key and error messages as value.
    /// </summary>
    /// <param name="errors">Member errors dictionary.</param>
    public ValidationException(IDictionary<string, IEnumerable<string>> errors) :
        base(DefaultErrorMessage)
    {
        if (errors == null)
        {
            throw new ArgumentNullException(nameof(errors));
        }

        this.Errors = errors.ToDictionary(kv => kv.Key, kv => (ICollection<string>)kv.Value);
    }
    
}