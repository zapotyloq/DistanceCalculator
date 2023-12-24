using DistanceCalculator.BLL.Services.Abstractions;
using DistanceCalculator.BLL.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace DistanceCalculator.BLL
{
    /// <summary>
    /// Define extension methods to add BLL services to DI container.
    /// </summary>
    public static class DependencyInjectionBll
    {
        /// <summary>
        /// Add BLL services to DI container.
        /// </summary>
        /// <param name="services">DI container.</param>
        public static IServiceCollection AddDistanceCalculatorBLL(this IServiceCollection services)
        {
            // Add BLL services to DI container.
            services.AddScoped<IDistanceService, DistanceService>();
            services.AddScoped<IAirportInfoProvider, AirportInfoProvider>();

            return services;
        }

    }
}
