using prontuario.Domain.Errors;
using prontuario.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace prontuario.Domain.ValuesObjects
{
    public class CEP
    {
        public string Value { get; private set; } = string.Empty;
        public CEP(string value)
        {
            this.Value = value;
        }
    }
}
