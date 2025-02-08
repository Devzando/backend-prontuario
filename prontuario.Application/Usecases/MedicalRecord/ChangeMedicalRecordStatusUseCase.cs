using prontuario.Application.Factories;
using prontuario.Application.Gateways;
using prontuario.Domain.Dtos.MedicalRecord;
using prontuario.Domain.Errors;

namespace prontuario.Application.Usecases.MedicalRecord;

public class ChangeMedicalRecordStatusUseCase(IMedicalRecordGateway medicalRecordGateway)
{
    public async Task<ResultPattern<string>> Execute(ChangeMedicalRecordStatusDTO data)
        {
            var MedicalRecordEntity = MedicalRecordFactory.ChangeMedicalRecordStatus(data).medicalRecordEntity;
            await medicalRecordGateway.Save(MedicalRecordEntity);
            return ResultPattern<string>.SuccessResult();
        }
}