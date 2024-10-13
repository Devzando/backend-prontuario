namespace prontuario.Domain.Errors
{
    public class ResultPattern<T>
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public T Data { get; private set; }
        public ProblemDetails? ErrorDetails { get; private set; }

        private ResultPattern(bool success, string message, T data = default, ProblemDetails? errorDetails = null)
        {
            Success = success;
            Message = message;
            Data = data;
            ErrorDetails = errorDetails;
        }

        // Método estático para sucesso (sem dados de retorno)
        public static ResultPattern<T> SuccessResult(string message = "Operação realizada com sucesso.")
        {
            return new ResultPattern<T>(true, message);
        }

        // Método estático para sucesso (com dados de retorno)
        public static ResultPattern<T> SuccessResult(T data, string message = "Operação realizada com sucesso.")
        {
            return new ResultPattern<T>(true, message, data);
        }

        // Método estático para falha (usando ProblemDetails)
        public static ResultPattern<T> FailureResult(string detail, int statusCode, string title = "Ocorreu um erro")
        {
            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = title,
                Detail = detail,
                Instance = $"urn:problem:{Guid.NewGuid()}"  // Gera um identificador único para o problema
            };

            return new ResultPattern<T>(false, detail, default, problemDetails);
        }
    }
}
