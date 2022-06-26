using CarteiraDigital.Model.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarteiraDigital.Infrastructure.Data.Context
{
    public class MySqlContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> User { get; set; } = null!;
    }
}