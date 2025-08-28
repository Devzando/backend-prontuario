using prontuario.Domain.Exceptions;

namespace prontuario.Domain.ValuesObjects;

public class ColoracaoPeleStatus
{
    public string? Value { get; private set; }

    public ColoracaoPeleStatus(string? value)
    {
        if(!string.IsNullOrEmpty(value))
            if (!Enum.IsDefined(typeof(Enums.ColoracaoPeleStatusType), value))
                throw new DomainException("O status de coloração de pele do paciente tem que ser um dos seguintes valores: " +
                                      "NORMOCORADA, " +
                                      "HIPORCORADA, " +
                                      "PRESENCA_DE_LESAO_POR_PRESSAO, " +
                                      "PRESENCA_DE_MACULAS, " +
                                      "PRESENCA_DE_PETEQUIAS, " +
                                      "PRESENCA_DE_PAPULAS, " +
                                      "PRESENCA_DE_VESICULAS, " +
                                      "PRESENCA_DE_PUSTULAS, " );
        this.Value = value;
    }
}