using CarteiraDigital.Model.Domain;
using CarteiraDigital.Model.Dto;

namespace CarteiraDigital.Core.Interfaces.IService;

public interface IAuthService
{
    Task<List<ApplicationUser>> ListUsers();
    Task<ApplicationUser> GetUserById(Guid userId);
    Task<int> UpdateUser(ApplicationUser user);
    Task<bool> DeleteUser(Guid userId);
    Task<bool> SignUp(SignUpDto signUpDto);
    Task<SsoDto> SignIn(SignInDto signInDto);
    Task<ApplicationUser> GetCurrentUser();
}