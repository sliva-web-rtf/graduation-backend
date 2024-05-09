using MediatR;

namespace ScientificWork.UseCases.Professors.GetProfessorDegrees;

public class GetProfessorDegreesQueryHandler : IRequestHandler<GetProfessorDegreesQuery, IList<string>>
{
    public async Task<IList<string>> Handle(GetProfessorDegreesQuery request, CancellationToken cancellationToken)
    {
        var degrees = new List<string>()
        {
            "Ассистент",
            "Декан",
            "Директор института",
            "Доцент",
            "Заведующий кафедрой",
            "Преподаватель",
            "Профессор",
            "Старший преподаватель",
            "Ведущий научный сотрудник",
            "Главный научный сотрудник",
            "Младший научный сотрудник",
            "Научный сотрудник",
            "Старший научный сотрудник",
            "Заместитель начальника центра",
            "Начальник военной кафедры",
            "Начальник учебной части-зам. начальника кафедры",
            "Начальник учебной части-зам. начальника факультета",
            "Начальник учебной части-зам. начальника центра",
            "Начальник факультета ВО"
        };
        var result = degrees
            .Where(x => x.ToLower().StartsWith(request.Search.ToLower()))
            .ToList();

        return result;
    }
}
