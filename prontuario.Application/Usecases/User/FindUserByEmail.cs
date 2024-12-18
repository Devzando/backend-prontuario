using prontuario.Application.Gateways;
using prontuario.Domain.Entities.User;
using prontuario.Domain.Errors;

namespace prontuario.Application.Usecases.User;

public class FindUserByEmail(IUserGateway userGateway)
{
    public async Task<ResultPattern<UserEntity>> Execute(string userEmail)
    {
        var user = await userGateway.FindUserByEmail(userEmail);
        if(user is null)
            return ResultPattern<UserEntity>.FailureResult("Usuário não encontrado", 404);
        return ResultPattern<UserEntity>.SuccessResult(user);
    }
}