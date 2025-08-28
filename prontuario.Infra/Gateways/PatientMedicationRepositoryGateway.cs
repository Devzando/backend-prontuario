using Microsoft.EntityFrameworkCore;
using prontuario.Application.Gateways;
using prontuario.Domain.Entities.PatientExams;
using prontuario.Domain.Entities.PatientMedication;
using prontuario.Infra.Database;

namespace prontuario.Infra.Gateways
{
    public class PatientMedicationRepositoryGateway(ProntuarioDbContext context) : IPatientMedicationGateway
    {
        public async Task<PatientMedicationEntity?> GetById(long id)
        {
            return await context.PatientMedications
                .Include(pe => pe.MedicalRecord)
                .FirstOrDefaultAsync(pe => pe.Id == id);
        }

        public async Task Save(PatientMedicationEntity patientMedication)
        {
            context.Update(patientMedication);
            await context.SaveChangesAsync();
        }
    }
}
