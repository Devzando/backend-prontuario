namespace prontuario.Domain.ValuesObjects
{
    public class RG
    {
        public string Value { get; private set; } = string.Empty;
        public RG(string value)
        {
            this.Value = value;
        }
    }
}
