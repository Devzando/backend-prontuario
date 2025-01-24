using prontuario.Domain.Entities.Anamnese;

namespace prontuario.WebApi.ResponseModels.Anamnese;

public class AnamneseResponseModels
{
    public static AnamneseResponse CreateCompleteAnamneseReponse(AnamneseEntity anamneseEntity)
    {
        var anamneseResponse = new AnamneseResponseBuilder()
            .WithId(anamneseEntity.Id)
            .WithGlucose(anamneseEntity.Glucose)
            .WithBloodPressure(anamneseEntity.BloodPressure)
            .WithSignsAndSymptoms(anamneseEntity.SignsAndSymptoms)
            .WithClassificationStatus(anamneseEntity.ClassificationStatus.Value)
            .Build();
        
        return anamneseResponse;
    }
}