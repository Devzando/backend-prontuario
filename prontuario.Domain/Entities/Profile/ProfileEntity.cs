using prontuario.Domain.ValuesObjects;

namespace prontuario.Domain.Entities.Profile;

public class ProfileEntity
{
    public long Id { get; private set; }
    public Role Role { get; private set; } = null!;
    
    public ProfileEntity() { }

    public ProfileEntity(long id, Role role)
    {
        Id = id;
        role = role;
    }
}
