namespace Graduation.Web.Configuration;

public static class ConfigurationExtensions
{
    public static IConfigurationBuilder AddJsonFiles(this IConfigurationBuilder builder,
        IWebHostEnvironment environment)
    {
        var basePath = Directory.GetCurrentDirectory();

        var configFiles = Directory.GetFiles(basePath, $"appsettings.{environment.EnvironmentName}.*.json");

        foreach (var file in configFiles)
        {
            builder.AddJsonFile(file, optional: true, reloadOnChange: true);
        }

        return builder;
    }
}