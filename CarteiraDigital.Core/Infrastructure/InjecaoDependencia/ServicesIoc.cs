using CarteiraDigital.Core.Interfaces.IService;
using CarteiraDigital.Core.Service;
using Microsoft.Extensions.DependencyInjection;

namespace CarteiraDigital.Core.Infrastructure.InjecaoDependencia;

public static class ServicesIoc
{
    public static void Config(IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();

    }
}