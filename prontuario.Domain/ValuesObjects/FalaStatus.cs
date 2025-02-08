using prontuario.Domain.Exceptions;

namespace prontuario.Domain.ValuesObjects;

public class FalaStatus
{
    public string? Value { get; private set; }

    public FalaStatus(string? value)
    {
        if(!string.IsNullOrEmpty(value))
            if (!Enum.IsDefined(typeof(Enums.FalaStatusType), value))
                throw new DomainException("O status respiratório do paciente tem que ser um dos seguintes valores: " +
                                      "AFASIA, " +
                                      "DISFASIA, " +
                                      "DISARTRIA, " );
        this.Value = value;
    }
}