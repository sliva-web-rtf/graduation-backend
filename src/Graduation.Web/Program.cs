using Graduation.Application;
using Graduation.Infrastructure;
using Graduation.Infrastructure;
using Graduation.Infrastructure.Authentication;
using Graduation.Infrastructure.Persistence;
using Graduation.Web;
using Graduation.Web.Configuration;
using Graduation.Web.HealthCheck;
using Graduation.Web.Middlewares;
using Graduation.Web.Startup;
using Graduation.Web.Startup.Swagger;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);
var environment = builder.Environment;
var configuration = builder.Configuration;
configuration.AddJsonFiles(environment);
builder.Services.AddApi(environment, configuration)
    .AddDataAccess(configuration)
    .AddAuthentication(configuration)
    .AddInfrastructure()
    .AddApplication();
    .AddValidation();


var app = builder.Build();
app
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


await app.RunAsync();