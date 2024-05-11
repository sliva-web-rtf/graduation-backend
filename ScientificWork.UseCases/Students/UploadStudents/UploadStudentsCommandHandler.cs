using ClosedXML.Excel;
using MediatR;
using ScientificWork.Domain.Notifications.Enums;
using ScientificWork.Domain.Students.Enums;
using ScientificWork.Infrastructure.Abstractions.Interfaces;
using ScientificWork.UseCases.Notifications.SendNotification;
using ScientificWork.UseCases.Students.CompleteOnBoarding;
using ScientificWork.UseCases.Students.CreateStudent;
using ScientificWork.UseCases.Users.UpdateProfileInfo;
using ScientificWork.UseCases.Users.UpdateStudentScientificPortfolio;
using ScientificWork.UseCases.Users.UpdateStudentStatusCommand;

namespace ScientificWork.UseCases.Students.UploadStudents;

public class UploadStudentsCommandHandler : IRequestHandler<UploadStudentsCommand>
{
    private readonly ISender sender;
    private readonly ILoggedUserAccessor userAccessor;

    public UploadStudentsCommandHandler(ISender sender, ILoggedUserAccessor userAccessor)
    {
        this.sender = sender;
        this.userAccessor = userAccessor;
    }

    public async Task Handle(UploadStudentsCommand request, CancellationToken cancellationToken)
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
                var result = await sender.Send(new CreateStudentCommand(name, password), cancellationToken);
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
            var degree = ws.Cell($"I{i}").GetValue<string>();
            var year = ws.Cell($"J{i}").GetValue<string>();
            var scientificInterests = ws.Cell($"K{i}").GetValue<string>();
            var scientificAreaSubsections = ws.Cell($"L{i}").GetValue<string>();
            if (!string.IsNullOrWhiteSpace(degree)
                && !string.IsNullOrWhiteSpace(year)
                && !string.IsNullOrWhiteSpace(scientificInterests)
                && !string.IsNullOrWhiteSpace(scientificAreaSubsections))
            {
                await sender.Send(
                    new UpdateStudentScientificPortfolioCommand
                    {
                        About = about,
                        Degree = degree,
                        Year = int.Parse(year),
                        ScientificInterests = scientificInterests.Split(','),
                        ScientificAreaSubsections = scientificAreaSubsections.Split(',')
                    }, cancellationToken);
            }
            else
            {
                continue;
            }

            await sender.Send(new UpdateStudentStatusCommand { Status = SearchStatus.DoNotSearch }, cancellationToken);
            await sender.Send(
                new SendNotificationCommand(userAccessor.UserId.Value, "Welcome to our platform!",
                    NotificationType.Info), cancellationToken);
        }
    }
}
