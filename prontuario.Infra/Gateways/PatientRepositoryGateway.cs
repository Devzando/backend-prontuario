using Microsoft.EntityFrameworkCore;
using prontuario.Application.Gateways;
using prontuario.Domain.Entities;
using prontuario.Domain.Entities.Patient;
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

        public async Task<List<PatientEntity>> GetAll()
        {
            var patients = await context.Patients
                .Include(p => p.AddressEntity)
                .Include(p => p.EmergencyContactDetailsEntity)
                .Include(p => p.ServicesEntity)
                .ToListAsync();

            return patients;
        }

        public async Task<PatientEntity?> GetByFilter(string filter)
        {
            var patient = await context.Patients
                .Include(p => p.AddressEntity)
                .Include(p => p.EmergencyContactDetailsEntity)
                .Include(p => p.ServicesEntity)
                .FirstOrDefaultAsync(p => (p.Cpf.Value == filter || p.Sus.Value == filter));

            return patient;
        }

        public async Task<PatientEntity?> GetById(long id)
        {
            var patient = await context.Patients
                .Include(p => p.AddressEntity)
                .Include(p => p.EmergencyContactDetailsEntity)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
            return patient;
        }
    }
}
