using Canteen.Application.Common.Interfaces.Authentication;

namespace Canteen.Application.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthResult Register(string firstName, string lastName, string email, string password)
    {
        // Check if user already exists

        // Create user 

        // Create JWT Token
        var userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GeneratorToken(userId, firstName, lastName);

        return new AuthResult(
            userId,
            firstName,
            lastName,
            email,
            token
        );
    }

    public AuthResult Login(string email, string password)
    {
        var userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GeneratorToken(userId, "", "");
        return new AuthResult(
            userId,
            "FirstName",
            "LastName",
            email,
            "Token Nich"
        );
    }
}