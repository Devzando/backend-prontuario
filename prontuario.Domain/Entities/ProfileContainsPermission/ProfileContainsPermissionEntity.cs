using prontuario.Domain.Entities.AccessCode;
using prontuario.Domain.Entities.Profile;

namespace prontuario.Domain.Entities.ProfileContainsPermission;

public class ProfileContainsPermissionEntity
{
    public long Id { get; set; }
    public ProfileEntity Profile { get; private set; } = null!;
    public PermissionEntity Permission { get; private set; } = null!;
    
    public ProfileContainsPermissionEntity() { }

    public ProfileContainsPermissionEntity(long id, ProfileEntity profile, PermissionEntity permission)
    {
        Id = id;
        Profile = profile;
        Permission = permission;
    }
    
}