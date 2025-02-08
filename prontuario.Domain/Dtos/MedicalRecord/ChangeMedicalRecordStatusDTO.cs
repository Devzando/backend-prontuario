using prontuario.Domain.Entities.MedicalRecord;
using prontuario.Domain.Entities.Patient;

namespace prontuario.Domain.Dtos.MedicalRecord
{
    public record ChangeMedicalRecordStatusDTO(PatientEntity PatientEntity, MedicalRecordEntity MedicalRecordEntity, String Status)
    {
    }
}
