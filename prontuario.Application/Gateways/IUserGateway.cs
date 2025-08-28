using prontuario.Domain.Entities.User;

namespace prontuario.Application.Gateways;

public interface IUserGateway
{
    Task<UserEntity?> FindUserByEmail(string userEmail);
    Task<UserEntity?> FindUserById(long userId);
    Task Create(UserEntity userEntity);
    Task<UserEntity> Update(UserEntity userEntity);
}