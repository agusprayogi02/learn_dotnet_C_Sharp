using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Canteen.Application.Common.Interfaces.Authentication;
using Canteen.Application.Common.Interfaces.Services;
using Microsoft.Extensions.Options;

namespace Canteen.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings _settings;
    private readonly IDateTimeProvider _dateTimeProvider;

    public JwtTokenGenerator(IOptions<JwtSettings> settings, IDateTimeProvider dateTimeProvider)
    {
        _settings = settings.Value;
        _dateTimeProvider = dateTimeProvider;
    }

    public string GeneratorToken(Guid userId, string email, string firstname, string lastName)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var expired = _dateTimeProvider.UtcNow.AddMinutes(_settings.ExpiryMinutes);
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
            Issuer = _settings.Issuer,
            Audience = _settings.Audience,
            Expires = expired,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Secret)),
                SecurityAlgorithms.Aes128CbcHmacSha256
            )
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}