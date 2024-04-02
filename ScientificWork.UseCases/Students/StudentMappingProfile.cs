using AutoMapper;
using ScientificWork.Domain.Students;
using ScientificWork.UseCases.Students.Common.Dtos;
using ScientificWork.UseCases.Students.CreateStudent;
using ScientificWork.UseCases.Students.GetStudentProfileById;
using ScientificWork.UseCases.Users.UpdateUserPassword;

namespace ScientificWork.UseCases.Students;

/// <summary>
/// Student mapper.
/// </summary>
public class StudentMappingProfile : Profile
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public StudentMappingProfile()
    {
        CreateMap<CreateStudentCommand, Student>()
            .ForMember(x => x.ScientificInterests, opt => opt.Ignore())
            .ForMember(x => x.ScientificAreaSubsections, opt => opt.Ignore())
            .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.Email));

        CreateMap<UpdateUserPasswordCommand, Student>()
            .ForMember(x => x.ScientificInterests, opt => opt.Ignore())
            .ForMember(x => x.ScientificAreaSubsections, opt => opt.Ignore())
            .ForMember(x => x.Email, opt => opt.Ignore())
            .ForAllMembers(opts =>
            {
                opts.AllowNull();
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });

        CreateMap<Student, GetStudentProfileByIdResult>()
            .ForMember(x => x.ScientificArea, opt => opt.Ignore())
            .ForMember(x => x.ScientificInterests, opt => opt.MapFrom(x => x.ScientificInterests.Select(s => s.Name)))
            .ForMember(x => x.Status, opt => opt.MapFrom(student => student.SearchStatus!.Status))
            .ForMember(x => x.CommandSearching, opt => opt.MapFrom(student => student.SearchStatus!.CommandSearching))
            .ForMember(x => x.ProfessorSearching, opt => opt.MapFrom(student => student.SearchStatus!.ProfessorSearching));

        CreateMap<Student, StudentDto>()
            .ForMember(x => x.ScientificInterests, opt => opt.MapFrom(x => x.ScientificInterests.Select(s => s.Name)))
            .ForMember(x => x.Status, opt => opt.MapFrom(student => student.SearchStatus!.Status))
            .ForMember(x => x.CommandSearching, opt => opt.MapFrom(student => student.SearchStatus!.CommandSearching))
            .ForMember(x => x.ProfessorSearching, opt => opt.MapFrom(student => student.SearchStatus!.ProfessorSearching));
    }
}
