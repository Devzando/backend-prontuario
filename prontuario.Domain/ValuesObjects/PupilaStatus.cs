using prontuario.Domain.Exceptions;

namespace prontuario.Domain.ValuesObjects;

public class PupilaStatus
{
    public string? Value { get; private set; }
    public PupilaStatus(string? value)
    {
        if(!string.IsNullOrEmpty(value))
            if (!Enum.IsDefined(typeof(Enums.PupilaStatusType), value))
                throw new DomainException("O status da pupila do paciente tem que ser um dos seguintes valores: " +
                                      "ISOCORICA, " +
                                      "ANISOCORICA, " +
                                      "MIDRIASE, " +
                                      "MIOTICA, " );
        this.Value = value;
    }
}