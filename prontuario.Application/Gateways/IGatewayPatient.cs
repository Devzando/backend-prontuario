using prontuario.Domain.Entities;
using prontuario.Domain.Entities.Patient;
using prontuario.Domain.Utils;

namespace prontuario.Application.Gateways
{
    public interface IGatewayPatient
    {
        Task Save(PatientEntity patientEntity);
        Task Update(PatientEntity patientEntity);
        Task<PagedResult<List<PatientEntity>?>> GetByFilterList(string filter, string status, int pageNumber, int pageSize);
        Task<PatientEntity?> GetById(long id);
        Task<PatientEntity?> GetByCpf(string cpf);
    }
}
