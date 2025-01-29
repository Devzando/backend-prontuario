using prontuario.Domain.Entities.PatientExams;

namespace prontuario.WebApi.ResponseModels.PatientExams
{
    public class PatientExamsResponseModels
    {
        public static PatientExamsResponse CreatePatientExamsResponse(PatientExamsEntity patientExamsEntity)
        {
            return new PatientExamsResponseBuilder()
                .WithId(patientExamsEntity.Id)
                .WithPrescriptionDate(patientExamsEntity.PrescriptionDate)
                .WithExecutionDate(patientExamsEntity.ExecutionDate)
                .WithDescription(patientExamsEntity.Description)
                .Build();
        }
    }

}
