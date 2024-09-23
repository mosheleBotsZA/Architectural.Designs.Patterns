namespace Monolithic.Architecture.API.Common.Extensions
{
    public static class ServiceCollection
    {
        public static IServiceCollection ConfigureService(this IServiceCollection services)
        {
            return services;
        }
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            return services;
        }
        public static IServiceCollection ConfigureOptions(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}