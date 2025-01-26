using Microsoft.EntityFrameworkCore;
using prontuario.Application.Gateways;
using prontuario.Domain.Entities;
using prontuario.Domain.Entities.Patient;
using prontuario.Domain.Utils;
using prontuario.Infra.Database;

namespace prontuario.Infra.Gateways
{
    public class PatientRepositoryGateway(ProntuarioDbContext context) : IGatewayPatient
    {
        public async Task Save(PatientEntity patientEntity)
        {
            context.Patients.Add(patientEntity);
            await context.SaveChangesAsync();
        }
        
        public async Task<PagedResult<List<PatientEntity>?>> GetByFilterList(string filter, string status, int pageNumber, int pageSize)
        {
            var totalRecords = await context.Patients.CountAsync();

            var patients = await context.Patients
                .Include(p => p.AddressEntity)
                .Include(p => p.EmergencyContactDetailsEntity)
                .Include(p => p.ServicesEntity)
                    !.ThenInclude(s => s.MedicalRecordEntity)
                    .ThenInclude(m => m!.Anamnese)
                .Include(p => p.ServicesEntity)
                    !.ThenInclude(s => s.MedicalRecordEntity)
                    .ThenInclude(mr => mr!.PatientMonitoring.OrderBy(pm => pm.MonitoringDate))
                .Include(p => p.ServicesEntity)
                    !.ThenInclude(s => s.MedicalRecordEntity)
                    .ThenInclude(mr => mr!.PatientExams.OrderBy(pe => pe.PrescriptionDate))
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Where(p =>
                    (p.Cpf.Value == filter) || 
                    (p.Sus.Value == filter) ||
                    (p.Status.Value == status) ||
                    (p.ServicesEntity != null && 
                     p.ServicesEntity.Any(s => 
                         s.MedicalRecordEntity != null && 
                         (
                             s.MedicalRecordEntity.Status.Value == status ||
                             (s.MedicalRecordEntity.Anamnese != null && s.MedicalRecordEntity.Anamnese.ClassificationStatus.Value == status)
                         )
                     )
                    )
                )
                .ToListAsync();

            return new PagedResult<List<PatientEntity>?>
            {
                Pages = patients,
                TotalRecords = totalRecords
            };
        }

        public async Task<PatientEntity?> GetById(long id)
        {
            var patient = await context.Patients
                .Include(p => p.AddressEntity)
                .Include(p => p.EmergencyContactDetailsEntity)
                .Include(p => p.ServicesEntity)
                .FirstOrDefaultAsync(p => p.Id == id);
            return patient;
        }
    }
}
