using System.Text.RegularExpressions;
using prontuario.Domain.Exceptions;

namespace prontuario.Domain.ValuesObjects
{
    public class Phone
    {
        public string Value { get; private set; } = string.Empty;
        public Phone(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainException("Número de telefone não pode ser vazio ou nulo.");

            if (!Regex.IsMatch(value, "^\\(\\d{2}\\) \\d{4,5}-\\d{4}$"))
                throw new DomainException("Número de telefone inválido. Deve estar no formato (XX) XXXXX-XXXX ou (XX) XXXX-XXXX.");

            this.Value = value;
        }
    }
}
