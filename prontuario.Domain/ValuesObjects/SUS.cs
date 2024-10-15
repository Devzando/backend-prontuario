namespace prontuario.Domain.ValuesObjects
{
    public class SUS
    {
        public string Value { get; private set; } = string.Empty;
        public SUS(string value)
        {
            this.Value = value;
        }
    }
}
