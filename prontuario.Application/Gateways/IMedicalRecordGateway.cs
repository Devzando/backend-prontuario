using prontuario.Domain.Entities.MedicalRecord;

namespace prontuario.Application.Gateways;

public interface IMedicalRecordGateway
{
    Task Save(MedicalRecordEntity medicalRecord);
}