namespace prontuario.Domain.Dtos.Patient
{
    public record CreatePatientDTO(
        string Name,
        string BirthDate,
        string Sus,
        string Cpf,
        string Rg,
        string Phone,
        AddressDTO Address,
        EmergencyContactDetailsDTO EmergencyContactDetails
        )
    {
    }
}
