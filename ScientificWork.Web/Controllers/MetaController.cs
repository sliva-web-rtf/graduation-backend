﻿using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using ScientificWork.Infrastructure.Presentation.Dtos;

namespace ScientificWork.Web.Controllers;

/// <summary>
/// Contains methods related to application info.
/// </summary>
[Route("api/meta")]
[ApiController]
[ApiExplorerSettings(GroupName = "meta", IgnoreApi = true)]
public class MetaController : ControllerBase
{
    /// <summary>
    /// Get application version.
    /// </summary>
    [HttpGet("version")]
    public AppVersionDto GetAppVersion()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        var assemblyVersion = assembly.GetName().Version?.ToString();
        var informationVersion = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;
        return new AppVersionDto
        {
            AssemblyVersion = assemblyVersion,
            InformationalVersion = informationVersion
        };
    }
}
