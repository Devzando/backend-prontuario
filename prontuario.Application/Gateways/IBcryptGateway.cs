using prontuario.Domain.Entities.User;

namespace prontuario.Application.Gateways;

public interface IBcryptGateway
{
    bool VerifyHashPassword(UserEntity user, string password);
    string GenerateHashPassword(string password);
}