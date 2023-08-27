using Canteen.Application.Common.Interfaces.Authentication;
using Canteen.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Canteen.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service)
    {
        service.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        
        return service;
    }
}