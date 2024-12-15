

using prontuario.Domain.Entities.ProfileContainsPermission;

namespace prontuario.Domain.Entities.Permission;

public class PermissionEntity
{
    public long? Id { get; set; }
    public ValuesObjects.Permission Title { get; private set; } = null!;
    public ICollection<ProfileContainsPermissionEntity> ProfileContainsPermission { get; private set; } = null!;
    
    public PermissionEntity() {}

    public PermissionEntity(long? id, ValuesObjects.Permission title, ICollection<ProfileContainsPermissionEntity> profileContainsPermission)
    {
        Id = id;
        Title = title;
        ProfileContainsPermission = profileContainsPermission;
    }
}