using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CarteiraDigital.Core.Interfaces.IRepository;
using CarteiraDigital.Model.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using CarteiraDigital.Model.Dto;
using CarteiraDigital.Core.Interfaces.IService;

namespace CarteiraDigital.Core.Service;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;

    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<ApplicationUser> _userManager;

    public AuthService(IUserRepository userRepository, IConfiguration configuration, UserManager<ApplicationUser> userManager,
        IHttpContextAccessor httpContextAccessor)
    {
        _userRepository = userRepository;

        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
        _userManager = userManager;
    }

    public async Task<List<ApplicationUser>> ListUsers()
    {
        List<ApplicationUser> listUsers = await _userRepository.ListUsers();

        return listUsers;
    }

    public async Task<ApplicationUser> GetUserById(Guid userId)
    {
        ApplicationUser user = await _userRepository.GetByIdAsync(userId);

        if (user == null)
            throw new ArgumentException("Usuário não existe!");

        return user;
    }

    public async Task<int> UpdateUser(ApplicationUser user)
    {
        ApplicationUser findUser = await _userRepository.GetByIdAsync(user.Id);
        if (findUser == null)
            throw new ArgumentException("Usuário não encontrado");

        findUser.Email = user.Email;
        findUser.UserName = user.UserName;

        return await _userRepository.UpdateAsync(findUser);
    }

    public async Task<bool> DeleteUser(Guid userId)
    {
        ApplicationUser findUser = await _userRepository.GetByIdAsync(userId);
        if (findUser == null)
            throw new ArgumentException("Usuário não encontrado");

        await _userRepository.DeleteAsync(findUser);

        return true;
    }

    public async Task<bool> SignUp(SignUpDto signUpDto)
    {
        ApplicationUser? userExists = await _userManager.FindByNameAsync(signUpDto.Username);
        if (userExists != null)
            throw new ArgumentException("Username already exists!");

        ApplicationUser user = new(signUpDto.Username, signUpDto.Email, signUpDto.PhoneNumber, signUpDto.Cpf);

        IdentityResult? result = await _userManager.CreateAsync(user, signUpDto.Password);

        if (result.Succeeded) return true;
        if (result.Errors.ToList().Count > 0)
            throw new ArgumentException(result.Errors.ToList()[0].Description);
        throw new ArgumentException("SignUp fail.");
    }

    public async Task<SsoDto> SignIn(SignInDto signInDto)
    {
        ApplicationUser? user = await _userManager.FindByNameAsync(signInDto.Username);
        if (user == null)
            throw new ArgumentException("User not found.");

        if (!await _userManager.CheckPasswordAsync(user, signInDto.Password))
            throw new ArgumentException("Password invalid.");

        IList<string>? userRoles = await _userManager.GetRolesAsync(user);

        List<Claim> authClaims = new()
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };
        authClaims.AddRange(userRoles.Select(userRole => new Claim(ClaimTypes.Role, userRole)));

        SymmetricSecurityKey authSigningKey = new(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

        JwtSecurityToken token = new(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddHours(3),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );

        return new SsoDto(new JwtSecurityTokenHandler().WriteToken(token), user);
    }

    public async Task<ApplicationUser> GetCurrentUser()
    {
        ApplicationUser? user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext!.User);

        return user;
    }
    
    public async Task<ApplicationUser> GetUserByCpf(string cpf)
    {
        ApplicationUser user = await _userRepository.GetUserByCpf(cpf);

        return user;
    }
}