using Swashbuckle.AspNetCore.SwaggerUI;

namespace ScientificWork.Web.Infrastructure.Startup.Swagger;

/// <summary>
/// Swagger UI options.
/// </summary>
internal class SwaggerUIOptionsSetup
{
    private readonly string appPrefix;

    public SwaggerUIOptionsSetup(string? appPrefix = null)
    {
        this.appPrefix = appPrefix ?? string.Empty;
    }
    
    /// <summary>
    /// Setup.
    /// </summary>
    /// <param name="options">Swagger generation options.</param>
    public void Setup(SwaggerUIOptions options)
    {
        options.ShowExtensions();
        options.SwaggerEndpoint($"{appPrefix}/swagger/v1/swagger.json?v=1", "API Documentation");
        options.EnableValidator();
        options.EnableDeepLinking();
        options.DisplayOperationId();
        // Preserve authorization token after browser page refresh.
        options.ConfigObject.AdditionalItems.Add("persistAuthorization", "true");
    }
}
