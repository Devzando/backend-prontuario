namespace prontuario.Domain.Dtos.Patient
{
    public record CreatePatientDTO(
        string Name,
        string SocialName,
        DateTime BirthDate,
        string Sus,
        string Cpf,
        string Rg,
        string Phone,
        string MotherName,
        string Status,
        AddressDTO Address,
        EmergencyContactDetailsDTO EmergencyContactDetails
        )
    {
    }
}
