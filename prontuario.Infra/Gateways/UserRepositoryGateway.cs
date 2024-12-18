using Microsoft.EntityFrameworkCore;
using prontuario.Application.Gateways;
using prontuario.Domain.Entities.User;
using prontuario.Infra.Database;
using prontuario.Infra.Gateways.Mappers;

namespace prontuario.Infra.Gateways;

public class UserRepositoryGateway(ProntuarioDbContext context) : IUserGateway
{
    public async Task<UserEntity?> FindUserByEmail(string userEmail)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Email == userEmail);
        return user is not null ? UserMapper.ToDomain(user) : null;
    }
}