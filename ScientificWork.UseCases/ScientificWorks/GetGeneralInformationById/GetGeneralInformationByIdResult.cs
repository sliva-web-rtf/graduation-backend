using ScientificWork.Domain.Professors;
using ScientificWork.Domain.ScientificWorks.Enums;
using ScientificWork.UseCases.Professors.Common.Dtos;
using ScientificWork.UseCases.Students.Common.Dtos;

namespace ScientificWork.UseCases.ScientificWorks.GetGeneralInformationById;

public class GetGeneralInformationByIdResult
{
    public Guid Id { get; init; }

    required public string Name { get; init; }

    required public string Description { get; init; }

    required public int Limit { get; init; }

    public string Result { get; init; }

    required public int Fullness { get; init; }

    required public WorkStatus WorkStatus { get; init; }

    public ProfessorDto? Professor { get; set; }

    public bool IsFavorite { get; set; }

    public bool CanJoin { get; set; }

    required public IList<string> ScientificInterests { get; init; }

    public List<StudentDto> StudentDtos { get; set; }
}
