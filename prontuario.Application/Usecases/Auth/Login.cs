using prontuario.Application.Gateways;
using prontuario.Domain.Errors;

namespace prontuario.Application.Usecases.Auth;

public class Login(IUserGateway userGateway, IBcryptGateway bcryptGateway, ITokenGateway tokenGateway)
{
    public async Task<ResultPattern<string>> Execute(string userEmail, string userPassword)
    {
        var user = await userGateway.FindUserByEmail(userEmail);
        if (user is null || !user.Active)
            return ResultPattern<string>.FailureResult("Usuário não encontrado ou desativado", 404);
        if (user.FirstAccess)
        {
            var result = bcryptGateway.VerifyHashPassword(user, userPassword);
            if(!result)
                return ResultPattern<string>.FailureResult("Email ou senha incorretos", 400);
        }
        else
        {
            if (user.Password != userPassword)
            {
                return ResultPattern<string>.FailureResult("Email ou senha incorretos", 400);
            }
        }

        var accessToken = tokenGateway.CreateToken(user);
        if(accessToken is null)
            return ResultPattern<string>.FailureResult("Erro ao gerar o token de acesso", 400);

        return ResultPattern<string>.SuccessResult(accessToken);
    }
}