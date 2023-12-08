using IofficePlus.Dados.Contexts;
using IofficePlus.Dominio.Models;
using System;

namespace IofficePlus;

public static class Bootstrapper
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<IofficedbContext>();

        return services;
    }
}