using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CommonLibrary.Lib
{
    public class TokenLib
    {
        public static class AppClaims
        {
            public const string Scope = "scope";
        }

        public static class AppPolicy
        {
            public const string Customer = "Customer";
            public const string Teller = "Teller";
            public const string Manager = "Manager";
        }

        public static class AppScope
        {
            public const string Customer = "Customer";
            public const string Teller = "Teller";
            public const string Manager = "Manager";
        }

        private static readonly string _securityKey = "BTMS_secure_app_key_abczyx_12345678900987654321_!@#$%^&*";
        private static readonly string _issuer = "http://localhost:8079";
        private static readonly string _audience = "http://localhost:8080";

        public static void ConfigureJWTServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _issuer,
                    ValidAudience = _audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_securityKey))
                };
            });
            services.AddMvc();
        }

        public static AuthorizationOptions AuthorizationOptions(AuthorizationOptions options)
        {
            options.AddPolicy(AppPolicy.Customer, policy => 
                policy.RequireClaim(AppClaims.Scope, AppScope.Customer));
            options.AddPolicy(AppPolicy.Teller, policy => 
                policy.RequireClaim(AppClaims.Scope, AppScope.Teller));
            options.AddPolicy(AppPolicy.Manager, policy => 
                policy.RequireClaim(AppClaims.Scope, AppScope.Manager));
            return options;
        }

        public static string Newtoken(string username, string displayName, string[] roles, string[] scopes, int validTimeInMinutes = 120)
        {
            IEnumerable<Claim> claims = new List<Claim> {
                new (JwtRegisteredClaimNames.Sub, username),
                new (JwtRegisteredClaimNames.Name, displayName),
                new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var role in roles)
            {
                claims = claims.Append(new Claim(ClaimTypes.Role, role));
            }

            foreach (var scope in scopes)
            {
                claims = claims.Append(new Claim(AppClaims.Scope, scope));
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_securityKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_issuer,
                _issuer,
                claims,
                expires: DateTime.Now.AddMinutes(validTimeInMinutes),
                signingCredentials: credentials);
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}