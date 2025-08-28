using prontuario.WebApi.ResponseModels.Address;
using prontuario.WebApi.ResponseModels.EmergencyContactDetails;
using prontuario.WebApi.ResponseModels.Service;

namespace prontuario.WebApi.ResponseModels.Patient;

public class PatientResponseBuilder
{
    private long? _id;
    private string _name = string.Empty!;
    private string? _socialName;
    private DateTime? _birthDate;
    private string? _sus;
    private string _cpf = string.Empty!;
    private string? _rg;
    private string? _phone;
    private string? _motherName;
    private string? _status;
    private AddressResponse _address = null!;
    private ICollection<EmergencyContactDetailsResponse> _emergencyContactDetails = null!;
    private ICollection<ServiceResponse>? _services;

    public PatientResponseBuilder WithId(long? id)
    {
        _id = id;
        return this;
    }

    public PatientResponseBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public PatientResponseBuilder WithSocialName(string? socialName)
    {
        _socialName = socialName;
        return this;
    }

    public PatientResponseBuilder WithBirthDate(DateTime? birthDate)
    {
        _birthDate = birthDate;
        return this;
    }

    public PatientResponseBuilder WithSus(string? sus)
    {
        _sus = sus;
        return this;
    }

    public PatientResponseBuilder WithCpf(string cpf)
    {
        _cpf = cpf;
        return this;
    }

    public PatientResponseBuilder WithRg(string? rg)
    {
        _rg = rg;
        return this;
    }

    public PatientResponseBuilder WithPhone(string? phone)
    {
        _phone = phone;
        return this;
    }

    public PatientResponseBuilder WithMotherName(string? motherName)
    {
        _motherName = motherName;
        return this;
    }

    public PatientResponseBuilder WithStatus(string? status)
    {
        _status = status;
        return this;
    }

    public PatientResponseBuilder WithAddress(AddressResponse address)
    {
        _address = address;
        return this;
    }

    public PatientResponseBuilder WithEmergencyContactDetails(
        ICollection<EmergencyContactDetailsResponse> emergencyContactDetails)
    {
        _emergencyContactDetails = emergencyContactDetails;
        return this;
    }

    public PatientResponseBuilder WithServices(ICollection<ServiceResponse>? services)
    {
        _services = services;
        return this;
    }

    public PatientResponse Build()
    {
        return new PatientResponse(
            _id,
            _name,
            _socialName,
            _birthDate,
            _sus,
            _cpf,
            _rg,
            _phone,
            _motherName,
            _status,
            _address,
            _emergencyContactDetails,
            _services
        );
    }
}