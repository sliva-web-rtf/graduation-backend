using AutoMapper;
using ScientificWork.Domain.Professors;
using ScientificWork.UseCases.Professors.Common.Dtos;

namespace ScientificWork.UseCases.Professors;

/// <summary>
/// Professor mapping profile.
/// </summary>
public class ProfessorMappingProfile : Profile
{
    /// <summary>
    /// Ctor.
    /// </summary>
    public ProfessorMappingProfile()
    {
        CreateMap<Professor, ProfessorDto>()
            .ForMember(x => x.ScientificArea, opt => opt.Ignore())
            .ForMember(x => x.ScientificInterests, opt => opt.MapFrom(x => x.ScientificInterests.Select(s => s.Name)));
    }
}
