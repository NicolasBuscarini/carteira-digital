using Microsoft.EntityFrameworkCore;
using CarteiraDigital.Core.Interfaces.IRepository;
using CarteiraDigital.Model.Domain;
using CarteiraDigital.Infrastructure.Data.Context;

namespace CarteiraDigital.Core.Repository;

public class UserRepository : GenericRepository<ApplicationUser, Guid>, IUserRepository
{
    private readonly MySqlContext _context;
    public UserRepository(MySqlContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<ApplicationUser>> ListUsers()
    {
        List<ApplicationUser> list = await _context.User.ToListAsync();

        return list;
    }
}