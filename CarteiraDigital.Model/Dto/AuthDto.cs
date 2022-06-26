using CarteiraDigital.Model.Domain;
using System.ComponentModel.DataAnnotations;

namespace CarteiraDigital.Model.Dto;

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
        Access_token = access_token;
        Expiration = DateTime.Now.DayOfWeek;
        User = user;
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
    [Required(ErrorMessage = "User Name is required")] public string Username { get; set; } = "username";

    [EmailAddress][Required(ErrorMessage = "Email is required")] public string Email { get; set; } = "email@email.com";

    [Required(ErrorMessage = "PhoneNumber is required")] public string PhoneNumber { get; set; } = "(11)99999-9999";

    [Required(ErrorMessage = "Password is required")] public string Password { get; set; } = "123";

    [Required(ErrorMessage = "Password is required")] public string PasswordConfirm { get; set; } = "123";
}