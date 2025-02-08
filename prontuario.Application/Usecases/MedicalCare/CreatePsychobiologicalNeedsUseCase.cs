using prontuario.Application.Factories;
using prontuario.Application.Gateways;
using prontuario.Domain.Dtos.MedicalCare;
using prontuario.Domain.Errors;

namespace prontuario.Application.Usecases.MedicalCare
{
    public class CreatePsychobiologicalNeedsUseCase(IMedicalCareGateway medicalCareGateway)
    {
        public async Task<ResultPattern<string>> Execute(CreatePsychobiologicalNeedsDTO data)
        {
            var MedicalCareEntity = MedicalCareFactory.CreatePsychobiologicalNeeds(data);
            await medicalCareGateway.Save(MedicalCareEntity);
            return ResultPattern<string>.SuccessResult();
        }
    }
}
