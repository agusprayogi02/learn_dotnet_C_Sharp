namespace Canteen.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GeneratorToken(Guid userId, string firstname, string lastName);
}