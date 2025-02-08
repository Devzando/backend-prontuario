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
            context.MedicalCare.Add(MedicalCareEntity);
            await context.SaveChangesAsync();
        }

        public async Task<PagedResult<List<MedicalCareEntity>?>> GetByFilterList(int pageNumber, int pageSize)
        {
            var totalRecords = await context.MedicalCare.CountAsync();
            
            // var nursingNotes = await context.Nursing
            //     .Skip((pageNumber - 1) * pageSize)
            //     .Take(pageSize)
            //     .ToListAsync();

            // return new PagedResult<List<NursingEntity>?>
            // {
            //     Pages = nursingNotes,
            //     TotalRecords = totalRecords
            // };

        }
    }
}
