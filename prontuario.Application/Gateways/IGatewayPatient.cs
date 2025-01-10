using prontuario.Domain.Entities;
using prontuario.Domain.Entities.Patient;

namespace prontuario.Application.Gateways
{
    public interface IGatewayPatient
    {
        Task<PatientEntity> Create(PatientEntity patientEntity);
        Task<List<PatientEntity>> GetAll();
        Task<PatientEntity?> GetByFilter(string filter);
    }
}
