using prontuario.Domain.Entities.ProfileContainsPermission;
using prontuario.Domain.ValuesObjects;

namespace prontuario.Domain.Entities.Profile;

public class ProfileEntity
{
    public long? Id { get; private set; }
    public Role Role { get; private set; } = null!;
    public ICollection<ProfileContainsPermissionEntity> ProfileContainsPermission { get; private set; } = null!;
    
    public ProfileEntity() { }

    public ProfileEntity(long? id, Role role, ICollection<ProfileContainsPermissionEntity> profileContainsPermission)
    {
        Id = id;
        role = role;
        ProfileContainsPermission = profileContainsPermission;
    }
}
