using prontuario.Domain.Entities.MedicalCare;
using prontuario.WebApi.ResponseModels.MedicalCare;

namespace prontuario.WebApi.ResponseModels.Patient
{
    public class MedicalCareResponseModel
    {
        public static List<MedicalCareResponse> CreateGetAllMedicalCareResponse(List<MedicalCareEntity> entity)
        {
            return entity.Select(medicalCare => new MedicalCareResponse(
                medicalCare.Id,
                medicalCare.ExamPrescription,
                medicalCare.MedicalPrescription,
                medicalCare.MedicalHypothesis,
                medicalCare.PatientId,
                medicalCare.BreathingPattern.ToString(),
                medicalCare.Pulmonar.ToString(),
                medicalCare.ColoracaoPele.ToString(),
                medicalCare.Pupila.ToString(),
                medicalCare.Fala.ToString(),
                medicalCare.NivelDeConsciencia.ToString(),
                medicalCare.RespostaMotora.ToString(),
                medicalCare.Bulhas.ToString(),
                medicalCare.Ritmo.ToString(),
                medicalCare.Pulso.ToString()
                )).ToList();
        }
    }
}
