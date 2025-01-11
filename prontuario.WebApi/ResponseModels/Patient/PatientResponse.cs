using prontuario.WebApi.ResponseModels.Address;
using prontuario.WebApi.ResponseModels.EmergencyContactDetails;

namespace prontuario.WebApi.ResponseModels.Patient;

public record PatientResponse(
    long? Id, 
    string Name, 
    string? SocialName,
    DateTime? BirthDate, 
    string? Sus, 
    string Cpf, 
    string? Rg, 
    string? Phone, 
    string? MotherName,
    string? Status,
    AddressResponse Address, 
    EmergencyContactDetailsResponse EmergencyContactDetails
    );