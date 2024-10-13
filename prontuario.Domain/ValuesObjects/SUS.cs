using prontuario.Domain.Errors;

namespace prontuario.Domain.ValuesObjects
{
    public class SUS
    {
        public string Value { get; private set; } = string.Empty;
        public SUS(string value)
        {
            this.Value = value;
            Validate(value);
        }

        private ResultPattern<string> Validate(string sus)
        {
            if (string.IsNullOrWhiteSpace(sus) || sus.Length != 15 || !sus.All(char.IsDigit))
            {
                return ResultPattern<string>.FailureResult(
                    detail: "O número do cartão SUS deve conter exatamente 15 dígitos.",
                    statusCode: 400,
                    title: "Erro de Validação"
                );
            }

            return ResultPattern<string>.SuccessResult("SUS Válido");
        }
    }
}
