namespace ScientificWork.UseCases.Students.Common.Exceptions;

class UserNotFoundException : Exception
{
    public UserNotFoundException(string message) : base(message)
    {
    }
}
