using prontuario.Infra.Database.SqLite.EntityFramework.Models.Patient;

namespace prontuario.Infra.Database.SqLite.EntityFramework.Models.Address;

public class AddressModelBuilder
{
    private long? _id;
    private string? _cep;
    private string? _street;
    private string? _city;
    private long? _number;
    private string? _neighborhood;

    public AddressModelBuilder WithId(long? id)
    {
        _id = id;
        return this;
    }

    public AddressModelBuilder WithCep(string? cep)
    {
        _cep = cep;
        return this;
    }

    public AddressModelBuilder WithStreet(string? street)
    {
        _street = street;
        return this;
    }

    public AddressModelBuilder WithCity(string? city)
    {
        _city = city;
        return this;
    }

    public AddressModelBuilder WithNumber(long? number)
    {
        _number = number;
        return this;
    }

    public AddressModelBuilder WithNeighborhood(string? neighborhood)
    {
        _neighborhood = neighborhood;
        return this;
    }

    public AddressModel Build()
    {
        return new AddressModel(_id, _cep, _street, _city, _number, _neighborhood);
    }
}
