using Microsoft.EntityFrameworkCore;
using prontuario.Application.Gateways;
using prontuario.Domain.Entities.User;
using prontuario.Infra.Database;

namespace prontuario.Infra.Gateways;

public class UserRepositoryGateway(ProntuarioDbContext context) : IUserGateway
{
    public async Task Create(UserEntity userEntity)
    {
        context.Users.Add(userEntity);
        await context.SaveChangesAsync();
    }


    public async Task<UserEntity?> FindUserByEmail(string userEmail)
    {
        var user = await context.Users
            .Include(u => u.Profile)
            .Include(u => u.AccessCode)
            .FirstOrDefaultAsync(u => u.Email.Value == userEmail);
        return user;
    }
    public async Task<UserEntity> Update(UserEntity userEntity)
    {
        context.Users.Update(userEntity);
        await context.SaveChangesAsync();
        return userEntity;
    }
}