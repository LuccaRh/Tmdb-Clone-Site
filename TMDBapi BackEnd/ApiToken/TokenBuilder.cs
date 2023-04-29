using ApiTMDB.MOD;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApiToken
{
    public class TokenBuilder
    {
        public string GenerateToken(Usuário user)
        {
            var tokenHandler = new JwtSecurityTokenHandler(); //objeto para criar o token
            var key = Encoding.ASCII.GetBytes(TokenSettings.Secret); //passar key de string para byte
            var tokenDescriptor = new SecurityTokenDescriptor //características do token
            {
                Subject = new ClaimsIdentity(new Claim[] //Informações que estarão no token
                {
                    new Claim(ClaimTypes.Name, user.userName.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(2), //em quanto tempo token será expirado
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
