using prontuario.Domain.Enums;
using prontuario.Domain.Exceptions;

namespace prontuario.Domain.ValuesObjects;

public class Role
{
    public string Value { get; private set; }

    public Role(string value)
    {
        if (!Enum.IsDefined(typeof(RoleType), value))
            throw new DomainException("A role precisa ser um dos seguintes valores: ADMIN, RECEPTIONTEAM, HEALTHTEAM, INTITUATIONMANAGEMENT");
        Value = value;
    }
}