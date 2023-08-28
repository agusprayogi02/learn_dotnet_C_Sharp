using Canteen.Application.Common.Interfaces.Authentication;
using Canteen.Application.Common.Interfaces.Services;
using Canteen.Infrastructure.Authentication;
using Canteen.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Canteen.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection service,
        ConfigurationManager configuration
    )
    {
        service.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        service.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        service.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        return service;
    }
}