using prontuario.Domain.Errors;
using prontuario.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace prontuario.Domain.ValuesObjects
{
    public class CEP
    {
        public string Value { get; private set; }

        public CEP(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainException("CEP não pode ser vazio ou nulo.");

            if (!Regex.IsMatch(value, @"^\d{5}-\d{3}$"))
                throw new DomainException("CEP inválido. Deve estar no formato 12345-678.");

            this.Value = value;
        }
    }
}
