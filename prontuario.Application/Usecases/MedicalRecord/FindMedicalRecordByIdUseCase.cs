using prontuario.Application.Gateways;
using prontuario.Domain.Entities.MedicalRecord;
using prontuario.Domain.Errors;

namespace prontuario.Application.Usecases.MedicalRecord;

public class FindMedicalRecordByIdUseCase(IMedicalRecordGateway medicalRecordGateway)
{
    public async Task<ResultPattern<MedicalRecordEntity>> Execute(long medicalRecordId)
    {
        var medicalRecord = await medicalRecordGateway.FindById(medicalRecordId);
        return medicalRecord is null ? 
            ResultPattern<MedicalRecordEntity>.FailureResult("Erro ao buscar prontuário", 400) : 
            ResultPattern<MedicalRecordEntity>.SuccessResult(medicalRecord);
    }
}