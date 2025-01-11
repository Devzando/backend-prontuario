using Microsoft.EntityFrameworkCore;
using prontuario.Application.Gateways;
using prontuario.Domain.Entities.User;
using prontuario.Infra.Database;
using prontuario.Infra.Gateways.Mappers;

namespace prontuario.Infra.Gateways;

public class UserRepositoryGateway(ProntuarioDbContext context) : IUserGateway
{
    public async Task Create(UserEntity userEntity)
    {
        var userModel = UserMapper.ToModel(userEntity);
        context.Users.Add(userModel);
        await context.SaveChangesAsync();
    }


    public async Task<UserEntity?> FindUserByEmail(string userEmail)
    {
        var user = await context.Users
            .Include(u => u.Profile)
            .Include(u => u.AccessCode)
            .FirstOrDefaultAsync(u => u.Email == userEmail);
        return user is not null ? UserMapper.ToDomain(user) : null;
    }
    public async Task<UserEntity> Update(UserEntity userEntity)
    {
        var userModel = UserMapper.ToModel(userEntity);
        context.Users.Update(userModel);
        await context.SaveChangesAsync();
        return UserMapper.ToDomain(userModel);
    }
}