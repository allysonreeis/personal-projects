using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace ByteShop.ECommerce.Api.Configurations;

public static class SecurityConfiguration
{
    public static IServiceCollection AddSecurity(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    {
        services.AddKeycloakWebApiAuthentication(configuration);
        services.AddKeycloakAuthorization(configuration);

        if (environment.IsDevelopment())
        {
            services.Configure<JwtBearerOptions>(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.RequireHttpsMetadata = false;
            });
        }

        return services;
    }
}
