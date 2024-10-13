using prontuario.Domain.Errors;
using System.Text.RegularExpressions;

namespace prontuario.Domain.ValuesObjects
{
    public class Phone
    {
        public string Value { get; private set; } = string.Empty;
        public Phone(string value)
        {
            this.Value = value;
            Validate(value);
        }
        private ResultPattern<string> Validate(string phone)
        {
            // Expressão regular para validar o número de telefone brasileiro
            string phonePattern = @"^\(?\d{2}\)? ?\d{4,5}-?\d{4}$"; // (XX) XXXX-XXXX ou (XX) XXXXX-XXXX

            if (string.IsNullOrWhiteSpace(phone) || !Regex.IsMatch(phone, phonePattern))
            {
                return ResultPattern<string>.FailureResult(
                    detail: "O número de telefone deve estar no formato válido: (XX) XXXX-XXXX ou (XX) XXXXX-XXXX.",
                    statusCode: 400,
                    title: "Erro de Validação"
                );
            }

            return ResultPattern<string>.SuccessResult("Telefone válido");
        }
    }
}
