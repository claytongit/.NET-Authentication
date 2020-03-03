using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using systemLogin.Models;


namespace systemLogin.Services
{
    public static class TokenService
    {
        public static string GenerateToken(UserModel user)
        {
            var tokenHandle = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(settings.Secret);
            var TokenDescript = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.Name, user.username.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials
                (
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature
                )               
            };
            var token = tokenHandle.CreateToken(TokenDescript);

            return tokenHandle.WriteToken(token);
        }
    }
}