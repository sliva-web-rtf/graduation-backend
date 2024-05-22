using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScientificWork.Domain.Admins;

namespace ScientificWork.Web.Controllers;

/// <summary>
/// Roles controller.
/// </summary>
[ApiController]
[Route("api/roles")]
[ApiExplorerSettings(GroupName = "roles")]
[Authorize(Roles = nameof(SystemAdmin))]
public class RolesController;
