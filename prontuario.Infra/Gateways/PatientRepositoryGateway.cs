using Microsoft.EntityFrameworkCore;
using prontuario.Application.Gateways;
using prontuario.Domain.Entities;
using prontuario.Domain.Entities.Patient;
using prontuario.Infra.Database;
using prontuario.Infra.Database.SqLite.EntityFramework.Models;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.Patient;
using prontuario.Infra.Gateways.Mappers;

namespace prontuario.Infra.Gateways
{
    public class PatientRepositoryGateway : IGatewayPatient
    {
        private readonly ProntuarioDbContext _context;
        public PatientRepositoryGateway(ProntuarioDbContext context)
        {
            _context = context;
        }
        public async Task Save(PatientEntity patientEntity)
        {
            var model = PatientMapper.toModel(patientEntity);
            _context.Patients.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PatientEntity>> GetAll()
        {
            var patients = await _context.Patients
                .Include(p => p.AddressModel)
                .Include(p => p.EmergencyContactDetailsModel)
                .Include(p => p.ServicesModel)
                .ToListAsync();

            return PatientMapper.toEntity(patients);
        }

        public async Task<PatientEntity?> GetByFilter(string filter)
        {
            var patient = await _context.Patients
                .Include(p => p.AddressModel)
                .Include(p => p.EmergencyContactDetailsModel)
                .Include(p => p.ServicesModel)
                .FirstOrDefaultAsync(p => (p.Cpf == filter || p.Sus == filter));

            return patient != null ? PatientMapper.toEntity(patient) : null;
        }

        public async Task<PatientEntity?> GetById(long id)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(p => p.Id == id);
            return patient != null ? PatientMapper.toEntity(patient) : null;
        }
    }
}
