using Microsoft.EntityFrameworkCore;
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
    public async Task<MedicalRecordEntity?> FindById(long medicalRecordId)
    {
        var medicalRecord = await context.MedicalRecords
                .Include(m => m.Anamnese)
                .Include(m => m.PatientMonitoring)
                .Include(m => m.PatientExams)
                .Include(m => m.PatientMedications)
                .Include(m => m.HealthAndDisease)
                .Where(m => m.Id == medicalRecordId)
                .FirstOrDefaultAsync();

        return medicalRecord;
    }
}