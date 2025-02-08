using prontuario.Application.Factories;
using prontuario.Application.Gateways;
using prontuario.Domain.Dtos.MedicalCare;
using prontuario.Domain.Errors;

namespace prontuario.Application.Usecases.MedicalCare
{
    public class CreateMedicalPrescriptionUseCase(IMedicalCareGateway medicalCareGateway)
    {
        public async Task<ResultPattern<string>> Execute(CreateMedicalPrescriptionDTO data)
        {
            var MedicalCareEntity = MedicalCareFactory.CreateMedicalPrescription(data);
            await medicalCareGateway.Save(MedicalCareEntity);
            return ResultPattern<string>.SuccessResult();
        }
    }
}
