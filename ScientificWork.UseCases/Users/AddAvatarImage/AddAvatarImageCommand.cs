using MediatR;

namespace ScientificWork.UseCases.Users.AddAvatarImage;

public class AddAvatarImageCommand : IRequest
{
    public Stream Data { get; init; }

    public string FileName { get; init; }

    public string ContentType { get; init; }
}
