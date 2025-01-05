using prontuario.Application.Factories;
using prontuario.Application.Gateways;
using prontuario.Domain.Dtos.User;
using prontuario.Domain.Entities.User;
using prontuario.Domain.Errors;

namespace prontuario.Application.Usecases.User
{
    public class CreateUserUseCase(IUserGateway userGateway, IBcryptGateway bcryptGateway)
    {
        public async Task<ResultPattern<UserEntity>> Execute(UserDTO data)
        {
            var user = await userGateway.FindUserByEmail(data.Email);
            if(user is not null)
                return ResultPattern<UserEntity>.FailureResult("Não foi possível criar o usuário.", 409);
            
            var userEntity = UserFactory.CreateUser(data);
            var result = await userGateway.Create(userEntity);
            return ResultPattern<UserEntity>.SuccessResult(userEntity);
        }
    }
}
