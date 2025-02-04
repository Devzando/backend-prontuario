using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using prontuario.Application.Gateways;
using prontuario.Domain.Entities.User;

namespace prontuario.Infra.Gateways;

public class TokenGateway : ITokenGateway
{
    public string? CreateToken(UserEntity user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Environment.GetEnvironmentVariable("TOKEN_KEY");
        if (key is null) return null;
        var keyEncoded = Encoding.ASCII.GetBytes(key);
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Profile.Role.Value),
                new Claim(ClaimTypes.Email, user.Email.Value),
                new Claim("position", user.Position.Value),
                new Claim("firstAccess", user.FirstAccess.ToString()),
                new Claim("active", user.Active.ToString()),
            }),
            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyEncoded), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}