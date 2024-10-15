namespace prontuario.Domain.ValuesObjects
{
    public class Phone
    {
        public string Value { get; private set; } = string.Empty;
        public Phone(string value)
        {
            this.Value = value;
        }
    }
}
