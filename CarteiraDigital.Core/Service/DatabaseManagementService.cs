using CarteiraDigital.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;

namespace CarteiraDigital.Core.Service;

public static class DatabaseManagementService
{
    public static void MigrationInitialisation(IApplicationBuilder app)
    {
        using IServiceScope serviceScope = app.ApplicationServices.CreateScope();
        MySqlContext serviceMySql = serviceScope.ServiceProvider.GetService<MySqlContext>()!;

        IMigrator? migrator = serviceMySql.GetInfrastructure().GetService<IMigrator>();

        migrator!.Migrate();
    }
}