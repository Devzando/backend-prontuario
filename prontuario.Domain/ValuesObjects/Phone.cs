using System.Text.RegularExpressions;
using prontuario.Domain.Exceptions;

namespace prontuario.Domain.ValuesObjects
{
    public class Phone
    {
        public string? Value { get; private set; }
        public Phone(string? value)
        {
            this.Value = value;
        }
    }
}
