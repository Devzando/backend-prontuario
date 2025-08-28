using Microsoft.EntityFrameworkCore;
using prontuario.Application.Gateways;
using prontuario.Domain.Entities;
using prontuario.Domain.Entities.MedicalCare;
using prontuario.Domain.Entities.Patient;
using prontuario.Domain.Utils;
using prontuario.Infra.Database;

namespace prontuario.Infra.Gateways
{
    public class MedicalCareRepositoryGateway(ProntuarioDbContext context) : IMedicalCareGateway
    {
        public async Task Save(MedicalCareEntity MedicalCareEntity)
        {
            context.MedicalCares.Add(MedicalCareEntity);
            await context.SaveChangesAsync();
        }

        public async Task<PagedResult<List<MedicalCareEntity>?>> GetByFilterList(int pageNumber, int pageSize)
        {
            var totalRecords = await context.MedicalCares.CountAsync();
            
            var medicalCares = await context.MedicalCares
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<List<MedicalCareEntity>?>
            {
                Pages = medicalCares,
                TotalRecords = totalRecords
            };

        }
    }
}
