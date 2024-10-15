namespace prontuario.WebApi.Validators
{
    public class ValidationException: Exception
    {
        public ValidationException(string message): base(message)
        {
        }
    }
}
