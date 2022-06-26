using System.IdentityModel.Tokens.Jwt;

namespace CarteiraDigital.Core.Infrastructure.Config.Identity;

public class TokenJwt
{
    private readonly JwtSecurityToken token;

    internal TokenJwt(JwtSecurityToken token)
    {
        this.token = token;
    }

    public DateTime ValidTo => token.ValidTo;

    public string Value => new JwtSecurityTokenHandler().WriteToken(token);
}