using ScientificWork.UseCases.Users.AuthenticateUser;

namespace ScientificWork.UseCases.Users.OnBoarding.CreateStudent;

public record CreateStudentCommandResult(Guid UserId, TokenModel token);
