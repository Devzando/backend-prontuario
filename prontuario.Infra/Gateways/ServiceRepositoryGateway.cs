using Microsoft.EntityFrameworkCore;
using prontuario.Application.Gateways;
using prontuario.Domain.Entities.MedicalRecord;
using prontuario.Domain.Entities.Patient;
using prontuario.Domain.Entities.Service;
using prontuario.Domain.Utils;
using prontuario.Infra.Database;

namespace prontuario.Infra.Gateways;

public class ServiceRepositoryGateway(ProntuarioDbContext context) : IServiceGateway
{
    public async Task Init(ServiceEntity serviceEntity)
    {
        context.Update(serviceEntity);
        await context.SaveChangesAsync();
    }

    public async Task<ServiceEntity?> FindById(long serviceId)
    {
        var service = await context.Services
            .Include(s => s.PatientEntity).ThenInclude(s => s.AddressEntity)
            .Include(s => s.PatientEntity).ThenInclude(s => s.EmergencyContactDetailsEntity)
            .Include(s =>  s.MedicalRecordEntity).ThenInclude(m => m!.Anamnese)
            .FirstOrDefaultAsync(s => s.Id == serviceId);
        return service;
    }

    public async Task<PagedResult<List<ServiceEntity>?>> FindAllByPatientId(long patientId, int pageNumber, int pageSize)
    {
        var totalRecords = await context.Patients.Where(s => s.Id == patientId).CountAsync();
        
        var services = await context.Services
            .Include(s => s.MedicalRecordEntity).ThenInclude(m => m!.Anamnese)
            .Where(s => s.PatientId == patientId && s.ServiceStatus != null)
            .OrderBy(s => s.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResult<List<ServiceEntity>?>()
        {
            Pages = services,
            TotalRecords = totalRecords
        };
    }

    public async Task InitScreening(MedicalRecordEntity medicalRecordEntity, long serviceEntity)
    {
        context.Update(medicalRecordEntity);
        await context.SaveChangesAsync();
    }
}