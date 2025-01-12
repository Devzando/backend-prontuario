using prontuario.Domain.Entities.User;
using prontuario.Domain.ValuesObjects;

namespace prontuario.Domain.Entities.Profile;

public class ProfileEntity
{
    public long Id { get; private set; }
    public Role Role { get; private set; } = null!;
    public ICollection<UserEntity> Users { get; private set; } = null!;
    public ProfileEntity() { }

    public ProfileEntity(long id, Role role)
    {
        Id = id;
        Role = role;
    }

    public ProfileEntity(Role role)
    {
        Role = role;
    }
}
