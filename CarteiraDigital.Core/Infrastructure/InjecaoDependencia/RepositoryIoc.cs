using CarteiraDigital.Core.Interfaces.IRepository;
using Microsoft.Extensions.DependencyInjection;
using PokeNetCore.Impl.Repository;

namespace CarteiraDigital.Core.Infrastructure.InjecaoDependencia;

public static class RepositoryIoc
{
    public static void Config(IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
    }
}