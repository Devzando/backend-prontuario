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
                medicalCare.MedicalHypothesis,
                medicalCare.MedicalPrescription,
                medicalCare.PatientId             
                ).ToList();
        }
    }
}
