using System.Text.RegularExpressions;
using prontuario.Domain.Exceptions;

namespace prontuario.Domain.ValuesObjects
{
    public class RG
    {
        public string Value { get; private set; } = string.Empty;
        public RG(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainException("RG não pode ser vazio ou nulo.");

            if (!Regex.IsMatch(value, "^\\d{1,2}\\.\\d{3}\\.\\d{3}-\\d{1}$"))
                throw new DomainException("RG inválido. Deve estar no formato XX.XXX.XXX-X.");

            this.Value = value;
        }
    }
}
