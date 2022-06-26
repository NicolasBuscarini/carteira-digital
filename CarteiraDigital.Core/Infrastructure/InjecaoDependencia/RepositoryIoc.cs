using CarteiraDigital.Core.Interfaces.IRepository;
using CarteiraDigital.Core.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CarteiraDigital.Core.Infrastructure.InjecaoDependencia;

public static class RepositoryIoc
{
    public static void Config(IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
    }
}