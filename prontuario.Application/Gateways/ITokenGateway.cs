using prontuario.Domain.Entities.User;

namespace prontuario.Application.Gateways;

public interface ITokenGateway
{
    string? CreateToken(UserEntity user);
}