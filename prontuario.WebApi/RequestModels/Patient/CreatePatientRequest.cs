namespace prontuario.WebApi.RequestModels.Patient
{
    public record CreatePatientRequest(
        string Name,
        DateTime BirthDate,
        string Sus,
        string Cpf,
        string Rg,
        string Phone,
        AddressRequest Address,
        EmergencyContactDetailsRequest EmergencyContactDetails)
    {
    }
}
