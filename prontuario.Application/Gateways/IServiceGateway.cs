using prontuario.Domain.Entities.Service;

namespace prontuario.Application.Gateways;

public interface IServiceGateway
{
    Task Save(ServiceEntity serviceEntity);
}