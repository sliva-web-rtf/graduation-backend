using ClosedXML.Excel;
using MediatR;
using ScientificWork.Domain.Notifications.Enums;
using ScientificWork.Domain.Students.Enums;
using ScientificWork.Infrastructure.Abstractions.Interfaces;
using ScientificWork.UseCases.Notifications.SendNotification;
using ScientificWork.UseCases.Professors.CreateProfessor;
using ScientificWork.UseCases.Users.UpdateProfessorScientificPortfolio;
using ScientificWork.UseCases.Users.UpdateProfessorStatus;
using ScientificWork.UseCases.Users.UpdateProfileInfo;

namespace ScientificWork.UseCases.Professors.UplaodProfessors;

public class UploadProfessorsCommandHandler : IRequestHandler<UploadProfessorsCommand>
{
    private readonly ISender sender;
    private readonly ILoggedUserAccessor userAccessor;

    public UploadProfessorsCommandHandler(ISender sender, ILoggedUserAccessor userAccessor)
    {
        this.sender = sender;
        this.userAccessor = userAccessor;
    }

    public async Task Handle(UploadProfessorsCommand request, CancellationToken cancellationToken)
    {
        using var stream = new MemoryStream();
        await request.File.CopyToAsync(stream, cancellationToken);

        using var workbook = new XLWorkbook(stream);
        var ws = workbook.Worksheet(1);
        var countRow = ws.Rows().Count();
        for (var i = 1; i <= countRow; i++)
        {
            var name = ws.Cell($"A{i}").GetValue<string>();
            var password = ws.Cell($"B{i}").GetValue<string>();
            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(password))
            {
                var result = await sender.Send(new CreateProfessorCommand(name, password), cancellationToken);
                if (result.UserId == default)
                {
                    continue;
                }
                userAccessor.UserId = result.UserId;
            }
            else
            {
                continue;
            }

            var firstName = ws.Cell($"C{i}").GetValue<string>();
            var lastName = ws.Cell($"D{i}").GetValue<string>();
            var patronymic = ws.Cell($"E{i}").GetValue<string>();
            var contacts = ws.Cell($"F{i}").GetValue<string>();
            var phone = ws.Cell($"G{i}").GetValue<string>();
            if (!string.IsNullOrWhiteSpace(firstName)
                && !string.IsNullOrWhiteSpace(lastName)
                && !string.IsNullOrWhiteSpace(name)
                && !string.IsNullOrWhiteSpace(patronymic))
            {
                await sender.Send(
                    new UpdateProfileInfoCommand
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Contacts = contacts,
                        Email = name,
                        Patronymic = patronymic,
                        Phone = phone
                    }, cancellationToken);
            }
            else
            {
                continue;
            }

            var about = ws.Cell($"H{i}").GetValue<string>();
            var address = ws.Cell($"I{i}").GetValue<string>();
            var degree = ws.Cell($"J{i}").GetValue<string>();
            var limit = ws.Cell($"K{i}").GetValue<string>();
            var post = ws.Cell($"L{i}").GetValue<string>();
            var workExperienceYears = ws.Cell($"M{i}").GetValue<string>();
            var scopusURI = ws.Cell($"N{i}").GetValue<string>();
            var URPURI = ws.Cell($"O{i}").GetValue<string>();
            var RISCURI = ws.Cell($"P{i}").GetValue<string>();
            var scientificInterests = ws.Cell($"Q{i}").GetValue<string>();
            var scientificAreaSubsections = ws.Cell($"R{i}").GetValue<string>();
            if (!string.IsNullOrWhiteSpace(degree)
                && !string.IsNullOrWhiteSpace(limit)
                && !string.IsNullOrWhiteSpace(workExperienceYears)
                && !string.IsNullOrWhiteSpace(scientificInterests)
                && !string.IsNullOrWhiteSpace(scientificAreaSubsections))
            {
                await sender.Send(
                    new UpdateProfessorScientificPortfolioCommand
                    {
                        About = about,
                        Address = address,
                        Degree = degree,
                        Post = post,
                        WorkExperienceYears = int.Parse(workExperienceYears),
                        ScopusUri = scopusURI,
                        URPUri = URPURI,
                        RISCUri = RISCURI,
                        ScientificInterests = scientificInterests.Split(','),
                        ScientificAreaSubsections = scientificAreaSubsections.Split(',')
                    }, cancellationToken);
            }
            else
            {
                continue;
            }
            
            await sender.Send(new UpdateProfessorStatusCommand { Status = SearchStatus.DoNotSearch }, cancellationToken);
            await sender.Send(
                new SendNotificationCommand(userAccessor.UserId.Value, "Welcome to our platform!",
                    NotificationType.Info), cancellationToken);
        }
    }
}
