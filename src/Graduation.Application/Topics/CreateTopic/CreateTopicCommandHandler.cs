using MediatR;

namespace Graduation.Application.Topics.CreateTopic;

public class CreateTopicCommandHandler : IRequestHandler<CreateTopicCommand, CreateTopicCommandResult>
{
    public Task<CreateTopicCommandResult> Handle(CreateTopicCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}