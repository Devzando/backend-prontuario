namespace prontuario.Domain.ValuesObjects
{
    public class CPF
    {
        public string Value { get; private set; } = string.Empty;

        public CPF(string value)
        {
            this.Value = value;
        }
    }
 }
