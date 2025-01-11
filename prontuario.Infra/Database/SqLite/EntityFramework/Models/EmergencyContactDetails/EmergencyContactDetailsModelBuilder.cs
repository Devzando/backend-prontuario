namespace prontuario.Infra.Database.SqLite.EntityFramework.Models.EmergencyContactDetails;

public class EmergencyContactDetailsModelBuilder
{
    private long? _id;
    private string? _name;
    private string? _phone;
    private string? _relationship;

    public EmergencyContactDetailsModelBuilder WithId(long? id)
    {
        _id = id;
        return this;
    }

    public EmergencyContactDetailsModelBuilder WithName(string? name)
    {
        _name = name;
        return this;
    }

    public EmergencyContactDetailsModelBuilder WithPhone(string? phone)
    {
        _phone = phone;
        return this;
    }

    public EmergencyContactDetailsModelBuilder WithRelationship(string? relationship)
    {
        _relationship = relationship;
        return this;
    }

    public EmergencyContactDetailsModel Build()
    {
        return new EmergencyContactDetailsModel(_id, _name, _phone, _relationship);
    }
}
