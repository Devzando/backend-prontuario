using prontuario.Domain.Errors;
using System.Text.RegularExpressions;

namespace prontuario.Domain.ValuesObjects
{
    public class CEP
    {
        public string Value { get; private set; } = string.Empty;
        public CEP(string value)
        {
            this.Value = value;
            Validate(value);
        }
        private ResultPattern<string> Validate(string cep)
        {
            // Expressão regular para validar o formato do CEP brasileiro
            string cepPattern = @"^\d{5}-?\d{3}$"; // XXXXX-XXX ou XXXXXXXX

            if (string.IsNullOrWhiteSpace(cep) || !Regex.IsMatch(cep, cepPattern))
            {
                return ResultPattern<string>.FailureResult(
                    detail: "O CEP deve estar no formato válido: XXXXX-XXX ou XXXXXXXX.",
                    statusCode: 400,
                    title: "Erro de Validação"
                );
            }

            return ResultPattern<string>.SuccessResult("CEP válido");
        }
    }
}
