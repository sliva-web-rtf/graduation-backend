using ScientificWork.UseCases.Users.AuthenticateUser;

namespace ScientificWork.UseCases.Users.CreateStudent;

public record CreateStudentCommandResult(Guid UserId, TokenModel token);
