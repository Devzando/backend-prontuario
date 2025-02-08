using prontuario.Domain.Exceptions;

namespace prontuario.Domain.ValuesObjects;

public class NivelDeConscienciaStatus
{
    public string? Value { get; private set; }

    public NivelDeConscienciaStatus(string? value)
    {
        if(!string.IsNullOrEmpty(value))
            if (!Enum.IsDefined(typeof(Enums.NivelDeConscienciaStatusType), value))
                throw new DomainException("O status respiratório do paciente tem que ser um dos seguintes valores: " +
                                      "CONSCIENTE, " +
                                      "LETARGICO, " +
                                      "INCONSCIENTE, " +
                                      "RESPOSTA_AO_ESTIMULO_DOLOROSO, " +
                                      "RESPOSTA_AO_ESTIMULO_VERBAL, ");
        this.Value = value;
    }
}