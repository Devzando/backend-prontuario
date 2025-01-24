using prontuario.Domain.Entities.MedicalRecord;
using prontuario.Domain.Entities.Patient;
using prontuario.Domain.Entities.Service;
using prontuario.Domain.Utils;

namespace prontuario.Application.Gateways;

public interface IServiceGateway
{
    Task Init(ServiceEntity serviceEntity);
    Task<ServiceEntity?> FindById(long serviceId);
    Task<PagedResult<List<ServiceEntity>?>> FindAllByPatientId(long patientId, int pageNumber, int pageSize);
    Task InitScreening(MedicalRecordEntity medicalRecordEntity, long serviceId);
}