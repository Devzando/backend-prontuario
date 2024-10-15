using prontuario.Domain.Enums;
using prontuario.Domain.Exceptions;

namespace prontuario.Domain.ValuesObjects
{
    public class Relationship
    {
        public string Value { get; private set; } = string.Empty;
        public Relationship(string value)
        {
            Validate(value);
            this.Value = value;
        }
        private void Validate(string relationship)
        {
            if (!relationship.Equals(TypeRelationship.FATHER.ToString())  
                && !relationship.Equals(TypeRelationship.MOTHER.ToString())
                && !relationship.Equals(TypeRelationship.SON.ToString()))
            {
                throw new DomainException("O campo de relacionamento precisa ser um dos seguintes valores: FATHER, MOTHER, SON.");
            }
        }
    }
}
