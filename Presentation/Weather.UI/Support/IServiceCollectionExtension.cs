using Microsoft.Extensions.DependencyInjection;

namespace Weather.UI.Support
{
    public static class IServiceCollectionExtension
    {

        public static IServiceCollection AddWpfDependencies(this IServiceCollection services)
        {
            services.AddTransient<MainWindow>();
            return services;
        }
    }
}
