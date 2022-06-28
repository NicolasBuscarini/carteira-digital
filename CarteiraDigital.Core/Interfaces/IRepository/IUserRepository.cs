using CarteiraDigital.Model.Domain;

namespace CarteiraDigital.Core.Interfaces.IRepository;

public interface IUserRepository : IGenericRepository<ApplicationUser, Guid>
{
    Task<List<ApplicationUser>> ListUsers();
    Task<ApplicationUser> GetUserByCpf(string cpf);
}