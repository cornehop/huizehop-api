using HuizeHop.Api.Library.Database;

namespace HuizeHop.Api.Configuration.DependencyInjection;

public static class General
{
    public static void RegisterDependencies(this IServiceCollection services)
    {
        // Database
        services.AddDbContext<HuizeHopDbContext>();
    }
}