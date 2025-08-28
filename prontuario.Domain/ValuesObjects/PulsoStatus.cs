using prontuario.Domain.Exceptions;

namespace prontuario.Domain.ValuesObjects;

public class PulsoStatus
{
    public string? Value { get; private set; }
    
    public PulsoStatus(string? value)
    {
        if(!string.IsNullOrEmpty(value))
            if (!Enum.IsDefined(typeof(Enums.PulsoStatusType), value))
                throw new DomainException("O Pulso do paciente tem que ser um dos seguintes valores: " +
                                      "FILIFORME, " +
                                      "NORMOESFIGMICO, " +
                                      "TAQUIEAFIGMICO, " +
                                      "BRADESFIGMICO, ");
        this.Value = value;
    }
}