using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Domain.Professors;

namespace ScientificWork.UseCases.Professors.GetProfessorProfileInfo;

public class GetProfessorProfileInfoQueryHandler
    : IRequestHandler<GetProfessorProfileInfoQuery, GetProfessorProfileInfoQueryResult>
{
    private readonly IMapper mapper;
    private readonly UserManager<Professor> professorManager;

    public GetProfessorProfileInfoQueryHandler(IMapper mapper, UserManager<Professor> professorManager)
    {
        this.mapper = mapper;
        this.professorManager = professorManager;
    }

    public async Task<GetProfessorProfileInfoQueryResult> Handle(
        GetProfessorProfileInfoQuery request,
        CancellationToken cancellationToken)
    {
        var userId = request.Id;
        var student = await GetProfessorByIdAsync(userId, cancellationToken);

        var result = mapper.Map<GetProfessorProfileInfoQueryResult>(student);

        return result;
    }

    private async Task<Professor> GetProfessorByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var professor = await professorManager.Users
            .Where(x => x.Id == id)
            .FirstAsync(cancellationToken);

        if (!await professorManager.IsInRoleAsync(professor, nameof(Professor).ToLower()))
        {
            throw new Exception();
        }

        return professor;
    }
}