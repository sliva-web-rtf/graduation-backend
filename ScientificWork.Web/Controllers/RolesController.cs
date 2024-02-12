using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ScientificWork.Domain.Users;

namespace ScientificWork.Web.Controllers;

/// <summary>
/// Roles controller.
/// </summary>
[ApiController]
[Route("api/roles")]
[ApiExplorerSettings(GroupName = "roles")]
[Authorize(Roles = "admin")]
public class RolesController
{
    private readonly RoleManager<IdentityRole> roleManager;
    private readonly UserManager<User> userManager;

    /// <summary>
    /// Constructor.
    /// </summary>
    public RolesController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
    {
        this.roleManager = roleManager;
        this.userManager = userManager;
    }
}
