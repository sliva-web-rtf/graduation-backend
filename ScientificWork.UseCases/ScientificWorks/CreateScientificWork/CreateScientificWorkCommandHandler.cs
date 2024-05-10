using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Domain.Professors;
using ScientificWork.Domain.ScientificWorks.Enums;
using ScientificWork.Domain.Students;
using ScientificWork.Infrastructure.Abstractions.Interfaces;

namespace ScientificWork.UseCases.ScientificWorks.CreateScientificWork;

public class CreateScientificWorkCommandHandler : IRequestHandler<CreateScientificWorkCommand>
{
    private readonly IAppDbContext dbContext;
    private readonly ILoggedUserAccessor userAccessor;
    private readonly UserManager<Student> studentManager;
    private readonly UserManager<Professor> professorManager;

    /// <summary>
    /// Constructor.
    /// </summary>
    public CreateScientificWorkCommandHandler(IAppDbContext dbContext, UserManager<Professor> professorManager,
        UserManager<Student> studentManager, ILoggedUserAccessor userAccessor)
    {
        this.dbContext = dbContext;
        this.professorManager = professorManager;
        this.studentManager = studentManager;
        this.userAccessor = userAccessor;
    }

    /// <inheritdoc />
    public async Task Handle(CreateScientificWorkCommand request, CancellationToken cancellationToken)
    {
        if (dbContext.ScientificWorks.Any(x => x.Name == request.Name && x.WorkStatus != WorkStatus.NotConfirmed))
        {
            throw new Exception("Такое иследование уже существует");
        }

        var student = await studentManager.FindByIdAsync(userAccessor.GetCurrentUserId().ToString());
        var scientificWork = new Domain.ScientificWorks.ScientificWork();

        // тут я проверяю к какой роли пренадлежит пользователь.
        if (student == null)
        {
            var professor = await professorManager.FindByIdAsync(userAccessor.GetCurrentUserId().ToString());
            scientificWork.CreateForProfessor(request.Name, request.Description, request.Result, request.Limit, professor!.Id, professor);
        }
        else
        {
            if (request.IsEducator)
            {
                var professor = await professorManager.FindByIdAsync(userAccessor.GetCurrentUserId().ToString());
                scientificWork.CreateForStudentWithProfessor(request.Name, request.Description, request.Result,
                    request.Limit, student, professor!.Id, professor);
            }
            else
            {
                scientificWork.CreateForStudent(request.Name, request.Description, request.Result, request.Limit, student);
            }
        }

        await AddScientificAreaSubsectionsAsync(scientificWork, request.ScientificAreaSubsections, cancellationToken);
        await AddScientificInterestsAsync(scientificWork, request.ScientificInterests, cancellationToken);

        await dbContext.ScientificWorks.AddAsync(scientificWork, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task AddScientificAreaSubsectionsAsync(Domain.ScientificWorks.ScientificWork scientificWork, IList<string> scientificAreaSubsections,
        CancellationToken cancellationToken)
    {
        var selectedSubsections = await dbContext.ScientificAreaSubsections
            .Where(x => scientificAreaSubsections.Contains(x.Name))
            .ToArrayAsync(cancellationToken);

        scientificWork.AddScientificAreaSubsections(selectedSubsections);
    }

    private async Task AddScientificInterestsAsync(Domain.ScientificWorks.ScientificWork scientificWork, IList<string> scientificInterests,
        CancellationToken cancellationToken)
    {
        var selectedInterests = await dbContext.ScientificInterests
            .Where(x => scientificInterests.Contains(x.Name))
            .ToArrayAsync(cancellationToken);

        scientificWork.AddScientificInterest(selectedInterests);
    }
}
