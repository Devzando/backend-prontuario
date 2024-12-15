using prontuario.Domain.Enums;
using prontuario.Domain.Exceptions;

namespace prontuario.Domain.ValuesObjects
{
    public class Relationship
    {
        public string Value { get; private set; }
        public Relationship(string value)
        {
            Validate(value);
            this.Value = value;
        }
        private void Validate(string relationship)
        {
            if(!Enum.IsDefined(typeof(TypeRelationship), relationship))
                throw new DomainException("O campo de relacionamento precisa ser um dos seguintes valores: FATHER, MOTHER, SON.");
        }
    }
}
