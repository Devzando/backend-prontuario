using prontuario.Domain.Enums;
using prontuario.Domain.Errors;

namespace prontuario.Domain.ValuesObjects
{
    public class Relationship
    {
        public string Value { get; private set; } = string.Empty;
        public Relationship(string value)
        {
            this.Value = value;
        }
        private ResultPattern<string> Validate(string relationship)
        {
            if (relationship != TypeRelationship.FATHER.ToString() 
                || relationship != TypeRelationship.MOTHER.ToString() 
                || relationship != TypeRelationship.SON.ToString())
            {
                return ResultPattern<string>.FailureResult(
                    detail: "O campo de relacionamento precisa ser um dos seguintes valores: FATHER, MOTHER, SON.",
                    statusCode: 400,
                    title: "Erro de Validação"
                );
            }

            return ResultPattern<string>.SuccessResult("Relacionamento Válido");
        }
    }
}
