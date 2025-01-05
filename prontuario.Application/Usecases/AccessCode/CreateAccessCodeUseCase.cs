using prontuario.Application.Gateways;
using prontuario.Domain.Dtos.User;
using prontuario.Domain.Errors;

namespace prontuario.Application.Usecases.AccessCode
{
    public class CreateAccessCodeUseCase
    {
        public CreateAccessCodeUseCase()
        {
        }

        public ResultPattern<AccessCodeDTO> Execute()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();

            var code = new string(Enumerable.Repeat(chars, 10)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            // Extrapolando aqui nessa data, porque na minha interpretação (sem documentação e apenas olhando o protótipo),
            // o código de acesso não expira e é criado uma única vez
            var expiration = DateTime.UtcNow.AddYears(10);

            var accessCode = new AccessCodeDTO(
                code, 
                true, 
                false, 
                expiration);

            return ResultPattern<AccessCodeDTO>.SuccessResult(accessCode);
        }
    }
}
