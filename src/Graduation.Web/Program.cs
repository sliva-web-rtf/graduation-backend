using Graduation.Application;
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
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var environment = builder.Environment;
var configuration = builder.Configuration;
configuration.AddJsonFiles(environment);
builder.Services.AddApi(environment, configuration)
    .AddDataAccess(configuration)
    .AddAuthentication(configuration)
    .AddInfrastructure()
    .AddApplication();


var app = builder.Build();
if (environment.IsDevelopment())
    app
        .UseSwagger(c =>
        {
            c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
            {
                swaggerDoc.Servers = new List<OpenApiServer>
                    { new() { Url = $"https://{httpReq.Host.Value}/api" } };
            });
        })
        .UseSwaggerUI(new SwaggerUIOptionsSetup().Setup);

app
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