using ScientificWork.Web;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplication(builder.Environment, builder.Configuration);

var app = builder.Build();
app.UseApplication();

await app.InitAsync();
await app.RunAsync();