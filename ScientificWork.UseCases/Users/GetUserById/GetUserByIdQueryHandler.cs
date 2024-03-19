using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Infrastructure.Abstractions.Interfaces;
using ScientificWork.Domain.Users;
using ScientificWork.UseCases.Common.Exceptions;

namespace ScientificWork.UseCases.Users.GetUserById;

/// <summary>
/// Handler for <see cref="GetUserByIdQuery" />.
/// </summary>
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

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetUserByIdQueryHandler(IAppDbContext dbContext, IMapper mapper, UserManager<User> userManager)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
        this.userManager = userManager;
    }

    /// <inheritdoc />
    public async Task<UserDetailsDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken: cancellationToken);
        if (user == null)
        {
            throw new UserNotFoundException($"User not found by id - {request.UserId}");
        }
        var res = mapper.Map<UserDetailsDto>(user);
        res.Role = string.Join(", ", await userManager.GetRolesAsync(user));
        return res;
    }
}
