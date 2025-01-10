using prontuario.Domain.ValuesObjects;

namespace prontuario.Domain.Entities.Address
{
    public class AddressEntity
    {
        public long? Id { get; private set; }
        public CEP Cep { get; private set; } = null!;
        public string Street { get; private set; } = string.Empty;
        public string City { get; private set; } = string.Empty;
        public long Number { get; private set; } = 0;
        public string Neighborhood { get; private set; } = string.Empty;
        public AddressEntity() { }
        public AddressEntity(long? id, CEP cep, string street, string city, long number, string neighborhood)
        {
            this.Id = id;
            this.Cep = cep;
            this.Street = street;
            this.City = city;
            this.Number = number;
            this.Neighborhood = neighborhood;
        }
    }
}
