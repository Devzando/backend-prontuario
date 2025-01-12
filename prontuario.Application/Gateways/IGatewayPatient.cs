using prontuario.Domain.Entities;
using prontuario.Domain.Entities.Patient;
using prontuario.Domain.Utils;

namespace prontuario.Application.Gateways
{
    public interface IGatewayPatient
    {
        Task Save(PatientEntity patientEntity);
        Task<PagedResult<List<PatientEntity>>> GetAll(int pageNumber, int pageSize);
        Task<PatientEntity?> GetByFilter(string filter);
        Task<PatientEntity?> GetById(long id);
    }
}
