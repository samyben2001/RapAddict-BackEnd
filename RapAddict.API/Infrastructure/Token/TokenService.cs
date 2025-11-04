using Microsoft.IdentityModel.Tokens;
using RapAddict.Domain.Entities.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RapAddict.API.Infrastructure.Token
{
    public class TokenService : ITokenRepository
    {
        private readonly JwtOptions _jwtOptions;

        public TokenService(JwtOptions jwtOptions)
        {
            _jwtOptions = jwtOptions;
        }

        public string GenerateToken(User user)
        {
            // 'Payload' est constitué de 'Claims'
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };

            // Génération du token
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecurityKey)), SecurityAlgorithms.HmacSha512)
                );

            string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return token;
        }
    }
}
