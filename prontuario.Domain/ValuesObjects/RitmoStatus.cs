using prontuario.Domain.Exceptions;

namespace prontuario.Domain.ValuesObjects;

public class RitmoStatus
{
    public string? Value { get; private set; }
    
    public RitmoStatus(string? value)
    {
        if(!string.IsNullOrEmpty(value))
            if (!Enum.IsDefined(typeof(Enums.RitmoStatusType), value))
                throw new DomainException("O Ritmo do paciente tem que ser um dos seguintes valores: " +
                                      "SINUSAL, " +
                                      "TAQUICARDIA, " +
                                      "BRADICARDIA, ");
        this.Value = value;
    }
}