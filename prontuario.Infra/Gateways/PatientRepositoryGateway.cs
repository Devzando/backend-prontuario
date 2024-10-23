using Microsoft.EntityFrameworkCore;
using prontuario.Application.Gateways;
using prontuario.Domain.Entities;
using prontuario.Infra.Database;
using prontuario.Infra.Database.SqLite.EntityFramework.Models;
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
        public async Task<PatientEntity> Create(PatientEntity patientEntity)
        {
            PatientModel model = PatientMapper.toModel(patientEntity);
            _context.Patients.Add(model);
            await _context.SaveChangesAsync();
            return PatientMapper.toEntity(model);
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
    }
}
