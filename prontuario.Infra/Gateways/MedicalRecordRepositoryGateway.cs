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
    public async Task<MedicalRecordEntity?> GetById(long id)
    {
        var patientMonitoring = await context.MedicalRecords
                .Include(mr => mr.PatientMonitoring)
                .Include(mr => mr.PatientExams)
                .FirstOrDefaultAsync(pm => pm.Id == id);

        return patientMonitoring;
    }
}