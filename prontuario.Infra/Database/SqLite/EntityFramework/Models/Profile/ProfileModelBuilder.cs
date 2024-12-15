using prontuario.Infra.Database.SqLite.EntityFramework.Models.ProfileContainsPermission;

namespace prontuario.Infra.Database.SqLite.EntityFramework.Models.Profile;

public class ProfileModelBuilder
{
    private long? _id;
    private string _role = string.Empty;
    private ICollection<ProfileContainsPermissionModel> _profileContainsPermission = null!;

    public ProfileModelBuilder WithId(long? id)
    {
        _id = id;
        return this;
    }

    public ProfileModelBuilder WithRole(string role)
    {
        _role = role;
        return this;
    }

    public ProfileModelBuilder WithProfileContainsPermission(ICollection<ProfileContainsPermissionModel> profileContainsPermission)
    {
        _profileContainsPermission = profileContainsPermission;
        return this;
    }

    public ProfileModel Build()
    {
        return new ProfileModel(_id, _role, _profileContainsPermission);
    }
}