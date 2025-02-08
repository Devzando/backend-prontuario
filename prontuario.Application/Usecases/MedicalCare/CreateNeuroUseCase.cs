using prontuario.Application.Factories;
using prontuario.Application.Gateways;
using prontuario.Domain.Dtos.MedicalCare;
using prontuario.Domain.Errors;

namespace prontuario.Application.Usecases.MedicalCare
{
    public class CreateNeuroUseCase(IMedicalCareGateway medicalCareGateway)
    {
        public async Task<ResultPattern<string>> Execute(CreateNeuroDTO data)
        {
            var MedicalCareEntity = MedicalCareFactory.CreateNeuro(data);
            await medicalCareGateway.Save(MedicalCareEntity);
            return ResultPattern<string>.SuccessResult();
        }
    }
}
