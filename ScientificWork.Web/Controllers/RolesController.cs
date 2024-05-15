using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ScientificWork.Domain.Admins;
using ScientificWork.Domain.Users;

namespace ScientificWork.Web.Controllers;

/// <summary>
/// Roles controller.
/// </summary>
[ApiController]
[Route("api/roles")]
[ApiExplorerSettings(GroupName = "roles")]
[Authorize(Roles = nameof(SystemAdmin))]
public class RolesController;
