using prontuario.Domain.Errors;
using System.Text.RegularExpressions;

namespace prontuario.Domain.ValuesObjects
{
    public class CPF
    {
        public string Value { get; private set; } = string.Empty;

        public CPF(string value)
        {
            this.Value = value;
            Validate(value);
        }

        private ResultPattern<string> Validate(string cpf)
        {
            // Expressão regular para validar se o CPF contém exatamente 11 dígitos numéricos
            string cpfPattern = @"^\d{11}$";

            if (string.IsNullOrWhiteSpace(cpf) || !Regex.IsMatch(cpf, cpfPattern))
            {
                return ResultPattern<string>.FailureResult(
                    detail: "O CPF deve conter exatamente 11 dígitos numéricos.",
                    statusCode: 400,
                    title: "Erro de Validação"
                );
            }

            // Verifica se o CPF é uma sequência de números repetidos
            if (cpf.Distinct().Count() == 1)
            {
                return ResultPattern<string>.FailureResult(
                    detail: "O CPF não pode ser uma sequência de números repetidos.",
                    statusCode: 400,
                    title: "Erro de Validação"
                );
            }

            return ResultPattern<string>.SuccessResult("CPF válido");
        }
    }
 }
