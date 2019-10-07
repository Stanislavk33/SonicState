using Microsoft.AspNetCore.Http;
using SonicState.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SonicState.Authentication
{
    public class ClaimAccessor : IClaimAccessor
    {
        private readonly ClaimsPrincipal claims;

        public ClaimAccessor(IHttpContextAccessor http)
        {
            this.claims = http.HttpContext.User;
        }

        public int Id => int.Parse(FindClaim(ClaimTypes.NameIdentifier));
        //public string Email => FindClaim(JwtRegisteredClaimNames.Email);
        public bool IsAuthenticated => this.claims.Identity.IsAuthenticated;
        private string FindClaim(string type) => this.claims.FindFirstValue(type);
    }
}
