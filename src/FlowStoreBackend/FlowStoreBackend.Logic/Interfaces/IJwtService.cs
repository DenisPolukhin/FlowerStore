using System.Security.Claims;

namespace FlowStoreBackend.Logic.Interfaces
{
    public interface IJwtService
    {
        string GenerateSuccessfulAccessToken(IEnumerable<Claim> accessTokenPayload);
    }
}
