using AutoMapper;
using ScientificWork.Domain.Students;
using ScientificWork.UseCases.Students.Common.Dtos;
using ScientificWork.UseCases.Students.GetStudents;
using ScientificWork.UseCases.Students.OnBoarding.CreateStudent;
using ScientificWork.UseCases.Students.UpdateStudent;

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

        CreateMap<UpdateStudentCommand, Student>()
            .ForMember(x => x.ScientificInterests, opt => opt.Ignore())
            .ForMember(x => x.ScientificAreaSubsections, opt => opt.Ignore())
            .ForMember(x => x.Email, opt => opt.Ignore())
            .ForAllMembers(opts =>
            {
                opts.AllowNull();
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });

        CreateMap<Student, StudentDto>()
            .ForMember(x => x.ScientificArea, opt => opt.Ignore())
            .ForMember(x => x.ScientificInterests, opt => opt.MapFrom(x => x.ScientificInterests.Select(s => s.Name)));
    }
}
