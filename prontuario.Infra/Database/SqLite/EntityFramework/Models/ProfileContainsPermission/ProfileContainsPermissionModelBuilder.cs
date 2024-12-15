using prontuario.Infra.Database.SqLite.EntityFramework.Models.Permission;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.Profile;

namespace prontuario.Infra.Database.SqLite.EntityFramework.Models.ProfileContainsPermission;

public class ProfileContainsPermissionModelBuilder
{
    private long? _id;
    private ProfileModel _profile = null!;
    private PermissionModel _permission = null!;

    public ProfileContainsPermissionModelBuilder WithId(long? id)
    {
        _id = id;
        return this;
    }

    public ProfileContainsPermissionModelBuilder WithProfile(ProfileModel profile)
    {
        _profile = profile;
        return this;
    }

    public ProfileContainsPermissionModelBuilder WithPermission(PermissionModel permission)
    {
        _permission = permission;
        return this;
    }

    public ProfileContainsPermissionModel Build()
    {
        return new ProfileContainsPermissionModel(_id, _profile, _permission);
    }
}