using Microsoft.EntityFrameworkCore;
using prontuario.Application.Gateways;
using prontuario.Domain.Entities.Profile;
using prontuario.Infra.Database;

namespace prontuario.Infra.Gateways;

public class ProfileRepositoryGateway(ProntuarioDbContext context) : IProfileGateway
{
    public async Task<List<ProfileEntity>> FindAll()
    {
        var profiles = await context.Profiles.ToListAsync();
        return profiles;
    }
}