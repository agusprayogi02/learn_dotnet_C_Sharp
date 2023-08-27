namespace Canteen.Application.Services;

public interface IAuthenticationService
{
     public AuthResult Register(string FirstName, string LastName, string Email, string Password);
     public AuthResult Login(string Email, string Password);
}