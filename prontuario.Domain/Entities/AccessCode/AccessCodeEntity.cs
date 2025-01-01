namespace prontuario.Domain.Entities.AccessCode;

public class AccessCodeEntity
{
    public long? Id { get; private set; }
    public string Code { get; private set; } = string.Empty;
    public bool IsActive { get; private set; } = true;
    public bool IsUserUpdatePassword { get; private set; } = false;
    public DateTime ExperationDate { get; private set; }
    
    public AccessCodeEntity() {}

    public AccessCodeEntity(long? id, string code, bool isActive, bool isUserUpdatePassword, DateTime experationDate)
    {
        Id = id;
        Code = code;
        IsActive = isActive;
        IsUserUpdatePassword = isUserUpdatePassword;
        ExperationDate = experationDate;
    }

    public AccessCodeEntity(string code, bool isActive, bool isUserUpdatePassword, DateTime experationDate)
    {
        Code = code;
        IsActive = isActive;
        IsUserUpdatePassword = isUserUpdatePassword;
        ExperationDate = experationDate;
    }
}