using prontuario.Application.Factories;
using prontuario.Application.Gateways;
using prontuario.Domain.Dtos.Nursing;
using prontuario.Domain.Errors;

namespace prontuario.Application.Usecases.Patient
{
    public class CreateNursingNoteUseCase(INursingGateway nursingGateway)
    {
        public async Task<ResultPattern<string>> Execute(CreateNursingNoteDTO data)
        {
            var nursingEntity = NursingFactory.CreateNursingNote(data);
            await nursingGateway.Save(nursingEntity);
            return ResultPattern<string>.SuccessResult();
        }
    }
}
