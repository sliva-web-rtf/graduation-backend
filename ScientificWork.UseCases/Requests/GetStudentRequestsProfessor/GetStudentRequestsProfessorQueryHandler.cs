using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Common.Pagination;
using ScientificWork.Domain.Requests.Enums;
using ScientificWork.Infrastructure.Abstractions.Interfaces;
using ScientificWork.UseCases.Requests.Common.Dtos;

namespace ScientificWork.UseCases.Requests.GetStudentRequestsProfessor;

public class GetStudentRequestsProfessorQueryHandler : IRequestHandler<GetStudentRequestsProfessorQuery, GetStudentRequestsProfessorResult>
{
    private readonly IAppDbContext dbContext;
    private readonly ILoggedUserAccessor userAccessor;

    public GetStudentRequestsProfessorQueryHandler(IAppDbContext dbContext, ILoggedUserAccessor userAccessor)
    {
        this.dbContext = dbContext;
        this.userAccessor = userAccessor;
    }

    public async Task<GetStudentRequestsProfessorResult> Handle(GetStudentRequestsProfessorQuery request, CancellationToken cancellationToken)
    {
        var professorId = userAccessor.GetCurrentUserId();

        var requests = dbContext.StudentRequestProfessors
            .ToList()
            .Where(x => x.RequestEnum == RequestEnum.FromStudent)
            .Where(x => x.IsActive)
            .Where(x => x.ProfessorId == professorId)
            .Select(x => new RequestDto() { Id = x.Id, ScientificWorkId = x.ScientificWorkId, Message = "" });

        var res = PagedListFactory.FromSource(requests,
            page: request.Page, pageSize: request.PageSize);

        return new GetStudentRequestsProfessorResult() { Requests = res, Page = request.Page, Length = res.Count() };
    }
}
