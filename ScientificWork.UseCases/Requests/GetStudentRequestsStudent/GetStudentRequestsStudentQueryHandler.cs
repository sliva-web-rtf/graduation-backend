using MediatR;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Common.Pagination;
using ScientificWork.Infrastructure.Abstractions.Interfaces;
using ScientificWork.UseCases.Requests.Common.Dtos;

namespace ScientificWork.UseCases.Requests.GetStudentRequestsStudent;

public class GetStudentRequestsStudentQueryHandler : IRequestHandler<GetStudentRequestsStudentQuery, GetStudentRequestsStudentResult>
{
    private readonly IAppDbContext dbContext;
    private readonly ILoggedUserAccessor userAccessor;

    public GetStudentRequestsStudentQueryHandler(IAppDbContext dbContext, ILoggedUserAccessor userAccessor)
    {
        this.dbContext = dbContext;
        this.userAccessor = userAccessor;
    }

    public async Task<GetStudentRequestsStudentResult> Handle(GetStudentRequestsStudentQuery request, CancellationToken cancellationToken)
    {
        var studentId = userAccessor.GetCurrentUserId();

        var requests = dbContext.StudentRequestStudents
            .ToList()
            .Where(x => x.StudentToId == studentId)
            .Where(x => x.IsActive)
            .Select(x =>
                new RequestDto()
                {
                    Id = x.Id, ScientificWorkId = x.ScientificWorkId, UserFrom = x.StudentFromId, Message = ""
                });

        var res = PagedListFactory.FromSource(requests,
            page: request.Page, pageSize: request.PageSize);

        return new GetStudentRequestsStudentResult() { Requests = res, Page = request.Page, Length = res.Count() };
    }
}
