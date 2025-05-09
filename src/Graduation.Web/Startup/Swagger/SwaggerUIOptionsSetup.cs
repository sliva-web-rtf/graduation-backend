using Swashbuckle.AspNetCore.SwaggerUI;

namespace Graduation.Web.Startup.Swagger;

/// <summary>
/// Swagger UI options.
/// </summary>
public class SwaggerUIOptionsSetup
{
    /// <summary>
    /// Setup.
    /// </summary>
    /// <param name="options">Swagger generation options.</param>
    public void Setup(SwaggerUIOptions options)
    {
        options.ShowExtensions();
        options.SwaggerEndpoint("/swagger/v1/swagger.json?v=1", "API Documentation");
        options.EnableValidator();
        options.EnableDeepLinking();
        options.DisplayOperationId();
        // Preserve authorization token after browser page refresh.
        options.ConfigObject.AdditionalItems.Add("persistAuthorization", "true");
    }
}
