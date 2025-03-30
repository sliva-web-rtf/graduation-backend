using AutoMapper;
using Graduation.Application.Interfaces.DataAccess;
using Graduation.Domain.Exceptions;
using Graduation.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Users.GetUserById;

internal class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDetailsDto>
{
    private readonly IAppDbContext dbContext;
    private readonly IMapper mapper;
    private readonly UserManager<User> userManager;

    internal class GetUserByIdQueryMappingProfile : Profile
    {
        public GetUserByIdQueryMappingProfile()
        {
            CreateMap<User, UserDetailsDto>();
        }
    }

    public GetUserByIdQueryHandler(IAppDbContext dbContext, IMapper mapper, UserManager<User> userManager)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
        this.userManager = userManager;
    }

    public async Task<UserDetailsDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken: cancellationToken);
        if (user == null)
        {
            throw new NotFoundException("User not found");
        }
        var res = mapper.Map<UserDetailsDto>(user);
        res.Roles = await userManager.GetRolesAsync(user);
        return res;
    }
}
