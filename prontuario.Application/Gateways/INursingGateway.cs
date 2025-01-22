using prontuario.Domain.Entities.Nursing;
using prontuario.Domain.Utils;

namespace prontuario.Application.Gateways
{
    public interface INursingGateway
    {
        Task Save(NursingEntity nursingEntity);
        Task<PagedResult<List<NursingEntity>?>> GetByFilterList(int pageNumber, int pageSize);
    }
}
