using CarteiraDigital.Model.Domain;
using System.ComponentModel.DataAnnotations;

namespace PokeNetCore.Domain.Models.Dto;

public class AuthDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = null!;
}

public class SsoDto
{
    public string Access_token { get; set; }
    public DayOfWeek Expiration { get; set; }
    public ApplicationUser User { get; set; }

    public SsoDto(string access_token, ApplicationUser user)
    {
        this.Access_token = access_token;
        this.Expiration = DateTime.Now.DayOfWeek;
        this.User = user;
    }
}

public class SignInDto
{
    [Required(ErrorMessage = "User Name is required")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }

    public SignInDto(string username, string password)
    {
        Username = username;
        Password = password;
    }
}

public class SignUpDto
{
    [Required(ErrorMessage = "User Name is required")] public string Username { get; set; }

    [EmailAddress][Required(ErrorMessage = "Email is required")] public string Email { get; set; }

    [Required(ErrorMessage = "PhoneNumber is required")] public string PhoneNumber { get; set; }
        
    [Required(ErrorMessage = "Password is required")] public string Password { get; set; }

    [Required(ErrorMessage = "Password is required")] public string PasswordConfirm { get; set; }
}