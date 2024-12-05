using AutoMapper;
using ScientificWork.Domain.Professors;
using ScientificWork.UseCases.Professors.Common.Dtos;
using ScientificWork.UseCases.Professors.GetProfessors;
using ScientificWork.UseCases.Professors.GetProfessorScientificPortfolio;
using ScientificWork.UseCases.Professors.GetProfileById;

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
            .ForMember(x => x.ScientificInterests, opt => opt.MapFrom(x => x.ScientificInterests.Select(s => s.Name)));

        CreateMap<Professor, GetProfileByIdResult>()
            .ForMember(x => x.ScientificArea, opt => opt.Ignore())
            .ForMember(x => x.ScientificInterests, opt => opt.MapFrom(x => x.ScientificInterests.Select(s => s.Name)))
            .ForMember(x => x.SearchStatus, opt => opt.MapFrom(student => student.SearchStatus!.Status))
            .ForMember(x => x.Limit, opt => opt.MapFrom(student => student.SearchStatus!.Limit));

        CreateMap<Professor, GetProfessorScientificPortfolioQueryResult>()
            .ForMember(x => x.ScientificArea, opt => opt.Ignore())
            .ForMember(x => x.ScientificInterests, opt => opt.MapFrom(x => x.ScientificInterests.Select(s => s.Name)));
    }
}