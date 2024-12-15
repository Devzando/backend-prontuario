

using prontuario.Domain.Entities.ProfileContainsPermission;
using prontuario.Domain.ValuesObjects;

namespace prontuario.Domain.Entities.Permission;

public class PermissionEntity
{
    public long? Id { get; set; }
    public Permissions Title { get; private set; } = null!;
    public ICollection<ProfileContainsPermissionEntity> ProfileContainsPermission { get; private set; } = null!;
    
    public PermissionEntity() {}

    public PermissionEntity(long? id, Permissions title, ICollection<ProfileContainsPermissionEntity> profileContainsPermission)
    {
        Id = id;
        Title = title;
        ProfileContainsPermission = profileContainsPermission;
    }
}