using Identity.Domain.Entities;
using Identity.Domain.Interfaces.Services;
using Identity.Infrastructure.Services.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Services.Services
{
    public class TokenService : ITokenService
    {
        private readonly string _secret;
        private readonly string _iss;
        private readonly string _aud;

        public TokenService(IOptions<AudienceConfiguration> audienceOptions)
        {
            _secret = audienceOptions.Value.Secret;
            _iss = audienceOptions.Value.Iss;
            _aud = audienceOptions.Value.Aud;
        }

        public async Task<AcessToken> CreateTokenAsync(User user)
        {
            var now = DateTime.UtcNow;

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToUniversalTime().ToString(), ClaimValueTypes.Integer64)
            };

            var signingKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_secret)
                );

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _iss,
                ValidAudience = _aud,
                IssuerSigningKey = signingKey,
                RequireExpirationTime = true,
                ClockSkew = TimeSpan.Zero
            };

            var jwt = new JwtSecurityToken(
                issuer: _iss,
                audience: _aud,
                claims: claims,
                notBefore: now,
                expires: now.Add(TimeSpan.FromMinutes(2)),
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return await Task.FromResult(new AcessToken
            {
                Token = encodedJwt,
                TokenExpires = jwt.ValidFrom
            });
        }
    }
}
