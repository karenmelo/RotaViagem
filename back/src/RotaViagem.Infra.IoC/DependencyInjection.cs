using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RotaViagem.Infra.Data.Context;

namespace RotaViagem.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection ResolveDependecncy(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => {
            options.UseSqlite(configuration.GetConnectionString("Default"),
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
        });

        return services;
    }
}
