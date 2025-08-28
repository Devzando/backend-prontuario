using prontuario.Domain.Entities.PatientExams;

namespace prontuario.Application.Gateways
{
    public interface IPatientExamGateway
    {
        Task<PatientExamsEntity?> GetById(long id);
        Task Save(PatientExamsEntity patientExam);
    }

}
