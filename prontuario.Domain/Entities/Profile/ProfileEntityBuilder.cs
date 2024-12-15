using prontuario.Domain.Entities.ProfileContainsPermission;
using prontuario.Domain.ValuesObjects;

namespace prontuario.Domain.Entities.Profile;

public class ProfileEntityBuilder
{
    private long? _id;
    private Role _role = null!;
    private ICollection<ProfileContainsPermissionEntity> _profileContainsPermission = null!;

    public ProfileEntityBuilder WithId(long? id)
    {
        _id = id;
        return this;
    }

    public ProfileEntityBuilder WithRoleType(Role role)
    {
        _role = role;
        return this;
    }

    public ProfileEntityBuilder WithProfileContainsPermission(ICollection<ProfileContainsPermissionEntity> profileContainsPermission)
    {
        _profileContainsPermission = profileContainsPermission;
        return this;
    }

    public ProfileEntity Build()
    {
        return new ProfileEntity(_id, _role, _profileContainsPermission);
    }
}