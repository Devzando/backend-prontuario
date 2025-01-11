using prontuario.Application.Gateways;
using prontuario.Domain.Entities.Service;
using prontuario.Infra.Database;
using prontuario.Infra.Gateways.Mappers;

namespace prontuario.Infra.Gateways;

public class ServiceRepositoryGateway(ProntuarioDbContext context) : IServiceGateway
{
    public async Task Save(ServiceEntity serviceEntity)
    {
        var serviceModel = ServiceMapper.ToModelWithoutMedicalRecord(serviceEntity);
        context.Add(serviceModel);
        await context.SaveChangesAsync();
    }
}