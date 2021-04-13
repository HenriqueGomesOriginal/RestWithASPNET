using System.Collections.Generic;
using System.Security.Claims;

namespace RestWithASPNET.Services
{
    public interface ITokenService
    {   
        string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiryToken(string token);
    }
}
