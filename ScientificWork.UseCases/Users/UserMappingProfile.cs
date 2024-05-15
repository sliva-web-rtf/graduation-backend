using AutoMapper;
using ScientificWork.Domain.Professors;
using ScientificWork.Domain.Students;
using ScientificWork.Domain.Users;
using ScientificWork.UseCases.Users.Common.Dtos;
using ScientificWork.UseCases.Users.GetProfessorOnBoardingInfo;
using ScientificWork.UseCases.Users.GetStudentOnBoardingInfo;
using ScientificWork.UseCases.Users.GetUserById;

namespace ScientificWork.UseCases.Users;

/// <summary>
/// User mapping profile.
/// </summary>
public class UserMappingProfile : Profile
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public UserMappingProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<User, UserDetailsDto>();
        
        CreateMap<Student, GetStudentOnBoardingInfoCommandResult>()
            .ForMember(x => x.ScientificArea, opt => opt.Ignore())
            .ForMember(x => x.ScientificInterests, opt => opt.MapFrom(x => x.ScientificInterests.Select(s => s.Name)))
            .ForMember(x => x.Status, opt => opt.MapFrom(student => student.SearchStatus!.Status))
            .ForMember(x => x.CommandSearching, opt => opt.MapFrom(student => student.SearchStatus!.CommandSearching))
            .ForMember(x => x.ProfessorSearching, opt => opt.MapFrom(student => student.SearchStatus!.ProfessorSearching));
        
        CreateMap<Professor, GetProfessorOnBoardingInfoCommandResult>()
            .ForMember(x => x.ScientificArea, opt => opt.Ignore())
            .ForMember(x => x.SearchStatus, opt => opt.MapFrom(student => student.SearchStatus!.Status))
            .ForMember(x => x.Limit, opt => opt.MapFrom(student => student.SearchStatus!.Limit))
            .ForMember(x => x.ScientificInterests, opt => opt.MapFrom(x => x.ScientificInterests.Select(s => s.Name)));
    }
}
