using prontuario.Application.Gateways;
using prontuario.Domain.Entities.MedicalRecord;
using prontuario.Infra.Database;

namespace prontuario.Infra.Gateways;

public class MedicalRecordRepositoryGateway(ProntuarioDbContext context) : IMedicalRecordGateway
{
    public async Task Save(MedicalRecordEntity medicalRecord)
    {
        context.Update(medicalRecord);
        await context.SaveChangesAsync();
    }
}