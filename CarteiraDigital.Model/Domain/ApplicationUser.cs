using Microsoft.AspNetCore.Identity;

namespace CarteiraDigital.Model.Domain;
public class ApplicationUser : IdentityUser<Guid>
{
    public string Cpf { get; set; }
    
    public ApplicationUser(string username, string email, string phoneNumber, string cpf)
    {
        SecurityStamp = Guid.NewGuid().ToString();
        UserName = username;
        Email = email;
        PhoneNumber = phoneNumber;
        Cpf = cpf;
    }
}