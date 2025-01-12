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

        public async Task<PagedResult<List<PatientEntity>>> GetAll(int pageNumber, int pageSize)
        {
            var totalRecords = await context.Patients.CountAsync();
            
            var patients = await context.Patients
                .Include(p => p.AddressEntity)
                .Include(p => p.EmergencyContactDetailsEntity)
                .Include(p => p.ServicesEntity)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<List<PatientEntity>>
            {
                Pages = patients,
                TotalRecords = totalRecords
            };
        }

        public async Task<PatientEntity?> GetByFilter(string filter, string status)
        {
            var patient = await context.Patients
                .Include(p => p.AddressEntity)
                .Include(p => p.EmergencyContactDetailsEntity)
                .Include(p => p.ServicesEntity)
                .FirstOrDefaultAsync(p => (p.Cpf.Value == filter || p.Sus.Value == filter) && p.Status.Value == status);

            return patient;
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
