using prontuario.Domain.Entities.User;

namespace prontuario.Application.Gateways;

public interface IUserGateway
{
    Task<UserEntity?> FindUserByEmail(string userEmail);
    Task<UserEntity> Create(UserEntity userEntity);
}