namespace prontuario.Infra.Database.SqLite.EntityFramework.Models.AccessCode;

public class AccessCodeModelBuilder
{
    private long? _id;
    private string _code = string.Empty;
    private bool _isActive;
    private bool _isUserUpdatePassword;
    private DateTime _expirationDate;

    public AccessCodeModelBuilder WithId(long? id)
    {
        _id = id;
        return this;
    }

    public AccessCodeModelBuilder WithCode(string code)
    {
        _code = code;
        return this;
    }

    public AccessCodeModelBuilder WithIsActive(bool isActive)
    {
        _isActive = isActive;
        return this;
    }

    public AccessCodeModelBuilder WithIsUserUpdatePassword(bool isUserUpdatePassword)
    {
        _isUserUpdatePassword = isUserUpdatePassword;
        return this;
    }

    public AccessCodeModelBuilder WithExpirationDate(DateTime expirationDate)
    {
        _expirationDate = expirationDate;
        return this;
    }

    public AccessCodeModel Build()
    {
        return new AccessCodeModel(_id, _code, _isActive, _isUserUpdatePassword, _expirationDate);
    }
}