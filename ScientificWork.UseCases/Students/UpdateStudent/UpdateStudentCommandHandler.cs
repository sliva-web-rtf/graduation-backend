using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Domain.ScientificAreas;
using ScientificWork.Domain.Students;
using ScientificWork.Domain.Users;
using ScientificWork.Infrastructure.Abstractions.Interfaces;
using ScientificWork.UseCases.Students.Common.Exceptions;

namespace ScientificWork.UseCases.Students.UpdateStudent;

public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand>
{
    private readonly IMapper mapper;
    private readonly IAppDbContext dbContext;
    private readonly UserManager<Student> userManager;

    /// <summary>
    /// Constructor.
    /// </summary>
    public UpdateStudentCommandHandler(IMapper mapper, IAppDbContext dbContext, UserManager<Student> userManager)
    {
        this.mapper = mapper;
        this.dbContext = dbContext;
        this.userManager = userManager;
    }

    /// <inheritdoc />
    public async Task Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await GetStudentByIdAsync(request.Id, cancellationToken);

        mapper.Map(request, student);

        if (request.ScientificAreaSubsections != null)
        {
            await UpdateScientificAreaSubsectionsAsync(student, request.ScientificAreaSubsections, cancellationToken);
        }

        if (request.ScientificInterests != null)
        {
            await UpdateScientificInterestsAsync(student, request.ScientificInterests, cancellationToken);
        }

        await userManager.UpdateAsync(student);

        if (request.Email != null)
        {
            await userManager.SetEmailAsync(student, request.Email);
        }
        if (!string.IsNullOrEmpty(request.CurrentPassword) && !string.IsNullOrEmpty(request.NewPassword))
        {
            await userManager.ChangePasswordAsync(student, request.CurrentPassword, request.NewPassword);
        }
    }

    private async Task<Student> GetStudentByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var student = await userManager.Users
            .Where(x => x.Id == id)
            .Include(x => x.ScientificAreaSubsections)
            .Include(x => x.ScientificInterests)
            .FirstOrDefaultAsync(cancellationToken);

        if (student == null)
        {
            throw new UserNotFoundException($"Пьзователь с ID {id} не найден");
        }

        return student;
    }

    private async Task UpdateScientificAreaSubsectionsAsync(Student student, IList<string> scientificAreaSubsections,
        CancellationToken cancellationToken)
    {
        var selectedSubsections = await dbContext.ScientificAreaSubsections
            .Where(x => scientificAreaSubsections.Contains(x.Name))
            .ToArrayAsync(cancellationToken);

        student.UpdateScientificAreaSubsections(selectedSubsections);
    }

    private async Task UpdateScientificInterestsAsync(Student student, IList<string> scientificInterests,
        CancellationToken cancellationToken)
    {
        var selectedInterests = await dbContext.ScientificInterests
            .Where(x => scientificInterests.Contains(x.Name))
            .ToArrayAsync(cancellationToken);

        student.UpdateScientificInterest(selectedInterests);
    }
}
