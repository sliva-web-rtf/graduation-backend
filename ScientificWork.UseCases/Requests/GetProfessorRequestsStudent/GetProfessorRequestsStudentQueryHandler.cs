using MediatR;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Common.Pagination;
using ScientificWork.Domain.Requests.Enums;
using ScientificWork.Infrastructure.Abstractions.Interfaces;
using ScientificWork.UseCases.Requests.Common.Dtos;

namespace ScientificWork.UseCases.Requests.GetProfessorRequestsStudent;

public class GetProfessorRequestsStudentQueryHandler : IRequestHandler<GetProfessorRequestsStudentQuery, GetProfessorRequestsStudentResult>
{
    private readonly IAppDbContext dbContext;
    private readonly ILoggedUserAccessor userAccessor;

    public GetProfessorRequestsStudentQueryHandler(IAppDbContext dbContext, ILoggedUserAccessor userAccessor)
    {
        this.dbContext = dbContext;
        this.userAccessor = userAccessor;
    }

    public async Task<GetProfessorRequestsStudentResult> Handle(GetProfessorRequestsStudentQuery request, CancellationToken cancellationToken)
    {
        var studentId = userAccessor.GetCurrentUserId();

        var requests = dbContext.StudentRequestProfessors
            .ToList()
            .Where(x => x.StudentId == studentId)
            .Where(x => x.IsActive)
            .Where(x => x.RequestEnum == RequestEnum.FromProfessor)
            .Select(x =>
                new RequestDto()
                {
                    Id = x.Id, ScientificWorkId = x.ScientificWorkId, UserFrom = x.ProfessorId, Message = x.Message
                });

        var res = PagedListFactory.FromSource(requests,
            page: request.Page, pageSize: request.PageSize);

        return new GetProfessorRequestsStudentResult() { Requests = res, Page = request.Page, Length = requests.Count() };
    }
}
