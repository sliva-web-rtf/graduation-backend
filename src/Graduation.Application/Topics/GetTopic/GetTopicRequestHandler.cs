using Graduation.Application.Interfaces.DataAccess;
using Graduation.Domain;
using Graduation.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Topics.GetTopic;

public class GetTopicRequestHandler : IRequestHandler<GetTopicRequest, GetTopicRequestResult>
{
    private readonly IAppDbContext dbContext;

    public GetTopicRequestHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<GetTopicRequestResult> Handle(GetTopicRequest request, CancellationToken cancellationToken)
    {
        var topicInfo = await dbContext.Topics
            .Where(t => t.Id == request.TopicId)
            .Include(t => t.RequestedRoles)
            .Include(t => t.AcademicPrograms)
            .Include(t => t.Owner)
            .Select(t => new
            {
                Topic = t,
                StudentInfo = t.UserRoleTopics
                    .Where(urt => urt.QualificationWorkRole!.Role != WellKnownRoles.Supervisor)
                    .Select(urt => new { Student = urt.User!, Role = urt.QualificationWorkRole!.Role })
                    .FirstOrDefault(),
                Supervisor = t.UserRoleTopics
                    .Where(urt => urt.QualificationWorkRole!.Role == WellKnownRoles.Supervisor)
                    .Select(urt => urt.User)
                    .FirstOrDefault()
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (topicInfo == null)
        {
            throw new DomainException("Topic not found");
        }

        var requestedRoleName = topicInfo.Topic.RequestedRoles.FirstOrDefault()?.Role;
        var academicPrograms = topicInfo.Topic.AcademicPrograms.Select(p => p.Name).ToList();
        var topicOwner = new GetTopicRequestTopicOwner(topicInfo.Topic.OwnerId, topicInfo.Topic.Owner!.FullName);
        
        GetTopicRequestTopicStudent? topicStudent = null;
        if (topicInfo.StudentInfo != null)
            topicStudent = new GetTopicRequestTopicStudent(
                topicInfo.StudentInfo.Student.Id,
                topicInfo.StudentInfo.Student.FullName,
                topicInfo.StudentInfo.Role);
        
        GetTopicRequestTopicSupervisor? topicSupervisor = null;
        if (topicInfo.Supervisor != null)
            topicSupervisor = new GetTopicRequestTopicSupervisor(
                topicInfo.Supervisor.Id,
                topicInfo.Supervisor.FullName);

        var result = new GetTopicRequestResult(
            topicInfo.Topic.Name,
            topicInfo.Topic.Description,
            topicInfo.Topic.Result,
            requestedRoleName,
            topicOwner,
            topicStudent,
            topicSupervisor,
            academicPrograms);

        return result;
    }
}