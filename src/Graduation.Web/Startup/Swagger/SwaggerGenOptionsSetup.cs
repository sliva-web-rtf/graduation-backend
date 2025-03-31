using System.Diagnostics;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Unchase.Swashbuckle.AspNetCore.Extensions.Extensions;

namespace Graduation.Web.Startup.Swagger;

/// <summary>
///     Swagger generation options.
/// </summary>
public class SwaggerGenOptionsSetup
{
    /// <summary>
    ///     Setup.
    /// </summary>
    /// <param name="options">Swagger generation options.</param>
    /// <param name="assembly"></param>
    public static void Setup(SwaggerGenOptions options, Assembly assembly)
    {
        var fileVersionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);

        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = fileVersionInfo.FileVersion,
            Title = "Graduation swagger",
            Description = "API documentation for the project."
        });
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "Insert JWT token to the field.",
            Scheme = "bearer",
            BearerFormat = "JWT",
            Name = "bearer",
            Type = SecuritySchemeType.Http
        });
        options.IncludeXmlCommentsWithRemarks(GetAssemblyLocation(assembly));
        options.SchemaFilterDescriptors = options
            .SchemaFilterDescriptors
            .Where(filterDescriptor => filterDescriptor.Arguments is not null)
            .ToList();
        options.IncludeXmlCommentsFromInheritDocs(true);

        // Our custom filters.
        options.SchemaFilter<SwaggerExampleSetterSchemaFilter>();
        options.SchemaFilter<SwaggerEnumDescriptionSchemaOperationFilter>();
        options.OperationFilter<SwaggerEnumDescriptionSchemaOperationFilter>();
        options.OperationFilter<SwaggerSecurityRequirementsOperationFilter>();

        // Group by ApiExplorerSettings.GroupName name.
        options.TagActionsBy(apiDescription => [apiDescription.GroupName]);
        options.DocInclusionPredicate((_, api) => !string.IsNullOrWhiteSpace(api.GroupName));

        options.CustomOperationIds(a =>
            a.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor
                ? string.Concat(controllerActionDescriptor.ControllerName, "/", controllerActionDescriptor.ActionName)
                : string.Empty);

        options.UseDateOnlyTimeOnlyStringConverters();
    }

    private static string GetAssemblyLocation(Assembly assembly)
    {
        return Path.Combine(AppContext.BaseDirectory, $"{assembly.GetName().Name}.xml");
    }
}