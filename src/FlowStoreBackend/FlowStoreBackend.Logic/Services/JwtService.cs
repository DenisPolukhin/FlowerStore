using FlowStoreBackend.Logic.Interfaces;
using FlowStoreBackend.Logic.Models.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FlowStoreBackend.Logic.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateSuccessfulAccessToken(IEnumerable<Claim> accessTokenPayload)
        {
            var jwtConfiguration = _configuration.GetSection(nameof(JwtConfiguration))
                .Get<JwtConfiguration>();
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.SecretKey));

            var jwtToken = new JwtSecurityToken(
                jwtConfiguration.Issuer,
                jwtConfiguration.Audience,
                accessTokenPayload,
                expires: DateTime.UtcNow.AddMinutes(jwtConfiguration.LifeTime),
                signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256));

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return accessToken;
        }
    }
}
