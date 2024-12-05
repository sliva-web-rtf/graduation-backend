using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Domain.Exceptions;
using ScientificWork.Domain.Users;
using ScientificWork.Infrastructure.Abstractions.Interfaces;

namespace ScientificWork.UseCases.Users.GetProfileInfo;

public class GetProfileInfoQueryHandler
    : IRequestHandler<GetProfileInfoQuery, GetProfileInfoQueryResult>
{

    private readonly ILoggedUserAccessor userAccessor;
    private readonly UserManager<User> userManager;

    public GetProfileInfoQueryHandler(ILoggedUserAccessor userAccessor,
        UserManager<User> userManager)
    {
        this.userAccessor = userAccessor;
        this.userManager = userManager;
    }
    
    public async Task<GetProfileInfoQueryResult> Handle(GetProfileInfoQuery request, CancellationToken cancellationToken)
    {
        var userId = userAccessor.GetCurrentUserId().ToString();
        var user = await userManager.FindByIdAsync(userId);
        if (user is null)
        {
            throw new NotFoundException($"User with id {userId} not found.");
        }
        
        return new GetProfileInfoQueryResult()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Patronymic = user.Patronymic,
            Email = user.Email,
            Phone = user.PhoneNumber,
            Contacts = user.Contacts,
            LastPasswordChangedDate = user.LastPasswordChange
        };
    }
}