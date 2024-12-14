using prontuario.Domain.Entities;

namespace prontuario.Application.Gateways
{
    public interface IGatewayPatient
    {
        Task<PatientEntity> Create(PatientEntity patientEntity);
        Task<List<PatientEntity>> GetAll();
        Task<PatientEntity?> GetByFilter(string filter);
    }
}
