using Microsoft.AspNetCore.HttpOverrides;
using ScientificWork.Infrastructure.Common.Startup;
using ScientificWork.Infrastructure.DataAccess.Startup;
using ScientificWork.UseCases;
using ScientificWork.Web;
using ScientificWork.Infrastructure.Presentation.Middlewares;
using ScientificWork.Infrastructure.Presentation.Startup;
using ScientificWork.Infrastructure.Presentation.Startup.HealthCheck;
using ScientificWork.Infrastructure.Presentation.Startup.Swagger;


var builder = WebApplication.CreateBuilder(args);
var environment = builder.Environment;
var configuration = builder.Configuration;
builder.Services.AddInfrastructure(configuration)
                .AddDataAccess(configuration)
                .AddDomain()
                .AddApi(environment, configuration);


var app = builder.Build();
app.UseStaticFiles()
    .UseSwagger() 
    .UseSwaggerUI(new SwaggerUIOptionsSetup().Setup)
    .UseMiddleware<ApiExceptionMiddleware>() 
    .UseRouting() 
    .UseCors(CorsOptionsSetup.CorsPolicyName) 
    .UseForwardedHeaders(new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.All })
    .UseAuthentication()
    .UseAuthorization()
    .UseEndpoints(endpoints =>
    {
            HealthCheckModule.Register(endpoints);
            endpoints.Map("/", context =>
            {
                    context.Response.Redirect("/swagger");
                    return Task.CompletedTask;
            });
            endpoints.MapControllers();
    });


await app.InitAsync();
await app.RunAsync();
