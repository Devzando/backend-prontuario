namespace prontuario.Infra.Database.SqLite.EntityFramework.Models.EmergencyContactDetails;

public class EmergencyContactDetailsModelBuilder
{
    private long? _id;
    private string _name = string.Empty;
    private string _phone = string.Empty;
    private string _relationship = string.Empty;

    public EmergencyContactDetailsModelBuilder WithId(long? id)
    {
        _id = id;
        return this;
    }

    public EmergencyContactDetailsModelBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public EmergencyContactDetailsModelBuilder WithPhone(string phone)
    {
        _phone = phone;
        return this;
    }

    public EmergencyContactDetailsModelBuilder WithRelationship(string relationship)
    {
        _relationship = relationship;
        return this;
    }

    public EmergencyContactDetailsModel Build()
    {
        return new EmergencyContactDetailsModel(_id, _name, _phone, _relationship);
    }
}
