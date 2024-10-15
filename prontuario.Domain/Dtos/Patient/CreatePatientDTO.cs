namespace prontuario.Domain.Dtos.Patient
{
    public record CreatePatientDTO(
        string Name,
        DateTime BirthDate,
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
