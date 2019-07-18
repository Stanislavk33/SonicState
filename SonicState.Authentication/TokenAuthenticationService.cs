using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SonicState.Contracts;
using SonicState.Contracts.Services;
using SonicState.Models.BindingModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SonicState.Authentication
{
    public class TokenAuthenticationService : AuthenticateService
    {
        private readonly IUserRepository userRepository;
        private readonly TokenManagement tokenManagement;
        public TokenAuthenticationService
            (IUserRepository userRepository, IOptions<TokenManagement> tokenManagement)
        {
            this.userRepository = userRepository;
            this.tokenManagement = tokenManagement.Value;
        }
        public bool IsAuthenticated(LoginUser user, out string token)
        {
            token = string.Empty;
            if (!userRepository.Exists(user.Email)) return false;

            var claim = new[]
            {
                new Claim(ClaimTypes.Email, user.Email)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenManagement.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                tokenManagement.Issuer,
                tokenManagement.Audience,
                claim,
                expires: DateTime.Now.AddMinutes(tokenManagement.AccessExpiration),
                signingCredentials: credentials
            );

            token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return true;
        }
    }
}
