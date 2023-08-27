using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Canteen.Application.Common.Interfaces.Authentication;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Canteen.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    public string GeneratorToken(Guid userId, string firstname, string lastName)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey("super-secret-key"u8.ToArray()),
            SecurityAlgorithms.HmacSha256
        );
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, firstname),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };
        var securityToken = new JwtSecurityToken(
            issuer: "CanteenBroo",
            expires: DateTime.Now.AddDays(1),
            claims: claims,
            signingCredentials: signingCredentials
        );
        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}