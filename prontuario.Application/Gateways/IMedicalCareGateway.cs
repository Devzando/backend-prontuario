using prontuario.Domain.Entities.MedicalCare;
using prontuario.Domain.Utils;

namespace prontuario.Application.Gateways
{
    public interface IMedicalCareGateway
    {
        Task Save(MedicalCareEntity medicalCareEntity);
        Task<PagedResult<List<MedicalCareEntity>?>> GetByFilterList(int pageNumber, int pageSize);
    }
}
