using prontuario.Domain.Entities.User;

namespace prontuario.Domain.Entities.AccessCode;

public class AccessCodeEntity
{
    public long Id { get; private set; }
    public string Code { get; private set; } = string.Empty;
    public bool IsActive { get; private set; } = true;
    public bool IsUserUpdatePassword { get; private set; } = false;
    public DateTime ExperationDate { get; private set; }
    public long UserId { get; private set; }
    public UserEntity User { get; private set; }
    
    public AccessCodeEntity() {}

    public AccessCodeEntity(long id, string code, bool isActive, bool isUserUpdatePassword, DateTime experationDate)
    {
        Id = id;
        Code = code;
        IsActive = isActive;
        IsUserUpdatePassword = isUserUpdatePassword;
        ExperationDate = experationDate;
    }
}