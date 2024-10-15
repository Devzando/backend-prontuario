namespace prontuario.WebApi.ResponseModels
{
    public class MessageSuccessResponseModel
    {
        public string Message { get; set; }
        public MessageSuccessResponseModel(string message)
        {
            Message = message;
        }   
    }
}
