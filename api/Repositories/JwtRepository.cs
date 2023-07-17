using System.Text;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace api.Repositories
{
    public static class JwtRepository
    {
        public static void ConfigureAuth(WebApplicationBuilder builder, JwtOptions jwtOptions)
        {
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opts => AddBearer(opts, jwtOptions));
        }

        private static void AddBearer(JwtBearerOptions opts, JwtOptions jwtOptions)
        {
            byte[] signingKeyBytes = Encoding.UTF8.GetBytes(jwtOptions.SigningKey);

            opts.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtOptions.Issuer,
                ValidAudience = jwtOptions.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
            };
        }
    }
}