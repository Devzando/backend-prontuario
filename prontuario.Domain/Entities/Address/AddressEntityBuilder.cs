using prontuario.Domain.ValuesObjects;

namespace prontuario.Domain.Entities.Address;

public class AddressEntityBuilder
{
    private long? _id;
    private CEP _cep = null!;
    private string _street = string.Empty;
    private string _city = string.Empty;
    private long _number = 0;
    private string _neighborhood = string.Empty;

    public AddressEntityBuilder WithId(long? id)
    {
        _id = id;
        return this;
    }

    public AddressEntityBuilder WithCep(CEP cep)
    {
        _cep = cep;
        return this;
    }

    public AddressEntityBuilder WithStreet(string street)
    {
        _street = street;
        return this;
    }

    public AddressEntityBuilder WithCity(string city)
    {
        _city = city;
        return this;
    }

    public AddressEntityBuilder WithNumber(long number)
    {
        _number = number;
        return this;
    }

    public AddressEntityBuilder WithNeighborhood(string neighborhood)
    {
        _neighborhood = neighborhood;
        return this;
    }

    public AddressEntity Build()
    {
        return new AddressEntity(_id, _cep, _street, _city, _number, _neighborhood);
    }
}
