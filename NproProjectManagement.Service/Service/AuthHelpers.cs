using Common.Models;
using Common.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class AuthHelpers
    {
        private readonly IConfiguration _configuration;

        public AuthHelpers(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public LoginResponse GenerateToken(User user)
        {

            //var claims = new List<Claim>
            // {
            //      new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            //      new Claim(ClaimTypes.Name, user.Username),
            //      new Claim(ClaimTypes.Role, user.Role.ToString()),
            //      new Claim(ClaimTypes.Email, user.Email),
            // };

            //// Get the JWT secret key from configuration
            //var secretKey = _configuration["JWT:Secret"];

            //// Ensure that the secret key is not null or empty
            //if (string.IsNullOrEmpty(secretKey))
            //{
            //    throw new InvalidOperationException("JWT secret key is not configured.");
            //}

            //// Ensure that the key size is sufficient for HmacSha256Signature
            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            //if (key.KeySize < 256 / 8) // Check if key size is less than 256 bits
            //{
            //    throw new InvalidOperationException("JWT secret key size is too small. It must be at least 256 bits.");
            //}

            //var jwtToken = new JwtSecurityToken(
            //    claims: claims,
            //    notBefore: DateTime.UtcNow,
            //    expires: DateTime.UtcNow.AddDays(30),
            //    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            //);

            //return new JwtSecurityTokenHandler().WriteToken(jwtToken);
            var result = new LoginResponse();
            result.Username = user.Username;
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                     new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                     new Claim(ClaimTypes.Name, user.Username),
                     new Claim(ClaimTypes.Role, user.Role.ToString()),
                     new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            result.Token = tokenHandler.WriteToken(token);
            result.Message = "Success";

            return result;
        }
    }
}
