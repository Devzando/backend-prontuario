using prontuario.Domain.Entities.MedicalRecord;
using prontuario.Domain.Entities.Patient;
using prontuario.Domain.Entities.Service;

namespace prontuario.Application.Gateways;

public interface IServiceGateway
{
    Task Init(ServiceEntity serviceEntity);
    Task<ServiceEntity?> FindById(long serviceId);
    Task InitScreening(MedicalRecordEntity medicalRecordEntity, long serviceId);
}