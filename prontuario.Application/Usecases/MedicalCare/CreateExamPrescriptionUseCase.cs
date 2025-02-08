using prontuario.Application.Factories;
using prontuario.Application.Gateways;
using prontuario.Domain.Dtos.MedicalCare;
using prontuario.Domain.Errors;

namespace prontuario.Application.Usecases.MedicalCare
{
    public class CreateExamPrescriptionUseCase(IMedicalCareGateway medicalCareGateway)
    {
        public async Task<ResultPattern<string>> Execute(CreateExamPrescriptionDTO data)
        {
            var MedicalCareEntity = MedicalCareFactory.CreateExamPrescription(data);
            await medicalCareGateway.Save(MedicalCareEntity);
            return ResultPattern<string>.SuccessResult();
        }
    }
}
