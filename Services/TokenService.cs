using Blog.Extensions;
using Blog.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Blog.Services
{
    public class TokenService
    {
        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler(); // Chamamos o metoto JwtSecurityTokenHandler que será o construtor do nosso Token
            var key = Encoding.ASCII.GetBytes(Configuration.JwtKey); // Aqui chamamos nossa Key da classe JWT e convertemos ela para Bytes pois o tokenHandler so aceita arrays de bytes
            var claims = user.GetClaims();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(8), // Adicionamos o tempo de expiração do token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),// Codificação do nosso token, passamos nosso array de Key
            }; // Aqui chamamos o metodo que terá todos os dados para criação do nosso token
            var token = tokenHandler.CreateToken(tokenDescriptor); // Nesse metodo criamos nosso token atraves do construtor tokenHandler

            return tokenHandler.WriteToken(token); //Aqui alteramos o tipo do arquivo para string, o WriteToken retorna uma string
        }
    }
}
