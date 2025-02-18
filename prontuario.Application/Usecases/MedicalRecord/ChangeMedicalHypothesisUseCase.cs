using prontuario.Application.Gateways;
using prontuario.Domain.Errors;

namespace prontuario.Application.Usecases.MedicalRecord;

public class ChangeMedicalHypothesisUseCase(IMedicalRecordGateway medicalRecordGateway)
{
    public async Task<ResultPattern<string>> Execute(long medicalRecordId, string medicalHypothesis)
    {
        var medicalRecordEntity = await medicalRecordGateway.FindById(medicalRecordId);
        medicalRecordEntity.Anamnese.MedicalHypothesis = medicalHypothesis;
        medicalRecordGateway.Update(medicalRecordEntity);
        return ResultPattern<string>.SuccessResult();
    }
}