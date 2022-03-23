using FlowStoreBackend.Logic.Interfaces;
using System.Security.Claims;

namespace FlowStoreBackend.Logic.Services
{
    public class JwtService : IJwtService
    {
        public string GenerateSuccessfulAccessToken(IEnumerable<Claim> claims)
        {
            throw new NotImplementedException();
        }
    }
}
