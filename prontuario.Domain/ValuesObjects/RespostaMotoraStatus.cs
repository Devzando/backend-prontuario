using prontuario.Domain.Exceptions;

namespace prontuario.Domain.ValuesObjects;

public class RespostaMotoraStatus
{
    public string? Value { get; private set; }

    public RespostaMotoraStatus(string? value)
    {
        if(!string.IsNullOrEmpty(value))
            if (!Enum.IsDefined(typeof(Enums.RespostaMotoraStatusType), value))
                throw new DomainException("O status respiratório do paciente tem que ser um dos seguintes valores: " +
                                      "PLEGIA, " +
                                      "DEAMBULA_SEM_AUXILIO, " +
                                      "DEAMBULA_COM_AUXILIO, " +
                                      "CLAUDIACAO, " );
        this.Value = value;
    }
}