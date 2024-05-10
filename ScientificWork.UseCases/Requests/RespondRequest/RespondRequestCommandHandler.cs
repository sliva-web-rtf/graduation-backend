using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Domain.Professors;
using ScientificWork.Domain.Requests;
using ScientificWork.Domain.Requests.Enums;
using ScientificWork.Domain.ScientificWorks.Enums;
using ScientificWork.Domain.Students;
using ScientificWork.Infrastructure.Abstractions.Interfaces;

namespace ScientificWork.UseCases.Requests.RespondRequest;

public class RespondRequestCommandHandler : IRequestHandler<RespondRequestCommand>
{
    private readonly IAppDbContext dbContext;
    private readonly UserManager<Student> studentManager;
    private readonly UserManager<Professor> professorManager;

    public RespondRequestCommandHandler(IAppDbContext dbContext, UserManager<Student> studentManager, UserManager<Professor> professorManager)
    {
        this.dbContext = dbContext;
        this.studentManager = studentManager;
        this.professorManager = professorManager;
    }

    public async Task Handle(RespondRequestCommand request, CancellationToken cancellationToken)
    {
        var srp = await dbContext.StudentRequestProfessors.FirstOrDefaultAsync(x => x.Id == request.RequestId,
            cancellationToken);
        if (srp == null)
        {
            var srs = await dbContext.StudentRequestStudents.FirstOrDefaultAsync(x => x.Id == request.RequestId,
                cancellationToken);
            if (srs == null)
            {
                throw new Exception();
            }

            srs.Respond();
            if (request.RespondEnum == RespondEnum.Agree)
            {
                var sw = await studentManager.Users
                    .Where(x => x.Id == srs.StudentFromId)
                    .Include(x => x.ScientificWorks)
                    .SelectMany(x => x.ScientificWorks)
                    .FirstOrDefaultAsync(x => x.Id == srs.ScientificWorkId, cancellationToken);

                var studentTo = await studentManager.FindByIdAsync(srs.StudentToId.ToString());
                if (sw != null && studentTo != null && !sw.Students.Contains(studentTo))
                {
                    sw.AddStudent(studentTo);
                }
                else
                {
                    throw new Exception();
                }
            }
        }
        else
        {
            srp.Respond();
            if (request.RespondEnum == RespondEnum.Agree)
            {
                if (srp.RequestEnum == RequestEnum.FromProfessor)
                {
                    var sw = await studentManager.Users
                        .Where(x => x.Id == srp.StudentId)
                        .Include(x => x.ScientificWorks)
                        .SelectMany(x => x.ScientificWorks)
                        .FirstOrDefaultAsync(x => x.Id == srp.ScientificWorkId, cancellationToken);

                    var professor = await professorManager.FindByIdAsync(srp.ProfessorId.ToString());
                    var checkStudent = studentManager.Users
                        .Where(x => x.Id == srp.StudentId)
                        .Include(x => x.ScientificWorks)
                        .SelectMany(x => x.ScientificWorks)
                        .Any(x => x.WorkStatus == WorkStatus.Confirmed);

                    if (professor != null && sw != null && !checkStudent && sw.Professor == null)
                    {
                        sw.AddProfessor(professor, professor.Id);
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                else
                {
                    var sw = await professorManager.Users
                        .Where(x => x.Id == srp.ProfessorId)
                        .Include(x => x.ScientificWorks)
                        .SelectMany(x => x.ScientificWorks)
                        .FirstOrDefaultAsync(x => x.Id == srp.ScientificWorkId, cancellationToken);

                    var student = await studentManager.FindByIdAsync(srp.StudentId.ToString());

                    if (student != null && sw != null && !sw.Students.Contains(student))
                    {
                        sw.AddStudent(student);
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
        }
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
