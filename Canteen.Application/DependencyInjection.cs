using Canteen.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Canteen.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddScoped<IAuthenticationService, AuthenticationService>();
        return service;
    }
}
