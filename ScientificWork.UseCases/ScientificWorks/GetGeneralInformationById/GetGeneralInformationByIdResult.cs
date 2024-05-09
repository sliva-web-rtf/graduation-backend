using ScientificWork.Domain.Professors;
using ScientificWork.Domain.ScientificWorks.Enums;

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

    public Professor? Professor { get; init; }

    public Guid? ImageId { get; init; }

    required public IList<string> ScientificInterests { get; init; }
}
