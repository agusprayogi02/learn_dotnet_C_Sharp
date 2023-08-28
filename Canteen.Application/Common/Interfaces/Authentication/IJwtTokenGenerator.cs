namespace Canteen.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GeneratorToken(Guid userId, string email, string firstname, string lastName);
}