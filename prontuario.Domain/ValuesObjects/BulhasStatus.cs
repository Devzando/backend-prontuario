using prontuario.Domain.Exceptions;

namespace prontuario.Domain.ValuesObjects;

public class BulhasStatus
{
    public string? Value { get; private set; }
    
    public BulhasStatus(string? value)
    {
        if(!string.IsNullOrEmpty(value))
            if (!Enum.IsDefined(typeof(Enums.BulhasStatusType), value))
                throw new DomainException("A bulha do paciente tem que ser um dos seguintes valores: " +
                                      "NORMOFONETICAS, " +
                                      "HIPOFONETICAS, " +
                                      "HIPERFONETICAS, " +
                                      "PRESANCA_DE_SOPRO, ");
        this.Value = value;
    }
}