using System.Text.RegularExpressions;
using prontuario.Domain.Exceptions;

namespace prontuario.Domain.ValuesObjects
{
    public class SUS
    {
        public string Value { get; private set; }
        public SUS(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainException("Número do SUS não pode ser vazio ou nulo.");

            if (!Regex.IsMatch(value, "^\\d{15}$"))
                throw new DomainException("Número do SUS inválido. Deve conter exatamente 15 dígitos.");

            this.Value = value;
        }
    }
}
