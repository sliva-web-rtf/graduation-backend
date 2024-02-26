using AutoMapper;
using ScientificWork.Domain.ScientificAreas;
using ScientificWork.UseCases.Common.Dtos;

namespace ScientificWork.UseCases.ScientificAreas;

public class ScientificAreaProfile : Profile
{
    public ScientificAreaProfile()
    {
        CreateMap<ScientificArea, ScientificAreasDto>()
            .ForMember(x => x.Section, opt => opt.MapFrom(x => x.Name))
            .ForMember(x => x.Subsections, opt => opt.MapFrom(x => x.ScientificAreaSubsections.Select(s => s.Name)));
    }
}
