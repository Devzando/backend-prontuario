namespace prontuario.Domain.Dtos.User;

public class AccessCodeDtoBuilder
{
    private long? _id;
    private string _code = string.Empty;
    private bool _isActive = true;
    private bool _isUserUpdatePassword = false;
    private DateTime _expirationDate;

    public AccessCodeDtoBuilder WithId(long? id)
    {
        _id = id;
        return this;
    }

    public AccessCodeDtoBuilder WithCode(string code)
    {
        _code = code;
        return this;
    }

    public AccessCodeDtoBuilder WithIsActive(bool isActive)
    {
        _isActive = isActive;
        return this;
    }

    public AccessCodeDtoBuilder WithIsUserUpdatePassword(bool isUserUpdatePassword)
    {
        _isUserUpdatePassword = isUserUpdatePassword;
        return this;
    }

    public AccessCodeDtoBuilder WithExpirationDate(DateTime expirationDate)
    {
        _expirationDate = expirationDate;
        return this;
    }

    public AccessCodeDTO Build()
    {
        return new AccessCodeDTO(_id, _code, _isActive, _isUserUpdatePassword, _expirationDate);
    }
}