using IdentityModel;
using Microsoft.IdentityModel.Tokens;

namespace API
{
    public static class Authentication
    {
        public static void Config(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = configuration["IdentityServer:Authority"];
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        NameClaimType = JwtClaimTypes.Name,
                    };
                    options.RequireHttpsMetadata = false;
                });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "Ticketing.API", "Ticketing_Identity_Resource" , "Ticketing_API_Resource");
                });
            });
        }
    }
}
