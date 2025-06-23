using ERP_System.Persistence.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ERP_System.Authentication
{
    public class JwtProvider : IJwtProvider
    {
        public (string Token, int ExpiresIn) GenerateToken(ApplicationUser user)
        {
            Claim[] claims = [
            new(JwtRegisteredClaimNames.Sub, user.Id),
            new(JwtRegisteredClaimNames.Email, user.Email!),
            new(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        ];

            var symmetricSecurityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("YEvrYq0irZOE59iBaEORQmstaTmzMIM1")
            );

            var signingCredentials = new SigningCredentials(
                symmetricSecurityKey,
                SecurityAlgorithms.HmacSha256
            );

            var expiresIn = 30;

            var token = new JwtSecurityToken(
                issuer: "ERP_SystemApp",
                audience: "ERP_SystemApp users",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiresIn),
                signingCredentials: signingCredentials
            );

            return (
                new JwtSecurityTokenHandler().WriteToken(token),
                expiresIn * 60
            );
        }
    }
}
