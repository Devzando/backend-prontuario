using prontuario.Infra.Database.SqLite.EntityFramework.Models.ProfileContainsPermission;

namespace prontuario.Infra.Database.SqLite.EntityFramework.Models.Permission;

public class PermissionModelBuilder
{
    private long? _id;
    private string _title = string.Empty;
    private ICollection<ProfileContainsPermissionModel> _profileContainsPermission = null!;

    public PermissionModelBuilder WithId(long? id)
    {
        _id = id;
        return this;
    }

    public PermissionModelBuilder WithTitle(string title)
    {
        _title = title;
        return this;
    }

    public PermissionModelBuilder WithProfileContainsPermission(ICollection<ProfileContainsPermissionModel> profileContainsPermission)
    {
        _profileContainsPermission = profileContainsPermission;
        return this;
    }

    public PermissionModel Build()
    {
        return new PermissionModel(_id, _title, _profileContainsPermission);
    }
}