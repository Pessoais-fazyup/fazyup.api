using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using fazyup.api.Shared.Configs;
using Microsoft.Extensions.Options;
using fazyup.api.Shared.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace fazyup.api.Feature.User
{
    public class TokenService
    {
        private readonly JwtConfiguration _settings;

        public TokenService(IOptions<JwtConfiguration> settings)
        {
            _settings = settings.Value;
        }

        public string GenerateToken(UserRole user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(_settings.ExpirationHours),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature),
                Issuer = _settings.Emitter,
                Audience = _settings.ValidIn
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
