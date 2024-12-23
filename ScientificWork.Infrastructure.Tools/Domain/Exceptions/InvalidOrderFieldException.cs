namespace ScientificWork.Infrastructure.Tools.Domain.Exceptions;

[Serializable]
public class InvalidOrderFieldException: Exception
{
    private const string DefaultMessage = "Ordering by field \"{0}\" is not supported. Available fields are: {1}.";
    /// <summary>
    /// Available fields that can be used for ordering.
    /// </summary>
    public string[] AvailableFields { get; } = Array.Empty<string>();
    
    /// <summary>
    /// Initializes a new instance of the class
    /// with a specified error message by arguments.
    /// </summary>
    /// <param name="fieldName">Order field name.</param>
    /// <param name="availableFields">Available fields that can be used for ordering.</param>
    public InvalidOrderFieldException(string fieldName, string[] availableFields) :
        base(string.Format(DefaultMessage, fieldName, string.Join(", ", availableFields)))
    {
        AvailableFields = availableFields;
    }
}
