using prontuario.Domain.Exceptions;

namespace prontuario.Domain.ValuesObjects;

public class BreathingPatternStatus
{
    public string? Value { get; private set; }

    public BreathingPatternStatus(string? value)
    {
        if(!string.IsNullOrEmpty(value))
            if (!Enum.IsDefined(typeof(Enums.BreathingPatternStatusType), value))
                throw new DomainException("O status respiratório do paciente tem que ser um dos seguintes valores: " +
                                      "EUPNEICO, " +
                                      "DISPNEICO, " +
                                      "TAQUIPNEICO, " +
                                      "BRADIPNEICO, " +
                                      "APNEIA, ");
        this.Value = value;
    }
}