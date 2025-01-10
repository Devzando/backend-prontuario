using prontuario.Infra.Database.SqLite.EntityFramework.Models.Address;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.EmergencyContactDetails;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.Service;

namespace prontuario.Infra.Database.SqLite.EntityFramework.Models.Patient;

public class PatientModelBuilder
{
    private long? _id;
    private string _name = string.Empty;
    private string _socialName = string.Empty;
    private DateTime _birthDate;
    private string _sus = null!;
    private string _cpf = null!;
    private string _rg = null!;
    private string _phone = null!;
    private string _motherName = string.Empty;
    private string _status = string.Empty;
    private AddressModel _address = null!;
    private EmergencyContactDetailsModel _emergencyContactDetails = null!;
    private ICollection<ServiceModel> _services = new List<ServiceModel>();

    public PatientModelBuilder WithId(long? id)
    {
        _id = id;
        return this;
    }

    public PatientModelBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public PatientModelBuilder WithSocialName(string socialName)
    {
        _socialName = socialName;
        return this;
    }

    public PatientModelBuilder WithBirthDate(DateTime birthDate)
    {
        _birthDate = birthDate;
        return this;
    }

    public PatientModelBuilder WithSus(string sus)
    {
        _sus = sus;
        return this;
    }

    public PatientModelBuilder WithCpf(string cpf)
    {
        _cpf = cpf;
        return this;
    }

    public PatientModelBuilder WithRg(string rg)
    {
        _rg = rg;
        return this;
    }

    public PatientModelBuilder WithPhone(string phone)
    {
        _phone = phone;
        return this;
    }

    public PatientModelBuilder WithMotherName(string motherName)
    {
        _motherName = motherName;
        return this;
    }

    public PatientModelBuilder WithStatus(string status)
    {
        _status = status;
        return this;
    }

    public PatientModelBuilder WithAddress(AddressModel address)
    {
        _address = address;
        return this;
    }

    public PatientModelBuilder WithEmergencyContactDetails(EmergencyContactDetailsModel emergencyContactDetails)
    {
        _emergencyContactDetails = emergencyContactDetails;
        return this;
    }

    public PatientModelBuilder WithServices(ICollection<ServiceModel> services)
    {
        _services = services;
        return this;
    }

    public PatientModel Build()
    {
        return new PatientModel(
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
