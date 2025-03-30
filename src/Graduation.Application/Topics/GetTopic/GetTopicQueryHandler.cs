using Graduation.Application.Interfaces.DataAccess;
using Graduation.Domain;
using Graduation.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Topics.GetTopic;

public class GetTopicQueryHandler : IRequestHandler<GetTopicQuery, GetTopicQueryResult>
{
    private readonly IAppDbContext dbContext;

    public GetTopicQueryHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<GetTopicQueryResult> Handle(GetTopicQuery query, CancellationToken cancellationToken)
    {
        var topicInfo = await dbContext.Topics
            .Where(t => t.Id == query.TopicId)
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
        var topicOwner = new GetTopicQueryTopicOwner(topicInfo.Topic.OwnerId, topicInfo.Topic.Owner!.FullName);
        
        GetTopicQueryTopicStudent? topicStudent = null;
        if (topicInfo.StudentInfo != null)
            topicStudent = new GetTopicQueryTopicStudent(
                topicInfo.StudentInfo.Student.Id,
                topicInfo.StudentInfo.Student.FullName,
                topicInfo.StudentInfo.Role);
        
        GetTopicQueryTopicSupervisor? topicSupervisor = null;
        if (topicInfo.Supervisor != null)
            topicSupervisor = new GetTopicQueryTopicSupervisor(
                topicInfo.Supervisor.Id,
                topicInfo.Supervisor.FullName);

        var result = new GetTopicQueryResult(
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