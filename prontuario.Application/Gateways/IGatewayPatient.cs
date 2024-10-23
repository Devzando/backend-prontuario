using prontuario.Domain.Entities;

namespace prontuario.Application.Gateways
{
    public interface IGatewayPatient
    {
        Task<PatientEntity> Create(PatientEntity patientEntity);
        Task<List<PatientEntity>> GetAll();
    }
}
