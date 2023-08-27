namespace Canteen.Application.Services;

public interface IAuthenticationService
{
     public AuthResult Register(string firstName, string lastName, string email, string Password);
     public AuthResult Login(string Email, string Password);
}