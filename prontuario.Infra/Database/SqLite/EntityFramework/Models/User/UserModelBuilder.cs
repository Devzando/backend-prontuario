using prontuario.Infra.Database.SqLite.EntityFramework.Models.AccessCode;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.Profile;

namespace prontuario.Infra.Database.SqLite.EntityFramework.Models.User;

public class UserModelBuilder
{
    private long? _id;
    private string _name = string.Empty;
    private string _email = string.Empty;
    private string _cpf = string.Empty;
    private string _password = string.Empty;
    private ProfileModel _profile = null!;
    private AccessCodeModel _accessCode = null!;

    public UserModelBuilder WithId(long? id)
    {
        _id = id;
        return this;
    }

    public UserModelBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public UserModelBuilder WithEmail(string email)
    {
        _email = email;
        return this;
    }

    public UserModelBuilder WithCpf(string cpf)
    {
        _cpf = cpf;
        return this;
    }

    public UserModelBuilder WithPassword(string password)
    {
        _password = password;
        return this;
    }

    public UserModelBuilder WithProfile(ProfileModel profile)
    {
        _profile = profile;
        return this;
    }

    public UserModelBuilder WithAccessCode(AccessCodeModel accessCode)
    {
        _accessCode = accessCode;
        return this;
    }

    public UserModel Build()
    {
        return new UserModel(_id, _name, _email, _cpf, _password, _profile, _accessCode);
    }
}