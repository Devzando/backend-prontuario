using Microsoft.EntityFrameworkCore;
using prontuario.Application.Gateways;
using prontuario.Domain.Entities;
using prontuario.Domain.Entities.Nursing;
using prontuario.Domain.Entities.Patient;
using prontuario.Domain.Utils;
using prontuario.Infra.Database;

namespace prontuario.Infra.Gateways
{
    public class NursingRepositoryGateway(ProntuarioDbContext context) : INursingGateway
    {
        public async Task Save(NursingEntity nursingEntity)
        {
            context.Nursing.Add(nursingEntity);
            await context.SaveChangesAsync();
        }

        public async Task<PagedResult<List<NursingEntity>?>> GetByFilterList(int pageNumber, int pageSize)
        {
            var totalRecords = await context.Nursing.CountAsync();
            
            var nursingNotes = await context.Nursing
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<List<NursingEntity>?>
            {
                Pages = nursingNotes,
                TotalRecords = totalRecords
            };

        }
    }
}
