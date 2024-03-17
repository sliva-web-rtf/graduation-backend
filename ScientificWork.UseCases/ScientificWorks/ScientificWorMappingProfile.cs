using AutoMapper;
using ScientificWork.UseCases.ScientificWorks.Common.Dtos;
using ScientificWork.UseCases.ScientificWorks.CreateScientificWork;
using ScientificWork.UseCases.ScientificWorks.GetGeneralInformationById;

namespace ScientificWork.UseCases.ScientificWorks;

public class ScientificWorMappingProfile : Profile
{
    public ScientificWorMappingProfile()
    {
        CreateMap<Domain.ScientificWorks.ScientificWork, ScientificWorkDto>()
            .ForMember(x => x.ScientificInterests, opt => opt.MapFrom(x => x.ScientificInterests.Select(s => s.Name)));
        CreateMap<Domain.ScientificWorks.ScientificWork, GetGeneralInformationByIdResult>()
            .ForMember(x => x.ScientificInterests, opt => opt.MapFrom(x => x.ScientificInterests.Select(s => s.Name)));
        CreateMap<CreateScientificWorkCommand, Domain.ScientificWorks.ScientificWork>()
            .ForMember(x => x.ScientificInterests, opt => opt.Ignore())
            .ForMember(x => x.ScientificAreaSubsections, opt => opt.Ignore());
    }
}
