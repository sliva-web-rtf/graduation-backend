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
        var scientificWork =
            await dbContext.ScientificWorks.FirstOrDefaultAsync(x => x.Id == request.ScientificWorkId,
                cancellationToken);

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
            scientificWork.Id, request.RequestEnum);

        await dbContext.StudentRequestStudents.AddAsync(r, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
