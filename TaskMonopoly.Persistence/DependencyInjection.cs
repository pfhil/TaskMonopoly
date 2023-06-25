using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskMonopoly.Application.Common.Interfaces;
using TaskMonopoly.Persistence.Services;

namespace TaskMonopoly.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString());
            });
            services.AddScoped<IApplicationDbContext>(provider =>
                provider.GetService<ApplicationDbContext>());
            services.AddTransient<IPalletService, PalletService>();
            return services;
        }
    }
}
