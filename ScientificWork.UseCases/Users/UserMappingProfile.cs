using AutoMapper;
using ScientificWork.Domain.Users;
using ScientificWork.UseCases.Users.Common.Dtos;
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
    }
}
