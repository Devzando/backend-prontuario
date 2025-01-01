using Microsoft.EntityFrameworkCore;
using prontuario.Application.Gateways;
using prontuario.Domain.Entities.User;
using prontuario.Infra.Database;
using prontuario.Infra.Gateways.Mappers;

namespace prontuario.Infra.Gateways;

public class UserRepositoryGateway : IUserGateway
{
    private readonly ProntuarioDbContext _context;
    public UserRepositoryGateway(ProntuarioDbContext context)
    {
        _context = context;
    }

    public async Task<UserEntity> Create(UserEntity userEntity)
    {
        var userModel = UserMapper.ToModel(userEntity);
        _context.Users.Add(userModel);
        await _context.SaveChangesAsync();
        return UserMapper.ToDomain(userModel);
    }

    public async Task<UserEntity?> FindUserByEmail(string userEmail)
    {
        var user = await _context.Users
            .Include(u => u.Profile)
            .Include(u => u.AccessCode)
            .FirstOrDefaultAsync(u => u.Email == userEmail);
        return user is not null ? UserMapper.ToDomain(user) : null;
    }
}