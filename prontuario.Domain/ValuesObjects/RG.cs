using prontuario.Domain.Errors;
using System.Text.RegularExpressions;

namespace prontuario.Domain.ValuesObjects
{
    public class RG
    {
        public string Value { get; private set; } = string.Empty;
        public RG(string value)
        {
            this.Value = value;
            Validate(value);
        }

        private ResultPattern<string> Validate(string rg)
        {
            // Expressão regular para validar se o RG contém apenas dígitos e possui 9 ou 12 dígitos
            string rgPattern = @"^\d{9,12}$";

            if (string.IsNullOrWhiteSpace(rg) || !Regex.IsMatch(rg, rgPattern))
            {
                return ResultPattern<string>.FailureResult(
                    detail: "O RG deve conter entre 9 e 12 dígitos numéricos.",
                    statusCode: 400,
                    title: "Erro de Validação"
                );
            }

            // Verifica se o RG é uma sequência de números repetidos
            if (rg.Distinct().Count() == 1)
            {
                return ResultPattern<string>.FailureResult(
                    detail: "O RG não pode ser uma sequência de números repetidos.",
                    statusCode: 400,
                    title: "Erro de Validação"
                );
            }

            return ResultPattern<string>.SuccessResult("RG válido");
        }
    }
}
