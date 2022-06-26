using Microsoft.Extensions.DependencyInjection;
using PokeNetCore.Impl.Service;
using PokeNetCore.Interfaces.IService;

namespace CarteiraDigital.Core.Infrastructure.InjecaoDependencia;

public static class ServicesIoc
{
    public static void Config(IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();

    }
}