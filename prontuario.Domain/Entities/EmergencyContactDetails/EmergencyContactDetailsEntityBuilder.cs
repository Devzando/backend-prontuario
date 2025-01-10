using prontuario.Domain.ValuesObjects;

namespace prontuario.Domain.Entities.EmergencyContactDetails;

public class EmergencyContactDetailsEntityBuilder
{
    private long? _id;
    private string _name = string.Empty;
    private Phone _phone = null!;
    private Relationship _relationship = null!;

    public EmergencyContactDetailsEntityBuilder WithId(long? id)
    {
        _id = id;
        return this;
    }

    public EmergencyContactDetailsEntityBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public EmergencyContactDetailsEntityBuilder WithPhone(Phone phone)
    {
        _phone = phone;
        return this;
    }

    public EmergencyContactDetailsEntityBuilder WithRelationship(Relationship relationship)
    {
        _relationship = relationship;
        return this;
    }

    public EmergencyContactDetailsEntity Build()
    {
        return new EmergencyContactDetailsEntity(_id, _name, _phone, _relationship);
    }
}
