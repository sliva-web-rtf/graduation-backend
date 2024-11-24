using MediatR;
using Microsoft.EntityFrameworkCore;
using ScientificWork.UseCases.Common.Exceptions;
using ScientificWork.Domain.Professors;
using ScientificWork.Domain.Students;
using ScientificWork.Infrastructure.Abstractions.Interfaces;

namespace ScientificWork.UseCases.ScientificWorks.LeaveScientificWork;

public class LeaveScientificWorkCommandHandler : IRequestHandler<LeaveScientificWorkCommand>
{
    private ILoggedUserAccessor userAccessor;
    private IAppDbContext dbContext;

    public LeaveScientificWorkCommandHandler(ILoggedUserAccessor userAccessor, IAppDbContext dbContext)
    {
        this.userAccessor = userAccessor;
        this.dbContext = dbContext;
    }

    public async Task Handle(LeaveScientificWorkCommand request, CancellationToken cancellationToken)
    {
        var userId = userAccessor.GetCurrentUserId();
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId, cancellationToken: cancellationToken);
        var scientificWork = await dbContext.ScientificWorks
            .Include(sw => sw.Students)
            .Include(sw => sw.Professor)
            .FirstOrDefaultAsync(u => u.Id == request.ScientificWorkId, cancellationToken: cancellationToken);
        if (user is null || scientificWork is null)
        {
            throw new DomainException("Что-то пошло не так. Попробуйте обновить страницу.");
        }

        if (user is Professor professor)
        {
            if (scientificWork.ProfessorId is null || scientificWork.ProfessorId != professor.Id)
                throw new DomainException("Вы не являетесь профессором этой научной работы");

            var studentProfessorRequests = await dbContext.StudentRequestProfessors
                .Where(r => r.ScientificWorkId == request.ScientificWorkId && r.ProfessorId == professor.Id)
                .ToListAsync(cancellationToken: cancellationToken);
            studentProfessorRequests.ForEach(r => r.Respond());

            scientificWork.RemoveProfessor();
        }
        else if (user is Student student)
        {
            if (scientificWork.Students.All(s => s.Id != student.Id))
                throw new DomainException("Вы не состоите в этой научной работе");

            var studentProfessorRequests = await dbContext.StudentRequestProfessors
                .Where(r => r.ScientificWorkId == request.ScientificWorkId && r.StudentId == student.Id)
                .ToListAsync(cancellationToken: cancellationToken);
            studentProfessorRequests.ForEach(r => r.Respond());

            var studentStudentRequests = await dbContext.StudentRequestProfessors
                .Where(r => r.ScientificWorkId == request.ScientificWorkId && r.StudentId == student.Id)
                .ToListAsync(cancellationToken: cancellationToken);
            studentStudentRequests.ForEach(r => r.Respond());

            scientificWork.RemoveStudent(student.Id);
        }
        else
        {
            throw new DomainException("Вы не являетесь студентом или профессором");
        }

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}