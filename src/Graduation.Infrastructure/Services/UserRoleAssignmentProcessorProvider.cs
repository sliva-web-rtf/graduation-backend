﻿using Graduation.Application.Interfaces.Services;
using Graduation.Domain;

namespace Graduation.Infrastructure.Services;

public class UserRoleAssignmentProcessorProvider(IServiceProvider serviceProvider)
    : IUserRoleAssignmentProcessorProvider
{
    public IUserRoleAssignmentProcessor? GetProcessor(string role)
    {
        return role switch
        {
            WellKnownRoles.Student => (serviceProvider.GetService(typeof(StudentUserRoleAssignmentProcessor)) as
                IUserRoleAssignmentProcessor)!,
            _ => null
        };
    }
}