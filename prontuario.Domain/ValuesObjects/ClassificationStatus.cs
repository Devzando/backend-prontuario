using prontuario.Domain.Exceptions;

namespace prontuario.Domain.ValuesObjects;

public class ClassificationStatus
{
    public string Value { get; private set; }

    public ClassificationStatus(string value)
    {
        if (!Enum.IsDefined(typeof(Enums.ClassificationStatusType), value))
            throw new DomainException("A classificação da anamnese tem que ser um dos seguintes valores: " +
                                      "EMERGENCY, " +
                                      "VERY_URGENT, " +
                                      "URGENCY, " +
                                      "LESS_SERIOUS, " +
                                      "LIGHTWEIGHT, " );
        this.Value = value;
    }
}