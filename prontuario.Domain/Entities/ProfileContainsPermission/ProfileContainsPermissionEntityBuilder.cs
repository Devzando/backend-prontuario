using prontuario.Domain.Entities.Permission;
using prontuario.Domain.Entities.Profile;

namespace prontuario.Domain.Entities.ProfileContainsPermission;

public class ProfileContainsPermissionEntityBuilder
{
    private long _id;
    private ProfileEntity _profile = null!;
    private PermissionEntity _permission = null!;

    public ProfileContainsPermissionEntityBuilder WithId(long id)
    {
        _id = id;
        return this;
    }

    public ProfileContainsPermissionEntityBuilder WithProfile(ProfileEntity profile)
    {
        _profile = profile;
        return this;
    }

    public ProfileContainsPermissionEntityBuilder WithPermission(PermissionEntity permission)
    {
        _permission = permission;
        return this;
    }

    public ProfileContainsPermissionEntity Build()
    {
        return new ProfileContainsPermissionEntity(_id, _profile, _permission);
    }

}