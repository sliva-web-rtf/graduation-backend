using ScientificWork.Web;

// ReSharper disable UnassignedGetOnlyAutoProperty
// ReSharper disable UnusedMember.Global

var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services, builder.Environment);

var app = builder.Build();

startup.Configure(app, app.Environment);

if (app == null)
{
    throw new InvalidOperationException("app is not initialized");
}

await app.InitAsync();
await app.RunAsync();

return 0;