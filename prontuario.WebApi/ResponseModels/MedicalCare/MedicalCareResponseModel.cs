using prontuario.Domain.Entities.MedicalCare;

namespace prontuario.WebApi.ResponseModels.MedicalCare
{
    public class MedicalCareResponseModel
    {
        public static MedicalCareResponse CreateCompleteMedicalCareResponse(MedicalCareEntity medicalCareEntity)
        {
            var medicalCareResponse = new MedicalCareResponseBuilder()
            .WithId(medicalCareEntity.Id)
            .WithBreathingPattern(medicalCareEntity.BreathingPattern.ToString())
            .WithBulhas(medicalCareEntity.Bulhas.ToString())
            .WithColoracaoPele(medicalCareEntity.ColoracaoPele.ToString())
            .WithFala(medicalCareEntity.Fala.ToString())
            .WithMedicalHypothesis(medicalCareEntity.MedicalHypothesis)
            .WithNivelDeConsciencia(medicalCareEntity.NivelDeConsciencia.ToString())
            .WithPatientId(medicalCareEntity.PatientId)
            .WithPulmonar(medicalCareEntity.Pulmonar.ToString())
            .WithPulso(medicalCareEntity.Pulso.ToString())
            .WithPupila(medicalCareEntity.Pupila.ToString())
            .WithRespostaMotora(medicalCareEntity.RespostaMotora.ToString())
            .WithRitmo(medicalCareEntity.Ritmo.ToString())  
            .Build();

            return medicalCareResponse;
        }
    }
}