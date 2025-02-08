using prontuario.Domain.Exceptions;

namespace prontuario.Domain.ValuesObjects;

public class PulmonarStatus
{
    public string? Value { get; private set; }

    public PulmonarStatus(string? value)
    {
        if(!string.IsNullOrEmpty(value))
            if (!Enum.IsDefined(typeof(Enums.PulmonarStatusType), value))
                throw new DomainException("O status pulmonar do paciente tem que ser um dos seguintes valores: " +
                                      "MURMURIOS_PRESENTES_BILATERAL, " +
                                      "RONCOS, " +
                                      "SIBILOS, " +
                                      "CREPTOS, " +
                                      "ESTERTORES, ");
        this.Value = value;
    }
}