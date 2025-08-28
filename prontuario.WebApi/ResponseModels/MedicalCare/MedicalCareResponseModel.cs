using prontuario.Domain.Entities.MedicalCare;

namespace prontuario.WebApi.ResponseModels.MedicalCare
{
    public class MedicalCareResponseModel
    {
        public static MedicalCareResponse CreateCompleteMedicalCareResponse(MedicalCareEntity medicalCareEntity)
        {
            var medicalCareResponse = new MedicalCareResponseBuilder()
            .WithId(medicalCareEntity.Id)
            .WithBreathingPattern(medicalCareEntity.BreathingPattern.Value)
            .WithBulhas(medicalCareEntity.Bulhas.Value)
            .WithColoracaoPele(medicalCareEntity.ColoracaoPele.Value)
            .WithFala(medicalCareEntity.Fala.Value)
            .WithNivelDeConsciencia(medicalCareEntity.NivelDeConsciencia.Value)
            .WithPulmonar(medicalCareEntity.Pulmonar.Value)
            .WithPulso(medicalCareEntity.Pulso.Value)
            .WithPupila(medicalCareEntity.Pupila.Value)
            .WithRespostaMotora(medicalCareEntity.RespostaMotora.Value)
            .WithRitmo(medicalCareEntity.Ritmo.Value)  
            .Build();

            return medicalCareResponse;
        }
    }
}