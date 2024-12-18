using prontuario.Domain.Entities.AccessCode;
using prontuario.Domain.Entities.Profile;
using prontuario.Domain.ValuesObjects;

namespace prontuario.Domain.Entities.User;

public class UserEntity
{
    public UserEntity(long? id, string name, Email email, CPF cpf, string password, bool firstAccess, bool active, ProfileEntity profile, AccessCodeEntity accessCode)
    {
        Id = id;
        Name = name;
        Email = email;
        Cpf = cpf;
        Password = password;
        FirstAccess = firstAccess;
        Active = active;
        Profile = profile;
        AccessCode = accessCode;
    }

    public UserEntity() { }
    public long? Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public Email Email { get; private set; } = null!;
    public CPF Cpf { get; private set; } = null!;
    public string Password { get; private set; } = string.Empty;
    public bool FirstAccess { get; private set; } = false;
    public bool Active { get; private set; } = true;
    public ProfileEntity Profile { get; private set; } = null!;
    public AccessCodeEntity AccessCode { get; private set; } = null!;
}