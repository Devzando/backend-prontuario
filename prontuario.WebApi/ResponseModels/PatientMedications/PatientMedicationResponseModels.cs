using prontuario.Domain.Entities.PatientExams;
using prontuario.Domain.Entities.PatientMedication;
using prontuario.WebApi.ResponseModels.PatientExams;

namespace prontuario.WebApi.ResponseModels.PatientMedications
{
    public class PatientMedicationResponseModels
    {
        public static PatientMedicationResponse CreatePatientExamsResponse(PatientMedicationEntity patientMedicationEntity)
        {
            return new PatientMedicationResponseBuilder()
                .WithId(patientMedicationEntity.Id)
                .WithPrescriptionDate(patientMedicationEntity.PrescriptionDate)
                .WithExecutionDate(patientMedicationEntity.ExecutionDate)
                .WithDescription(patientMedicationEntity.Description)
                .Build();
        }
    }
}
