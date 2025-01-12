using prontuario.Application.Factories;
using prontuario.Application.Gateways;
using prontuario.Application.Usecases.AccessCode;
using prontuario.Domain.Dtos.User;
using prontuario.Domain.Entities.User;
using prontuario.Domain.Errors;

namespace prontuario.Application.Usecases.User
{
    public class CreateUserUseCase(
        IUserGateway userGateway, 
        IBcryptGateway bcryptGateway,
        IProfileGateway profileGateway,
        CreateAccessCodeUseCase createAccessCodeUseCase)
    {
        public async Task<ResultPattern<UserEntity>> Execute(CreateUserDTO data)
        {
            var user = await userGateway.FindUserByEmail(data.Email);
            var profiles = await profileGateway.FindAll();
            if(user is not null)
                return ResultPattern<UserEntity>.FailureResult("Não foi possível criar o usuário.", 409);
            
            var accessCodeResult = createAccessCodeUseCase.Execute();
            
            var userEntity = UserFactory.CreateUser(data, accessCodeResult.Data, profiles);
            await userGateway.Create(userEntity);
            return ResultPattern<UserEntity>.SuccessResult(userEntity);
        }
    }
}
