using prontuario.Application.Gateways;
using prontuario.Domain.Entities.User;
using static BCrypt.Net.BCrypt;

namespace prontuario.Infra.Gateways;

public class BcryptServiceGateway : IBcryptGateway
{
    private const int WorkFactor = 12;

    public string GenerateHashPassword(string password)
    {
        var hashedPassword = HashPassword(password, WorkFactor);
        return hashedPassword;
    }

    public bool VerifyHashPassword(UserEntity user, string password)
    {
        var passwordMatch = Verify(password, user.Password);
        return passwordMatch;
    }
}