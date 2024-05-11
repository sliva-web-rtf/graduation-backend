using MediatR;

namespace ScientificWork.UseCases.Users.GetAvatarImage;

public record GetAvatarImageCommand : IRequest<GetAvatarImageCommandResult>;
