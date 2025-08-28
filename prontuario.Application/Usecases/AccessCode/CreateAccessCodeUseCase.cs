using prontuario.Application.Factories;
using prontuario.Domain.Entities.AccessCode;
using prontuario.Domain.Errors;

namespace prontuario.Application.Usecases.AccessCode
{
    public class CreateAccessCodeUseCase
    {
        public ResultPattern<AccessCodeEntity> Execute()
        {
            var accessCode = AccessCodeFactory.CreateAccessCodeEntity();
            return ResultPattern<AccessCodeEntity>.SuccessResult(accessCode);
        }
    }
}
