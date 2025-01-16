using prontuario.Domain.Entities.Nursing;

namespace prontuario.Application.Gateways
{
    public interface INursingGateway
    {
        Task Save(NursingEntity nursingEntity);
        Task<NursingEntity?> GetById(long id);
    }
}
