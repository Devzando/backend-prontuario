using prontuario.Domain.Entities.ProfileContainsPermission;

namespace prontuario.Domain.Entities.Permission;

public class PermissionEntityBuilder
{
    private long? _id;
    private ValuesObjects.Permission _title = null!;
    private ICollection<ProfileContainsPermissionEntity> _profileContainsPermissions = null!;

    public PermissionEntityBuilder WithId(long? id)
    {
        _id = id;
        return this;
    }

    public PermissionEntityBuilder WithTitle(ValuesObjects.Permission title)
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