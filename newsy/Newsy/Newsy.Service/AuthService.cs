using Microsoft.IdentityModel.Tokens;
using Newsy.Core.Entities;
using Newsy.Core.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Newsy.Service
{
    public class AuthService : IAuthService
    {
        private readonly SymmetricSecurityKey _key;
        public AuthService()
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is my new api key thatz i use hell yea yea yea"));
        }

        public string CreateJwtToken(Author author)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, author.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, author.FirstName),
                new Claim(JwtRegisteredClaimNames.Email, author.Email)
            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
