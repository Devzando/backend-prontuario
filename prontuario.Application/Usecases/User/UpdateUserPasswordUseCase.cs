using prontuario.Application.Factories;
using prontuario.Application.Gateways;
using prontuario.Domain.Errors;

namespace prontuario.Application.Usecases.User;

public class UpdateUserPasswordUseCase(IUserGateway userGateway, IBcryptGateway bcryptGateway)
{
    public async Task<ResultPattern<string>> Execute(string email, string password, string accessCode)
    {
        var user = await userGateway.FindUserByEmail(email);
        if(user is null)
            return ResultPattern<string>.FailureResult("Não foi possível atualizar a senha do usuário.", 409);
        
        if(user?.AccessCode.Code != accessCode)
            return ResultPattern<string>.FailureResult("Não foi possível atualizar a senha do usuário.", 409);

        var firstAccess = user.FirstAccess;
        if (!firstAccess)
            firstAccess = true;
        
        var hashPassword = bcryptGateway.GenerateHashPassword(password);
        var newUserWithNewPassword = UserFactory.CreateUser(user, hashPassword, firstAccess);
        
        await userGateway.Update(newUserWithNewPassword);
        
        return ResultPattern<string>.SuccessResult();
    }
}