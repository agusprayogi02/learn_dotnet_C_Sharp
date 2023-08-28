using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Canteen.Application.Common.Interfaces.Authentication;

namespace Canteen.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    public string GeneratorToken(Guid userId, string email, string firstname, string lastName)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var expired = DateTime.UtcNow.AddDays(1);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("id", userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Exp, expired.ToLongDateString()),
                new Claim(JwtRegisteredClaimNames.GivenName, firstname),
                new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            }),
            Expires = expired,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey("super-secret-key"u8.ToArray()),
                SecurityAlgorithms.Aes128CbcHmacSha256
            )
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}