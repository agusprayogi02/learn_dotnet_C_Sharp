namespace Canteen.Application.Services;

public class AuthenticationService : IAuthenticationService
{
    public AuthResult Register(string FirstName, string LastName, string Email, string Password)
    {
        return new AuthResult(
            Guid.NewGuid(),
            FirstName,
            LastName,
            Email,
            "Token hahah"
        );
    }

    public AuthResult Login(string Email, string Password)
    {
        return new AuthResult(
            Guid.NewGuid(),
            "FirstName",
            "LastName",
            Email,
            "Token Nich"
            
        );
    }
}