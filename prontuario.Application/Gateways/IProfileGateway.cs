using prontuario.Domain.Entities.Profile;

namespace prontuario.Application.Gateways;

public interface IProfileGateway
{
    Task<List<ProfileEntity>> FindAll();
}