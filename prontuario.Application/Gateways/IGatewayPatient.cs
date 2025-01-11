using prontuario.Domain.Entities;
using prontuario.Domain.Entities.Patient;

namespace prontuario.Application.Gateways
{
    public interface IGatewayPatient
    {
        Task Save(PatientEntity patientEntity);
        Task<List<PatientEntity>> GetAll();
        Task<PatientEntity?> GetByFilter(string filter);
        Task<PatientEntity?> GetById(long id);
    }
}
