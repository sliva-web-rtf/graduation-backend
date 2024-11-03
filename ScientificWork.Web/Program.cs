using Microsoft.AspNetCore.HttpOverrides;
using ScientificWork.Infrastructure.Common.Startup;
using ScientificWork.Infrastructure.DataAccess.Startup;
using ScientificWork.UseCases;
using ScientificWork.Web;
using ScientificWork.Web.Infrastructure.Middlewares;
using ScientificWork.Web.Infrastructure.Startup;
using ScientificWork.Web.Infrastructure.Startup.HealthCheck;
using ScientificWork.Web.Infrastructure.Startup.Swagger;


var builder = WebApplication.CreateBuilder(args);
var environment = builder.Environment;
var configuration = builder.Configuration;
builder.Services.AddApi(environment, configuration)
                .AddInfrastructure(configuration)
                .AddDataAccess(configuration)
                .AddDomain();


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
