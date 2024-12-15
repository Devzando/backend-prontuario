using prontuario.Domain.Entities.ProfileContainsPermission;
using prontuario.Domain.ValuesObjects;

namespace prontuario.Domain.Entities.Permission;

public class PermissionEntityBuilder
{
    private long? _id;
    private Permissions _title = null!;
    private ICollection<ProfileContainsPermissionEntity> _profileContainsPermissions = null!;

    public PermissionEntityBuilder WithId(long? id)
    {
        _id = id;
        return this;
    }

    public PermissionEntityBuilder WithTitle(Permissions title)
    {
        _title = title;
        return this;
    }

    public PermissionEntityBuilder WithProfileContainsPermissions(
        ICollection<ProfileContainsPermissionEntity> profileContainsPermissions)
    {
        _profileContainsPermissions = profileContainsPermissions;
        return this;
    }

    public PermissionEntity Build()
    {
        return new PermissionEntity(_id, _title, _profileContainsPermissions);
    }
}