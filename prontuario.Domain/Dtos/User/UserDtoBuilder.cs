namespace prontuario.Domain.Dtos.User;

public class UserDtoBuilder
{
    private long? _id;
    private string _name = string.Empty;
    private string _email = string.Empty;
    private string _cpf = string.Empty;
    private string _password = string.Empty;
    private bool _firstAccess = false;
    private bool _isActive = true;
    private ProfileDTO _profile = null!;
    private AccessCodeDTO _accessCode = null!;

    public UserDtoBuilder WithId(long? id)
    {
        _id = id;
        return this;
    }

    public UserDtoBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public UserDtoBuilder WithEmail(string email)
    {
        _email = email;
        return this;
    }

    public UserDtoBuilder WithCpf(string cpf)
    {
        _cpf = cpf;
        return this;
    }

    public UserDtoBuilder WithPassword(string password)
    {
        _password = password;
        return this;
    }

    public UserDtoBuilder WithFirtsAccess(bool firstAccess)
    {
        _firstAccess = firstAccess;
        return this;
    }

    public UserDtoBuilder WithIsActive(bool isActive)
    {
        _isActive = isActive;
        return this;
    }

    public UserDtoBuilder WithProfile(ProfileDTO profile)
    {
        _profile = profile;
        return this;
    }

    public UserDtoBuilder WithAccessCode(AccessCodeDTO accessCode)
    {
        _accessCode = accessCode;
        return this;
    }

    public UserDTO Build()
    {
        return new UserDTO(_id, _name, _email, _cpf, _password, _firstAccess, _isActive, _profile, _accessCode);
    }
}