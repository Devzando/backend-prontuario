namespace prontuario.WebApi.RequestModels.Patient
{
    public record AddressRequest(string Cep, string Street, string City, long Number)
    {
    }
}
