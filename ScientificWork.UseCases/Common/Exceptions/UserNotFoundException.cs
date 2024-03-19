namespace ScientificWork.UseCases.Common.Exceptions;

class UserNotFoundException : Exception
{
    public UserNotFoundException(string message) : base(message)
    {
    }
}
