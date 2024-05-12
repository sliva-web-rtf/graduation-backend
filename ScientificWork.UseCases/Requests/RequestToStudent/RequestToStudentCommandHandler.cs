using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Domain.Requests;
using ScientificWork.Domain.Students;
using ScientificWork.Infrastructure.Abstractions.Interfaces;

namespace ScientificWork.UseCases.Requests.RequestToStudent;

public class RequestToStudentCommandHandler : IRequestHandler<RequestToStudentCommand>
{
    private readonly UserManager<Student> studentManager;
    private readonly IAppDbContext dbContext;

    public RequestToStudentCommandHandler(UserManager<Student> studentManager, IAppDbContext dbContext)
    {
        this.studentManager = studentManager;
        this.dbContext = dbContext;
    }

    public async Task Handle(RequestToStudentCommand request, CancellationToken cancellationToken)
    {
        var studentFrom = await studentManager.FindByIdAsync(request.StudentFromId.ToString());
        var studentTo = await studentManager.FindByIdAsync(request.StudentToId.ToString());
        var scientificWork = await dbContext.ScientificWorks
            .Where(x => x.Id == request.ScientificWorkId)
            .Include(x => x.Students)
            .FirstOrDefaultAsync(cancellationToken);

        if (studentFrom == null)
        {
            throw new Exception($"Не существует студента который отпаравил запрос с id: {request.StudentFromId}");
        }
        if (studentTo == null)
        {
            throw new Exception($"Не существует студента которому отправляют запрос с id: {request.StudentToId}");
        }
        if (scientificWork == null)
        {
            throw new Exception($"Не существует иследования с id: {request.ScientificWorkId}");
        }

        var r = new StudentRequestStudent(studentTo, studentTo.Id, studentFrom, studentFrom.Id, scientificWork,
            scientificWork.Id, request.RequestEnum, GetMessage(scientificWork, studentTo));

        await dbContext.StudentRequestStudents.AddAsync(r, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    private string GetMessage(Domain.ScientificWorks.ScientificWork scientificWork, Student studentTo)
    {
        var messages = new List<KeyValuePair<bool, string>>
        {
            new(
                scientificWork.Limit > 1 && !scientificWork.Students.Contains(studentTo),
                "Вас приглашают в команду"
            ),
            new(
                scientificWork.Limit == 1 && !scientificWork.Students.Contains(studentTo),
                "Вам предложили тему"
            ),
            new(
                scientificWork.Students.Contains(studentTo),
                "Над Вашим исследованием хотят поработать"
            )
        };
        return messages.FirstOrDefault(x => x.Key).Value;
    }
}
