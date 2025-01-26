using prontuario.Domain.Dtos.PatientExam;
using prontuario.Domain.Entities.PatientExams;

namespace prontuario.Application.Factories
{
    public class PatientExamsFactory
    {
        public static PatientExamsEntity CreatePatientExamsEntity(CreatePatientExamDTO data)
        {
            return new PatientExamsEntityBuilder()
                .WithMedicalRecordId(data.MedicalRecordId)
                .WithDescription(data.Description)
                .WithPrescriptionDate(data.PrescriptionDate)
                .Build();
        }

    }
}
