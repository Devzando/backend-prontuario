using prontuario.Domain.Entities.MedicalRecord;
using prontuario.WebApi.ResponseModels.Anamnese;

namespace prontuario.WebApi.ResponseModels.MedicalRecord;

public class MedicalRecordResponseModels
{
    public static MedicalRecordResponse CreateCompleteMedicalRecordResponse(MedicalRecordEntity medicalRecordEntity)
    {
        var medicalRecordResponse = new MedicalRecordResponseBuilder()
            .WithId(medicalRecordEntity.Id)
            .WithStatus(medicalRecordEntity.Status.Value)
            .WithAnamnese(medicalRecordEntity.Anamnese == null ? null : AnamneseResponseModels.CreateCompleteAnamneseReponse(medicalRecordEntity.Anamnese!))
            .Build();

        return medicalRecordResponse;
    }
}