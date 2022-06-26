using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CarteiraDigital.Core.Infrastructure.Config.Identity;

public class JwtSecurityKey
{
    public static SymmetricSecurityKey Create(string secret)
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
    }
}