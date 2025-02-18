using prontuario.Domain.Exceptions;

namespace prontuario.Domain.ValuesObjects;

public class ServiceStatus
{
    public string? Value { get; private set; }

    public ServiceStatus(string? value)
    {
        if(!string.IsNullOrEmpty(value))
            if (!Enum.IsDefined(typeof(Enums.ServiceStatusType), value))
                throw new DomainException("O status do paciente tem que ser um dos seguintes valores: " +
                                        "RESIDENCE, " +
                                        "ON_REQUEST, " +
                                        "DEATH, " );
        this.Value = value;
    }
}