using prontuario.Application.Factories;
using prontuario.Application.Gateways;
using prontuario.Domain.Dtos.MedicalCare;
using prontuario.Domain.Errors;

namespace prontuario.Application.Usecases.MedicalCare
{
    public class CreateCardioUseCase(IMedicalCareGateway medicalCareGateway)
    {
        public async Task<ResultPattern<string>> Execute(CreateCardioDTO data)
        {
            var MedicalCareEntity = MedicalCareFactory.CreateCardio(data);
            await medicalCareGateway.Save(MedicalCareEntity);
            return ResultPattern<string>.SuccessResult();
        }
    }
}
